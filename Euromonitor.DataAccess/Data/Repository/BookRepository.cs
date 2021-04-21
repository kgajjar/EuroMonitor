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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;

        //Inject our datacontext in here
        public BookRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByBookNameAsync(string bookname)
        {
            return await _context.Book
                .SingleOrDefaultAsync(x => x.BookName == bookname);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Book.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Book
                .ToListAsync();
        }

        /// <summary>
        /// Ensure that > 0 changes have been saved in order to return a boolean.
        /// </summary>
        /// <returns>boolean if changes saved successfully</returns>
        public async Task<bool> SaveAllAsync()
        {
            //ensure that > 0 changes have been saved in order to return a boolean.
            //Save changes async returns an int with number of changes saved in DB
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Book book)
        {
            //Set the state to modified in EF. Meaning dont save to DB yet.
            _context.Entry(book).State = EntityState.Modified;
        }
    }
}
