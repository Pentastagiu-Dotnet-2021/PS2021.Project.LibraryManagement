using System;

namespace Project.LibraryManagement.Services.Dtos
{
   public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }
        //public Uri ImageUri { get; set; }
    }
}
