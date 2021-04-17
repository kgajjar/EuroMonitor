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
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //Creates table called Users in DB
        public DbSet<AppUser> AppUser { get; set; }

        //Creates a table called Books in the DB
        public DbSet<Book> Book { get; set; }

        //Creates a table called AppUserBooks
        public DbSet<AppUserBook> AppUserBook { get; set; }

    }
}
