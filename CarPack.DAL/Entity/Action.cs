using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Action : IEntity<int>
    {
        public int Action_id { get; set; }

        public int Id
        {
            get
            {
                return Action_id;
            }
            set
            {
                Action_id = value;
            }

        }
        public string Action_name { get; set; }
    }
}
