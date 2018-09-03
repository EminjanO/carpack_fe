using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPack.DAL.Entity;
using CarPack.Models;
using CarPack.Utils;
using CarPack.Utils.Mappers;
using CarPack.Utils.ViewModels;
using InOutFCA.DAL.Repository;

namespace CarPack.Controllers
{
    public class VehicleController : Controller
    {
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
    }
}