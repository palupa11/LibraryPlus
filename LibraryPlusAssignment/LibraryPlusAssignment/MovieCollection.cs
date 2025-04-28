using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class MovieCollection
    {
        private Movie [] collection = new Movie[1000];
        private int movieTitle;

        //Properties 

        public Movie Collection(int index)
        {
            return collection[index];
        }
        public int MovieTitle { get { return movieTitle; }  set { movieTitle = value; } }


        // We need a key, table (array)

        //Methods
        //

        //public void Insert(int key)
        //{


        //}

        public void Insert(string movieTitle, Movie movie)
        {
            int sum = 0;
            foreach (char c in movieTitle)
            {
                sum = sum + (int)c;
            }

            int index = DivisionHashing(sum);
            collection[index] = movie;


        }

        public int Search(string movieTitle)
        {
            int sum = 0;
            foreach (char c in movieTitle)
            {
                sum = sum + (int)c;
            }
            int index = DivisionHashing(sum);
            Movie movie = collection[index];
            if (movie.Title != movieTitle)
            {
                return -1;

            }
            else if(movie == null)
            {
                return -1;
            }
            return index;

        }



        public int DivisionHashing(int sum)
        {
            int M = 101;
            int modulus = sum % M;
            Console.WriteLine("This is the sum" + sum);
            Console.WriteLine("This is mod" + modulus);
            return modulus;

        }

        //Insert, search, delete



    }
}
