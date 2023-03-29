using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library
{
    public class BookContext : DbContext
    {
        //We will create BookContext object by providing DB Context options from calling class here Start.cs
        public BookContext(DbContextOptions<BookContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
