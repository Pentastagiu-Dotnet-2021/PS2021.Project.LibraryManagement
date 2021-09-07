using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.LibraryManagement.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public string Language { get; set; }

        //private string _image;
        //public string Image { set { _image = value; } }
        //public Uri ImageUri
        //{
        //    get { return new Uri(_image); }
        //}
    }
}
