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
    public class ClientRepository : BaseRepository<int, Client>
    {
        public ClientRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public ClientRepository(DBConnect DB) : base(DB)
        {
        }

        protected override Client Convert(Dictionary<string, object> Data)
        {
            return new Client()
            {
                Id = System.Convert.ToInt32(Data["client_id"]),
                User_id = System.Convert.ToInt32(Data["user_id"]),
                Client_number = Data["client_number"].ToString(),
                Client_name = Data["client_name"].ToString(),
                Prefix = Data["prefix"].ToString(),
                Responsible = Data["responsible"].ToString(),
                IsIntern = System.Convert.ToBoolean(Data["isIntern"]),
                Email = Data["email"].ToString(),
                Address = Data["address"].ToString(),
                IsActive = System.Convert.ToBoolean(Data["isActive"]),
                Create_date = (DateTime)Data["create_date"],
                Last_update = (DateTime)Data["last_update"]
            };
        }

        public override Client GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM " + TableName + " WHERE client_id = @Id");
            cmd.AddParameter("Id", Id);


            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            if (datas.Count == 1)
            {
                return Convert(datas[0]);
            }
            return default(Client);
        }

        public override int Insert(Client Entity)
        {
            Command cmd = new Command("SET FOREIGN_KEY_CHECKS=0; INSERT INTO "+ TableName + "(user_id, client_number, client_name, prefix, responsible, isIntern, email, address) " +
                                      "VALUES (@User_id, @Client_number, @Client_name, @Prefix, @Responsible, @IsIntern, @Email, @Address); SET FOREIGN_KEY_CHECKS=1;");
            cmd.AddParameter("user_id", Entity.User_id);
            cmd.AddParameter("client_number", Entity.Client_number);
            cmd.AddParameter("client_name",Entity.Client_name);
            cmd.AddParameter("prefix",Entity.Prefix);
            cmd.AddParameter("responsible", Entity.Responsible);
            cmd.AddParameter("isIntern", Entity.IsIntern);
            cmd.AddParameter("email", Entity.Email);
            cmd.AddParameter("address", Entity.Address);

            DB.ExecuteNonQuery(cmd);
            int newId = (int)DB.getLastId("SELECT LAST_INSERT_ID()");

            return newId;
        }

        public override bool Update(Client Entity)
        {
            throw new NotImplementedException();
        }
        public bool DeleteUpdate(int Id)
        {
            
            Command cmd = new Command("UPDATE " + TableName + " SET isActive =" + 0 + " WHERE client_id =" + Id + ";");

            int nbRow = DB.ExecuteNonQuery(cmd);

            return (nbRow == 1);
        }
    }
}
