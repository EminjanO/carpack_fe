using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils.Mappers
{
    public static class ReportMapper
    {
        public static Glo.Report ToGlobal(this Cli.ReportModel obj)
        {
            return new Glo.Report()
            {
                Id = obj.Id,
                Vehicle_id = obj.Vehicle_id,
                Vehicle_Reference = obj.Vehicle_Reference,
                Chassis = obj.Chassis,
                Registration = obj.Registration,
                Deregistration = obj.Deregistration
            };
        }

        public static Cli.ReportModel ToClient(this Glo.Report obj)
        {
            Cli.ReportModel data = new Cli.ReportModel(obj.Vehicle_id, obj.Vehicle_Reference, obj.Chassis, obj.Registration, obj.Deregistration);
            data.Id = obj.Id;

            return data;
        }
    }
}