using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using CarPack.DAL.Entity;
using CarPack.Models;
using CarPack.Utils;
using CarPack.Utils.Mappers;
using CarPack.Utils.ViewModels;
using InOutFCA.DAL.Entity;
using InOutFCA.DAL.Repository;

namespace CarPack.Controllers
{
    public class HomeController : Controller
    {
        public static int LastEventId;
        //public static int CurrentUser;// = .Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
        public ActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Events = UnitOfWork.Instance.EventRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.Clients = UnitOfWork.Instance.ClientRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.Vehicles = UnitOfWork.Instance.VehicleRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.UserModels = UnitOfWork.Instance.UserRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.ReasonModels = UnitOfWork.Instance.ReasonRepository.GetAll().Select(s => s.ToClient()).ToList();
            int currentUser = indexViewModel.UserModels.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
            indexViewModel.UserprofilModels = UnitOfWork.Instance.UserprofilRepository.GetByUserId(currentUser).Select(s => s.ToClient()).ToList();
            List<DepartmentModel> departments = UnitOfWork.Instance.DepartmentRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.DepartmentModels = departments.GroupJoin(indexViewModel.UserModels,
                d => d.Id,
                u => u.Department_id,
                (d, u) => new DepartmentModel()
                {
                    Id = d.Id,
                    Department_name = d.Department_name,
                    VirtualUserModels = u
                });

