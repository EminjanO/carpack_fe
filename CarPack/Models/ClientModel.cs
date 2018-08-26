using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string Client_number { get; set; }
        public string Client_name { get; set; }
        public string Prefix { get; set; }
        public string Responsible { get; set; }
        public bool IsIntern { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update { get; set; }

        public string ValueConcatinated 
        {
            get 
            {
                return String.Format("{0} {1}", Client_number, Client_name);
            }
        }

        public ClientModel()
        {
            Id = -1;
        }
        public ClientModel(int User_id, string Client_number, string Client_name, string Prefix, 
            string Responsible, bool IsIntern, string Email, string Address, bool IsActive,
            DateTime Create_date, DateTime Last_update)
        {
            this.Id = Id;
            this.User_id = User_id;
            this.Client_number = Client_number;
            this.Client_name = Client_name;
            this.Prefix = Prefix;
            this.Responsible = Responsible;
            this.IsIntern = IsIntern;
            this.Email = Email;
            this.Address = Address;
            this.IsActive = IsActive;
            this.Create_date = Create_date;
            this.Last_update = Last_update;
        }

        public virtual IEnumerable<UserprofilModel> UserprofilModels { get; set; }
    }
}