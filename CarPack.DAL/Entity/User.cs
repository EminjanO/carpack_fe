using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class User : IEntity<int>
    {
        public int User_id { get; set; }
        public string User_windows_authent { get; set; }
        public int Department_id { get; set; }
        public string User_firstName { get; set; }
        public string User_lastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update { get; set; }

        public int Id
        {
            get
            {
                return User_id;
            }
            set
            {
                User_id = value;
            }
        }
        //public virtual ICollection<User> Users { get; set; }
        //public virtual ICollection<Profil> Profils { get; set; }
    }
}
