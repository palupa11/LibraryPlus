using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class Node<T>
    {
        private T? data;   //Makes it generic to allow any type of data (member is an object?)
        private Node<T>? next; //Storing a reference to another node object, which is the next node in the list

        //Properties 
        public T? Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T>? Next
        {
            get { return next; }
            set { next = value; }
        }

    }
}
