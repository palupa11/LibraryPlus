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
        private int KeyIndex = 0;
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
            keys[KeyIndex] = movieTitle;
            KeyIndex++;
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
            keys[KeyIndex] = null;
            KeyIndex--;

            
        }

        public void DisplayMovieInfo()
        {
            for (int i = 0; i < KeyIndex; i++)
            {
                if (keys[i] != null)
                {
                    Console.WriteLine("Title: " + keys[i]);
                }
            }
            Console.WriteLine("===================================================================================");
            Console.WriteLine("Total number of movies in the system: ", Convert.ToString(KeyIndex + 1));
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
        }

        
        public int DivisionHashing(int sum)
        {
            int M = 101;
            int modulus = sum % M;
            // Console.WriteLine("This is the sum" + sum);
            // Console.WriteLine("This is mod" + modulus);
            return modulus;

        }

        public void DisplayMovieByTitle(string title)
        {
            Movie? movie = Search(title);
            if (movie == null)
            {
                Console.WriteLine("Movie not found");
                 int milliseconds = 3000;
                 Thread.Sleep(milliseconds);
            }
            else
            {
                Console.WriteLine("Titles: " + movie?.Title);
                Console.WriteLine("Genre: " + movie?.Genre);
                Console.WriteLine("Classification: " + movie?.Classification);
                Console.WriteLine("Duration: " + movie?.Duration);
                Console.WriteLine("Copies: " + movie?.Copies);
                int milliseconds = 4000;
                Thread.Sleep(milliseconds);

            }

        }

        public void DisplayTop3Movies(MovieCollection collection)
        {
            for (int i = 0; i < KeyIndex; i++)
            {
                if (keys[i] != null)
                {
                    Movie? movie = Search(keys[i]);
                    if (movie == null)
                    {
                        Console.WriteLine("Movie title: " + movie.Title + " and rent count " + movie.RentCount);
                        int milliseconds = 4000;
                        Thread.Sleep(milliseconds);
                    }
                }
            }
        }



    }
}
