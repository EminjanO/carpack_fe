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
    public class ClientController : Controller
    {
        static List<User> Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
        IndexViewModel index = new IndexViewModel();

        //private IRepository<int, Client> clientRepo;
        //private IRepository<int, User> userRepo;

        //public ClientController(IRepository<int, Client> clientRepo)
        //{
        //    this.clientRepo = clientRepo;
        //}
        public ViewResult Clients()
        {
            int currentUser = Userlist.Where(s => String.Equals(s.User_windows_authent, User.Identity.Name, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Id;
            //int currentUser = 1;
            index.Clients = UnitOfWork.Instance.ClientRepository.GetAll().Select(s => s.ToClient()).ToList();
            //index.Clients = clientRepo.Entities.Select(s => s.ToClient()).ToList();
            index.UserprofilModels = UnitOfWork.Instance.UserprofilRepository.GetByUserId(currentUser).Select(s => s.ToClient()).ToList();

            return View(index);
        }
        public ViewResult ClientsTest()
        {
            List<Client> c =  UnitOfWork.Instance.ClientRepository.GetAll().ToList();
            return View(c);
        }
        public ActionResult CreateClient()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult CreateClient(ClientModel obj)
        {
            //var Userlist = UnitOfWork.Instance.UserRepository.GetAll().ToList();
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
    }
}