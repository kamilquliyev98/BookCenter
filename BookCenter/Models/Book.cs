using System;
using System.Collections.Generic;
using System.Text;

namespace BookCenter.Models
{
    class Book
    {
        private static int _counter = 0;
        public string Code { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }

        public Book(string name, string authorName, int pageCount)
        {
            _counter++;

            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
            Code = name.ToUpper().Substring(0, 2) + _counter;
        }
    }
}