            ViewBag.currentUserId = currentUser;
            var eventAction = UnitOfWork.Instance.EventActionRepository.GetByCurrentUserId(currentUser);
            ViewBag.isApprobator = false;
            if (eventAction != null)
            {
                indexViewModel.EventActionModels = UnitOfWork.Instance.EventActionRepository.GetByCurrentUserId(currentUser).Select(s => s.ToClient()).ToList();
                var vartest = false;
                foreach (var VARIABLE in indexViewModel.DepartmentModels)
                {
                     //vartest = VARIABLE.VirtualUserModels.Any(x => x.Department_id == UnitOfWork.Instance.EventActionRepository.GetByCurrentUserId(currentUser).ToList().Select(w=>w.Department_id).);
                    foreach (var VARI in VARIABLE.VirtualUserModels)
                    {
                        if (indexViewModel.EventActionModels.Exists(x => x.Department_id == VARI.Department_id))
                        {
                            vartest = true;
                        }
                    }
                }
                ViewBag.isApprobator = indexViewModel.EventActionModels.Any(s => s.User_id == currentUser) && indexViewModel.UserprofilModels.Any(u => u.Profil_id == 3) && vartest==true;
            }
            indexViewModel.UserprofilModels = UnitOfWork.Instance.UserprofilRepository.GetAll().Select(s => s.ToClient()).ToList();
            return View(indexViewModel);
        }
        public JsonResult GetEvents()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Events = UnitOfWork.Instance.EventRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.Clients = UnitOfWork.Instance.ClientRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.Vehicles = UnitOfWork.Instance.VehicleRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.UserModels = UnitOfWork.Instance.UserRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.ReasonModels = UnitOfWork.Instance.ReasonRepository.GetAll().Select(s => s.ToClient()).ToList();
            List<DepartmentModel> departments = UnitOfWork.Instance.DepartmentRepository.GetAll().Select(s => s.ToClient()).ToList();
            indexViewModel.DepartmentModels = departments.GroupJoin(indexViewModel.Vehicles,
                d => d.Id,
                v => v.Department_id,
                (d, v) => new DepartmentModel()
                {
                    Id = d.Id,
                    Department_name = d.Department_name,
                    VirtualVehicleModels = v
                });
            //var VehiclesGroup = indexViewModel.DepartmentModels.GroupJoin(indexViewModel.Vehicles,d => d.Id,v => v.Department_id,(d, v) => new{Department = d,Vehicles = v});
            int currentUser = indexViewModel.UserModels.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
            ViewBag.currentUserId = currentUser;
            indexViewModel.UserprofilModels = UnitOfWork.Instance.UserprofilRepository.GetAll().Select(s => s.ToClient()).ToList();
            return new JsonResult { Data = indexViewModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult SaveEvent(EventModel obj)
        {
            var status = false;
            Event v = EventMapper.ToGlobal(obj);

            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Events = UnitOfWork.Instance.EventRepository.GetAll().Select(s => s.ToClient()).ToList();
            if (obj.Id > 0)
            {
                //Update the event
                var Variable = indexViewModel.Events.Where(a => a.Id == obj.Id).FirstOrDefault();
                v = EventMapper.ToGlobal(Variable);
                if (v != null)
                {
                    v.Subject = obj.Subject;
                    v.Starttime = obj.Starttime;
                    v.Endtime = obj.Endtime;
                    v.Description = obj.Description;
                    v.Reason_id = obj.Reason_id;
                    v.Vehicle_id = obj.Vehicle_id;
                }
            }
            else
            {
                var Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                v.User_id = Userlist.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
                v.State_id = 1;
                //v.IsActive = true;
                //v.Create_date = DateTime.Now;
                int lastEventId = UnitOfWork.Instance.EventRepository.Insert(v);
                ViewBag.lastEventId = lastEventId;

                #region sendMail
                var LastEvent = UnitOfWork.Instance.EventRepository.GetOne(lastEventId).ToClient(); // here we can get the last inserted event Id
                LastEventId = LastEvent.Id;
                // if client is exist, means that, is vehicle in reparation or changement... or in normal demand for lend 
                var lastEventsClientId = DBNull.Value.Equals(LastEvent.Client_id) ? null : (int?)LastEvent.Client_id;
                int lastEventsClientIdConvertedToInt = (int)lastEventsClientId;

                // if its not null
                EventAction eventAction = new EventAction();
                if (lastEventsClientId != null) // it will be null if VR or Réparation reason 
                {
                    // check the members is intern client...
                    var LastEventsClient = UnitOfWork.Instance.ClientRepository.GetOne((lastEventsClientIdConvertedToInt)).ToClient();
                    if (LastEventsClient.IsIntern == true)
                    {
                        // send mail to HR as first Approbator
                        string MailFrom = "noreplay@ephec.labo";
                        var Approbators = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                        var candidatHRs = Approbators.Where(s => s.Department_id == 6).ToList();
                        ViewBag.currentDepartmentId = 6;
                        StringBuilder MailToApprobator = new StringBuilder();
                        foreach (var uitem in candidatHRs)
                        {
                            MailToApprobator.Append(uitem.Email).Append(",");
                        }
                        MailToApprobator.Remove(MailToApprobator.Length - 1, 1);
                        string MailSunject = " Nouvelle réservation du véhicule ";
                        string MailStrBody = " Nouvelle réservation à approuver : \n <a href=\"http://localhost:63500\">CarPack System</a>" + 6;
                        string MailCc = "";// on peut rajoute un addresse mail quelconque en tant que Cc
                        sendMail(MailFrom, MailToApprobator.ToString(), MailCc, MailSunject, MailStrBody, "");
                        // insert data to the table EventAction....
                        var HRUsers = UnitOfWork.Instance.UserRepository.GetUsersByDepartment(6).ToList();
                        foreach (var item in HRUsers)
                        {
                            WriteEventAction(LastEvent.Id, 1, 1, eventAction, 6, item.Id);
                            WriteEventAction(LastEvent.Id, 2, 2, eventAction, 6, item.Id);
                        }
                    }
                    else if (LastEventsClient.IsIntern == false)
                    {
                        // send mail to department concern to approvement
                        string MailFrom = "noreplay@ephec.labo";
                        var Approbators = UnitOfWork.Instance.UserRepository.GetAll().ToList();// profil
                        var vehicleConcern = UnitOfWork.Instance.VehicleRepository.GetOne(v.Vehicle_id);
                        ViewBag.currentDepartmentId = vehicleConcern.Department_id; // deaprtment depends on the department that contains the vehicle 
                        var UserByDepartments = Approbators.Where(s => (s.Department_id == vehicleConcern.Department_id)).ToList();
                        //string MailToApprobator = "";
                        StringBuilder MailToApprobator = new StringBuilder();
                        foreach (var uitem in UserByDepartments)
                        {
                            var Userprofils = UnitOfWork.Instance.UserprofilRepository.GetByUserId(uitem.Id).ToList();
                            var Userprof = Userprofils.Where(s => s.Profil_id == 3).FirstOrDefault();
                            MailToApprobator.Append(Approbators.Where(s => s.User_id == Userprof.User_id).FirstOrDefault().Email).Append(",");
                        }
                        MailToApprobator.Remove(MailToApprobator.Length - 1, 1);
                        string MailSunject = " Nouvelle réservation du véhicule ";
                        string MailStrBody = " Nouvelle réservation à approuver : \n <a href=\"http://localhost:63500\">CarPack System</a>" + vehicleConcern.Department_id;
                        string MailCc = "";// on peut rajoute un addresse mail quelconque en tant que Cc
                        sendMail(MailFrom, MailToApprobator.ToString(), MailCc, MailSunject, MailStrBody, "");
                        // insert data to the table EventAction....

                        var Users = UnitOfWork.Instance.UserRepository.GetUsersByDepartment(vehicleConcern.Department_id).ToList();

                        foreach (var item in Users)
                        {
                            var userprofils = UnitOfWork.Instance.UserprofilRepository.GetByUserId(item.Id).ToList();
                            if (userprofils.Exists(s => s.User_id == item.Id && s.Profil_id == 3))
                            {
                                WriteEventAction(LastEvent.Id, 1, 1, eventAction, vehicleConcern.Department_id, item.Id);
                                WriteEventAction(LastEvent.Id, 2, 2, eventAction, vehicleConcern.Department_id, item.Id);
                            }
                        }
                    }
                }
                #endregion
            }
            UnitOfWork.Instance.EventRepository.Update(v);

            status = true;
            return new JsonResult { Data = new { status = status } };
        }
        [HttpPost]
        public JsonResult ApproveEvent(int eventID)
        {
            var status = false;
            
            var eventActions = UnitOfWork.Instance.EventActionRepository.GetAll().ToList();
            List<EventModel> events = UnitOfWork.Instance.EventRepository.GetAll().Select(s => s.ToClient()).ToList();
            
            var v = events.Where(a => a.Id == eventID).FirstOrDefault();
            if (v != null)
            {
               // status = UnitOfWork.Instance.EventRepository.UpdateByIdToDelete(eventID); // comme on l'a deleté ???????????????????????????????????????????????????

                var Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                //int User_id = Userlist.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
                int User_id = 5; // for the sake of testing, line above is valuable....
                EventAction eventAction = new EventAction();
                
                if ((int?)v.Client_id != null)
                {
                    var Client = UnitOfWork.Instance.ClientRepository.GetOne((int)v.Client_id).ToClient();
                    int vehicleDepartment = UnitOfWork.Instance.VehicleRepository.GetOne(v.Vehicle_id).Department_id;
                    
                    var Department = eventActions.Select(s => new
                    {
                        eventId = s.Event_id,
                        userId = s.User_id,
                        actionId = s.Action_id,
                        DepartmentId = s.Department_id
                    }).ToList();
                    int DepartmentId = Department.Where(x => x.eventId == eventID &&
                                                             x.userId == User_id &&
                                                             x.actionId == 1).FirstOrDefault().DepartmentId;
                    if (Client.IsIntern == true)  // check if I update the state of event from start to normal 
                    {
                        //Response.Write(eventActions);
                        if (DepartmentId == 6)
                        {
                            Response.Write(eventActions);
                            UnitOfWork.Instance.EventActionRepository.UpdateCompletedByUser(eventID, User_id, 1);
                            UnitOfWork.Instance.EventRepository.UpdateStateById(eventID, 2);
                            // send mail to HR as first Approbator
                            string senMail = "noreplay@ephec.labo";
                            var Approbators = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                            var candidatHRs = Approbators.Where(s => s.Department_id == vehicleDepartment).ToList();
                            ViewBag.currentDepartmentId = vehicleDepartment;
                            StringBuilder MailToApproba = new StringBuilder();
                            foreach (var uitem in candidatHRs)
                            {
                                MailToApproba.Append(uitem.Email).Append(",");
                            }
                            MailToApproba.Remove(MailToApproba.Length - 1, 1);
                            string sujet = " Nouvelle réservation du véhicule ";
                            string Body = " Nouvelle réservation à approuver : \n <a href=\"http://localhost:63500\">CarPack System</a>" + vehicleDepartment;
                            string Cc = "";// on peut rajoute un addresse mail quelconque en tant que Cc
                            sendMail(senMail, MailToApproba.ToString(), Cc, sujet, Body, "");
                            // insert data to the table EventAction....
                            var Users = UnitOfWork.Instance.UserRepository.GetUsersByDepartment(vehicleDepartment).ToList();
                            foreach (var item in Users)
                            {
                                WriteEventAction(v.Id, 1, 1, eventAction, vehicleDepartment, item.Id);
                                WriteEventAction(v.Id, 2, 2, eventAction, vehicleDepartment, item.Id);
                            }
                        }
                        //else if (eventActions.Where(s => s.Event_id == eventID && s.User_id == User_id && s.Action_id == 1).FirstOrDefault().Department_id == vehicleDepartment)
                        else if (DepartmentId == vehicleDepartment)
                        {
                            UnitOfWork.Instance.EventActionRepository.UpdateCompletedByUser(eventID, User_id, 1);
                            // send mail to HR as first Approbator
                            string senMail = "noreplay@ephec.labo";
                            var Approbators = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                            var candidatHRs = Approbators.Where(s => s.Department_id == 7).ToList();
                            ViewBag.currentDepartmentId = 7;
                            StringBuilder MailToApproba = new StringBuilder();
                            foreach (var uitem in candidatHRs)
                            {
                                MailToApproba.Append(uitem.Email).Append(",");
                            }
                            MailToApproba.Remove(MailToApproba.Length - 1, 1);
                            string sujet = " Nouvelle réservation du véhicule ";
                            string Body = " Nouvelle réservation à approuver : \n <a href=\"http://localhost:63500\">CarPack System</a>" + 7;
                            string Cc = "";// on peut rajoute un addresse mail quelconque en tant que Cc
                            sendMail(senMail, MailToApproba.ToString(), Cc, sujet, Body, "");
                            // insert data to the table EventAction....
                            var Users = UnitOfWork.Instance.UserRepository.GetUsersByDepartment(7).ToList();
                            foreach (var item in Users)
                            {
                                WriteEventAction(v.Id, 1, 1, eventAction, 7, item.Id);
                                WriteEventAction(v.Id, 2, 2, eventAction, 7, item.Id);
                            }
                        }
                        else if (DepartmentId == 7)
                        {
                            UnitOfWork.Instance.EventActionRepository.UpdateCompletedByUser(eventID, User_id, 1);
                            // send mail to HR as first Approbator
                            string senMail = "noreplay@ephec.labo";
                            var Approbators = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                            var candidatHRs = Approbators.Where(s => s.Department_id == 8).ToList();
                            ViewBag.currentDepartmentId = 8;
                            StringBuilder MailToApproba = new StringBuilder();
                            foreach (var uitem in candidatHRs)
                            {
                                MailToApproba.Append(uitem.Email).Append(",");
                            }
                            MailToApproba.Remove(MailToApproba.Length - 1, 1);
                            string sujet = " Nouvelle réservation du véhicule ";
                            string Body = " Nouvelle réservation à approuver : \n <a href=\"http://localhost:63500\">CarPack System</a>" + 7;
                            string Cc = "";// on peut rajoute un addresse mail quelconque en tant que Cc
                            sendMail(senMail, MailToApproba.ToString(), Cc, sujet, Body, "");
                            // insert data to the table EventAction....
                            var Users = UnitOfWork.Instance.UserRepository.GetUsersByDepartment(7).ToList();
                            foreach (var item in Users)
                            {
                                WriteEventAction(v.Id, 1, 1, eventAction, 8, item.Id);
                                WriteEventAction(v.Id, 2, 2, eventAction, 8, item.Id);
                            }
                        }
                        else if (DepartmentId == 8)
                        {
                            UnitOfWork.Instance.EventActionRepository.UpdateCompletedByUser(eventID, User_id, 1);
                            UnitOfWork.Instance.EventRepository.UpdateStateById(eventID, 3);
                            // send mail to HR as first Approbator
                            string senMail = "noreplay@ephec.labo";
                            int MailToUserId = UnitOfWork.Instance.EventRepository.GetOne(eventID).User_id;
                            string MailToApprobator = UnitOfWork.Instance.UserRepository.GetOne(MailToUserId).Email;
                            string MailCc = "info@ephec.labo";
                            string MailSunject = " inapproved ";
                            string MailStrBody = " Event for " + v.Description;
                            sendMail(senMail, MailToApprobator, MailCc, MailSunject, MailStrBody, "");
                        }
                    }
                    else
                    {
                        //var Department = eventActions.Select(s => new
                        //{
                        //    eventId = s.Event_id,
                        //    userId = s.User_id,
                        //    actionId = s.Action_id,
                        //    DepartmentId = s.Department_id
                        //}).ToList();
                        //int DepartmentId = Department.Where(x => x.eventId == eventID &&
                        //               x.userId == 9 /*User_id*/ &&
                        //               x.actionId == 1).FirstOrDefault().DepartmentId;
                        //if (eventActions.Where(s => s.Event_id == eventID && 
                        //                            s.User_id == User_id && 
                        //                            s.Action_id == 1).FirstOrDefault().Department_id == vehicleDepartment)
                        if (DepartmentId==vehicleDepartment)
                        {
                            UnitOfWork.Instance.EventActionRepository.UpdateCompletedByUser(eventID, User_id, 1);
                            UnitOfWork.Instance.EventRepository.UpdateStateById(eventID, 2);
                            // send mail to HR as first Approbator
                            string senMail = "noreplay@ephec.labo";
                            var Approbators = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                            var candidatHRs = Approbators.Where(s => s.Department_id == 7).ToList();
                            ViewBag.currentDepartmentId = 7;
                            StringBuilder MailToApproba = new StringBuilder();
                            foreach (var uitem in candidatHRs)
                            {
                                MailToApproba.Append(uitem.Email).Append(",");
                            }
                            MailToApproba.Remove(MailToApproba.Length - 1, 1);
                            string sujet = " Nouvelle réservation du véhicule ";
                            string Body = " Nouvelle réservation à approuver : \n <a href=\"http://localhost:63500\">CarPack System</a>" + 7;
                            string Cc = "";// on peut rajoute un addresse mail quelconque en tant que Cc
                            sendMail(senMail, MailToApproba.ToString(), Cc, sujet, Body, "");
                            // insert data to the table EventAction....
                            var Users = UnitOfWork.Instance.UserRepository.GetUsersByDepartment(7).ToList();
                            foreach (var item in Users)
                            {
                                WriteEventAction(v.Id, 1, 1, eventAction, 7, item.Id);
                                WriteEventAction(v.Id, 2, 2, eventAction, 7, item.Id);
                            }
                        }
                        //else if (eventActions.Where(s => s.Event_id == eventID && s.User_id == User_id && s.Action_id == 1).FirstOrDefault().Department_id == 7)
                        else if (DepartmentId == 7)
                        {
                            UnitOfWork.Instance.EventActionRepository.UpdateCompletedByUser(eventID, User_id, 1);
                            // send mail to HR as first Approbator
                            string senMail = "noreplay@ephec.labo";
                            var Approbators = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                            var candidatHRs = Approbators.Where(s => s.Department_id == 8).ToList();
                            ViewBag.currentDepartmentId = 8;
                            StringBuilder MailToApproba = new StringBuilder();
                            foreach (var uitem in candidatHRs)
                            {
                                MailToApproba.Append(uitem.Email).Append(",");
                            }
                            MailToApproba.Remove(MailToApproba.Length - 1, 1);
                            string sujet = " Nouvelle réservation du véhicule ";
                            string Body = " Nouvelle réservation à approuver : \n <a href=\"http://localhost:63500\">CarPack System</a>" + 7;
                            string Cc = "";// on peut rajoute un addresse mail quelconque en tant que Cc
                            sendMail(senMail, MailToApproba.ToString(), Cc, sujet, Body, "");
                            // insert data to the table EventAction....
                            var Users = UnitOfWork.Instance.UserRepository.GetUsersByDepartment(8).ToList();
                            foreach (var item in Users)
                            {
                                WriteEventAction(v.Id, 1, 1, eventAction, 8, item.Id);
                                WriteEventAction(v.Id, 2, 2, eventAction, 8, item.Id);
                            }
                        }
                        //else if (eventActions.Where(s => s.Event_id == eventID && s.User_id == User_id && s.Action_id == 1).FirstOrDefault().Department_id == 8)
                        else if (DepartmentId == 8)
                        {
                            UnitOfWork.Instance.EventActionRepository.UpdateCompletedByUser(eventID, User_id, 1);
                            UnitOfWork.Instance.EventRepository.UpdateStateById(eventID, 3);
                            // send mail to HR as first Approbator
                            string senMail = "noreplay@ephec.labo";
                            int MailToUserId = UnitOfWork.Instance.EventRepository.GetOne(eventID).User_id;
                            string MailToApprobator = UnitOfWork.Instance.UserRepository.GetOne(MailToUserId).Email;
                            string MailCc = "info@ephec.labo";
                            string MailSunject = " inapproved ";
                            string MailStrBody = " Event for " + v.Description;
                            sendMail(senMail, MailToApprobator, MailCc, MailSunject, MailStrBody, "");
                            var Users = UnitOfWork.Instance.UserRepository.GetUsersByDepartment(9).ToList();
                            // after finished update the event table ( like state to normal in order to change the color )
                            // and eventAction too lie isActive is 0 and isCompleted is 1 to all
                            //foreach (var item in Users)
                            //{
                            //    WriteEventAction(v.Id, 1, 1, eventAction, 8, item.Id);
                            //    WriteEventAction(v.Id, 2, 2, eventAction, 8, item.Id);
                            //}
                        }
                    }
                }
            }
            status = true;
            return new JsonResult { Data = new { status = status } };
        }
        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            List<EventModel> events = UnitOfWork.Instance.EventRepository.GetAll().Select(s => s.ToClient()).ToList();

            var v = events.Where(a => a.Id == eventID).FirstOrDefault();
            if (v != null)
            {
                status = UnitOfWork.Instance.EventRepository.UpdateByIdToDelete(eventID); // comme on l'a deleté
                UnitOfWork.Instance.EventActionRepository.UpdateById(eventID);
                var Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
                int currentUser = Userlist.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
                UnitOfWork.Instance.EventActionRepository.UpdateCompletedByUser(eventID, currentUser, 2);
                string MailFrom = UnitOfWork.Instance.UserRepository.GetOne(currentUser).Email;
                int MailToUserId = UnitOfWork.Instance.EventRepository.GetOne(eventID).User_id;
                string MailToApprobator = UnitOfWork.Instance.UserRepository.GetOne(MailToUserId).Email;
                string MailCc = "info@ephec.labo";
                string MailSunject = " inapproved ";
                string MailStrBody = " Event for " + v.Description;
                sendMail(MailFrom, MailToApprobator, MailCc, MailSunject, MailStrBody, "");
            }

            return new JsonResult { Data = new { status = status } };
        }

