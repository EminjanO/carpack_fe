using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;
using ToolDataBase;

namespace InOutFCA.DAL.Repository
{
    public class Tbl_logRepository : BaseRepository<int, Tbl_log>
    {
        public Tbl_logRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public Tbl_logRepository(DBConnect DB) : base(DB)
        {
        }

        protected override Tbl_log Convert(Dictionary<string, object> Data)
        {
            return new Tbl_log()
            {
                Id = (int)Data["log_id"],
                log_date = (DateTime)Data["log_date"],
                log_action = Data["log_action"].ToString(),
                log_description = Data["log_description"].ToString(),
                log_user = Data["log_user"].ToString(),
                log_type = Data["log_type"].ToString()
            };
        }

        public override Tbl_log GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Tbl_log Entity)
        {
            Command cmd = new Command("INSERT INTO " + TableName + " (log_date, log_action, log_description, log_user, log_type) VALUES (@log_date, @log_action, @log_description, @log_user, @log_type);");
            cmd.AddParameter("log_date", Entity.log_date);
            cmd.AddParameter("log_action", Entity.log_action);
            cmd.AddParameter("log_description", Entity.log_description);
            cmd.AddParameter("log_user", Entity.log_user);
            cmd.AddParameter("log_type", Entity.log_type);

            int newId = DB.ExecuteNonQuery(cmd);
            return newId;
        }

        public override bool Update(Tbl_log Entity)
        {
            throw new NotImplementedException();
        }
    }
}
