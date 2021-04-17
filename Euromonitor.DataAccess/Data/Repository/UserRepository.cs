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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        //Inject our datacontext in here
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.AppUser.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.AppUser
                //Eager Loading
                //.Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.AppUserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.AppUser
                //Eager Loading
                //.Include(p => p.Photos)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            //ensure that > 0 changes have been saved in order to return a boolean.
            //Save changes async returns an int with number of changes saved in DB
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            //Set the state to modified. Meaning dont sav to DB yet.
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
