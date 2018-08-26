using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils.Mappers
{
    public static class ReasonMapper
    {
        public static Glo.Reason ToGlobal(this Cli.ReasonModel obj)
        {
            return new Glo.Reason()
            {
                Id = obj.Id,
                Eventreason_name = obj.Eventreason_name,
                Eventreason_alias = obj.Eventreason_alias
            };
        }

        public static Cli.ReasonModel ToClient(this Glo.Reason obj)
        {
            Cli.ReasonModel data = new Cli.ReasonModel(obj.Eventreason_name, obj.Eventreason_alias);
            data.Id = obj.Id;

            return data;
        }
    }
}