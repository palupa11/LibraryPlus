// using System;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace LibraryPlusAssignment
// {
//     internal class LinkedList<T>
//     {
//         private Node<T> head;
//         private Node<T> tail;
//         private int count;    // To know the number of elements in the list

//         //Properties
//         public Node<T> Head
//         {
//             get { return head; }
//             set { head = value; }
//         }
//         public Node<T> Tail
//         {
//             get { return tail; }
//             set { tail = value; }
//         }
//         public int Count
//         {
//             get { return count; }
//             set { count = value; }
//         }


//         //Methods

//         //Inserting an item at the beginning
//         public void InsertAtBeginning(T memberObj)
//         {
//             Node<T> newNode = new Node<T>();
//             newNode.Data = memberObj; //Assigns the value to the member of the new node
//             newNode.Next = head; //The new node's next is the current head
//             head = newNode; //The head is now the new node

//             //checking if list is empty
//             if (tail == null)
//             {
//                 tail = newNode; //If the list is empty, the tail is also the new node
//             }
//             count++; //Increment the count of nodes in the list

//         }

//         public void InsertAtEnd(T memberObj)
//         {
//             Node<T> newNode = new Node<T>();
//             newNode.Data = memberObj; //Assigns the value to the member of the new node
//             newNode.Next = null; //The new node's next is null, since it will be the last node in the list
//                                  // Checking if the list is empty
//             if (tail == null)
//             {
//                 head = newNode;
//                 tail = newNode; //If the list is empty, the tail is also the new node
//             }
//             else
//             {
//                 tail.Next = newNode;
//                 tail = newNode; //The tail is now the new node
//             }

//             count++; //Increment the count of nodes in the list

//         }

//         public void PrintList()
//         {
//             Node<T> current = head; //Starting from beginning/head of  list
//             while (current != null) //While there are nodes in the list
//             {
//                 Console.WriteLine(current.Data); //Print the member of the current node
//                 current = current.Next; //Move to the next node
//             }


//         }

//         public bool SearchMember(T member)
//         {
//             Node<T> current = head; //Starting from beginning/head of  list
//             while (current != null) //While there are nodes in the list
//             {
//                 if (current.Data.GetFullName() == member.GetFullName())//If the current node's member is equal to the searched member
//                 {
//                    Console.WriteLine("Member already exists" + member.GetFullName());
//                     return; //Exit the method
//                 }
//                 else
//                 {
//                     current = current.Next; //Move to the next node
//                 }
                
//             }

//         }
//         public void RemoveAtBeginning(T member)
//         {
//             Node<T> current = head; //Starting from beginning/head of  list
//             Node<T> previous = null; //To keep track of the previous node

//             while (current != null) //While there are nodes in the list
//             {
//                 if (current.Data.Equals(member)) //If the current node's member is equal to the searched member
//                 {
//                     if (previous == null) //If the current node is the head
//                     {
//                         head = current.Next; //The head is now the next node
//                     }
//                     else
//                     {
//                         previous.Next = current.Next; //The previous node's next is now the current node's next
//                     }
//                     count--; //Decrement the count of nodes in the list
//                     return; //Exit the method
//                 }
//                 previous = current; //Move to the next node
//                 current = current.Next;
//             }
//             if (head == null) //If the list is empty
//             {
//                 Console.WriteLine("List is empty");
//                 return;
//             }
//             head = head.Next; //The head is now the next node
//             count--; //Decrement the count of nodes in the list
//         }

    

//     }
// }
