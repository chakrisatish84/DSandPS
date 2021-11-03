using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class SingleLinkedList
    {
        SingleListNode head;
        public SingleLinkedList()
        {
            head = null;
        }

        public SingleListNode create(int[] arr)
        {
            if (arr.Length == 0)
            {
                return null;
            }
            int listItem = 0;

            head = new SingleListNode();
            head.read(arr[listItem]);

            SingleListNode temp = head;

            for (listItem = 1; listItem < arr.Length; listItem++)
            {
                temp.next = new SingleListNode();
                temp.next.read(arr[listItem]);
                temp = temp.next;
            }

            return head;
        }

        public void PrintListElements()
        {
            if (head == null)
                Console.WriteLine("Select list is empty");

            SingleListNode temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.data + "\t");
                temp = temp.next;
            }
        }

        public void PrintListItemsRecursively()
        {
            PritnRecursivly(head);
        }

        public void PritnRecursivly(SingleListNode ptr)
        {
            if (ptr == null)
                return;

            Console.WriteLine(ptr.data + "\t");
            PritnRecursivly(ptr.next);
        }


        public void ReverseLinkedListRecursively()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if (head.next == null)
            {
                return;  //nothing to reverse
            }
            SingleListNode temp = head;
            reverseListRecursively(temp);
        }

        private SingleListNode reverseListRecursively(SingleListNode ptr)
        {
            if (ptr.next == null)
            {
                head = ptr;
                return head;
            }
            reverseListRecursively(ptr.next);

            SingleListNode q = ptr.next;
            q.next = ptr;
            ptr.next = null;

            return head;
        }

        internal void ReverseLinkedListitterative()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            if (head.next == null)
            {
                return;
            }

            SingleListNode currentElement = head;
            SingleListNode nextElement = null;
            SingleListNode previousElement = null;

            while (currentElement != null)
            {
                nextElement = currentElement.next;
                currentElement.next = previousElement;
                previousElement = currentElement;
                currentElement = nextElement;

            }

            head = previousElement;
        }

        internal void InsertAtBegning()
        {
            SingleListNode newElement = new SingleListNode();
            Console.WriteLine("Enter a new element");
            newElement.read(int.Parse(Console.ReadLine()));

            if (head == null)
            {
                head = newElement;
                return;
            }

            SingleListNode temp = head;

            newElement.next = temp;
            head = newElement;

        }

        internal void InsertAtEnd()
        {
            SingleListNode newElement = new SingleListNode();
            Console.WriteLine("Enter a new element to add at the end");
            newElement.read(int.Parse(Console.ReadLine()));

            //If head is null set new element as head and return.
            if (head == null)
            {
                head = newElement;
                return;
            }

            // Else find the last element and add the new element at the end.
            SingleListNode temp = head;

            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = newElement;
        }

        internal void InserElementAtMiddle()
        {
            SingleListNode newElement = new SingleListNode();
            Console.WriteLine("Enter a new element to add at the middle");
            newElement.read(int.Parse(Console.ReadLine()));

            //If head is null set new element as head and return.
            if (head == null)
            {
                head = newElement;
                return;
            }

            SingleListNode p = head;
            SingleListNode q = head;
            SingleListNode x = null;

            while (q.next != null && q.next.next != null)
            {
                x = p;
                p = p.next;
                q = q.next.next;
            }

            if (q.next != null)
            {
                x = p.next;
                p.next = newElement;
                newElement.next = x;
            }
            else
            {
                x.next = newElement;
                newElement.next = p;
            }
        }

        internal void InsertElementAtSpecificPosition()
        {
            SingleListNode newElement = new SingleListNode();
            Console.WriteLine("Enter an new element value to insert at specific position");
            newElement.read(int.Parse(Console.ReadLine()));

            Console.WriteLine("Enter a new element posiiton to insert");
            int position;
            bool isPositionValueisNumber = int.TryParse(Console.ReadLine(), out position);

            if (position < 0 || !isPositionValueisNumber || (head == null && position != 1))
            {
                Console.WriteLine("Enter a valid position to insert an element");
                return;
            }

            int currentPosition = 1;
            bool positionFound = false;

            SingleListNode temp = head;
            SingleListNode ptr = null;

            while (temp != null)
            {
                if (position == currentPosition)
                {
                    positionFound = true;
                    if (position == 1)
                    {
                        newElement.next = temp;
                        head = newElement;
                    }
                    else
                    {
                        ptr.next = newElement;
                        newElement.next = temp;
                    }
                    return;
                }
                currentPosition++;
                ptr = temp;
                temp = temp.next;
            }
            if (!positionFound)
            {
                Console.WriteLine("Specific position is not available in this list");
            }
        }
        internal void DeleteElementAtBegning()
        {
            // Check if list is empty.
            if (head == null)
            {
                Console.WriteLine("List is empty and nothing to delete");
                return;
            }
            // If list is having only element Delete that and make list empty
            else if (head.next == null)
            {
                Console.WriteLine("List is empty after deleting the element");
                return;
            }

            SingleListNode temp = head;
            head = temp.next;
        }

        internal void DeleteElementAtEnd()
        {
            // Check if list is empty.
            if (head == null)
            {
                Console.WriteLine("List is empty and nothing to delete");
                return;
            }
            // If list is having only element Delete that and make list empty
            else if (head.next == null)
            {
                Console.WriteLine("List is empty after deleting the element");
                return;
            }

            SingleListNode ptr = head;
            SingleListNode x = null;
            while (ptr.next != null)
            {
                x = ptr;
                ptr = ptr.next;
            }
            x.next = null;
        }

        internal void DeleteElementAtMid()
        {
            // check if list is empty 
            if (head == null)
            {
                Console.WriteLine("List is empty and nothing to delete");
                return;
            }

            SingleListNode p = head;

            //check if list is having one element
            if (p != null && p.next == null)
            {
                Console.WriteLine("List is empty after deleting the mid element");
                head = null;
                return;
            }

            //check if list is having two elements
            if (p.next != null && p.next.next == null)
            {
                head = p.next;
                return;
            }

            SingleListNode q = p;
            SingleListNode x = null;

            while (q.next != null && q.next.next != null)
            {
                x = p;
                p = p.next;
                q = q.next.next;
            }

            x.next = p.next;
        }

        internal void DeleteElementAtSpecificPosition()
        {
            // Check list is empty
            if (head == null)
            {
                Console.WriteLine("List is empty and nothing to delete");
                return;
            }

            //Read the position
            Console.WriteLine("Enter the position value to remove");
            int position;
            bool isNumber = int.TryParse(Console.ReadLine(), out position);

            // Check if specific position is not valid
            if (!isNumber || position <= 0)
            {
                Console.WriteLine("Enter a valid poistion value to delete");
                return;
            }

            // If position value is One, Need to set the new head value
            if (position == 1 && head.next == null) // Only one element
            {
                head = null;
                return;
            }

            SingleListNode p = head;
            if (position == 1) // If position is 1, update the head value
            {

                head = p.next;
                return;
            }

            int currentPositon = 1;
            SingleListNode x = null;

            bool positionFindIntheList = false;

            while (p != null)
            {
                if (position == currentPositon)
                {
                    positionFindIntheList = true;
                    break;
                }
                x = p;
                p = p.next;
                currentPositon++;
            }

            if (!positionFindIntheList)
            {
                Console.WriteLine("The specific postion is not found in the list");
            }
            else
            {
                x.next = p.next;
            }
        }

        internal void MergeTwosortedLists()
        {
            SingleListNode firstList = create(new int[] { 1, 5, 8, 12, 15 });
            SingleListNode secondList = create(new int[] { 2, 3, 7, 9, 20 });

            SingleListNode sortList = null;

            //Check both lists are not empty
            if (firstList == null && secondList == null)
            {
                Console.WriteLine("Both list are empty and noting merge");
                return;
            }

            if (firstList != null && secondList == null)
            {
                head = firstList;
                return;
            }
            else if (firstList == null && secondList != null)
            {
                head = secondList;
                return;
            }

            if (firstList.data <= secondList.data)
            {
                sortList = firstList;
                firstList = firstList.next;
            }
            else
            {
                sortList = secondList;
                secondList = secondList.next;
            }

            SingleListNode temp = sortList;
            while (firstList != null && secondList != null)
            {
                if (firstList.data <= secondList.data)
                {
                    temp.next = firstList;
                    temp = temp.next;
                    firstList = firstList.next;
                }
                else
                {
                    temp.next = secondList;
                    temp = temp.next;
                    secondList = secondList.next;
                }
            }

            if (firstList != null)
            {
                temp.next = firstList;
            }
            else
            {
                temp.next = secondList;
            }

            head = sortList;
        }

        /// <summary>
        /// Check the link list is pallindrome
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        internal void isListisPallindrome()
        {
            if (head == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }
            SingleListNode temp = head;

            if (temp.next == null)
            {
                Console.WriteLine("It is pallindrome");
                return;
            }

            ////Using Stack (it might take extra space for creating a stack).

            //// Create a stack to stort list element
            //Stack<int> lstStack = new Stack<int>();

            //while(temp != null)
            //{
            //    lstStack.Push(temp.data);
            //    temp = temp.next;
            //}

            //temp = head;
            //while(temp != null)
            //{
            //    int currentValueFromStock = lstStack.Pop();

            //    if(temp.data != currentValueFromStock)
            //    {
            //        Console.WriteLine("This list is not a pallindrome");
            //        return;
            //    }

            //    temp = temp.next;
            //}
            //Console.WriteLine("This list is a Pallindrome");

            SingleListNode p = head;
            SingleListNode q = head;
            SingleListNode x = null;

            // Find the middle element.
            while (q.next != null && q.next.next != null)
            {
                x = p;
                p = p.next;
                q = q.next.next;
            }

            // list has even nodes
            if (q.next != null)
            {
                x = p.next;
                p.next = null;
            }
            else
            {
                x.next = null;
                x = p.next;
                p.next = null;
            }

            bool isListsSame = false;

            compareTwolists(head, x, out isListsSame);

            if (isListsSame)
            {
                Console.WriteLine("list is pallindrome");
            }
            else
            {
                Console.WriteLine("list is not a pallindrome");
            }

        }

        private void compareTwolists(SingleListNode list1, SingleListNode list2, out bool isListsSame)
        {
            isListsSame = true;
            // if both list are empty
            // we may treate two lists are same
            if (list1 == null && list2 == null)
            {
                return;
            }

            if (list1 == null || list2 == null)
            {
                isListsSame = false;
                return;
            }
            else
            {
                list2 = reverseListRecursively(list2);
            }

            while (list1 != null && list2 != null)
            {
                if (list1.data != list2.data)
                {
                    isListsSame = false;
                    return;
                }

                list1 = list1.next;
                list2 = list2.next;
            }

            //Check if any list is not empty
            if (list1 != null || list2 != null)
            {
                isListsSame = false;
                return;
            }
        }


        internal void RemoveDuplicatesFromUnsortedList()
        {
            if (head == null || head.next == null)
            {
                Console.WriteLine("List is not having duplicates nodes");
                return;
            }

            // Remove duplicates using Hash set (TC: O(n)

            #region withHastSet

            //HashSet<int> hs = new HashSet<int>();

            //SingleListNode current = head;
            //SingleListNode previous = null;
            //while (current != null)
            //{
            //    if (hs.Contains(current.data))
            //    {
            //        previous.next = current.next;
            //    }
            //    else
            //    {
            //        hs.Add(current.data);
            //        previous = current;
            //    }
            //    current = current.next;
            //}
            #endregion

            #region withoutHashset
            SingleListNode p = head;
            SingleListNode q = null;
            SingleListNode x = p;
            SingleListNode prev = null;
            bool isDuplicateFound = false;
            int position = 1;

            while (p.next != null)
            {
                isDuplicateFound = false;
                q = p.next;
                while (q != null)
                {
                    //check q and p nodes are same.
                    if (p.data == q.data)
                    {
                        isDuplicateFound = true;
                        x = p.next;

                        // if postion is 1 we need to change the head too.
                        if (position == 1)
                        {
                            p = x; // Move P to next element (ignore the first element as that is duplicate to other).
                            head = p; // Make second element as head.
                            break;
                        }
                        prev.next = x;
                        p = x;

                        break;
                    }
                    else
                    {
                        q = q.next;
                    }
                }
                if (!isDuplicateFound)
                {
                    prev = p; // If we find duplicate element from second position , keep the previous element to get a connection.
                    p = p.next;
                    x = p;
                    position++;
                }
            }
            #endregion
        }


        internal void RemoveDuplicatesFromSortedList()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            if (head != null && head.next == null)
            {
                Console.WriteLine("List is is having only one element and that is sorted");
                return;
            }

            SingleListNode p = head;
            SingleListNode q = null;

            while (p != null & p.next != null)
            {
                if (p.data != p.next.data)
                {
                    p = p.next;
                }
                else
                {
                    q = p.next.next;
                    p.next = q;

                    if (p.next == null)
                    {
                        break;
                    }
                }
            }
        }

        internal void SwapNodesPairwise()
        {
            if (head == null || head.next == null)
            {
                Console.WriteLine("List is empty (or) have only one element");
                return;
            }

            SingleListNode p = head;
            SingleListNode q = null;
            SingleListNode ptr = null;
            SingleListNode new_header = null;

            new_header = p.next;

            while (p.next != null)
            {
                q = p.next;
                ptr = q.next;
                q.next = p;

                if (ptr == null || ptr.next == null)
                {
                    //If list is odd number last node exists and need keep as is
                    if (ptr != null)
                    {
                        p.next = ptr;
                        p.next.next = null;
                        break;
                    }
                    else
                    {
                        p.next = null;
                        break;
                    }
                }
                p.next = ptr.next;
                p = ptr;
            }

            head = new_header;
        }
    }
}
