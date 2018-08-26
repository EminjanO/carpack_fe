using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InOutFCA.DAL.Entity;

namespace InOutFCA.DAL.Repository
{
    public interface IRepository<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        TEntity GetOne(TKey Id);
        List<TEntity> GetAll();

        TKey Insert(TEntity Entity);
        bool Update(TEntity Entity);
        bool Delete(TKey Id);
        bool Delete(TEntity Entity);
    }
}
