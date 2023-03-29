using System.Collections.Generic;

namespace ConsoleAppIntermediate.LINQ
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>{
               new Book("C# Basic", 230.06),
               new Book("C# Advamced", 430.34),
               new Book("C# Intermediate", 730.90),
               new Book("ADO.Net Basic", 830.50),
               new Book("ASP.Net Core Basic", 330.06),
               new Book("Entity Framework Basic", 890.09)
            };
        }
    }


}