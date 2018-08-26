using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPack.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string User_windows_authent { get; set; }
        public int Department_id { get; set; }
        public string User_firstName { get; set; }
        public string User_lastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Last_update { get; set; }

        public UserModel()
        {
            Id = -1;
        }

        public UserModel(string User_windows_authent, int Department_id, string User_firstName, string User_lastName,
            string Email, bool IsActive, DateTime Create_date, DateTime Last_update)
        {
            this.Id = Id;
            this.User_windows_authent = User_windows_authent;
            this.Department_id = Department_id;
            this.User_firstName = User_firstName;
            this.User_lastName = User_lastName;
            this.Email = Email;
            this.IsActive = IsActive;
            this.Create_date = Create_date;
            this.Last_update = Last_update;
        }
    }
}