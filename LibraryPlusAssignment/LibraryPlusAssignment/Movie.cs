using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class Movie
    {
        //Data fields
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Classification { get; set; }
        public string Duration { get; set; }
        public int Copies { get; set; }

        public int RentCount { get; set; }

       public Movie(string title, string genre, string classification, string duration, int copies)
        {
            Title = title;
            Genre = genre;
            Classification = classification;
            Duration = duration;
            Copies = copies;
            RentCount = 0;
            
        }

        //Constructor overload for testing
        public Movie(string title, string genre, string classification, string duration, int copies, int rentCount)
        {
            Title = title;
            Genre = genre;
            Classification = classification;
            Duration = duration;
            Copies = copies;
            RentCount = rentCount;

        }


    }
}