        #region Clients

        public ActionResult Clients()
        {
            var Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
            int currentUser = Userlist.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;

            IndexViewModel index = new IndexViewModel();
            index.Clients = UnitOfWork.Instance.ClientRepository.GetAll().Select(s => s.ToClient()).ToList();
            index.UserprofilModels = UnitOfWork.Instance.UserprofilRepository.GetByUserId(currentUser).Select(s => s.ToClient()).ToList();

            return View(index);
        }
        
        public ActionResult CreateClient()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult CreateClient(ClientModel obj)
        {
            var Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
            int currentUser = Userlist.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
            Client c = new Client();
            c.User_id = currentUser;
            c.Client_number = obj.Client_number;
            c.Client_name = obj.Client_name;
            c.Prefix = obj.Prefix;
            c.Responsible = obj.Responsible;
            c.IsIntern = obj.IsIntern;
            c.Email = obj.Email;
            c.Address = obj.Address;
            c.Create_date = DateTime.Now;
            UnitOfWork.Instance.ClientRepository.Insert(c);

            return RedirectToAction("Clients");
        }

        public ActionResult DeleteClient(int Id)
        {
            UnitOfWork.Instance.ClientRepository.DeleteUpdate(Id);
            return RedirectToAction("Clients");
        }

        #endregion

