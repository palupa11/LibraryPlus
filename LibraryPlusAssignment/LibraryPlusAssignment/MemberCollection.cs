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
        //Data fields
        private List<Member> collection = new List<Member>();

        public void addMember(Member member)
        {
            collection.Add(member);
        }
    }
}
