using System;
using System.Collections.Generic;
using static FluentvalidationDemoConsoles.Books;

namespace FluentvalidationDemoConsoles
{
    class Program
    {
        static void Main(string[] args)
        {
            Books myBook = new Books()
            {
                //srgswefg
                //Name = "三体",
                Price = 140m,
                Author = "刘慈欣",
                Images = null, //new List<string>()
                Code = "134",
                PublishTime=new DateTime(2019,12,09),
                StartTime =new DateTime(2019,05,01),
                EndTime =new DateTime(2019,06,02),
                country = (BookCountry)5
            };
            BookDetails bookDetails = new BookDetails()
            {
                PageCount = 0,
                Source = "科幻出版社"
            };
            myBook.BookDetails = bookDetails;

            BooksValidator booksValidator = new BooksValidator();
            booksValidator.Validate(myBook).Check();
            Console.WriteLine("校验完成");
            Console.ReadKey();
        }
    }
}
