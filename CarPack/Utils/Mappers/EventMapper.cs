using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils
{
    public static class EventMapper
    {
        public static Glo.Event ToGlobal(this Cli.EventModel obj)
        {
            return new Glo.Event()
            {
                Id = obj.Id,
                Subject = obj.Subject,
                Description = obj.Description,
                User_id = obj.User_id,
                State_id = obj.State_id,
                Vehicle_id = obj.Vehicle_id,
                Client_id = obj.Client_id,
                Reason_id = obj.Reason_id,
                IsActive = obj.IsActive,
                Starttime = obj.Starttime,
                Endtime = obj.Endtime,
                Create_date = obj.Create_date,
                Last_update = obj.Last_update
            };
        }

        public static Cli.EventModel ToClient(this Glo.Event obj)
        {
            Cli.EventModel data = new Cli.EventModel(obj.Subject, obj.Description, obj.User_id, obj.State_id,
                obj.Vehicle_id, obj.Client_id, obj.Reason_id, obj.IsActive, obj.Starttime, obj.Endtime, obj.Create_date, obj.Last_update);
            data.Id = obj.Id;

            return data;
        }
    }
}