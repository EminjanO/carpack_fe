using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class EventAction : IEntity<int>
    {
        public int Event_action_id { get; set; }
        public int Event_id { get; set; }
        public int Transition_id { get; set; }
        public int Action_id { get; set; }
        public int Department_id { get; set; }
        public int User_id { get; set; }
        public bool IsActive { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update { get; set; }

        public int Id
        {
            get
            {
                return Event_action_id;
            }
            set
            {
                Event_action_id = value;
            }
        }
    }
}
