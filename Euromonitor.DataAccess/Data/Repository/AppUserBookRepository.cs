using Euromonitor.DataAccess.Data.Repository.IRepository;
using Euromonitor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Repository
{
    public class AppUserBookRepository : Repository<AppUserBook>, IAppUserBookRepository
    {
        private readonly ApplicationDbContext _context;

        //Inject our DataContext into the DI container
        public AppUserBookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AppUserBook> GetAppUserBookByIdAsync(int id)
        {
            return await _context.AppUserBook.FindAsync(id);
        }

        public async Task<IEnumerable<AppUserBook>> GetAppUserBooksByAppUserIdAsync(int id)
        {
            return await _context.AppUserBook
                .Where(c => c.AppUserId == id)
               .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            //ensure that > 0 changes have been saved in order to return a boolean.
            //Save changes async returns an int with number of changes saved in DB
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUserBook appUserBook)
        {
            //Set the state to modified. Meaning dont sav to DB yet.
            _context.Entry(appUserBook).State = EntityState.Modified;
        }
    }
}
