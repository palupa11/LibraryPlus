using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class MemberCollection
    {
        // Singleton instance
        private static MemberCollection? instance;
        // private static readonly object lockObj = new object(); // Lock for thread safety

        // Data fields
        // private LinkedList<Member> collection;
        public Node<Member>? Head { get; set; }
        public int Count { get; set; }
        // Private constructor to prevent instantiation
        private MemberCollection()
        {
            Head = null; // Explicitly initialize Head to null
            Count = 0;
        }

        // Public method to get the singleton instance
        public static MemberCollection GetInstance()
        {
            if (instance == null)
            {

                if (instance == null)
                {
                    instance = new MemberCollection();
                }
            }

            return instance;
        }

        public void Insert(Member member)
        {
            // Check if the member already exists
            if (Head == null)
            {
                Head = new Node<Member>();
                Head.Data = member; // Assigns the value to the member of the new node
                Head.Next = null;
                Count++;
                return; // Exit the method
            }

            Node<Member> newNode = new Node<Member>();
            newNode.Data = member; // Assigns the value to the member of the new node
            newNode.Next = Head;
            Head = newNode; // Ensure Head is not null before assignment

        }
        public bool SearchMember(string fullName)
        {
            Node<Member> current = Head; // Start from the head of the list
            while (current != null) // While there are nodes in the list
            {
                if (current.Data.GetFullName() == fullName) // If the current node's member is equal to the searched member
                {
                    return true; // Exit the method
                }
                current = current.Next; // Move to the next node
            }
            return false;
        }

        public void Delete(string fullName)
        {
            Node<Member> current = Head;
            Node<Member> previous = null;

            while (current != null)
            {
                if (current.Data.GetFullName() == fullName)
                {
                    if (previous == null)
                    {
                        Head = current.Next; // Remove the head node
                    }
                    else
                    {
                        previous.Next = current.Next; // Bypass the current node
                    }
                    Count--;
                    Console.WriteLine("Member removed: " + fullName);
                    return;
                }
                previous = current;
                current = current.Next;
            }

            Console.WriteLine("Member not found");
        }
        public void PrintList()
        {
            Node<Member> current = Head; // Starting from beginning/head of list
            while (current != null) // While there are nodes in the list
            {
                Console.WriteLine(current.Data.GetFullName()); // Print the member of the current node
                current = current.Next; // Move to the next node
            }
        }
        // Method to add a member
        // public void AddMember(Member member)
        // {
        //     while (collection.Head != null) //While there are nodes in the list
        //     {
        //         if (collection.Head.Data.GetFullName() == member.GetFullName())//If the current node's member is equal to the searched member
        //         {
        //            Console.WriteLine("Member already exists" + member.GetFullName());
        //             return; //Exit the method
        //         }
        //         else
        //         {
        //             collection.Head = collection.Head.Next; //Move to the next node
        //         }

        //     }
        //     // If the member does not exist, add it to the collection
        //     collection.InsertAtBeginning(member);
        //     collection.PrintList();

        // }

        public void SearchPhoneNumber(string fullName)
        {
            Node<Member>? current = Head; // Start from the head of the list
            while (current != null) //While there are nodes in the list
            {
                if (current.Data.GetFullName() == fullName)//If the current node's member is equal to the searched member
                {
                    string phoneNumber = current.Data.PhoneNumber;
                    Console.WriteLine("Member" + " " + fullName + " " + "has phone number" + " " + phoneNumber);
                    return; //Exit the method
                }
                else
                {
                    current = current.Next; //Move to the next node

                }
                // If the member does not exist, return null
                Console.WriteLine("Member not found");
            }


        }

        public Member MemberLogIn(string firstName, string LastName, string password)
        {
            Node<Member> current = Head; // Start from the head of the list
            while (current != null) // While there are nodes in the list
            {
                if (current.Data.FirstName == firstName && current.Data.LastName == LastName && current.Data.Password == password)  // If the current node's member is equal to the searched member
                {
                    return current.Data; // Exit the method
                }
                current = current.Next; // Move to the next node
            }
            return null;
        }





    }



}