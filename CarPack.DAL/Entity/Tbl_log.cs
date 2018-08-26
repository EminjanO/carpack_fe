using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOutFCA.DAL.Entity
{
    public class Tbl_log : IEntity<int>
    {
        
        public int log_id { get; set; }

        public int Id
        {
            get
            {
                return log_id;
            }
            set
            {
                log_id = value;
            }
        }

        public DateTime log_date { get; set; }
        public string log_action { get; set; }
        public string log_description { get; set; }
        public string log_user { get; set; }
        public string log_type { get; set; }

    }
}
