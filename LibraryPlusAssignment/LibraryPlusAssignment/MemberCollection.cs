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
        private LinkedList<Member> collection;

        // Private constructor to prevent instantiation
        private MemberCollection() { 
            collection = new LinkedList<Member>();
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

        // Method to add a member
        public void AddMember(Member member)
        {
            while (collection.Head != null) //While there are nodes in the list
            {
                if (collection.Head.Data.GetFullName() == member.GetFullName())//If the current node's member is equal to the searched member
                {
                   Console.WriteLine("Member already exists" + member.GetFullName());
                    return; //Exit the method
                }
                else
                {
                    collection.Head = collection.Head.Next; //Move to the next node
                }
                
            }
            // If the member does not exist, add it to the collection
            collection.InsertAtBeginning(member);
            collection.PrintList();
  
        }

        public void SearchPhoneNumber(string fullName)
        {
            while (collection.Head != null) //While there are nodes in the list
            {
                if (collection.Head.Data.GetFullName() == fullName)//If the current node's member is equal to the searched member
                {
                    string phoneNumber = collection.Head.Data.PhoneNumber;
                    Console.WriteLine("Member" + " " + fullName + "has phone number" + " "  + phoneNumber);
                    return; //Exit the method
                }
                else
                {
                    collection.Head = collection.Head.Next; //Move to the next node
                }
                
            }

            // If the member does not exist, return null
            Console.WriteLine("Member not found");
            


        }

        public void DeleteMember(string fullName) 
        {
            Node<Member> current = collection.Head; // Start from the head of the list
            while (current != null) //While there are nodes in the list
            {
                Console.WriteLine("inside the deletemember function of member collection , searching for" + current.Data.GetFullName());
                if (current.Data.GetFullName() == fullName)//If the current node's member is equal to the searched member
                {
                    collection.Remove(current.Data); //Remove the member from the list
                    Console.WriteLine("Member" + " " + fullName + " " + "has been removed from collection");
                    collection.PrintList();
                    return; //Exit the method
                }
                
                 current = current.Next; //Move to the next node
                

            }

            // If the member does not exist, return null
            Console.WriteLine("Member not found");



        }






        // Method to search for a member by name

        // // Optional: Method to retrieve all members
        // public List<Member> GetAllMembers()
        // {
        //     return collection;
        // }
    }
}