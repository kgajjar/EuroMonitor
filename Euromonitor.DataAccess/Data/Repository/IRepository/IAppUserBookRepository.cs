using Euromonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Repository.IRepository
{
    public interface IAppUserBookRepository : IRepository<AppUserBook>
    {
        void Update(AppUserBook appUserBook);//No need to be async as it's not updating DB. Only EF in memory.

        Task<bool> SaveAllAsync();

        Task<AppUserBook> GetAppUserBookByIdAsync(int id);

        Task<IEnumerable<AppUserBook>> GetAppUserBooksByAppUserIdAsync(int id);

    }
}
