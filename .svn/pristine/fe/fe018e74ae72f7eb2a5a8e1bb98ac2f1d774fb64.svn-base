using System;
using System.Linq;
using System.Linq.Expressions;

namespace ICM.Data.Business.RepositoryInterface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetByKey(long? id);

        void Update(T entity);

        void Add(T entity);

        void Delete(T entity);

        void Save();
    }
}
