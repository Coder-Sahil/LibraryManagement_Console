using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;
using LibraryManagement.Utilities;

namespace LibraryManagement.Business
{
    public class LibraryManager
    {
        private string _userInput = string.Empty;
        private bool _isSucces = false;
        private List<Book> _Books = new List<Book>();
        public LibraryManager() {

            _Books = new DataFileHandler().GetBookDetails(false);
        }

        public void StartLibrary()
        {
            try
            {
                
                while (_userInput != "7")
                {
                    MessageHandler.DisplayProjectHeader();
                    MessageHandler.ShowLibraryMenu();
                    Console.Write(" Choose Valid Option : ");
                    _userInput = Console.ReadLine();

                    switch (_userInput)
                    {
                        case "1":
                            _isSucces = AddBook();
                            if (_isSucces)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Book Successfully Added!");
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Press Any Key To Continue . . .");
                            Console.WriteLine("");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            _isSucces = RemoveBook();
                            if (_isSucces)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Book Successfully Removed!");
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Press Any Key To Continue . . .");
                            Console.WriteLine("");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "3":
                            _isSucces = SearchBook();
                            if (_isSucces)
                            {

                            }
                            Console.WriteLine("");
                            Console.WriteLine("Press Any Key To Continue . . .");
                            Console.WriteLine("");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "4":
                            _isSucces = CheckoutBook();
                            if (_isSucces)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Book Successfully Checkout!");
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Press Any Key To Continue . . .");
                            Console.WriteLine("");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "5":
                            _isSucces = ReturnBook();
                            if (_isSucces)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Book Successfully Return!");
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Press Any Key To Continue . . .");
                            Console.WriteLine("");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "6":
                            _isSucces = DisplayAllBook();
                            if (_isSucces)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("");
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Press Any Key To Continue . . .");
                            Console.WriteLine("");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "7":
                            Console.Clear();
                            MessageHandler.DisplayExitMessage();
                            break;
                        default:
                            Console.WriteLine("");
                            Console.WriteLine("Entered InValid Input!");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("Press Any Key To Continue . . .");
                            Console.WriteLine("");
                            Console.ReadKey();
                            Console.Clear();

                            break;
                    }

                
                }
            }
            catch(Exception ex) {
                Console.WriteLine("Error Occur in Library Management System");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }

        private bool AddBook()
        {
            _isSucces= false;
            Book book = new Book();

            try
            {

                Console.WriteLine("Enter Book Details");

                Console.Write("Book Title : ");
                book.Title = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Book Author : ");
                book.Author = Console.ReadLine();

                _Books.Add(book);
                _isSucces = new DataFileHandler().SaveBookDetails(_Books, false);
            }
            catch (Exception ex) { 

            }
            return _isSucces;
        }

        private bool RemoveBook()
        {
            _isSucces = false;
            string bookName = string.Empty;

            try
            {

                Console.WriteLine("Enter Book Details");

                Console.Write("Book Title : ");
                bookName = Console.ReadLine();

                var book = _Books.Find(x => x.Title.Contains(bookName));
                if (book != null)
                {
                    _Books.Remove(book);
                    _isSucces = new DataFileHandler().SaveBookDetails(_Books);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Book Not Found");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            catch (Exception ex)
            {

            }
            return _isSucces;
        }

        private bool SearchBook()
        {
            _isSucces = false;
            string bookName = string.Empty;

            try
            {

                Console.WriteLine("Enter Book Details");

                Console.Write("Book Title : ");
                bookName = Console.ReadLine();

                var book = _Books.Find(x => x.Title.Contains(bookName));
                if (book != null)
                {
                    _isSucces = true;
                    Console.Write($" Title : {book.Title} , Author : {book.Author} , CheckedOutBy : {book.CheckedOutBy} ,  IsCheckedOut : {book.IsCheckedOut} ");
                    //Console.WriteLine($" Title : {book.Title} ");
                    //Console.WriteLine($" Author : {book.Author} ");
                    //Console.WriteLine($" CheckedOutBy : {book.CheckedOutBy} ");
                    //Console.WriteLine($" IsCheckedOut : {book.IsCheckedOut} ");
                    Console.WriteLine("");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Book Not Found");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            catch (Exception ex)
            {

            }
            return _isSucces;
        }

        private bool DisplayAllBook()
        {
            _isSucces = false;
            string bookName = string.Empty;

            try
            {

                new DataFileHandler().GetBookDetails();
                _isSucces = true;
            }
            catch (Exception ex)
            {

            }
            return _isSucces;
        }

        private bool CheckoutBook()
        {
            _isSucces = false;
            Book book = new Book();

            try
            {

                Console.WriteLine("Enter Details");

                Console.Write("Book Title : ");
                string bookName = Console.ReadLine();

                book = _Books.Find(x => x.Title.Contains(bookName));

                if (book != null)
                {
                    Console.WriteLine("Book Checked Out By :");
                    book.CheckedOutBy = Console.ReadLine();
                    book.IsCheckedOut = true;
                    //_Books.Add(book);
                    _isSucces = new DataFileHandler().SaveBookDetails(_Books,false);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Book Not Found");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            catch (Exception ex)
            {

            }
            return _isSucces;
        }

        private bool ReturnBook()
        {
            _isSucces = false;
            Book book = new Book();

            try
            {

                Console.WriteLine("Enter Details");

                Console.WriteLine("Book Title");
                string bookName = Console.ReadLine();

                book = _Books.Find(x => x.Title.Contains(bookName));

                if (book != null)
                {
                    //book.CheckedOutBy = string.Empty;
                    book.IsCheckedOut = false;
                    //_Books.Add(book);
                    _isSucces = new DataFileHandler().SaveBookDetails(_Books, false);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Book Not Found");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            catch (Exception ex)
            {

            }
            return _isSucces;
        }

    }
}
