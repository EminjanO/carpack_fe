using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarPack.DAL.Entity;
using CarPack.Models;

namespace CarPack.Utils.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<EventModel> Events;
        public IEnumerable<ReportModel> Reports;
        public EventModel Event;
        public Vehicle Vehicle;
        public IEnumerable<VehicleModel> Vehicles;
        public IEnumerable<ClientModel> Clients;
        public IEnumerable<UserModel> UserModels;
        public IEnumerable<ReasonModel> ReasonModels;
        public IEnumerable<UserprofilModel> UserprofilModels;
        public List<EventActionModel> EventActionModels;

        public DepartmentModel DepartmentModel;
        public IEnumerable<DepartmentModel> DepartmentModels;

        public int IdDepartment;
        public int IdClientModel;
        public int IdReasonModel;
        public int IdVehicleModel;
    }
}