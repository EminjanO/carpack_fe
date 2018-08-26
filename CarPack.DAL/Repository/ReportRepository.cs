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
    public class ReportRepository : BaseRepository<int, Report>
    {
        public ReportRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public ReportRepository(DBConnect DB) : base(DB)
        {
        }

        protected override Report Convert(Dictionary<string, object> Data)
        {
            return new Report()
            {
                Id = System.Convert.ToInt32(Data["Report_id"]),
                Vehicle_id = System.Convert.ToInt32(Data["Vehicle_id"]),
                Vehicle_Reference = Data["Vehicle_Reference"].ToString(),
                Chassis = Data["Chassis"].ToString(),
                Registration = (DateTime)Data["Registration"],
                Deregistration = (DateTime)Data["Deregistration"]
            };
        }

        public override Report GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Report Entity)
        {
            Command cmd = new Command("SET FOREIGN_KEY_CHECKS=0; INSERT INTO "+ TableName + "(Vehicle_id, Vehicle_Reference, Chassis, Registration, Deregistration) " +
                                      "VALUES (@Vehicle_id, @Vehicle_Reference, @Chassis, @Registration, @Deregistration); SET FOREIGN_KEY_CHECKS=1;");
            cmd.AddParameter("Vehicle_id", Entity.Vehicle_id);
            cmd.AddParameter("Vehicle_Reference", Entity.Vehicle_Reference);
            cmd.AddParameter("Chassis",Entity.Chassis);
            cmd.AddParameter("Registration",Entity.Registration);
            cmd.AddParameter("Deregistration", Entity.Deregistration);

            DB.ExecuteNonQuery(cmd);
            int newId = (int)DB.getLastId("SELECT LAST_INSERT_ID()");

            return newId;
        }

        public override bool Update(Report Entity)
        {
            throw new NotImplementedException();
        }
    }
}
