using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int Department_id { get; set; }
        public int User_id { get; set; }
        public string Mark { get; set; }
        public string Version { get; set; }
        public string Model { get; set; }
        public string Finition { get; set; }
        public string Chassis_number { get; set; }
        public string Color_extern { get; set; }
        public string Color_intern { get; set; }
        public string Plate { get; set; }
        public string Garage_reference { get; set; }
        public DateTime First_registration { get; set; }
        public bool Visible_in_schedule { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update { get; set; }

        public VehicleModel()
        {
            Id = -1;
        }

        public VehicleModel(int Department_id, int User_id, string Mark, string Version, string Model, string Finition,
         string Chassis_number, string Color_extern, string Color_intern, string Plate, string Garage_reference,
            DateTime First_registration, bool Visible_in_schedule, DateTime Create_date, DateTime Last_update)
        {
            this.Id = Id;
            this.Department_id = Department_id;
            this.User_id = User_id;
            this.Mark = Mark;
            this.Version = Version;
            this.Model = Model;
            this.Finition = Finition;
            this.Chassis_number = Chassis_number;
            this.Color_extern = Color_extern;
            this.Color_intern = Color_intern;
            this.Plate = Plate;
            this.Garage_reference = Garage_reference;
            this.First_registration = First_registration;
            this.Visible_in_schedule = Visible_in_schedule;
            this.Create_date = Create_date;
            this.Last_update = Last_update;
        }

        public virtual List<DepartmentModel> DepartmentModel { get; set; }
        public virtual  int IdDepartment { get; set; }
    }
}