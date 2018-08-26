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
    public class ProfilRepository : BaseRepository<int, Profil>
    {
        public ProfilRepository(DBConnect DB) : base(DB)
        {
        }

        public ProfilRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        protected override Profil Convert(Dictionary<string, object> Data)
        {
            return new Profil()
            {
                Id = System.Convert.ToInt32(Data["profil_id"]),
                Profil_name = Data["profil_name"].ToString(),
                Profil_description = Data["profil_description"].ToString()
            };
        }
        public override Profil GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Profil Entity)
        {
            Command cmd = new Command("INSERT INTO " + TableName + " (`profil_name`,`profil_description`)  VALUES (@profil_name, @profil_description);");
            cmd.AddParameter("profil_id", Entity.Id);
            cmd.AddParameter("profil_name", Entity.Profil_name);
            cmd.AddParameter("profil_description", Entity.Profil_description);

            int newId = DB.ExecuteNonQuery(cmd);

            return newId;
        }

        public override bool Update(Profil Entity)
        {
            throw new NotImplementedException();
        }

    }
}
