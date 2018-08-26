using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Reason : IEntity<int>
    {
        public int Eventreason_id { get; set; }
        public string Eventreason_name { get; set; }
        public string Eventreason_alias { get; set; }

        public int Id
        {
            get
            {
                return Eventreason_id;
            }
            set
            {
                Eventreason_id = value;
            }
        }
    }
}
