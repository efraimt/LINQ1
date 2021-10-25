using LINQ1;
using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;
using System.Xml.Linq;
using System.Linq;

namespace LINQ1
{
    public class Book
    {
        public int Id { get; set; }
        public Guid ISBN { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public short NumberOfCopies { get; set; }
        public short NumberOfBorrowedOut { get; set; }
        public DateTime DatePublished { get; set; }


        public bool IsNewBindingNeeded()
        {
            return DatePublished.Year < DateTime.Now.AddYears(20).Year;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            //var b = new Book();

            var obj = new { FirstName = "Ohad", LastName = "Zriadya" };

            Console.WriteLine(obj.FirstName);
            Console.WriteLine(obj.LastName);















            List<Book> books = new List<Book>()
            {
                new Book { Id = 300, Author = "Meir Shalev", Name = "Other Days", DatePublished = new DateTime(1982, 08, 03), NumberOfPages = 367, NumberOfCopies = 10000, NumberOfBorrowedOut = 78,},
                new Book { Id = 301, Author = "Albert Einstein", Name = "Black Holes", DatePublished = new DateTime(1919, 1, 01), NumberOfPages = 567, NumberOfCopies = 20000, NumberOfBorrowedOut = 67 }
            };
            books.Add(new Book { Id = 1, Author = "Lior Shlein", DatePublished = new DateTime(2009, 05, 17) });
            books.Add(new Book
            {
                Id = 8567,
                Author = "Yogev Poren",
                DatePublished = new DateTime(2003, 03, 27)
            });

            books.Add(new Book { Id = 56, Author = "Arthur Conan Doyle", DatePublished = new DateTime(1887, 04, 20) });
            books.Add(new Book { Id = 2, Author = "Oda", Name = "One Peace", DatePublished = new DateTime(2008, 03, 24) });
            books.Add(new Book { Id = 7101, Author = "Lev Tolstoy", DatePublished = new DateTime(1962, 05, 17), Name = "War and Pease", NumberOfPages = 780, NumberOfCopies = 2 });
            books.Add(new Book { Id = 7102, Author = "O'Henry", DatePublished = new DateTime(1932, 12, 17), Name = "Novells", NumberOfPages = 360, NumberOfCopies = 2 });
            books.Add(new Book { Id = 7103, Author = "Arthur Heily", DatePublished = new DateTime(1999, 11, 17), Name = "Hotel", NumberOfPages = 260, NumberOfCopies = 3 });
            books.Add(new Book { Id = 1, Author = "Marcel Proust", DatePublished = new DateTime(2009, 05, 17), Name = "In Search of Lost Time", NumberOfPages = 525, NumberOfBorrowedOut = 3 });
            books.Add(new Book { Id = 2, Author = "Miguel de Cervantes", DatePublished = new DateTime(1605, 03, 02), Name = "Miguel de Cervantes", NumberOfPages = 400, NumberOfBorrowedOut = 2 });
            books.Add(new Book { Id = 3, Author = "Gabriel Garcia Marquez", DatePublished = new DateTime(2013, 07, 05), Name = "One Hundred Years of Solitude", NumberOfPages = 321, NumberOfBorrowedOut = 5 });
            books.Add(new Book { Id = 4, Author = "Leo Tolstoy", DatePublished = new DateTime(1980, 05, 15), Name = "War and Peace", NumberOfPages = 900, NumberOfBorrowedOut = 15 });
            books.Add(new Book { Id = 5, Author = "Fyodor Dostoyevsky", DatePublished = new DateTime(1993, 05, 17), Name = "Crime and Punishment", NumberOfPages = 276, NumberOfBorrowedOut = 6 });
            books.Add(new Book { Id = 987, ISBN = new Guid(), Author = "Mozes", Name = "Efshar Gam Bly Qavier", NumberOfPages = 321, NumberOfCopies = 10, NumberOfBorrowedOut = 7, DatePublished = new DateTime(1947, 02, 01) });
            books.Add(new Book { Id = 964, ISBN = new Guid(), Author = "Ariel NAim", Name = "My First Book", NumberOfPages = 543, NumberOfCopies = 29, NumberOfBorrowedOut = 27, DatePublished = new DateTime(2007, 05, 24) });
            books.Add(new Book { Id = 864, ISBN = new Guid(), Author = "Haim Mosh", Name = "Ein li Shem Amiti", NumberOfPages = 111, NumberOfCopies = 7, NumberOfBorrowedOut = 0, DatePublished = new DateTime(1985, 11, 11) });
            books.Add(new Book { Id = 653, ISBN = new Guid(), Author = "Gady Halper", Name = "My New Car", NumberOfPages = 444, NumberOfCopies = 17, NumberOfBorrowedOut = 13, DatePublished = new DateTime(2021, 10, 21) });




            //Get all books published before 2001
            var myQuery = books.Where(book => book.DatePublished.Year < 2001);
            foreach (var book in myQuery)
            {
                Console.WriteLine("{0} {1}", book.Name, book.DatePublished);
            }

            //Get name and published date of all books that was published befor 2001
            var list1 = (from b in books
                         where b.DatePublished.Year <= 2000
                         select b.Name + " " + b.DatePublished).ToList();

            var list1N = books.Where(b => b.DatePublished.Year < 2001)
                .Select(b => b.Name + " " + b.DatePublished).ToList();



            var list2 = (from b in books
                         where b.NumberOfCopies > 10
                         select b.Name + b.NumberOfCopies).ToList();


            //Fetch all books and rertrn name and date published
            var q3 = from b in books
                     select new {  b.Name, DatePublished = b.DatePublished };
            /* pay tension that we can exclude the "Name =" */

            var q3N = books.Select(b => new { b.Name, b.DatePublished });

            foreach (var item in q3N)
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}
