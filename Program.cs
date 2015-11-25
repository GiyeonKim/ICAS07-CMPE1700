using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICAS07_CMPE1700
{
    class Program
    {
        static void Main(string[] args)
        {
            // make a node of the head
            Node H = null; // null is the tail
            int count = 0; // int for counting the number
            LinkedList.Append(ref H, 60); count += 1;
            LinkedList.Append(ref H, 4); count += 1;
            LinkedList.Append(ref H, 23); count += 1;
            LinkedList.Append(ref H, 1); count += 1;
            
            
            Console.WriteLine("Linked list (Tail to Head) :");
           
            LinkedList.AddToTail(ref H);
            LinkedList.Print(H);
            

            Console.WriteLine();
            Console.WriteLine("\nSorted List Order:");
            SortLinkedList(H,count);
            RecursivePrintList(H);
            
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Reverse:");
            LinkedList.Reverse(ref H);
            LinkedList.Print(H);
            Console.ReadKey();
            
        }


        static public void RecursivePrintList(Node H)
        {
            if (H == null)
            {
                Console.WriteLine();
                return;
            }

            Console.Write(H.Data + " ");

            //Head of the remainder of the list is just the next one after this one.
            RecursivePrintList(H.Next);

        }

        //sort the linked list of the value 
        public static Node SortLinkedList(Node head, int count)
        {
            // Basic Algorithm Steps
            //1. Find Min Node
            //2. Remove Min Node and attach it to new Sorted linked list
            //3. Repeat "count" number of times
            Node _current = head;
            Node _previous = _current;
            Node _min = _current;
            Node _minPrevious = _min;
            Node _sortedListHead = null;
            Node _sortedListTail = _sortedListHead;
            for (int i = 0; i < count; i++)
            {
                _current = head;
                _min = _current;
                _minPrevious = _min;
                //Find min Node
                while (_current != null)
                {
                    if (_current.Data < _min.Data)
                    {
                        _min = _current;
                        _minPrevious = _previous;
                    }
                    _previous = _current;
                    _current = _current.Next;
                }
                // Remove min Node 
                if (_min == head)
                {
                    head = head.Next;
                }
                else if (_min.Next == null) //if tail is min node
                {
                    _minPrevious.Next = null;
                }
                else
                {
                    _minPrevious.Next = _minPrevious.Next.Next;
                }
                //Attach min Node to the new sorted linked list
                if (_sortedListHead != null)
                {
                    _sortedListTail.Next = _min;
                    _sortedListTail = _sortedListTail.Next;
                }
                else
                {
                    _sortedListHead = _min;
                    _sortedListTail = _sortedListHead;
                }
            }
            return _sortedListHead;

        }

        public static class LinkedList
        {

            // add the tail to the list first
            public static void AddToTail(ref Node H)
            {
                if (H == null) return; // empty list

                Node pre = null, current = H, next = null;

                while (current.Next != null) // the list is not empty
                {
                    next = current.Next;
                    current.Next = pre;
                    pre = current;
                    current = next;
                }

                current.Next = pre;
                H = current;
            }
            // print out the linked list
            public static void Print(Node H)
            {
                if (H == null) return; //if the last item is on the first list it returns 

                Node current = H;
                do
                {
                    Console.Write("{0} ", current.Data);
                    current = current.Next;
                } while (current != null);
            }

            // Append the linked list
            public static void Append(ref Node H, int data)
            {
                if (H != null)
                {
                    Node current = H;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    current.Next = new Node();
                    current.Next.Data = data;
                }
                else
                {
                    H = new Node();
                    H.Data = data;
                }

            }

           //reverse the linked list
            public static void Reverse(ref Node H)
            {
                if (H == null) return;

                Node prev = null, current = H, next = null;

                while (current.Next != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                current.Next = prev;
                H = current;
            }
            

        }

        public class Node
        {
            public int Data = 0;
            public Node Next = null;
        }
    }
}
