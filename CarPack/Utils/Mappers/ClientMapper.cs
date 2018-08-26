using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils
{
    public static class ClientMapper
    {
        public static Glo.Client ToGlobal(this Cli.ClientModel obj)
        {
            return new Glo.Client()
            {
                Id = obj.Id,
                User_id = obj.User_id,
                Client_number = obj.Client_number,
                Client_name = obj.Client_name,
                Prefix = obj.Prefix,
                Responsible = obj.Responsible,
                IsIntern = obj.IsIntern,
                Email = obj.Email,
                Address = obj.Address,
                IsActive = obj.IsActive,
                Create_date = obj.Create_date,
                Last_update = obj.Last_update
            };
        }

        public static Cli.ClientModel ToClient(this Glo.Client obj)
        {
            Cli.ClientModel data = new Cli.ClientModel(obj.User_id, obj.Client_number, obj.Client_name, obj.Prefix,
            obj.Responsible, obj.IsIntern, obj.Email, obj.Address, obj.IsActive, obj.Create_date, obj.Last_update);
            data.Id = obj.Id;

            return data;
        }
    }
}