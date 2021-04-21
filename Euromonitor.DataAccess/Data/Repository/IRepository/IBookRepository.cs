using Euromonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book book);//No need to be async as it's not updating DB. Only EF in memory.

        Task<bool> SaveAllAsync();

        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        Task<Book> GetBookByBookNameAsync(string bookname);
    }
}
