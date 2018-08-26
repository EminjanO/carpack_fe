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
    public class UserprofilRepository : BaseRepository<int, Userprofil>
    {
        public UserprofilRepository(DBConnect DB) : base(DB)
        {
        }

        public UserprofilRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public override Userprofil GetOne(int Id)
        {
            throw new NotImplementedException();
        }
        public List<Userprofil> GetByUserId(int Id)
        {
            Command cmd = new Command("SELECT * FROM " + TableName + " WHERE user_id = @Id");
            cmd.AddParameter("Id", Id);

            List<Userprofil> results = new List<Userprofil>();
            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            foreach (Dictionary<string, object> data in datas)
            {
                results.Add(Convert(data));
            }
            return results;
        }
        public override int Insert(Userprofil Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Userprofil Entity)
        {
            throw new NotImplementedException();
        }

        protected override Userprofil Convert(Dictionary<string, object> Data)
        {
            return new Userprofil()
            {
                User_id = System.Convert.ToInt32(Data["user_id"]),
                Profil_id = System.Convert.ToInt32(Data["profil_id"])
            };
        }
    }
}
