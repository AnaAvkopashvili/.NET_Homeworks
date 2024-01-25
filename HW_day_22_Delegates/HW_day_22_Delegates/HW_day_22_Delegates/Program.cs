using System.Threading.Channels;

namespace HW_day_22_Delegates
{
    public delegate void LogMessage(string message);

    public delegate Decimal MathDelegate(Decimal a, Decimal b);



    public class Program
    {
        static void Main(string[] args)
        {
            // 1
            string path = "C:\\Users\\Kiu-Student\\Desktop\\file.txt";
            string message = "message";

            LogMessage logMessage = (message) => Console.WriteLine(message);
            logMessage += (message) =>
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(message);
                }
            };
            logMessage.Invoke(message);

            //2
            MathDelegate Del = MathOperation.Add;
            Del += MathOperation.Sub;
            Del += MathOperation.Div;
            Del += MathOperation.Mul;

            foreach (var item in Del.GetInvocationList())
            {
                Console.WriteLine(item.Method.Invoke(null, new object[2] { 2.4m, 1.2m }));
            }

            //3
            List<Book> books = new List<Book>
            {
            new Book { Title = "Book1", Author = "Author1", ISBN = "1234", Publisher = "Publisher1",
                Genre = Book.Genres.RomCom, NumberOfPages = 200, IsAvailable= true, Price = 12.0m },
            new Book {Title = "Book2", Author = "A", ISBN = "1234567891011", Publisher = "Publisher2",
                Genre = Book.Genres.Fiction, NumberOfPages = 0, IsAvailable = false, Price = 13.5m  },
            new Book {  Title = "Book3", Author = "Author3", ISBN = "1234567891011", Publisher = "Publisher1",
                Genre = Book.Genres.Mystery, NumberOfPages = 300, IsAvailable= true, Price = 15.5m }
            };

            Predicate<Book> TitleVal = (b) => b.Title.Length > 1 && b.Title.Length < 255;
            Predicate<Book> AuthorVal = (b) => b.Author.Length > 3 && b.Author.Length < 128;
            Predicate<Book> ISBNVal = (b) => b.ISBN.Length == 13;
            Predicate<Book> PublisherVal = (b) => b.Publisher.Length > 2 && b.Author.Length < 64;
            Predicate<Book> PagesVal = (b) => b.NumberOfPages > 0;
            Predicate<Book> PriceVal = (b) => b.Price > 0;
            int count = 1;
            foreach (Book book in books)
            {
                Console.WriteLine("For book " + count);
                if (!TitleVal(book))
                {
                    Console.WriteLine("Title of the book is invalid");
                }
                if (!AuthorVal(book))
                {
                    Console.WriteLine("Author of the book is invalid");
                }
                if (!ISBNVal(book))
                {
                    Console.WriteLine("ISBN of the book is invalid");
                }
                if (!PublisherVal(book))
                {
                    Console.WriteLine("Publisher of the book is invalid");
                }
                if (!PagesVal(book))
                {
                    Console.WriteLine("numbr of  pages of the book is invalid");
                }
                if (!PriceVal(book))
                {
                    Console.WriteLine("Price of the book is invalid");
                }
                count++;
            }

            //4
            //var filtered = books.Where(b => b.Genre == Book.Genres.RomCom);
            //foreach(var item in filtered)
            //{
            //    Console.WriteLine(item.Title + "is a RomCom");
            //}


            //Func<Book, BookDto> transform = (b) => new BookDto {Title = b.Title, Author = b.Author, Genre = b.Genre,
            //    IsAvailable = b.IsAvailable, Price = b.Price };

            DataPipline<Book> pipline = new DataPipline<Book>();
            var result = pipline.Process(books);
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Title},{ item.Author},{item.Genre}, {item.IsAvailable}, {item.Price} ");
            }
        }
    }
}