using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Initializer
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _db;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;

        //Get above properties through DI
        public DbInitializer(ApplicationDbContext db)
        {
            _db = db;
            //_roleManager = roleManager;
            //_userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                //If there are any pending migrations
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    //Migrate them to DB automatically
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }

            //If there are any roles in DB already
            //if (_db.Roles.Any(r => r.Name == SD.Admin)) return;

            //No roles found in DB. Create roles
            //_roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
            //_roleManager.CreateAsync(new IdentityRole(SD.Manager)).GetAwaiter().GetResult();

            //Add a Admin user
            //_userManager.CreateAsync(new ApplicationUser()
            //{
            //    UserName = "admin@gmail.com",
            //    Email = "admin@gmail.com",
            //    EmailConfirmed = true,
            //    Name = "Kieran Gajjar"

            //}, "Admin123*").GetAwaiter().GetResult();
            //Passing our password

            //Assign our new user admin role
            //ApplicationUser user = _db.ApplicationUser.Where(u => u.Email == "admin@gmail.com").FirstOrDefault();

            //Add user to role
            //_userManager.AddToRoleAsync(user, SD.Admin).GetAwaiter().GetResult();
        }
    }
}
