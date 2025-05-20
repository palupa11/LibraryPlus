using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class Member
    {
        //Data fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string[] rentedMovies; // Array to store borrowed movies
        public int BorrowedCount { get; set; } = 0; // Counter for borrowed movies
        public int BorrowLimit {get; set; } = 5;
        //Constructor

        public Member(string firstName, string lastName, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Password = password;
            rentedMovies = new string[BorrowLimit]; // Initialize the array with a size of 10       

        }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public void BorrowMovie(string movieTitle)
        {
            int milliseconds = 3000;
            if (BorrowedCount < 5)
            {
                MovieCollection movieCollection = MovieCollection.GetInstance();
                Movie? movie = movieCollection.Search(movieTitle);
                if (movie != null)
                {
                    movie.Copies--;
                    rentedMovies[BorrowedCount] = movieTitle;
                    BorrowedCount++;
                    movie.RentCount++;
                    Console.WriteLine("Movie borrowed successfully.");
                    Thread.Sleep(milliseconds);
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                    Thread.Sleep(milliseconds);
                }

            }
            else
            {
                Console.WriteLine("You have reached the maximum number of borrowed movies.");
                Thread.Sleep(milliseconds);
            }
        }

        public void ReturnMovie(string movieTitle)
        {
            for (int i = 0; i <= BorrowedCount; i++)
            {
                if (rentedMovies[i] == movieTitle)
                {
                    rentedMovies[i] = "";
                    BorrowedCount--;
                    MovieCollection movieCollection = MovieCollection.GetInstance();
                    Movie? movie = movieCollection.Search(movieTitle);
                    movie.Copies++;
                    Console.WriteLine("Movie returned successfully");
                    Console.ReadKey();
                    return;
                }


            }
            Console.WriteLine("You are currently not renting that movie");
            Console.ReadKey();

        }
        public void ListBorrowedMovies()
        {
            Console.WriteLine("***List of Currently Borrowed movies***");
            for (int i = 0; i < BorrowLimit; i++)
            {
                if (rentedMovies[i] != "" || rentedMovies[i] != null)
                {
                    Console.WriteLine(rentedMovies[i]);
                }
                
            }
            Console.ReadKey();

        }

        public void DisplayTopThree(MovieCollection movieCollection)
        {
            string[] sortedMovies = movieCollection.SortByRentCount();
            Console.WriteLine("Top Three Movies: ");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(sortedMovies[i]);
            }
            Console.ReadKey();
        }


    }
}
