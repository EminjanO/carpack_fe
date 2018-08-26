using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils.Mappers
{
    public static class DepartmentMapper
    {
        public static Glo.Department ToGlobal(this Cli.DepartmentModel obj)
        {
            return new Glo.Department()
            {
                Id = obj.Id,
                Department_name = obj.Department_name
            };
        }

        public static Cli.DepartmentModel ToClient(this Glo.Department obj)
        {
            Cli.DepartmentModel data = new Cli.DepartmentModel(obj.Department_name);
            data.Id = obj.Id;

            return data;
        }
    }
}