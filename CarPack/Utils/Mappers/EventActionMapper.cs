using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Glo = CarPack.DAL.Entity;
using Cli = CarPack.Models;

namespace CarPack.Utils.Mappers
{
    public static class EventActionMapper
    {
        public static Glo.EventAction ToGlobal(this Cli.EventActionModel obj)
        {
            return new Glo.EventAction()
            {
                Id = obj.Id,
                Event_id = obj.Event_id,
                Transition_id = obj.Transition_id,
                Action_id = obj.Action_id,
                Department_id = obj.Department_id,
                User_id = obj.User_id,
                IsActive = obj.IsActive,
                IsCompleted = obj.IsCompleted,
                Create_date = obj.Create_date,
                Last_update = obj.Last_update
            };
        }

        public static Cli.EventActionModel ToClient(this Glo.EventAction obj)
        {
            Cli.EventActionModel data = new Cli.EventActionModel(obj.Event_id, obj.Transition_id, obj.Action_id, obj.Department_id, obj.User_id, obj.IsActive, obj.IsCompleted, obj.Create_date, obj.Last_update);
            data.Id = obj.Id;

            return data;
        }
    }
}