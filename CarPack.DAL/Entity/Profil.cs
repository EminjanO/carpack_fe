using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Profil : IEntity<int>
    {
        public int Profil_id { get; set; }
        public string Profil_name { get; set; }
        public string Profil_description { get; set; }

        public int Id
        {
            get
            {
                return Profil_id;
            }
            set
            {
                Profil_id = value;
            }
        }
        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Profil> Profils { get; set; }
    }
}
