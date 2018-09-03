using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarPack.Models;
using CarPack.Utils;
using CarPack.Utils.Mappers;
using CarPack.Utils.ViewModels;
using InOutFCA.DAL.Repository;

namespace CarPack.Controllers
{
    public class ReportController : Controller
    {
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
    }
}