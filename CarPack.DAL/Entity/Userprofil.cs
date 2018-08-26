using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Userprofil : IEntity<int>
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Profil_id { get; set; }
    }
}
