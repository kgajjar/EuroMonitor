using Euromonitor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        //We will pass this ctor options from Startup.cs files later
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Creates table called User in DB
        public DbSet<AppUser> AppUser { get; set; }

        //Creates a table called Book in the DB
        public DbSet<Book> Book { get; set; }

        //Creates a table called AppUserBook
        public DbSet<AppUserBook> AppUserBook { get; set; }

    }
}
