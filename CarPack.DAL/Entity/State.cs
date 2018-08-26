using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class State : IEntity<int>
    {
        public int State_id { get; set; }
        public string State_name { get; set; }

        public int Id
        {
            get
            {
                return State_id;
            }
            set
            {
                State_id = value;
            }
        }
    }
}
