using System.Security.Cryptography.X509Certificates;

namespace LibraryPlusAssignment
{
    internal class Program
    {
        
        public static void StaffMenu()
        {
            MovieCollection firstCollection = new MovieCollection();
            Staff pauli = new Staff();
            pauli.AddMovie(firstCollection);
            
            //Hashtable hashtable = new Hashtable();
            Movie movie1 = new Movie("Mamma Mia", "Comedy", "PG", "1:30:00", 3);
            Movie movie2 = new Movie("Pride and Prejudice", "Romance", "PG", "1:45:00", 2);
            MovieCollection movie = new MovieCollection();
            movie.Insert(movie1.Title, movie1);
            movie.Insert(movie2.Title, movie2);
            int result = movie.Search(movie1.Title);
            Movie resultMovie = movie.Collection(result);
            Console.WriteLine(resultMovie.Title);
            Console.WriteLine("Result from movie search" + result);

            int result2 = movie.Search(movie2.Title);
            Movie resultMovie2 = movie.Collection(result2);
            Console.WriteLine(resultMovie2.Title);
            Console.WriteLine("Result from movie search" + result2);

            Console.WriteLine("Staff Menu");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Add DVDs to system");
            Console.WriteLine("2. Remove DVDs from system");
            Console.WriteLine("3. Register a new member to system");
            Console.WriteLine("4. Remove a registered member from system");
            Console.WriteLine("5. Find a member contact phone number, given the member's name");
            Console.WriteLine("6. Find members who are currently renting a particular movie");
            Console.WriteLine("0. Return to main menu");

            Console.WriteLine("Enter your choice --->");

        }



        public static void MemberMenu()
        {
            Console.WriteLine("Member Menu");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1. Browse all the movies" );
            Console.WriteLine("2. Display all the information about a movie, given the title of the movie");
            Console.WriteLine("3. Borrow a movie DVD");
            Console.WriteLine("4. Return a movie DVD");
            Console.WriteLine("5. List current borrowing movies");
            Console.WriteLine("6. Display the top 3 movies rented by the members");

            Console.WriteLine("Enter your choice --->");

        }


        static void Main(string[] args)
        {

            

            Console.WriteLine("===================================================================================");
            Console.WriteLine("COMMUNITY  LIBRARY MOVIE DVD MANAGEMENT SYSTEM");
            Console.WriteLine("===================================================================================");
            Console.WriteLine("");

            int option = 5; 
            while ( option != 0)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Staff");
                Console.WriteLine("2. Member");
                Console.WriteLine("0. End the program");
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    StaffMenu();


                }
                else if (option == 2)
                {

                    MemberMenu();

                }


            }


        }
    }
}
