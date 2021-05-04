using Dapper;
using Euromonitor.DataAccess.Data.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Repository
{
    public class SP_Call : ISP_Call
    {
        //Get DB Context Object
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";

        //Injecting ApplicationDbContext into DI container
        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            //Retrieve connection string from Application Db Context
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }

        /// <summary>
        /// Dispose of unused resources
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }

        /// <summary>
        /// Returns one value e.g number of records, rows updated
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                //Open connection to DB
                sqlCon.Open();

                //Call Stored Proc
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }


        /// <summary>
        /// Non value returning stored procedure
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        public void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                //Open connection to DB
                sqlCon.Open();

                //Call Stored Proc
                sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Can return a generic list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procedureName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                //Open connection to DB
                sqlCon.Open();

                //Call Stored Proc asynchronously
                return await sqlCon.QueryAsync<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
