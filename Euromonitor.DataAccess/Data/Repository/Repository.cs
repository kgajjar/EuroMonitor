using Euromonitor.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Access the Database
        protected readonly ApplicationDbContext Context;
        internal DbSet<T> dbSet;

        //Using DI to implement ApplicationDbContext
        public Repository(ApplicationDbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            //Adds to Db Set
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            //Implement filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Check for any properties that we have to include for Eager loading
            if (includeProperties != null)
            {
                //Include properties will be comma seperated
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //For each included property we will add to our query
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                //Order by order specified
                return orderBy(query).ToList();
            }
            //Not ordered
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            //Implement filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            //Check for any properties that we have to include for Eager loading
            if (includeProperties != null)
            {
                //Include properties will be comma seperated
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //For each included property we will add to our query
                    query = query.Include(includeProperty);
                }
            }
            //Only return first object in Query.
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            //Remove entity from our table
            T entityToRemove = dbSet.Find(id);

            Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
