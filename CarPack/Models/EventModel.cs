using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int User_id { get; set; }
        public int State_id { get; set; }
        public int Vehicle_id { get; set; }
        public int? Client_id { get; set; }
        public int Reason_id { get; set; }
        public bool IsActive { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime? Last_update { get; set; }

        public EventModel()
        {
            Id = -1;
        }

        public EventModel(string Subject, string Description, int User_id, int State_id, int Vehicle_id, int? Client_id,
            int Reason_id, bool IsActive, DateTime Starttime, DateTime Endtime, DateTime Create_date, DateTime? Last_update)
        {
            this.Id = Id;
            this.Subject = Subject;
            this.Description = Description;
            this.User_id = User_id;
            this.State_id = State_id;
            this.Vehicle_id = Vehicle_id;
            this.Client_id = Client_id;
            this.Reason_id = Reason_id;
            this.IsActive = IsActive;
            this.Starttime = Starttime;
            this.Endtime = Endtime;
            this.Create_date = Create_date;
            this.Last_update = Last_update;
        }
    }
}