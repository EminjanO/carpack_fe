using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPack.DAL.Entity;
using InOutFCA.DAL.Repository;
using ToolDataBase;

namespace CarPack.DAL.Repository
{
    public class EventRepository : BaseRepository<int, Event>
    {
        public EventRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public EventRepository(DBConnect DB) : base(DB)
        {
        }

        protected override Event Convert(Dictionary<string, object> Data)
        {
            return new Event()
            {
                Id = System.Convert.ToInt32(Data["event_id"]),
                Subject = Data["subject"].ToString(),
                Description = Data["description"].ToString(),
                User_id = System.Convert.ToInt32(Data["user_id"]),
                State_id = System.Convert.ToInt32(Data["state_id"]),
                Vehicle_id = System.Convert.ToInt32(Data["vehicle_id"]),
                Client_id = DBNull.Value.Equals(Data["client_id"])? 0 : System.Convert.ToInt32(Data["client_id"]),
                Reason_id = System.Convert.ToInt32(Data["reason_id"]),
                IsActive = System.Convert.ToBoolean(Data["isActive"]),
                Starttime = (DateTime)Data["starttime"],
                Endtime = (DateTime)Data["endtime"],
                Create_date = (DateTime)Data["create_date"],
                Last_update = DBNull.Value.Equals(Data["last_update"])? null : (DateTime?)Data["last_update"]
            };
        }

        public override Event GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM " + TableName + " WHERE event_id = @Id");
            cmd.AddParameter("Id", Id);


            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            if (datas.Count == 1)
            {
                return Convert(datas[0]);
            }
            return default(Event);
        }

        public override int Insert(Event Entity)
        {
            Command cmd = new Command("INSERT INTO " + TableName + " (`subject`,`description`,`user_id`,`state_id`,`vehicle_id`,`client_id`,`reason_id`,`isActive`,`starttime`,`endtime`,`create_date`) " +
                                      " VALUES (@subject, @description, @user_id, @state_id , @vehicle_id, @client_id, @reason_id, @isActive , @starttime, @endtime, @create_date);");
            cmd.AddParameter("event_id", Entity.Id);
            cmd.AddParameter("subject", Entity.Subject);
            cmd.AddParameter("description", Entity.Description);
            cmd.AddParameter("user_id", Entity.User_id);
            cmd.AddParameter("state_id", Entity.State_id);
            cmd.AddParameter("vehicle_id", Entity.Vehicle_id);
            cmd.AddParameter("client_id", Entity.Client_id);
            cmd.AddParameter("reason_id", Entity.Reason_id);
            cmd.AddParameter("isActive", Entity.IsActive);
            cmd.AddParameter("starttime", Entity.Starttime);
            cmd.AddParameter("endtime", Entity.Endtime);
            cmd.AddParameter("create_date", Entity.Create_date);

            // int newId = DB.ExecuteNonQuery(cmd);
            DB.ExecuteNonQuery(cmd);
            int newId = (int)DB.getLastId("SELECT LAST_INSERT_ID()");

            return newId;
        }

        public override bool Update(Event Entity)
        {
            Command cmd = new Command("UPDATE " + TableName + " SET subject = @subject, description = @description, user_id = @user_id, state_id = @state_id,  vehicle_id = @vehicle_id," +
                                      " client_id = @client_id, reason_id = @reason_id, isActive = @isActive, starttime = @starttime, endtime =@endtime, create_date = @create_date WHERE event_id = @Id;");
            cmd.AddParameter("Id", Entity.Id);
            cmd.AddParameter("subject", Entity.Subject);
            cmd.AddParameter("description", Entity.Description);
            cmd.AddParameter("user_id", Entity.User_id);
            cmd.AddParameter("state_id", Entity.State_id);
            cmd.AddParameter("vehicle_id", Entity.Vehicle_id);
            cmd.AddParameter("client_id", Entity.Client_id);
            cmd.AddParameter("reason_id", Entity.Reason_id);
            cmd.AddParameter("isActive", Entity.IsActive);
            cmd.AddParameter("starttime", Entity.Starttime);
            cmd.AddParameter("endtime", Entity.Endtime);
            cmd.AddParameter("create_date", Entity.Create_date);

            int nbRow = DB.ExecuteNonQuery(cmd);

            return (nbRow == 1);
        }
        public bool UpdateByIdToDelete(int eventId)
        {
            Command cmd = new Command("UPDATE " + TableName + " SET isActive =false WHERE event_id =" + eventId + ";");

            int nbRow = DB.ExecuteNonQuery(cmd);

            return (nbRow == 1);
        }
        public bool UpdateStateById(int eventId, int stateId)
        {
            Command cmd = new Command("UPDATE " + TableName + " SET state_id =" + stateId + " WHERE event_id =" + eventId + ";");

            int nbRow = DB.ExecuteNonQuery(cmd);

            return (nbRow == 1);
        }
    }
}
