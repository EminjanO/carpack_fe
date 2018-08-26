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
    public class VehicleRepository : BaseRepository<int, Vehicle>
    {
        public VehicleRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public VehicleRepository(DBConnect DB) : base(DB)
        {
        }

        protected override Vehicle Convert(Dictionary<string, object> Data)
        {
            return new Vehicle()
            {
                Id = System.Convert.ToInt32(Data["vehicle_id"]),
                Department_id = System.Convert.ToInt32(Data["department_id"]),
                User_id = System.Convert.ToInt32(Data["user_id"]),
                Mark = Data["mark"].ToString(),
                Version = Data["version"].ToString(),
                Model = Data["model"].ToString(),
                Finition = Data["finition"].ToString(),
                Chassis_number = Data["chassis_number"].ToString(),
                Color_extern = Data["color_extern"].ToString(),
                Color_intern = Data["color_intern"].ToString(),
                Plate = Data["plate"].ToString(),
                Garage_reference = Data["garage_reference"].ToString(),
                First_registration = (DateTime)Data["first_registration"],
                Visible_in_schedule = System.Convert.ToBoolean(Data["visible_in_schedule"]),
                Create_date = (DateTime)Data["create_date"],
                Last_update = (DateTime)Data["last_update"]
            };
        }

        public override Vehicle GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM " + TableName + " WHERE vehicle_id = @Id"); 
            cmd.AddParameter("Id", Id);


            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            if (datas.Count == 1)
            {
                return Convert(datas[0]);
            }
            return default(Vehicle);
        }

        public override int Insert(Vehicle Entity)
        {
            Command cmd = new Command("SET FOREIGN_KEY_CHECKS=0; INSERT INTO " + TableName + "(department_id, user_id, mark, version, model, finition, chassis_number, color_extern, color_intern, plate, garage_reference, first_registration ) " +
                                      "VALUES (@department_id, @user_id, @mark, @version, @model, @finition, @chassis_number, @color_extern, @color_intern, @plate, @garage_reference, @first_registration); SET FOREIGN_KEY_CHECKS=1;");
            cmd.AddParameter("department_id", Entity.Department_id);
            cmd.AddParameter("user_id", Entity.User_id);
            cmd.AddParameter("mark", Entity.Mark);
            cmd.AddParameter("version", Entity.Version);
            cmd.AddParameter("model", Entity.Model);
            cmd.AddParameter("finition", Entity.Finition);
            cmd.AddParameter("chassis_number", Entity.Chassis_number);
            cmd.AddParameter("color_extern", Entity.Color_extern);
            cmd.AddParameter("color_intern", Entity.Color_intern);
            cmd.AddParameter("plate", Entity.Plate);
            cmd.AddParameter("garage_reference", Entity.Garage_reference);
            cmd.AddParameter("first_registration", Entity.First_registration);

            DB.ExecuteNonQuery(cmd);
            int newId = (int)DB.getLastId("SELECT LAST_INSERT_ID()");

            return newId;
        }

        public override bool Update(Vehicle Entity)
        {
            throw new NotImplementedException();
        }
        public bool DeleteUpdate(int Id)
        {
            
            Command cmd = new Command("UPDATE " + TableName + " SET visible_in_schedule =" + 0 + " WHERE vehicle_id =" + Id + ";");

            int nbRow = DB.ExecuteNonQuery(cmd);

            return (nbRow == 1);
        }
    }
}