        #region Vehicles

        public ActionResult Vehicles()
        {
            var Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
            int currentUser = Userlist.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;

            IndexViewModel index = new IndexViewModel();
            index.Vehicles = UnitOfWork.Instance.VehicleRepository.GetAll().Select(s => s.ToClient()).ToList();
            index.DepartmentModels = UnitOfWork.Instance.DepartmentRepository.GetAll().Select(s => s.ToClient()).ToList();
            index.UserprofilModels = UnitOfWork.Instance.UserprofilRepository.GetByUserId(currentUser).Select(s => s.ToClient()).ToList();

            return View(index);
        }

        public ActionResult CreateVehicle()
        {
            VehicleModel v = new VehicleModel();
            v.DepartmentModel = UnitOfWork.Instance.DepartmentRepository.GetAll().Select(s => s.ToClient()).ToList();
            //IndexViewModel index = new IndexViewModel();
            //index.DepartmentModels = UnitOfWork.Instance.DepartmentRepository.GetAll().Select(s => s.ToClient()).ToList();
            return View(v);
        }
        [HttpPost]
        public ActionResult CreateVehicle(VehicleModel obj)
        {
            var Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
            int currentUser = Userlist.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;

            Vehicle v = VehicleMapper.ToGlobal(obj);
            v.Department_id = obj.IdDepartment;
            v.User_id = currentUser;
            UnitOfWork.Instance.VehicleRepository.Insert(v);
            return RedirectToAction("Vehicles");
        }

