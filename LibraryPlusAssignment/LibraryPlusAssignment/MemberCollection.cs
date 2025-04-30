using System;
using System.Collections.Generic;
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
        private List<Member> collection;

        // Private constructor to prevent instantiation
        private MemberCollection() { 
            collection = new List<Member>();
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
            collection.Add(member);
        }

        // Optional: Method to retrieve all members
        public List<Member> GetAllMembers()
        {
            return collection;
        }
    }
}