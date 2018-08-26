using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Report : IEntity<int>
    {
        public int Report_id { get; set; }

        public int Id
        {
            get
            {
                return Report_id;
            }
            set
            {
                Report_id = value;
            }

        }
        public int Vehicle_id { get; set; }
        public string Vehicle_Reference { get; set; }
        public string Chassis { get; set; }
        public DateTime Registration { get; set; }
        public DateTime Deregistration { get; set; }
    }
}
