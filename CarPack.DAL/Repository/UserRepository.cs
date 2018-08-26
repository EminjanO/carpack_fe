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
    public class UserRepository : BaseRepository<int, User>
    {
        public UserRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public UserRepository(DBConnect DB) : base(DB)
        {
        }

        protected override User Convert(Dictionary<string, object> Data)
        {
            return new User()
            {
                Id = System.Convert.ToInt32(Data["user_id"]),
                User_windows_authent = Data["user_windows_authent"].ToString(),
                Department_id = System.Convert.ToInt32(Data["department_id"]),
                User_firstName = Data["user_firstName"].ToString(),
                User_lastName = Data["user_lastName"].ToString(),
                Email = Data["email"].ToString(),
                IsActive = System.Convert.ToBoolean(Data["isActive"]),
                Create_date = (DateTime)Data["create_date"],
                Last_update = (DateTime)Data["last_update"]
            };
        }

        public override User GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM " + TableName + " WHERE user_id = @Id");
            cmd.AddParameter("Id", Id);
            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            if (datas.Count == 1)
            {
                return Convert(datas[0]);
            }
            return default(User);
        }
        public List<User> GetUsersByDepartment(int Id)
        {
            Command cmd = new Command("SELECT * FROM " + TableName + " WHERE department_id = @Id");
            cmd.AddParameter("Id", Id);

            List<User> results = new List<User>();
            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            foreach (Dictionary<string, object> data in datas)
            {
                results.Add(Convert(data));
            }
            return results;
        }

        public override int Insert(User Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(User Entity)
        {
            throw new NotImplementedException();
        }
    }
}