        public ActionResult DeleteVehicle(int Id)
        {
            UnitOfWork.Instance.VehicleRepository.DeleteUpdate(Id);
            Vehicle v = UnitOfWork.Instance.VehicleRepository.GetOne(Id);

            Report r = new Report();

            r.Vehicle_id = Id;
            r.Vehicle_Reference = v.Mark + " " + v.Model;
            r.Chassis = v.Chassis_number;
            r.Registration = v.Create_date;
            r.Deregistration = v.Last_update;

            UnitOfWork.Instance.ReportRepository.Insert(r);

            return RedirectToAction("Vehicles");
        }

        public ActionResult Reports()
        {
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.Events = UnitOfWork.Instance.EventRepository.GetAll().Select(s => s.ToClient()).ToList();
            List<ReportModel> reports = UnitOfWork.Instance.ReportRepository.GetAll().Select(s => s.ToClient()).ToList();
            
            indexViewModel.Reports = reports.GroupJoin(indexViewModel.Events,
                r => r.Vehicle_id,
                e => e.Vehicle_id,
                (r, e) => new ReportModel()
                {
                    Vehicle_Reference = r.Vehicle_Reference,
                    Chassis = r.Chassis,
                    Registration = r.Registration,
                    Deregistration = r.Deregistration,
                    virtualEvents = e
                });
            return View(indexViewModel);
        }
        #endregion
        
