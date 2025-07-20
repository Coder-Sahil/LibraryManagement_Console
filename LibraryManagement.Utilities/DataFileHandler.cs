using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement.Utilities
{
    public class DataFileHandler
    {
        public DataFileHandler() { }

        public bool SaveBookDetails(List<Book> books, bool isPrint = false)
        {
            bool IsBookSave = false;
            List<Book> Books = new List<Book>();
            try
            {
                //if (books.Count() > 0)
                {
                    // Serialize the object to JSON
                    string jsonString = JsonSerializer.Serialize(books);

                    // Write JSON to a file
                    File.WriteAllText("Books.json", jsonString);

                    if (isPrint)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Books Added Successfully!");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    
                    IsBookSave = true;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error Occur in Library Management System");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            return IsBookSave;
        }

        public List<Book> GetBookDetails(bool isPrint=true)
        {
            bool IsBookSave = false;
            List<Book> Books = new List<Book>();
            try
            {
                // Read JSON from a file
                string jsonString = File.ReadAllText("Books.json");

                // Deserialize JSON into a dynamic object
                if (!string.IsNullOrEmpty(jsonString))
                {
                    Books = JsonSerializer.Deserialize<List<Book>>(jsonString);
                    if (isPrint)
                    {
                        foreach (var book in Books)
                        {
                            if(!string.IsNullOrEmpty(book.CheckedOutBy) && book.IsCheckedOut == false)
                                Console.Write($" Title : {book.Title} , Author : {book.Author} , Last CheckedOutBy : {book.CheckedOutBy} ,  IsCheckedOut : {book.IsCheckedOut} ");
                            else
                                Console.Write($" Title : {book.Title} , Author : {book.Author} , CheckedOutBy : {book.CheckedOutBy} ,  IsCheckedOut : {book.IsCheckedOut} ");
                            Console.WriteLine();
                        }
                    }
                    if (Books != null && Books.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("No Books Available or File Missing!");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                }
                else {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("No Books Available or File Missing!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occur in Library Management System");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            return Books;
        }

    }
}
