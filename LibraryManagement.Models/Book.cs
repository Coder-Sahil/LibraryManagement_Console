using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibraryManagement.Models
{
    public class Book
    {
        public Book() {
            this.Title = string.Empty;
            this.Author = string.Empty;
            this.CheckedOutBy = string.Empty;
            this.IsCheckedOut = false;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsCheckedOut { get; set; }
        public string CheckedOutBy { get; set; }
    }
}
