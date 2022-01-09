using System;
using System.Collections.Generic;
using BookCenter.Models;
using BookCenter.Services;

namespace BookCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();

            do
            {
                Console.WriteLine("---------------------------Book Center---------------------------");
                Console.WriteLine("Etmek istediyniz emeliyyatin qarsisindaki nomreni daxil edin:\n");
                Console.WriteLine("1 - Butun kitablarin siyahisini goster");
                Console.WriteLine("2 - Adina gore kitablar axtar");
                Console.WriteLine("3 - Adina gore kitablari sil");
                Console.WriteLine("4 - Kitab axtar (adina, muellif adina ve ya sehife sayina gore)");
                Console.WriteLine("5 - Min ve max sehife sayina gore kitablar axtar");
                Console.WriteLine("6 - Nomresini daxil ederek kitabi sil");
                Console.WriteLine("7 - Kitab elave et");
                Console.Write("\nDaxil Et: ");

                string select = Console.ReadLine();
                int selectNum;
                int.TryParse(select, out selectNum);

                switch (selectNum)
                {
                    case 1:
                        Console.Clear();
                        ShowAllBooks(ref lib);
                        break;
                    case 2:
                        Console.Clear();
                        FindAllBooksByName(ref lib);
                        break;
                    case 3:
                        Console.Clear();
                        RemoveAllBooksByName(ref lib);
                        break;
                    case 4:
                        Console.Clear();
                        SearchBooks(ref lib);
                        break;
                    case 5:
                        Console.Clear();
                        FindAllBooksByPageCountRange(ref lib);
                        break;
                    case 6:
                        Console.Clear();
                        RemoveByNo(ref lib);
                        break;
                    case 7:
                        Console.Clear();
                        AddBook(ref lib);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nomreni duzgun daxil edin...\n");
                        break;
                }
            } while (true);
        }

        static void FindAllBooksByPageCountRange(ref Library lib)
        {
            if (lib.Books.Count <= 0)
            {
                Console.WriteLine("Bazada kitab movcud deyil...\n");
                return;
            }

            Console.WriteLine("Min ve max sehife sayini daxil ederek kitablari axtar:");
        reEnterMin:
            Console.WriteLine("\nMin sehife sayi:");
            Console.Write("=> ");
            string minPageStr = Console.ReadLine();
            int minPage;
            if (!int.TryParse(minPageStr, out minPage) || minPage < 0)
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterMin;
            }

        reEnterMax:
            Console.WriteLine("\nMax sehife sayi:");
            Console.Write("=> ");
            string maxPageStr = Console.ReadLine();
            int maxPage;
            if (!int.TryParse(maxPageStr, out maxPage) || maxPage < 0)
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterMax;
            }

            if (minPage > maxPage)
            {
                Console.WriteLine("\nMin sehife sayi max sehife sayindan boyuk ola bilmez...");
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterMin;
            }

            Console.Clear();
            Console.WriteLine($"{minPage} ve {maxPage} araligi sehife sayi olan kitablar:");
            List<Book> Books = new List<Book>(lib.Books.FindAll(n => n.PageCount >= minPage && n.PageCount <= maxPage));

            if (Books.Count <= 0)
            {
                Console.WriteLine($"{minPage} ve {maxPage} araligi sehife sayi olan kitab yoxdur...\n");
                return;
            }

            Console.WriteLine("------------------------------------------");
            foreach (Book item in Books)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------------");
            }

            lib.FindAllBooksByPageCountRange(minPage, maxPage);
        }

        static void RemoveByNo(ref Library lib)
        {
            if (lib.Books.Count <= 0)
            {
                Console.WriteLine("Bazada kitab movcud deyil...\n");
                return;
            }

            Console.WriteLine("------------------------------------------");
            foreach (Book book in lib.Books)
            {
                Console.WriteLine(book);
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine("Silmek istediyiniz kitabin nomresini daxil edin:");
        reEnterBookNo:
            string bookNo = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(bookNo) || bookNo.Length < 3)
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterBookNo;
            }

            lib.RemoveByNo(bookNo);
        }

        static void ShowAllBooks(ref Library lib)
        {
            if (lib.Books.Count <= 0)
            {
                Console.WriteLine("Bazada kitab movcud deyil...\n");
                return;
            }

            Console.WriteLine("Butun kitablarin siyahisi:\n");
            
            lib.ShowAllBooks();
        } // done

        static void SearchBooks(ref Library lib)
        {
            if (lib.Books.Count <= 0)
            {
                Console.WriteLine("Bazada kitab movcud deyil...\n");
                return;
            }

            Console.WriteLine("Adina, muellif adina ve ya sehife sayina gore kitab axtarisi:");
        reEnterValue:
            Console.Write("=> ");
            string value = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterValue;
            }

            List<Book> Books = new List<Book>(lib.Books.FindAll(n => n.Name.ToUpper().Contains(value.ToUpper()) || n.AuthorName.ToUpper().Contains(value.ToUpper()) || n.PageCount.ToString().ToUpper().Contains(value.ToUpper())));
            Console.WriteLine("------------------------------------------");
            foreach (Book item in Books)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------------");
            }
            lib.SearchBooks(value);
        } // done

        static void AddBook(ref Library lib)
        {
            Console.WriteLine("Elave etmek istediyiniz kitabin adini daxil edin:");
        reEnterBookName:
            Console.Write("=> ");
            string bookName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(bookName))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterBookName;
            }

            Console.WriteLine("\nMuellifin adini daxil edin:");
        reEnterAuthorName:
            Console.Write("=> ");
            string authorName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(bookName))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterAuthorName;
            }

            Console.WriteLine("\nSehife sayini daxil edin:");
        reEnterPageCount:
            Console.Write("=> ");
            string pageCountStr = Console.ReadLine();
            int pageCount;
            if (!int.TryParse(pageCountStr, out pageCount) || pageCount <= 0)
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterPageCount;
            }

            Console.Clear();
            Console.WriteLine("Kitab elave olundu...\n");

            lib.AddBook(bookName, authorName, pageCount);
        } // done

        static void FindAllBooksByName(ref Library lib)
        {
            if (lib.Books.Count <= 0)
            {
                Console.WriteLine("Bazada kitab movcud deyil...\n");
                return;
            }

            Console.WriteLine("Axtarmaq istediyiniz kitabin adini daxil edin:");
        reEnterBookName:
            Console.Write("=> ");
            string bookName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(bookName))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterBookName;
            }

            List<Book> Books = new List<Book>(lib.Books.FindAll(n => n.Name.ToUpper().Contains(bookName.ToUpper())));
            Console.WriteLine("------------------------------------------");
            foreach (Book item in Books)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------------");
            }

            lib.FindAllBooksByName(bookName);
        } // done

        static void RemoveAllBooksByName(ref Library lib)
        {
            if (lib.Books.Count <= 0)
            {
                Console.WriteLine("Bazada kitab movcud deyil...\n");
                return;
            }

            Console.WriteLine("Silmek istediyiniz kitabin adini daxil edin:");
        reEnterBookName:
            Console.Write("=> ");
            string bookName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(bookName))
            {
                Console.WriteLine("Duzgun daxil edin:");
                goto reEnterBookName;
            }

            Console.Clear();
            Console.WriteLine("Kitab silindi...\n");

            lib.RemoveAllBooksByName(bookName);
        } // done
    }
}
