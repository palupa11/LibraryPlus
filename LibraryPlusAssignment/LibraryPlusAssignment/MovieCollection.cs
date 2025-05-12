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
            if (movie == null)
            {
                Console.WriteLine("Movie is null");
                return;
            }

            int sum = FoldingHashing(movieTitle);
            int index = DivisionHashing(sum);
            Console.WriteLine("This is the index after division hashing " + index);
            bool isFound = searchByIndex(index);
            if (isFound)
            {
                int newIndex = collisionStrategy(index);
                collection[newIndex] = movie;
                keys[KeyIndex] = movieTitle;
                KeyIndex++;
                Console.WriteLine("Movie inserted here: " + collection[newIndex]);
                Console.ReadKey();

            }
            else
            {

                collection[index] = movie;
                keys[KeyIndex] = movieTitle;
                KeyIndex++;
                Console.WriteLine("Movie inserted here: " + collection[index]);
                Console.ReadKey();
            }
        }



        public bool searchByIndex(int index)
        {
            Movie movie = collection[index];
            if (movie == null)
            {
                return false;
            }
            return true;


        }

        public int collisionStrategy(int index)
        {
            Console.WriteLine("Entering collision strategy");

            int count = 1;
            while (true)
            {
                int position = index + count;
                bool isFound = searchByIndex(position);
                if (!isFound)
                {
                    Console.WriteLine("New index position");
                    return position;
                }

                count++;
                count = count * count;


            }


        }

        public Movie? Search(string movieTitle)
        {
            //int sum = 0;
            //foreach (char c in movieTitle)
            //{
            //    sum = sum + (int)c;
            //}
            int sum = FoldingHashing(movieTitle);
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
            int M = 1000;
            int modulus = sum % M;
            // Console.WriteLine("This is the sum" + sum);
            // Console.WriteLine("This is mod" + modulus);
            return modulus;

        }

        public int FoldingHashing(string title)
        {
            int sum = 0;
            //If it is an odd number 
            if (title.Length % 2 != 0)
                title += " ";


            for (int i = 0; i < title.Length; i = i + 2)
            {
                int group = (int)title[i] * 256 + (int)title[i + 1];
                sum += group;

            }
            Console.WriteLine("FoldingHashing function sum :" + sum);

            return sum;

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



    }
}
