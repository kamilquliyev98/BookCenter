using BookCenter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookCenter.Services
{
    class Library
    {
        public List<Book> Books { get; set; }

        public List<Book> FindAllBooksByName(string value)
        {
            return Books.FindAll(n => n.Name.ToUpper().Contains(value.ToUpper()));
        }

        public void RemoveAllBooksByName(string value)
        {
            Books.RemoveAll(n => n.Name.ToUpper().Contains(value.ToUpper()));
        }

        public List<Book> SearchBooks(string value)
        {
            return Books.FindAll(n => n.Name.ToUpper().Contains(value.ToUpper()) || n.AuthorName.ToUpper().Contains(value.ToUpper()) || n.PageCount.ToString().ToUpper().Contains(value.ToUpper()));
        }

        public List<Book> FindAllBooksByPageCountRange(int min, int max)
        {
            return Books.FindAll(n => n.PageCount >= min && n.PageCount <= max);
        }

        public void RemoveByNo(string value)
        {
            foreach (Book item in Books)
            {
                if (item.Code.ToUpper() == value.ToUpper())
                {

                }
            }
            Books.Remove()
        }
    }
}
