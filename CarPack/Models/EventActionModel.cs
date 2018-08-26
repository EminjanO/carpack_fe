using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class EventActionModel
    {
        public int Id { get; set; }
        public int Event_id { get; set; }
        public int Transition_id { get; set; }
        public int Action_id { get; set; }
        public int Department_id { get; set; }
        public int User_id { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update { get; set; }

        public EventActionModel()
        {
            Id = -1;
        }
        public EventActionModel(int Event_id, int Transition_id, int Action_id, int Department_id, int User_id, bool IsActive, bool IsCompleted, DateTime Create_date, DateTime Last_update)
        {
            this.Id = Id;
            this.Event_id = Event_id;
            this.Transition_id = Transition_id;
            this.Action_id = Action_id;
            this.Department_id = Department_id;
            this.User_id = User_id;
            this.IsActive = IsActive;
            this.IsCompleted = IsCompleted;
            this.Create_date = Create_date;
            this.Last_update = Last_update;
        }
    }
}