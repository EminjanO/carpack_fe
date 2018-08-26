using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Department_name { get; set; }

        public DepartmentModel()
        {
            Id = -1;
        }
        
        public DepartmentModel(string DepartmentName)
        {
            this.Id = Id;
            this.Department_name = DepartmentName;
        }

        public virtual IEnumerable<VehicleModel> VirtualVehicleModels { get; set; }
        public virtual IEnumerable<UserModel> VirtualUserModels { get; set; }
    }
}