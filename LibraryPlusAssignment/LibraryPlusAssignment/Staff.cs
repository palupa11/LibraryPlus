using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class Staff
    {
        //Data fields
        public string Username { get; set; }
        public string Password { get; set; }
        
    
        //Constructor
        public Staff(string username, string password)
        {
            Username = username;
            Password = password;
        }

        
        public void AddMovie()
        {   Console.WriteLine("Add DVD to the system");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            string genre;
            string [] validGenres = ["drama", "adventure", "family", "action", "sci-fi", "comedy", "animated", "thriller", "other"]; 
            while (true)
            {
                Console.WriteLine("The Genres can be drama, adventure, family, action, sci-fi, comedy, animated, thriller, or other");
                Console.Write("Genre: ");
                genre = Console.ReadLine().ToLower();
                if (validGenres.Contains(genre))
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid genre. Please enter a valid genre: ");
                }
            }
            string [] validClassifications = ["G", "PG", "M", "MA", "R", "other"];
            string classification;
            while (true)
            {   
                Console.WriteLine("The Classification can be G, PG, M, MA, R, or other");
                Console.Write("Classification: ");
                classification = Console.ReadLine().ToUpper();
                if (validClassifications.Contains(classification))
                {
                    break;
                }
                else
                {
                    Console.Write("Invalid classification. Please enter a valid classification: ");
                }
            }

            Console.Write("Duration: ");
            string duration = Console.ReadLine();
            Console.Write("Copies: ");
            int copies;
            while (!int.TryParse(Console.ReadLine(), out copies))
            {
                Console.Write("Invalid input. Please enter a valid number for copies: ");
            }
            Movie movie = new Movie(title, genre, classification, duration, copies);

            MovieCollection movieCollection = MovieCollection.GetInstance();

            //Check if the movie already exists
            if (movieCollection.Search(movie.Title) != null)
            {
                Console.WriteLine("Movie already exists");
                var existingMovie = movieCollection.Search(movie.Title);
                if (existingMovie != null)
                {
                    existingMovie.Copies = copies;
                    
                }
                
                Console.WriteLine("Copies updated");
                return;
            }
            movieCollection.Insert(title, movie);
            Console.WriteLine("Movie added to system");
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
        }

        public void RemoveMovie(string title, int copiesToRemove)
        {
            MovieCollection movieCollection = MovieCollection.GetInstance();
            Movie movie = movieCollection.Search(title);
            Console.WriteLine("Movie found with " + movie.Copies + " copies");
            if(movie.Copies >= copiesToRemove)
            {
                movie.Copies -= copiesToRemove;
                if (movie.Copies == 0)
                {
                    movieCollection.Delete(title);
                    Console.WriteLine("Movie removed from system");
                    int milliseconds = 3000;
                    Thread.Sleep(milliseconds);
                }
                else
                {
                    Console.WriteLine("Copies updated to " + movie.Copies);
                    int milliseconds = 3000;
                    Thread.Sleep(milliseconds);
                }
                return;
            }else {
                Console.WriteLine("Not enough copies to remove");
                int milliseconds = 3000;
                Thread.Sleep(milliseconds);
                return;
            }
            
        }
        public void AddMember(string firstName, string lastName, string phoneNumber, string password)
        {
            Member member = new Member(firstName, lastName, phoneNumber, password);
            MemberCollection memberCollection = MemberCollection.GetInstance();
            int milliseconds = 3000;
            if (memberCollection.SearchMember(member.GetFullName()))
            {
                Console.WriteLine("Member already exists");
                Thread.Sleep(milliseconds);
                return;
            }

            memberCollection.Insert(member);
            memberCollection.PrintList();
            Console.WriteLine("Member added to system");
            
            Thread.Sleep(milliseconds);
        }
        public void RemoveMember(string fullName)
        {
            MemberCollection memberCollection = MemberCollection.GetInstance();
            memberCollection.Delete(fullName);
            memberCollection.PrintList();
            Console.WriteLine("Member removed from system");
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
        }

        public void GetMemberPhoneNumber(string fullName)
        {
            MemberCollection memberCollection = MemberCollection.GetInstance();
            memberCollection.SearchPhoneNumber(fullName);
            int milliseconds = 3000;
            Thread.Sleep(milliseconds);
        }
    }
}
