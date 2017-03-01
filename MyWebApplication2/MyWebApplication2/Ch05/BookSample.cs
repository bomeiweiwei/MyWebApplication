using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication2.Ch05
{
    public class BookSample
    {
        public BookSample()
        { }

        public String ISBN { get; set; }
        public String Title { get; set; }

        public static List<BookSample> BookList()
        {
            List<BookSample> myBookList = new List<BookSample>();

            myBookList.Add(new BookSample { ISBN = "978989789654", Title = "XXXXXXX" });
            myBookList.Add(new BookSample { ISBN = "978989666654", Title = "QQQQQQQ" });

            return myBookList;
        }
    }
}