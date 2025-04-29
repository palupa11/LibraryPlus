using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class Member
    {
        //Data fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

       public Member(string firstName, string lastName, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;       
            
        }
        public String GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
