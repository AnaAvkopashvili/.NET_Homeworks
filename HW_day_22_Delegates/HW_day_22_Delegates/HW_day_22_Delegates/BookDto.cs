using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HW_day_22_Delegates.Book;

namespace HW_day_22_Delegates
{
    public class BookDto
    {
        public string Title { get; set; }

        public string Author { get; set; }
        public Genres Genre { get; set; }
        public bool IsAvailable { get; set; }

        public decimal? Price { get; set; }
    }
}
