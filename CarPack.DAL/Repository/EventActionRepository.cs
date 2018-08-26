using CarPack.DAL.Entity;
using InOutFCA.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolDataBase;

namespace CarPack.DAL.Repository
{
    public class EventActionRepository : BaseRepository<int, EventAction>
    {
        public EventActionRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }
        public EventActionRepository(DBConnect DB) : base(DB)
        {
        }

        protected override EventAction Convert(Dictionary<string, object> Data)
        {
            return new EventAction()
            {
                Id = System.Convert.ToInt32(Data["event_action_id"]),
                Event_id = System.Convert.ToInt32(Data["event_id"]),
                Transition_id = System.Convert.ToInt32(Data["transition_id"]),
                Action_id = System.Convert.ToInt32(Data["action_id"]),
                Department_id = System.Convert.ToInt32(Data["department_id"]),
                User_id = System.Convert.ToInt32(Data["user_id"]),
                IsActive = System.Convert.ToBoolean(Data["isActive"]),
                IsCompleted = System.Convert.ToBoolean(Data["isCompleted"]),
                Create_date = (DateTime)Data["create_date"],
                Last_update = (DateTime)Data["last_update"]
            };
        }
        public override EventAction GetOne(int Id)
        {
            throw new NotImplementedException();
        }
        public EventAction GetUserEventAction(int user_id, int event_id, int action_id)
        {
            Command cmd = new Command("SELECT * FROM " + TableName + " WHERE user_id = @user_id and event_id = @event_id and action_id = @action_id");
            cmd.AddParameter("user_id", user_id);
            cmd.AddParameter("event_id", event_id);
            cmd.AddParameter("action_id", action_id);


            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            if (datas.Count == 1)
            {
                return Convert(datas[0]);
            }
            return default(EventAction);
        }
        public List<EventAction> GetByCurrentUserId(int Id)
        {

            Command cmd = new Command("SELECT * FROM " + TableName + " WHERE user_id = @Id and isActive = 1 and isCompleted = 0");
            cmd.AddParameter("Id", Id);

            List<EventAction> results = new List<EventAction>();
            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            foreach (Dictionary<string, object> data in datas)
            {
                results.Add(Convert(data));
            }
            return results;
        }

        public override int Insert(EventAction Entity)
        {
            Command cmd = new Command("INSERT INTO " + TableName + " (`event_id`,`transition_id`,`action_id`,`department_id`,`user_id`,`isActive`,`isCompleted`,`create_date`) " +
                                                            " VALUES (@event_id, @transition_id, @action_id, @department_id , @user_id, @isActive, @isCompleted, @create_date);");
            cmd.AddParameter("event_action_id", Entity.Id);
            cmd.AddParameter("event_id", Entity.Event_id);
            cmd.AddParameter("transition_id", Entity.Transition_id);
            cmd.AddParameter("action_id", Entity.Action_id);
            cmd.AddParameter("department_id", Entity.Department_id);
            cmd.AddParameter("user_id", Entity.User_id);
            cmd.AddParameter("isActive", Entity.IsActive);
            cmd.AddParameter("isCompleted", Entity.IsCompleted);
            cmd.AddParameter("create_date", Entity.Create_date);

            // int newId = DB.ExecuteNonQuery(cmd);
            DB.ExecuteNonQuery(cmd);
            int newId = (int)DB.getLastId("SELECT LAST_INSERT_ID()");

            return newId;
        }

        public override bool Update(EventAction Entity)
        {
            throw new NotImplementedException();
        }
        public bool UpdateById(int event_id)
        {
            Command cmd = new Command("UPDATE " + TableName + " SET isActive = 0 WHERE event_id = " + event_id);

            int nbRow = DB.ExecuteNonQuery(cmd);

            return (nbRow == 1);
        }
        public bool UpdateCompletedByUser(int event_id, int user_id, int action_id)
        {
            Command cmd = new Command("UPDATE " + TableName + " SET isCompleted = 1, isActive = 0 WHERE event_id = " + event_id + " && user_id =" + user_id + " && action_id =" + action_id);

            int nbRow = DB.ExecuteNonQuery(cmd);

            return (nbRow == 1);
        }
    }
}
