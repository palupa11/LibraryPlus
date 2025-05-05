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

        //Properties
        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }
        public Node<T> Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }


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

        //public bool SearchMember(T member)
        //{
        //    Node<T> current = head; //Starting from beginning/head of  list
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (current.Data.Equals(member)) //If the current node's member is equal to the searched member
        //        {
        //            return true; //Return the index of the member
        //            break; //Exit the loop if the member is found
        //        }
        //        else
        //        {
        //            current = current.Next; //Move to the next node
        //        }

        //    }
        //    return false; //Return -1 if the member is not found

        //}

        public void Remove(T elementToDelete)
        { 
            
            Node<T> current = head; 
            Node<T> previous = null; //To keep track of the previous node
            while(current != null)
            {
                //previous = current; //The previous node is the current node
                if (current.Data.Equals(elementToDelete))
                {
                    if(previous == null) //If the current node is the head
                    {
                        head = current.Next; //The head is now the next node
                    }
                    else
                    {
                        previous.Next = current.Next; //The previous node's next is the current node's next
                    }
                    if( current == tail) //If the current node is the tail
                    {
                        tail = previous; //The tail is now the previous node
                    }
                    count--; //Decrement the count of nodes in the list
                    return;

                }
                else
                {
                    previous = current; //The previous node is the current node
                    current = current.Next; //Move to the next node
                }

            }
            Console.WriteLine("Element not found");



        }

    

    }
}
