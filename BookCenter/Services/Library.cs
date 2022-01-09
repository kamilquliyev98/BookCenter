using BookCenter.Models;
using System;
using System.Collections.Generic;

namespace BookCenter.Services
{
    class Library
    {
        public List<Book> Books = new List<Book>(0);

        public void AddBook(string name, string authorName, int pageCount)
        {
            Books.Add(new Book(name,authorName,pageCount));
        }

        public void ShowAllBooks()
        {
            Console.WriteLine("------------------------------------------");
            foreach (Book book in Books)
            {
                Console.WriteLine(book);
                Console.WriteLine("------------------------------------------");
            }
        }

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
            Console.Clear();
            bool find = true;

            foreach (Book item in Books)
            {
                if (item.Code.ToUpper() == value.ToUpper())
                {
                    Books.Remove(item);
                    find = false;
                    Console.WriteLine($"{item.Code} nomreli kitab silindi...");
                    break;
                }
            }

            if (find)
            {
                Console.WriteLine("Daxil etdiyiniz nomrede kitab yoxdur...\n");
            }
        } // done
    }
}
