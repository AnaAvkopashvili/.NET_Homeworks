using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class ISBNComparer : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            return (int)(x.ISBN - y.ISBN);

        }
    }

    public class YearComparer : IComparer<Book>
    {
        public int Compare(Book? x, Book? y)
        {
            return (int)(x.Year - y.Year);
        }
    }
    public class NameComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book? x, Book? y)
        {
            return (x.FirstName).Equals(y.FirstName, StringComparison.OrdinalIgnoreCase);

        }

        public int GetHashCode(Book obj)
        {
            return obj.GetHashCode();
        }
    }

}
