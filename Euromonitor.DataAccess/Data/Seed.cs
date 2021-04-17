using Euromonitor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Euromonitor.DataAccess.Data
{
    public class Seed
    {
        public static async Task SeedBooks(ApplicationDbContext context)
        {
            //Check if there are any books in the Books table
            if (await context.Book.AnyAsync()) return;

            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\Data/BookSeedData.json";

            //No books in DB. So fetch data from json file
            var bookData = await System.IO.File.ReadAllTextAsync(filePath);

            //No need to use Newtonsoft JSON since .net core 3.1
            //Deserialize the book JSON file content
            var books = JsonSerializer.Deserialize<List<Book>>(bookData);

            //Add these books to DB
            foreach (var book in books)
            {

                //Add to memory in EF Core
                context.Book.Add(book);
            }

            //Persist changes To DB asynchronously
            await context.SaveChangesAsync();
        }
    }
}
