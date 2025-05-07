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

        //Constructor

        public Member(string firstName, string lastName, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Password = password;
            rentedMovies = new string[5]; // Initialize the array with a size of 10       

        }
        public String GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public void BorrowMovie(string movieTitle)
        {
            if (BorrowedCount < 5)
            {
                MovieCollection movieCollection = MovieCollection.GetInstance();
                Movie? movie = movieCollection.Search(movieTitle);
                if (movie != null)
                {
                    movie.Copies--;
                    rentedMovies[BorrowedCount] = movieTitle;
                    BorrowedCount++;
                    Console.WriteLine("Movie borrowed successfully.");
                }
                else
                {
                    Console.WriteLine("Movie not found.");
                }


                Console.WriteLine("Movie borrowed successfully.");
            }
            else
            {
                Console.WriteLine("You have reached the maximum number of borrowed movies.");
            }
        }
        
    }
}
