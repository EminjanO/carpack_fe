using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Event : IEntity<int>
    {
        public int Event_id { get; set; }
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

        public int Id
        {
            get
            {
                return Event_id;
            }
            set
            {
                Event_id = value;
            }
        }
    }
}
