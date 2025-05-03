using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class MovieCollection
    {

        private static MovieCollection? instance; // singleton instance declaration
        private Movie[] collection;
        private string[] keys;
        public int Movietitle { get; set; }
        //private Constructor to prevent instantiation from outside the class
        private MovieCollection()
        {
            collection = new Movie[1000];
            keys = new string[1000];
        }

        public static MovieCollection GetInstance()
        {
            if (instance == null)
            {
                instance = new MovieCollection();
            }
            return instance;
        }

        public void Insert(string movieTitle, Movie movie)
        {   
            if(movie == null) {
                Console.WriteLine("Movie is null");
                return;
            }
            int sum = 0;
            foreach (char c in movieTitle)
            {
                sum = sum + (int)c;
            }

            int index = DivisionHashing(sum);
            collection[index] = movie;
            keys[index] = movieTitle;
            Console.WriteLine(collection[index]);
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

        public void Delete(string movieTitle)
        {
            int sum = 0;
            foreach (char c in movieTitle)
            {
                sum = sum + (int)c;
            }
            int index = DivisionHashing(sum);
            collection[index] = null;
            keys[index] = null;

            
        }

        public void DisplayAllKeys()
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] != null)
                {
                    Console.WriteLine("Key: " + keys[i]);
                }
            }
        }

        
        public int DivisionHashing(int sum)
        {
            int M = 101;
            int modulus = sum % M;
            // Console.WriteLine("This is the sum" + sum);
            // Console.WriteLine("This is mod" + modulus);
            return modulus;

        }



    }
}
