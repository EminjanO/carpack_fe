using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;
using ToolDataBase;

namespace InOutFCA.DAL.Repository
{
    public abstract class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        private string _TableName;
        private DBConnect _DB;

        public string TableName
        {
            get { return _TableName; }
            private set { _TableName = value; }
        }
        public DBConnect DB
        {
            get { return _DB; }
            private set { _DB = value; }
        }

        public BaseRepository(DBConnect DB, string TableName)
        {
            this.DB = DB;
            this.TableName = TableName;
        }
        public BaseRepository(DBConnect DB)
        {
            this.DB = DB;
        }

        protected abstract TEntity Convert(Dictionary<string, object> Data);

        #region SELECT
        public virtual List<TEntity> GetAll()
        {
            Command cmd = new Command("SELECT * FROM " + TableName);

            List<TEntity> results = new List<TEntity>();
            List<Dictionary<string, object>> datas = DB.ExecuteReader(cmd);
            foreach (Dictionary<string, object> data in datas)
            {
                results.Add(Convert(data));
            }
            return results;
        }

        public abstract TEntity GetOne(TKey Id);
        #endregion

        #region Insert/Update/Delete
        public abstract TKey Insert(TEntity Entity);
        public abstract bool Update(TEntity Entity);
        public virtual bool Delete(TKey Id)
        {
            Command cmd = new Command("DELETE FROM " + TableName + " WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            int nbRow = DB.ExecuteNonQuery(cmd);

            return (nbRow == 1);
        }
        public virtual bool Delete(TEntity Entity)
        {
            return Delete(Entity.Id);
        }
        #endregion

    }
}
