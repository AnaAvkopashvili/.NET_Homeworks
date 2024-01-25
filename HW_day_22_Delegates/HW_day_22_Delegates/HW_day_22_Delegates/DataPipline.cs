using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_day_22_Delegates
{
    public delegate List<Book> FilterDelegates(List<Book> books);
    public delegate List<BookDto> TransformDelegates(List<Book> book);
    public class DataPipline<T>
    {
        public static List<Book> FilterBooksByPages(List<Book> books)
        {
            return books.Where(b => b.IsAvailable == true).ToList();
        }
        public static List<BookDto> TransformedBooks(List<Book> books)
        {
            List<BookDto> transformedBooks = books.Select(b => new BookDto
            {
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre,
                IsAvailable = b.IsAvailable,
                Price = b.Price
            }).ToList();

            return transformedBooks;
        }

        FilterDelegates filtered = DataPipline<Book>.FilterBooksByPages;
        TransformDelegates transform = DataPipline<Book>.TransformedBooks;
        public List<BookDto> Process(List<Book> input)
        {
            List<Book> filteredBooks = filtered.Invoke(input);
            List<BookDto> transformedBooks = transform.Invoke(filteredBooks);
              
            return transformedBooks;
        }

    }
}
