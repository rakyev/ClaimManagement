using System;
using System.Data.Entity.Validation;
using System.Linq;
using ICM.Data.Business.RepositoryInterface;

namespace ICM.Data.Business.RepositoryImplementation
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ICMDBContext Context;

        protected GenericRepository()
        {
            if (Context == null)
                Context = new ICMDBContext();
        } 
        

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = Context.Set<T>();
            return query;
        }

        public virtual T GetByKey(long? id)
        {
            var query = Context.Set<T>().Find(id);
            return query;
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }   

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified; 
            Save();
        }

        public virtual void Save()
        {
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
               Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        
    }

}
