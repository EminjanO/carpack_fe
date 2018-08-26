using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils.Mappers
{
    public static class UserprofilMapper
    {
        public static Glo.Userprofil ToGlobal(this Cli.UserprofilModel obj)
        {
            return new Glo.Userprofil()
            {
                Id = obj.Id,
                User_id = obj.User_id,
                Profil_id = obj.Profil_id
            };
        }

        public static Cli.UserprofilModel ToClient(this Glo.Userprofil obj)
        {
            Cli.UserprofilModel data = new Cli.UserprofilModel(obj.User_id, obj.Profil_id);
            data.Id = obj.Id;

            return data;
        }
    }
}