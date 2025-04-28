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
        private string title;
        private string genre;
        private string classification;
        private string duration;
        private int copies;
        

        //Properties
        public string Title { get { return title; } set { title = value; } }
        public string Genre { get { return genre; } set { genre = value; } }

        public string Classification { get { return classification; } set { classification = value; } }

        public string Duration { get { return duration; } set { duration = value; } }

        public int Copies { get { return copies; } set { copies = value; } }

       public Movie(string title, string genre, string classification, string duration, int copies)
        {
            Title = title;
            Genre = genre;
            Classification = classification;
            Duration = duration;
            Copies = copies;
            
        }
    }
}
