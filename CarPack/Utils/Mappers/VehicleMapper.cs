using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils
{
    public static class VehicleMapper
    {
        public static Glo.Vehicle ToGlobal(this Cli.VehicleModel obj)
        {
            return new Glo.Vehicle()
            {
                Id = obj.Id,
                Department_id = obj.Department_id,
                User_id = obj.User_id,
                Mark = obj.Mark,
                Version = obj.Version,
                Model = obj.Model,
                Finition = obj.Finition,
                Chassis_number = obj.Chassis_number,
                Color_extern = obj.Color_extern,
                Color_intern = obj.Color_intern,
                Plate = obj.Plate,
                Garage_reference = obj.Garage_reference,
                First_registration = obj.First_registration//,
                //Visible_in_schedule = obj.Visible_in_schedule,
                //Create_date = obj.Create_date,
                //Last_update = obj.Last_update
            };
        }

        public static Cli.VehicleModel ToClient(this Glo.Vehicle obj)
        {
            Cli.VehicleModel data = new Cli.VehicleModel(obj.Department_id, obj.User_id, obj.Mark, obj.Version, obj.Model,
                obj.Finition, obj.Chassis_number, obj.Color_extern, obj.Color_intern, obj.Plate, obj.Garage_reference,
                obj.First_registration, obj.Visible_in_schedule, obj.Create_date, obj.Last_update);
            data.Id = obj.Id;

            return data;
        }
    }
}