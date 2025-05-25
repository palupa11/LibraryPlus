using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class MovieCollection
    {

        private static MovieCollection? instance; // singleton instance declaration
        private HashEntry<string, Movie>?[] collection;
        public int Movietitle { get; set; }
        private int movieCount = 0;
        public const int COLLECTION_SIZE = 1000;

        //Property for testing purposes only
        //public int BasicOperationCount { get; set; }  

        //private Constructor to prevent instantiation from outside the class
        private MovieCollection()
        {
            collection = new HashEntry<string, Movie>?[COLLECTION_SIZE];
        }

        //Singleton function
        public static MovieCollection GetInstance()
        {
            if (instance == null)
            {
                instance = new MovieCollection();
            }
            return instance;
        }
        //Hashing algorithms starts here
        public int FoldingHashing(string title)
        {
            int sum = 0;
            //If it is an odd number 
            if (title.Length % 2 != 0)
                title += " ";

            for (int i = 0; i < title.Length; i = i + 2)
            {
                int firstLetter = (int)title[i];
                int secondLetter = (int)title[i + 1];
                string pairedLetters = Convert.ToString(firstLetter) + Convert.ToString(secondLetter);
                int finalValue = Convert.ToInt32(pairedLetters);
                sum += finalValue;

            }
            return sum;
           
        }
        public int DivisionHashing(int sum)
        {
            int M = COLLECTION_SIZE;
            int modulus = sum % M;
            return modulus;

        }
        public HashEntry<string, Movie> CollisionStrategy(int index)
        {
            /* this function is for handling when two hash entries
            share the same index, using a separate chaining structure */
            
            HashEntry<string, Movie>? entry = collection[index];

            HashEntry<string, Movie>? current = entry;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current;

        }
        //hashing algorithm ends here
        public void Insert(string movieTitle, Movie movie)
        {
            int foldSum = FoldingHashing(movieTitle);
            int hashIndex = DivisionHashing(foldSum);
            HashEntry<string, Movie> movieEntry = new HashEntry<string, Movie>(movieTitle, movie);
            HashEntry<string, Movie>? entry = collection[hashIndex];

            if (entry == null)
            {
                collection[hashIndex] = movieEntry;
            }
            else
            {
                HashEntry<string, Movie> movieCheck = CollisionStrategy(hashIndex);
                movieCheck.Next = movieEntry;

            }
            movieCount++;

        }

        public Movie? Search(string movieTitle)
        {
            int foldSum = FoldingHashing(movieTitle);
            int hashIndex = DivisionHashing(foldSum);

            HashEntry<string, Movie>? current = collection[hashIndex];

            while (current != null)
            {
                if (current.Key == movieTitle)
                {
                    return current.Value;
                }
                current = current.Next;
            }

            return null; // Not found
        }


        public void Delete(string movieTitle)
        {
            int foldSum = FoldingHashing(movieTitle);
            int hashIndex = DivisionHashing(foldSum);

            collection[hashIndex] = null;
            movieCount--;


        }

        public void DisplayMovies()
        {
            Console.WriteLine("Title");
            Console.WriteLine("------");
            for (int i = 0; i < collection.Length; i++)
            {
                HashEntry<string, Movie>? current = collection[i];
                while (current != null)
                {
                    Console.WriteLine(current.Key);
                    current = current.Next;
                }
            }

            Console.WriteLine("=====================================================");
            Console.WriteLine("Total number of movies in the system: " + movieCount);
            Console.ReadKey();
        }

        public void DisplayMovieInfo(string title)
        {
            Movie? movie = Search(title);
            if (movie == null)
            {
                Console.WriteLine("Movie not found");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Titles\tGenre\tClassification\tDuration\tCopies:");
                Console.WriteLine(movie?.Title + "\t" + movie?.Genre + "\t" + movie?.Classification + "\t\t" + movie?.Duration + "\t\t" + movie?.Copies);
            }
            Console.ReadKey();

        }

        //sorting starts here
        public void MergeSort(string[] A, int initialIndex, int finalIndex)
        {
            if (initialIndex < finalIndex)
            {
                int midpoint = (initialIndex + finalIndex) / 2;
                MergeSort(A, initialIndex, midpoint);
                MergeSort(A, midpoint + 1, finalIndex);
                Merge(A, initialIndex, finalIndex, midpoint);


            }


        }

        public void Merge(string[] A, int initialIndex, int finalIndex, int mid)
        {
            int rightStart = mid + 1;
            int tempLength = finalIndex - initialIndex + 1;
            string[] temp = new string[tempLength];
            int leftStart = initialIndex;

            int tempIndex = 0;
            while (leftStart <= mid && rightStart <= finalIndex)
            {
                Movie? leftMovie = Search(A[leftStart]);
                Movie? rightMovie = Search(A[rightStart]);
                if (leftMovie.RentCount >= rightMovie.RentCount)
                {
                    //BasicOperationCount++;
                    temp[tempIndex] = A[leftStart];
                    leftStart++;
                }
                else
                {
                    temp[tempIndex] = A[rightStart];
                    rightStart++;
                }
                tempIndex++;
            }

            while (leftStart <= mid)
            {
                temp[tempIndex] = A[leftStart];
                tempIndex++;
                leftStart++;
            }
            while (rightStart <= finalIndex)
            {
                temp[tempIndex] = A[rightStart];
                tempIndex++;
                rightStart++;
            }
           
            for (int i = 0; i < tempLength; i++)
            {
                A[initialIndex + i] = temp[i];
            }
        }



        public string[] SortByRentCount()
        {
            string[] movieNames = new string[movieCount];
            //Testing
            //BasicOperationCount = 0;
            int j = 0;
            for (int i = 0; i < collection.Length; i++)
            {
                HashEntry<string, Movie>? current = collection[i];
                while (current != null)
                {
                    movieNames[j] = current.Key;
                    j++;
                    current = current.Next;
                }

            }

            MergeSort(movieNames, 0, movieNames.Length - 1);
            //Console.WriteLine($"Sorted {movieCount} movies with {BasicOperationCount} comparisons.");
            return movieNames;
        }






    }
}
