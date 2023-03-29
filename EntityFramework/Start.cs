using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Book_Library usses Code First Approach
using Book_Library;
//DBFirstLibrary usses Code First Database Approach
//using DBFirstLibrary;


namespace EntityFramework
{
    public class Start
    {
        static IEnumerable<Author> CreatedFakeData()
        {
            var authors = new List<Author>() {
                new Author()
                {
                    Name = "Somnath Singh", Books = new List<Book>()
                    {
                        new Book() { Title="C# Fundamentals", PublicationYear=1978},
                        new Book() { Title="C# Intermediate", PublicationYear=1997},
                        new Book() { Title="C# Advanced", PublicationYear=2012}
                    }
                },
                new Author()
                {
                    Name = "Raji Acharyya", Books = new List<Book>()
                    {
                        new Book() { Title="Entityframework", PublicationYear=1978},
                        new Book() { Title="Entityframework Core", PublicationYear=1989},
                        new Book() { Title="Entityframework Advanced", PublicationYear=2006}
                    }
                }
            };

            return authors;
        }

        static void Main(string[] args)
        {
            //Configuration using appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                                               .AddJsonFile("appsettings.json", false, true)
                                               .Build();

            ///////////////////////////////////////////////////////////////////////////////
            //Use Code First Approach - Book-Library
            //Create DB Cpontext options to pass as parameter to create BookContext object; It will create a DB.

            var options = new DbContextOptionsBuilder<BookContext>()
               .UseSqlServer(configuration.GetConnectionString("BookLibrary"))
               .Options;

            using var bookContext = new BookContext(options);

            // Console.WriteLine($"DataBase Created :{bookContext.Database.EnsureCreated()}");

            ///////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////
            //Use Code First Database Approach - DBFirstLibrary
            //Create DB Cpontext options to pass as parameter to create BookContext object; It will create a DB.
            /*
             var options = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookStoreDB;Trusted_Connection=True;MultipleActiveResultSets=True")
                .Options;

             using var bookContext = new BookStoreDbContext(options);
            */

            // Console.WriteLine($"DataBase Created :{bookContext.Database.EnsureCreated()}");

            ///////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////
            //Create data in DB table 
            /*var authers = CreatedFakeData();

            bookContext.AddRange(authers);

            bookContext.SaveChanges();
            */
            /////////////////////////////////////////////////////////////////////////////////////
            ///Read Data From DB Tables using bookContext

            //All Books which Auther is "Somnath"
            var authers = bookContext.Authors.Include(a => a.Books).Where(a => a.Name.Contains("Somnath"));

            foreach (var author in authers)
            {
                Console.WriteLine($"Name - {author.Name}");
                foreach (var book in author.Books)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine("------------------------------");
            }
            //Books published in 1978
            var books = bookContext.Books.Where(b => b.PublicationYear == 1978).Include(b => b.Author);

            foreach (var book in books)
            {
                Console.WriteLine($"Name - {book.Title}");
                Console.WriteLine($"Name - {book.PublicationYear}");
                Console.WriteLine($"Name - {book.Author.Name}");
                Console.WriteLine("------------------------------");
            }
            ////Add Book
            var currentAuthor = bookContext.Authors.Where(a => a.Name.Contains("Somnath8")).FirstOrDefault();
            if(currentAuthor != null )
            {
                bookContext.Books.Add(new Book { Title = "JAVA Basic", PublicationYear = 1978, Author = currentAuthor });
                bookContext.SaveChanges();
            }

            ///
            ///////////////////////////////////////////////////////////////
            //Display dummy data in console
            /*
                        Console.WriteLine("Entity Framework");
                        var authorsList = CreatedFakeData();

                        foreach (var author in authorsList)
                        {
                            Console.WriteLine(author);
                            foreach (var book in author.Books)
                            {
                                Console.WriteLine(book);
                            }
                        }
            */
            ///////////////////////////////////////////////////////////////
        }
    }

   
}
