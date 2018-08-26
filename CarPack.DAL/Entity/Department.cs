using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Department : IEntity<int>
    {
        public int Department_id { get; set; }
        public string Department_name { get; set; }
        public int Id
        {
            get
            {
                return Department_id;
            }
            set
            {
                Department_id = value;
            }
        }
    }
}
