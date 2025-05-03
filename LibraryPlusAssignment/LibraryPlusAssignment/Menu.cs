using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class Menu
    {
        // Singleton instance
        public int DisplayMenu()
        {
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Staff");
                Console.WriteLine("2. Member");
                Console.WriteLine("0. End the program");
                int option = Convert.ToInt32(Console.ReadLine());
                return option;
            }
        }
        public void StaffMenu(Staff staff)
        {
            while (true)
            {
                Console.Clear();
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
                string? choice = Console.ReadLine();
                if (choice == "0")
                {
                    break;
                }
                else if (choice == "1")
                {
                    Console.Clear();
                    staff.AddMovie();
                }
                else if (choice == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Enter the title of the movie you want to remove:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter the number of copies you want to remove:");
                    int copies = Convert.ToInt32(Console.ReadLine());

                    staff.RemoveMovie(title, copies);
                }
                else if (choice == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Register a new member to system");
                    Console.Write("First Name: ");
                    string? FirstName = Console.ReadLine();
                    Console.Write("Last Name: ");
                    string? LastName = Console.ReadLine();
                    Console.Write("Phone Number: ");
                    string? PhoneNumber = Console.ReadLine();
                    Console.Write("Password: ");
                    string? newPassword = Console.ReadLine();
                    while (newPassword.Length != 4)
                    {
                        Console.WriteLine("Password must be at least 4 characters long. Please enter a new password:");
                        newPassword = Console.ReadLine();
                    }
                    staff.AddMember(FirstName, LastName, PhoneNumber, newPassword);
                }
                else if (choice == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Paulis homework ");
                }
                else if (choice == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Find a member contact phone number, given the member's name");
                    Console.Write("Enter the member's full name: ");
                    string? fullName = Console.ReadLine();
                    staff.GetMemberPhoneNumber(fullName);

                }


            }

        }

        public void MemberMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Member Menu");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("1. Browse all the Movies");
                Console.WriteLine("2. Return a DVD");
                Console.WriteLine("3. Find a member contact phone number, given the member's name");
                Console.WriteLine("4. Find members who are currently renting a particular movie");
                Console.WriteLine("0. Return to main menu");
                Console.WriteLine("Enter your choice --->");
                string? choice = Console.ReadLine();
                if (choice == "0")
                {
                    break;
                }
                else if (choice == "1")
                {
                    Console.Clear();
                    MovieCollection movieCollection = MovieCollection.GetInstance();
                    movieCollection.DisplayMovieInfo();
                }

            }


        }
    }
}