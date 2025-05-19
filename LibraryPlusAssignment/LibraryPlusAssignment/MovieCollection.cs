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
        public const int COLLECTION_SIZE = 5;
        private MovieCollection()
        {
            collection = new Movie[COLLECTION_SIZE];
            keys = new string[COLLECTION_SIZE];
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
            int M = COLLECTION_SIZE;
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

        // public void DisplayTopThree()
        // {
        //     string[] sortedKeys = new string[keys.Length];
        //     Array.Copy(keys, 0, sortedKeys, 0, keys.Length);
        //     MergeSort(sortedKeys);

        //     for (int i = 0;  i < sortedKeys.Length; i++)
        //     {
        //         Movie movie = Search(sortedKeys[i]);
        //         Console.WriteLine(movie.Title); 
        //         Console.WriteLine(movie.RentCount); 
        //     }
        //     int milliseconds = 4000;
        //     Thread.Sleep(milliseconds);


        // }


        // //j = keys.Length();
        // public void MergeSort(string[] keys)
        // {
        //     int i = 0; 
        //     int j = keys.Length;
        //     if (i < j) 
        //     { 
        //         int m = Convert.ToInt32((i + j) / 2);
        //         string[] leftArray = keys[i..m];
        //         string[] rightArray = keys[(m+1)..j];
        //         MergeSort(leftArray);
        //         MergeSort(rightArray);
        //         Merge(keys, m);
                
        //     }
            
        //     // m = (i + j/2).Convert.ToInt32()
        //     // MergeSort(i,m)
        //     //MergeSort(m+1, j)
        //     //Merge ----


        // }
        // public void Merge(string[] keys, int m) 
        // { 
        //     int leftstart = 0;
        //     int rightstart = m + 1;
        //     int tempIndex = 0;
        //     Movie [] tempArray = new Movie[keys.Length]; 
        //     Console.WriteLine("Keys array length: " + keys.Length);
        //     while (leftstart <= m && rightstart < keys.Length)
        //     {
        //         Console.WriteLine("RightStart: " + rightstart);
        //         Movie leftMovie = Search(keys[leftstart]);
        //         Movie rightMovie = Search(keys[rightstart]);

        //         if (leftMovie.RentCount <= rightMovie.RentCount)
        //         {
             
        //             tempArray[tempIndex] = leftMovie;
        //             leftstart++;
        //             tempIndex++;

        //         }
        //         else
        //         {
        //             tempArray[tempIndex] = rightMovie;
        //             rightstart++;
        //             tempIndex++;

                    
        //         }


        //     }
        //     if (leftstart <= m)
        //     {
        //         for (int i = leftstart; i <= m; i++)
        //         {
        //             Console.WriteLine("Left Remaining");
        //             Movie movie = Search(keys[leftstart]);
        //             tempArray[tempIndex] = movie;
        //             tempIndex++;
        //             leftstart++;
        //         }  

        //     }
        //     if(rightstart < keys.Length)
        //     {
        //         for(int i = rightstart; i < keys.Length; i++)
        //         {
        //             Console.WriteLine("Right remaining");
        //             Movie movie = Search(keys[rightstart]);
        //             tempArray[tempIndex] = movie;
        //             tempIndex++;
        //             rightstart++;
        //         }
        //     }


        //     for (int i = rightstart; i < tempArray.Length; i++)
        //     {
        //         keys[i] = tempArray[i].Title;
        //     }


        // }


    }
}
