using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        //Can return a list
        Task<IEnumerable<T>> ReturnList<T>(string procedureName, DynamicParameters param = null);

        //Non value returning proc
        void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null);

        //Returns one value e.g number of records, rows updated
        T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null);
    }
}
