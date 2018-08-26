using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPack.DAL.Entity;
using InOutFCA.DAL.Entity;
using InOutFCA.DAL.Repository;
using ToolDataBase;

namespace CarPack.DAL.Repository
{
    public class ReasonRepository : BaseRepository<int, Reason>
    {
        public ReasonRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public ReasonRepository(DBConnect DB) : base(DB)
        {
        }

        protected override Reason Convert(Dictionary<string, object> Data)
        {
            return new Reason()
            {
                Id = System.Convert.ToInt32(Data["eventreason_id"]),
                Eventreason_name = Data["eventreason_name"].ToString(),
                Eventreason_alias = Data["eventreason_alias"].ToString()
            };
        }

        public override Reason GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Reason Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Reason Entity)
        {
            throw new NotImplementedException();
        }
    }
}
