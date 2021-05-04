using Euromonitor.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            AppUser = new AppUserRepository(_db);
            Book = new BookRepository(_db);
            AppUserBook = new AppUserBookRepository(_db);
            SP_Call = new SP_Call(_db);
        }

        public IAppUserRepository AppUser { get; private set; }

        public IBookRepository Book { get; private set; }

        public IAppUserBookRepository AppUserBook { get; private set; }

        public ISP_Call SP_Call { get; private set; }

        /// <summary>
        /// Dispose of unused resources
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }

        /// <summary>
        /// Persist changes to the DB
        /// </summary>
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
