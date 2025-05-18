using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public const int COLLECTION_SIZE = 1000;
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

        public void DisplayTopThree()
        {
            string[] sortedKeys = new string[KeyIndex]; //the size of the actual movies we have added to the array
            Array.Copy(keys, 0, sortedKeys, 0, KeyIndex);
            MergeSort(sortedKeys, 0, sortedKeys.Length - 1);

            for (int i = 0;  i < sortedKeys.Length; i++)
            {
                Movie movie = Search(sortedKeys[i]);
                Console.WriteLine(movie.Title); 
                Console.WriteLine(movie.RentCount); 
            }
            int milliseconds = 4000;
            Thread.Sleep(milliseconds);


        }


        //j = keys.Length();
        public void MergeSort(string[] keys, int i, int j)
        {
            //int i = 0; 
            //int j = keys.Length;
            if (i < j) 
            { 
                int m = Convert.ToInt32((i + j) / 2);
                //string[] leftArray = keys[i..m];
                //string[] rightArray = keys[(m+1)..j];
                //MergeSort(leftArray);
                //MergeSort(rightArray);
                //Merge(keys, m);
                MergeSort(keys, i, m);
                MergeSort(keys, m + 1, j);
                Merge(keys,i,m,j);
                
            }
            
            // m = (i + j/2).Convert.ToInt32()
            // MergeSort(i,m)
            //MergeSort(m+1, j)
            //Merge ----


        }
        public void Merge(string[] keys, int i, int m, int j) 
        { 
            int leftstart = i;   
            int rightstart = m + 1;
            int tempIndex = 0;
            Movie [] tempArray = new Movie[j - i + 1]; // Only working with that subsection of the array
            Console.WriteLine("Keys array length: " + keys.Length);
            while (leftstart <= m && rightstart <= j)
            {
                Console.WriteLine("RightStart: " + rightstart);
                Movie leftMovie = Search(keys[leftstart]);
                Movie rightMovie = Search(keys[rightstart]);

                if (leftMovie != null && rightMovie != null)
                {
                    if (leftMovie.RentCount <= rightMovie.RentCount) //Increasing order, lowest to highest rented movie
                    {

                        tempArray[tempIndex] = leftMovie;
                        leftstart++;
                        tempIndex++;

                    }
                    else
                    {
                        tempArray[tempIndex] = rightMovie;
                        rightstart++;
                        tempIndex++;
                    }
                }
                else if (leftMovie != null) //the movie on the right is null
                {
                    tempArray[tempIndex] = leftMovie; //add movie
                    leftstart++; //advance pointer to compare with the next movie
                    tempIndex++;   

                }

                else if (rightMovie != null)
                {
                    tempArray[tempIndex] = rightMovie;
                    rightstart++;
                    tempIndex++;
                }


            }
            if (leftstart <= m)
            {
                for (int h = leftstart; h <= m; h++)
                {
                    Console.WriteLine("Left Remaining");
                    Movie movie = Search(keys[h]);
                    if (movie != null)
                    {
                        tempArray[tempIndex] = movie;
                        tempIndex++;

                    }
                }  

            }
            if(rightstart <= j)
            {
                for(int h = rightstart; h <= j; h++)
                {
                    Console.WriteLine("Right remaining");
                    Movie movie = Search(keys[h]);
                    if (movie != null)
                    {
                        tempArray[tempIndex] = movie;
                        tempIndex++;

                    }
                   
                }
            }


            for (int h = 0; h < tempArray.Length; h++)
            {
                //keys[i] = tempArray[i].Title;   This was copying in the same position
                keys[i + h] = tempArray[h].Title;
            }


        }


    }
}
