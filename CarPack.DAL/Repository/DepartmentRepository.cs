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
    public class DepartmentRepository : BaseRepository<int, Department>
    {
        public DepartmentRepository(DBConnect DB, string TableName) : base(DB, TableName)
        {
        }

        public DepartmentRepository(DBConnect DB) : base(DB)
        {
        }

        protected override Department Convert(Dictionary<string, object> Data)
        {
            return new Department()
            {
                Id = System.Convert.ToInt32(Data["department_id"]),
                Department_name = Data["department_name"].ToString()
            };
        }

        public override Department GetOne(int Id)
        {
            throw new NotImplementedException();
        }

        public override int Insert(Department Entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Department Entity)
        {
            throw new NotImplementedException();
        }
    }
}
