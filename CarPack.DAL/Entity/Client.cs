using System;
using InOutFCA.DAL.Entity;

namespace CarPack.DAL.Entity
{
    public class Client : IEntity<int>
    {
        public int Client_id { get; set; }
        public int User_id { get; set; }
        public string Client_number { get; set; }
        public string Client_name  { get; set; }
        public string Prefix { get; set; }
        public string Responsible { get; set; }
        public bool IsIntern { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update { get; set; }

        public int Id
        {
            get
            {
                return Client_id;
            }
            set
            {
                Client_id = value;
            }
        }
    }
}
