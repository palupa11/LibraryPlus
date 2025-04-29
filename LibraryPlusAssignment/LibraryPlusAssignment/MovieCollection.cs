using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class MovieCollection
    {
        private Movie [] collection;
        private int movieTitle;
        public static int collectionSize = 0;

        public int MovieTitle { get { return movieTitle; }  set { movieTitle = value; } }
        //Constructor
        public MovieCollection()
        {
            collection = new Movie[1000];
        }

        public void Insert(string movieTitle, Movie movie)
        {
            int sum = 0;
            foreach (char c in movieTitle)
            {
                sum = sum + (int)c;
            }

            int index = DivisionHashing(sum);
            collection[index] = movie;
            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i] == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("This is the movie title" + collection[i].Title);
                 
                }
            }
            collectionSize++;   


        }

        public Movie? Search(string movieTitle)
        {
            int sum = 0;
            foreach (char c in movieTitle)
            {
                sum = sum + (int)c;
            }
            int index = DivisionHashing(sum);


            Movie movie = collection[index];
            //Check if the movie is null
            if (movie == null)
            {
                return null;
            }
            //Check if the movie title matches
            if (movie.Title != movieTitle)
            {
                return null;
            }
            return movie;

        }

        
        //public static Movie GetMovie(int index)
        //{
        //    return collection[index];
        //}
        public int DivisionHashing(int sum)
        {
            int M = 101;
            int modulus = sum % M;
            Console.WriteLine("This is the sum" + sum);
            Console.WriteLine("This is mod" + modulus);
            return modulus;

        }



    }
}
