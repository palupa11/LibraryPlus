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
        {
            Console.WriteLine("Add DVD to the system");
            Console.Write("Title: ");
            string? title = Console.ReadLine();
            string? genre;
            string[] validGenres = ["drama", "adventure", "family", "action", "sci-fi", "comedy", "animated", "thriller", "other"];
            while (true)
            {
                Console.WriteLine("The Genres can be drama, adventure, family, action, sci-fi, comedy, animated, thriller, or other");
                Console.Write("Genre: ");
                genre = Console.ReadLine();
                if (!string.IsNullOrEmpty(genre))
                {
                    genre = genre.ToLower();
                    if (validGenres.Contains(genre))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid genre. Please enter a valid genre: ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid or empty field. Please try again");
                }

            }
            string[] validClassifications = ["G", "PG", "M", "MA", "R", "other"];
            string? classification;
            while (true)
            {
                Console.WriteLine("The Classification can be G, PG, M, MA, R, or other");
                Console.Write("Classification: ");
                classification = Console.ReadLine();
                if (!string.IsNullOrEmpty(classification))
                {
                    classification = classification.ToUpper();
                    if (validClassifications.Contains(classification))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Invalid classification. Please enter a valid classification: ");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid or empty field. Please try again");
                }

                
            }

            Console.Write("Duration: ");
            string? duration = Console.ReadLine();
            Console.Write("Copies: ");
            int copies;
            while (!int.TryParse(Console.ReadLine(), out copies))
            {
                Console.Write("Invalid input. Please enter a valid number for copies: ");
            }
            Movie movie = new Movie(title, genre, classification, duration, copies);

            MovieCollection movieCollection = MovieCollection.GetInstance();

            //Check if the movie already exists
            Movie? movieExists = movieCollection.Search(movie.Title);
            if (movieExists != null)
            {
                Console.WriteLine("Movie already exists");
                
                movieExists.Copies = copies;
                Console.WriteLine("Copies updated");
                return;
            }
            if (movie != null)
            {
                movieCollection.Insert(title, movie);
                Console.WriteLine("Movie added to system");
            }
            else
            {
                Console.WriteLine("Error! Movie not added");
            }


            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
        }

        public void RemoveMovie(string title, int copiesToRemove)
        {
            MovieCollection movieCollection = MovieCollection.GetInstance();
            Movie? movie = movieCollection.Search(title);
            if (movie == null)
            {
                Console.WriteLine("Movie not found. Enter any key to continue");
                Console.ReadKey();
                return;
            }
            int milliseconds = 3000;
            if (movie.Copies >= copiesToRemove)
            {
                movie.Copies -= copiesToRemove;
                if (movie.Copies == 0)
                {
                    movieCollection.Delete(title);
                    Console.WriteLine("Movie removed from system");
                }
                else
                {
                    Console.WriteLine("Copies updated to " + movie.Copies);

                }
                Thread.Sleep(milliseconds);
                return;
            }
            else
            {
                Console.WriteLine("Not enough copies to remove");
                Thread.Sleep(milliseconds);
                return;
            }

        }
        public void AddMember(string firstName, string lastName, string phoneNumber, string password)
        {
            Member member = new Member(firstName, lastName, phoneNumber, password);
            MemberCollection memberCollection = MemberCollection.GetInstance();
            int milliseconds = 3000;
            Member? existingMember = memberCollection.SearchMember(member.GetFullName());
            if (existingMember != null)
            {
                Console.WriteLine("Member already exists");
                Thread.Sleep(milliseconds);
                return;
            }

            memberCollection.Insert(member);
            
            Console.WriteLine("Member " + member.GetFullName() +" added to system");

            Thread.Sleep(milliseconds);
        }
        public void RemoveMember(string fullName)
        {
            MemberCollection memberCollection = MemberCollection.GetInstance();
            Member? member = memberCollection.SearchMember(fullName);
            if (member != null)
            {
                if (member.BorrowedCount > 0)
                {
                    Console.WriteLine("The member must return the rented DVDs before they can removed. Enter any key to continue...");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    memberCollection.Delete(fullName);
                    memberCollection.PrintList();
                    Console.WriteLine("Member removed from system. Enter any key to continue....");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Member not found. Enter any key to continue...");
                Console.ReadKey();
            }

        }

        public void GetMemberPhoneNumber(string fullName)
        {
            MemberCollection memberCollection = MemberCollection.GetInstance();
            memberCollection.SearchPhoneNumber(fullName);
            Console.WriteLine("Enter any key to continue....");
            Console.ReadKey();
        }
    }
}
