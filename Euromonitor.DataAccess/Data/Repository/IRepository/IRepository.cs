using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class //Generic class so any object can be passed through
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            //Add filter
            Expression<Func<T, bool>> filter = null,
            //Order By Class
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            //Include properties
            string includeProperties = null
        );

        T GetFirstOrDefault(
            //Add filter
            Expression<Func<T, bool>> filter = null,
            //Include properties
            string includeProperties = null
            );

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);
    }
}
