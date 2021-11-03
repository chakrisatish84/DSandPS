using DSandPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //int[] arr = { 5, 4, 8, 7, 1, 2, 3, 4, 5, 6, };
            int[] arr = { 5, 4, 5, 8, 1, 7, 1, 2, 5 };

            //int[] arr = { 1,2,2,3,4,5,5,5,6,6,7,8,9,9 };

            //Single Linked List
            SingleLinkedList list = new SingleLinkedList();

            //Create a list
            list.create(arr);

            // Print the list items, Iterative way.
            Console.WriteLine("Print all list elements");
            list.PrintListElements();

            //Print the list items using recursive way.
            //Console.WriteLine("Print all list element using recursive");
            //list.PrintListItemsRecursively();


            //Console.WriteLine("Reverse Linked list");
            //Reverse Linked list using recursion.
            //list.reverseLinkedListRecursively();

            // Reverse Linked list with out recursion.
            //list.ReverseLinkedListitterative();

            //Print the list items using recursive way.
            Console.WriteLine("Print all list element using recursive");
            list.PrintListItemsRecursively();

            //// Insert element at the Begning.
            //list.InsertAtBegning();
            //Console.WriteLine("Elements after Insert a new element at Begning");
            //list.PrintListItemsRecursively();

            //// Insert element at the end.
            //list.InsertAtEnd();
            //Console.WriteLine("Elements after Insert a new element at the end");
            //list.PrintListItemsRecursively();

            //Insert element at middle.
            //list.InserElementAtMiddle();
            //Console.WriteLine("Elements after Insert a new element at the middle");
            //list.PrintListItemsRecursively();

            //Insert element at specific position
            //list.InsertElementAtSpecificPosition();
            //Console.WriteLine("Elements after Insert a new element at specific position");
            //list.PrintListItemsRecursively();

            //Delete an element at the Begning
            //list.DeleteElementAtBegning();
            //Console.WriteLine("Elements after Deleting the element at the begning");
            //list.PrintListItemsRecursively();

            ////Delete an element at the End
            //list.DeleteElementAtEnd();
            //Console.WriteLine("Elements after Deleting the element at the begning");
            //list.PrintListItemsRecursively();

            //Delete an element at the middle
            //list.DeleteElementAtMid();
            //Console.WriteLine("Elements after Deleting the element at middile");
            //list.PrintListItemsRecursively();

            //Delete the element at the speicfic position
            //list.DeleteElementAtSpecificPosition();
            //Console.WriteLine("Elements after Deleting the element at sppecfc position");
            //list.PrintListItemsRecursively();

            // Merge two sorted lists
            //list.MergeTwosortedLists();
            //Console.WriteLine("Elements after merging two lists");
            //list.PrintListItemsRecursively();

            // Check linked list is pallindrome
            //list.isListisPallindrome();

            // Remove duplicates from unsortedList
            //list.RemoveDuplicatesFromUnsortedList();
            //Console.WriteLine("Elements after remvoing duplicates from unsorted list");
            //list.PrintListItemsRecursively();

            // Remove duplicates from sortedList
            //list.RemoveDuplicatesFromSortedList();
            //Console.WriteLine("Elements after remvoing duplicates from sorted list");
            //list.PrintListItemsRecursively();

            // Swap nodes pairwise.
            list.SwapNodesPairwise();
            Console.WriteLine("Elements after swapping the elements pair wise");
            list.PrintListItemsRecursively();

        }
    }
}
