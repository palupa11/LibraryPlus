using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace LibraryPlusAssignment
{
    internal class Program
    {

        // public static void StaffMenu()
        // {   

        //     if (username == "staff" || password == "today123")
        //     {
        //         Console.WriteLine("Login Successful");
        //         Staff staff = new Staff(username, password);
        //         do
        //         { 
        //         Console.Clear();  
        //         Console.WriteLine("Staff Menu");
        //         Console.WriteLine("---------------------------------------");
        //         Console.WriteLine("1. Add DVDs to system");
        //         Console.WriteLine("2. Remove DVDs from system");
        //         Console.WriteLine("3. Register a new member to system");
        //         Console.WriteLine("4. Remove a registered member from system");
        //         Console.WriteLine("5. Find a member contact phone number, given the member's name");
        //         Console.WriteLine("6. Find members who are currently renting a particular movie");
        //         Console.WriteLine("0. Return to main menu");
        //         Console.WriteLine("Enter your choice --->");
        //         string? choice = Console.ReadLine();
        //         if (choice == "1")
        //         {   
        //             Console.Clear();
        //             Console.Write("Title: ");
        //             string? title = Console.ReadLine();
        //             Console.WriteLine("A Genre can be Drama, adventure, family, action, sci-fi,comedy, animated, thriller, or other");
        //             Console.Write("Genre: ");
        //             string? genre = Console.ReadLine();
        //             Console.WriteLine("A movie is classified as General (G), Parental Guidance(PG), Mature (M15+), or Mature Accompanied (MA15+)");
        //             Console.WriteLine("Enter G, PG, M or MA: ");
        //             Console.Write("classification: ");
        //             string? classification = Console.ReadLine();
        //             Console.Write("Duration(in minuites): ");
        //             string? duration = Console.ReadLine();
        //             Console.Write("Copies: ");
        //             int copies = Convert.ToInt32(Console.ReadLine());
        //             staff.AddMovie(title, genre, classification, duration, copies);

        //         }else if (choice == "2")
        //         {

        //             // Remove DVDs from system
        //         }else if (choice == "3")
        //         {
        //             // Register a new member to system
        //             Console.Write("First Name: ");
        //             string? FirstName = Console.ReadLine();
        //             Console.Write("Last Name: ");
        //             string? LastName = Console.ReadLine();
        //             Console.Write("Phone Number: ");
        //             string? PhoneNumber = Console.ReadLine();
        //             Console.Write("Password: ");
        //             string? newPassword = Console.ReadLine();

        //             staff.AddMember(FirstName, LastName, PhoneNumber, newPassword);
        //             Console.WriteLine("Member added to system");


        //         }else if (choice == "4")
        //         {
        //             // Remove a registered member from system
        //         }else if (choice == "5")
        //         {
        //             // Find a member contact phone number, given the member's name
        //         }else if (choice == "6")    
        //         {
        //             // Find members who are currently renting a particular movie
        //         }
        //         else
        //         {
        //             Console.WriteLine("Invalid option. Please try again.");
        //         }

        //     }while(Console.ReadLine() != "0");

        //     }else {
        //         Console.WriteLine("Invalid username or password");
        //     }


        // }

        static void Main(string[] args)
        {

            Console.WriteLine("===================================================================================");
            Console.WriteLine("COMMUNITY  LIBRARY MOVIE DVD MANAGEMENT SYSTEM");
            Console.WriteLine("===================================================================================");
            Console.WriteLine("");

            while (true)
            {
                Menu menu = new Menu();
                int option = menu.DisplayMenu();
                if (option == 1)
                {
                    Console.Clear();
                    Console.Write("Username: ");
                    string? username = Console.ReadLine();
                    Console.Write("Password: ");
                    string? password = Console.ReadLine();
                    if (username == null || password == null)
                    {
                        Console.WriteLine("Invalid username or password field");
                    }
                    if (username == "staff" && password == "today123")
                    {
                        Staff staff = new Staff(username, password);
                        Console.WriteLine("Login Successful");
                        menu.StaffMenu(staff);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username or password. Enter any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.Write("Enter first name: ");
                    string? firstName = Console.ReadLine(); 
                    Console.Write("Enter last name: ");
                    string? lastName = Console.ReadLine();
                    Console.Write("Enter 4 digit password: ");
                    string? password = Console.ReadLine();
                    MemberCollection collection = MemberCollection.GetInstance();
                    Member? member = collection.MemberLogIn(firstName, lastName, password);
                    if(member == null){
                        Console.Write("Invalid details, try again:");
                    }
                    else{
                         menu.MemberMenu(member);

                    }

                }
                else if (option == 0)
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }


            }


        }
    }
}
