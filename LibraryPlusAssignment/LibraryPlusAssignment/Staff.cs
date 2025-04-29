using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class Staff
    {
        // Data fields
        string username;
        string password;


        //properties

        //constructor 

        //function 

        public void AddMovie (MovieCollection collection)
        {
            Console.WriteLine("Input movie title:");
            string movieTitle = Console.ReadLine();
            Console.WriteLine("This is the title of the movie to search" + movieTitle);
            //Search if the movie is not already in the collection
            Movie? searchResult = collection.Search(movieTitle);
            Console.WriteLine("This is the search result" + searchResult);
            if (searchResult == null)
            {
                //string title = "Barbie";
                Console.WriteLine("The movie does not exist in collection");
                Console.WriteLine("Input title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Input genre:");
                Console.WriteLine("-Drama  -Adventure  -Family  -Action  -Sci-fi  -Comedy  -Animated  -Thriller  -Other");
                string genre = Console.ReadLine();
                Console.WriteLine("Input classification:");
                Console.WriteLine("-General (G)  -Parental Guidance (PG)  -Mature (M15+)  -Mature Accompanied (MA15+)");
                string classification = Console.ReadLine();
                Console.WriteLine("Input duration in minutes: ");
                string duration = Console.ReadLine();
                Console.WriteLine("Input number of copies of the movie");
                int copies = Convert.ToInt32(Console.ReadLine());


                //Movie movie = new Movie("Barbie", "Comedy", "PG", "100", 1);
                Movie movie = new Movie(title, genre, classification, duration, copies);    
                collection.Insert(title, movie);
                Console.WriteLine(MovieCollection.collectionSize);
                Console.WriteLine("Movie added successfully");

            }
            else
            {
                Console.WriteLine("The else, TBD");
            }
            // Add new movies to collection 

            //If movie exists in collection, add new copy


        }





    }
}
