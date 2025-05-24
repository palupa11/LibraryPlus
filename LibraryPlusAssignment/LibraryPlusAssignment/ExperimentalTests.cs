using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class ExperimentalTests
    {
       public static void GenerateTestMovies(int testSize)
       {
            Member member = new Member("ti", "to", "0831239", "1000");
            MemberCollection memberCollection = MemberCollection.GetInstance();
            memberCollection.Insert(member);
            Random random = new Random();
            MovieCollection collection = MovieCollection.GetInstance();

            for (int i = 0; i < testSize; i++)
            {
                string letterOptions = "ABCDEFGHIJKLMNOPQRSTUVXYZ!#$@%^&*()_+1234567890abcdefghijklmnopqrstuvxyz ";
                int titleLength = random.Next(3, 15);
                string movieTitle = "";
                for (int j = 0; j < titleLength; j++)
                {
                    int letterIndex = random.Next(letterOptions.Length);
                    movieTitle += letterOptions[letterIndex];


                }
                int rentCount = random.Next(0, 20);
                Console.WriteLine("Movie title: " + movieTitle);
                Console.WriteLine("Rent count : " + rentCount);

                Movie movie = new Movie(movieTitle, "drama", "G", "100", 5, rentCount);
                collection.Insert(movieTitle, movie);


            }


       }


    }
}
