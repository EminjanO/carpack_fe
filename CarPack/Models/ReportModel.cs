using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class ReportModel
    {
        public int Id { get; set; }
        public int Vehicle_id { get; set; }
        public string Vehicle_Reference { get; set; }
        public string Chassis { get; set; }
        public DateTime Registration { get; set; }
        public DateTime Deregistration { get; set; }

        public ReportModel()
        {
            Id = -1;
        }

        public ReportModel(int Vehicle_id, string Vehicle_Reference, string Chassis, DateTime Registration,
            DateTime Deregistration)
        {
            this.Id = Id;
            this.Vehicle_id = Vehicle_id;
            this.Vehicle_Reference = Vehicle_Reference;
            this.Chassis = Chassis;
            this.Registration = Registration;
            this.Deregistration = Deregistration;
        }

        public virtual IEnumerable<EventModel> virtualEvents { get; set; }
    }
}