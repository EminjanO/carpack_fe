using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Vehicle : IEntity<int>
    {
        public int Vehicle_id { get; set; }
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

        public int Id
        {
            get
            {
                return Vehicle_id;
            }
            set
            {
                Vehicle_id = value;
            }
        }
    }
}
