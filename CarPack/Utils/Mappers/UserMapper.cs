using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils.Mappers
{
    public static class UserMapper
    {
        public static Glo.User ToGlobal(this Cli.UserModel obj)
        {
            return new Glo.User()
            {
                Id = obj.Id,
                User_windows_authent = obj.User_windows_authent,
                Department_id = obj.Department_id,
                User_firstName = obj.User_firstName,
                User_lastName = obj.User_lastName,
                Email = obj.Email,
                IsActive = obj.IsActive,
                Create_date = obj.Create_date,
                Last_update = obj.Last_update
            };
        }

        public static Cli.UserModel ToClient(this Glo.User obj)
        {
            Cli.UserModel data = new Cli.UserModel(obj.User_windows_authent, obj.Department_id, obj.User_firstName, obj.User_lastName,
                obj.Email, obj.IsActive, obj.Create_date, obj.Last_update);
            data.Id = obj.Id;

            return data;
        }
    }
}