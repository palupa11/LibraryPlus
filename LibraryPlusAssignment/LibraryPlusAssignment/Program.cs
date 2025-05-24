using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace LibraryPlusAssignment
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Console.WriteLine("=========Movie Title Generator TEST ==========");
            // ExperimentalTests.GenerateTestMovies(2000);

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
                    string? firstName = "";
                    string? lastName = "";
                    string? password = "";
                    while (string.IsNullOrWhiteSpace(firstName))
                    {
                        Console.Write("Enter first name: ");
                        firstName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(firstName))
                            Console.WriteLine("First name cannot be empty");  
                    }
                    while (string.IsNullOrWhiteSpace(lastName))
                    {
                        Console.Write("Enter last name: ");
                        lastName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(lastName))
                            Console.WriteLine("Last name name cannot be empty");  
                    }
                    while (string.IsNullOrEmpty(password) && password.Length != 4)
                    {
                        Console.Write("Enter 4 digit password: ");
                        password = Console.ReadLine();
                        if (string.IsNullOrEmpty(password) && password.Length != 4)
                            Console.WriteLine("Password cannot be empty or more than 4 characters");
                        
                    }
                    
                    MemberCollection collection = MemberCollection.GetInstance();
                    Member? member = collection.MemberLogIn(firstName!, lastName!, password!);
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