        public void sendMail(string adresseFrom, string strMailTo, string strMailCc, string strSujet, string strBody,
            string strPiecesJointes)
        {
            MailMessage mail = new MailMessage();
            MailAddress AdresseFrom = new MailAddress(adresseFrom);
            mail.From = AdresseFrom;
            mail.To.Add(strMailTo);

            if (strMailCc != "")
                //mail.Bcc.Add(strMailCc);
                mail.CC.Add(strMailCc);
            mail.Subject = strSujet;
            mail.IsBodyHtml = true;
            mail.Body = (strBody);

            if (strPiecesJointes != "")
            {
                Attachment oMailAttachment = new Attachment(@"" + strPiecesJointes);
                mail.Attachments.Add(oMailAttachment);
            }

            //SmtpClient client = new SmtpClient("smtp1.fiatauto.com");
            //SmtpClient client = new SmtpClient("151.92.27.8");
            SmtpClient client = new SmtpClient("localhost");
            client.Credentials = CredentialCache.DefaultNetworkCredentials;

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = "Erreur : \r\n" + ex.Message + "Class class_lib (sendMail)";

                Tbl_log logInoutModel = new Tbl_log();
                logInoutModel.log_date = DateTime.Now;
                logInoutModel.log_action = " event  (sendMail)";
                logInoutModel.log_description = "Erreur : \r\n" + ex.Message;
                logInoutModel.log_user = User.Identity.Name;
                logInoutModel.log_type = "error";

                UnitOfWork.Instance.Tbl_logRepository.Insert(logInoutModel);
            }
            finally
            {
                mail.Dispose();
                client = null;
            }
        }
        public static void WriteEventAction(int lastEventId, int Transition_id, int Action_id, EventAction Entity, int DepartmentId, int User_id)
        {
            Entity.Event_id = lastEventId;
            Entity.Transition_id = Transition_id;
            Entity.Action_id = Action_id;
            Entity.Department_id = DepartmentId;
            Entity.User_id = User_id;
            Entity.IsActive = true;
            Entity.IsCompleted = false;
            Entity.Create_date = DateTime.Now;
            UnitOfWork.Instance.EventActionRepository.Insert(Entity);
        }

    }
}