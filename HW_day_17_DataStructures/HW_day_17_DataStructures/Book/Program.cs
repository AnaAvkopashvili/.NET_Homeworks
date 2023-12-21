using System.Linq;

namespace Book
{
    public class Book
    {
        public enum Genre
        {
            Comedy,
            Romance,
            Action
        }
        public Book(string firstName, string lastName, int year, int isbn, Genre _genre) 
        { 
            FirstName = firstName;
            LastName = lastName;
            Year = year;
            ISBN = isbn;
            genre = _genre;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year {  get; set; }
        public int ISBN { get; set; }
        public Genre genre { get; set; }
        static void Main(string[] args)
        {
            List<Book> booksList = new List<Book>();
            booksList.Add(new Book("Ana", "Avkopashvili", 2004, 123, Genre.Romance));
            booksList.Add(new Book("Ninuca", "Avkopashvili", 2001, 456, Genre.Comedy));
            booksList.Add(new Book("Giorgi", "Avkopashvili", 1972, 789, Genre.Action));
            booksList.Add(new Book("Maia", "Muradashvili", 1973, 101, Genre.Romance));

            var ana = new Book("ana", "Avkopashvili", 2004, 123, Genre.Romance);

            booksList.Sort(new YearComparer());
            booksList.Sort(new ISBNComparer());
            Console.WriteLine(booksList.Contains(ana, new NameComparer()));

            foreach (var book in booksList)
                Console.WriteLine(book.FirstName);
        }

    }
}