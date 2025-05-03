using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPlusAssignment
{
    internal class LinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;    // To know the number of elements in the list


        //Methods

        //Inserting an item at the beginning
        public void InsertAtBeginning(T memberObj)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = memberObj; //Assigns the value to the member of the new node
            newNode.Next = head; //The new node's next is the current head
            head = newNode; //The head is now the new node

            //checking if list is empty
            if (tail == null)
            {
                tail = newNode; //If the list is empty, the tail is also the new node
            }
            count++; //Increment the count of nodes in the list

        }

        public void InsertAtEnd(T memberObj)
        {
            Node<T> newNode = new Node<T>();
            newNode.Data = memberObj; //Assigns the value to the member of the new node
            newNode.Next = null; //The new node's next is null, since it will be the last node in the list
                                 // Checking if the list is empty
            if (tail == null)
            {
                head = newNode;
                tail = newNode; //If the list is empty, the tail is also the new node
            }
            else
            {
                tail.Next = newNode;
                tail = newNode; //The tail is now the new node
            }

            count++; //Increment the count of nodes in the list

        }

        public void PrintList()
        {
            Node<T> current = head; //Starting from beginning/head of  list
            while (current != null) //While there are nodes in the list
            {
                Console.WriteLine(current.Data); //Print the member of the current node
                current = current.Next; //Move to the next node
            }


        }

        public void SearchMember(T member)
        {
            Node<T> current = head; //Starting from beginning/head of  list
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(member)) //If the current node's member is equal to the searched member
                {
                    Console.WriteLine("Member found at index: " + i);
                    break; //Exit the loop if the member is found
                }
                else
                {
                    Console.WriteLine("Member not found at index: " + i);
                    current = current.Next; //Move to the next node
                }

            }


        }

    }
}
