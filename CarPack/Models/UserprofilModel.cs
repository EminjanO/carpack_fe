using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class UserprofilModel
    { 
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Profil_id { get; set; }

        public UserprofilModel()
        {
            Id=-1;
        }
        public UserprofilModel(int User_id, int Profil_id)
        {
            this.Id=-1;
            this.User_id=User_id;
            this.Profil_id = Profil_id;
        }
    }
}