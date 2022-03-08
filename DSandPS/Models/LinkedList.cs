using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class LinkedList
    {
        ListNode head;
        public LinkedList()
        {
            head = null;
        }

        public ListNode createLL(int[] arr)
        {
            if (arr.Length < 1)
            {
                Console.WriteLine("Invalid input");
                return head;
            }

            int i = 0;

            ListNode node = new ListNode();
            node.Read(arr[i]);
            head = node;

            ListNode temp = head;
            for (i = 1; i < arr.Length; i++)
            {
                temp.next = new ListNode();
                temp.next.Read(arr[i]);

                temp = temp.next;
            }
            return head;
        }

        public void print()
        {
            if (head == null)
            {
                Console.WriteLine("Empty list");
                return;
            }

            ListNode temp = head;

            while (temp != null)
            {
                temp.Print();
                temp = temp.next;
            }
        }

        internal void PritnRecursivly()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            if (head.next == null)
            {
                head.Print();
            }

            ListNode temp = head;

            printListRecursively(temp);
        }

        private void printListRecursively(ListNode temp)
        {
            if (temp == null)
            {
                return;
            }
            temp.Print();
            printListRecursively(temp.next);
        }

        public void reverseLL()
        {
            if (head == null)
            {
                Console.WriteLine("Empty list");
                return;
            }

            if (head.next == null)
            {
                return;
            }

            ListNode temp = head;

            ListNode currentNode = temp;
            ListNode previousNode = null;
            ListNode nextNode = currentNode.next;

            while (currentNode.next != null)
            {
                currentNode.next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
                nextNode = currentNode.next;

            }

            currentNode.next = previousNode;

            head = currentNode;
        }

        public void reverseLLRecusiveLogic()
        {
            ListNode temp = head;
            reverseListRecursive(head);
        }

        private ListNode reverseListRecursive(ListNode temp)
        {
            if (temp.next == null)
            {
                head = temp;
                return head;
            }

             reverseListRecursive(temp.next);

            ListNode q = temp.next;
            q.next = temp;
            temp.next = null;

            return head;
        }

        internal ListNode AddTWoNumbers(ListNode firstList, ListNode secondList)
        {
            ListNode sumList = null;
            ListNode ptrList = null;

            // Make sure two list are not empty, if empty return the non empty list.
            // Make sure two liss are of the same size else add 0s at the begning.
            // For single linked list we can move only in one direction, but addition should happne from right so reverse the both the linked lists
            // Declare few variables that are useful to carry reminder and divideby zero value.
            //

            if (firstList == null && secondList == null)
            {
                return sumList;
            }

            if (firstList == null || secondList == null)
            {
                if (firstList == null)
                {
                    return secondList;
                }
                else
                {
                    return firstList;
                }
            }

            // Check size of the lists
            int firstListSize = 0, secondListSize = 0;
            checkLLSize(firstList, secondList, out firstListSize, out secondListSize);

            if (firstListSize != secondListSize)
            {
                int diff = 0;
                if (firstListSize < secondListSize)
                {
                    diff = secondListSize - firstListSize;
                    firstList = addZerostoList(firstList, diff);
                }
                else
                {
                    diff = firstListSize - secondListSize;
                    secondList = addZerostoList(secondList, diff);
                }
            }

            //Reverse the lniked lists
            //ListNode revFirstList = reverseListRecursive(firstList);
            //ListNode revSecondList = reverseListRecursive(secondList);

            // loop through all the elements
            ListNode tempFirstList = firstList;
            ListNode tempSecondList = secondList;

            int carry = 0;
            while (tempFirstList != null)
            {               

                int sum = tempFirstList.data + tempSecondList.data + carry;

                int dividebyZeroValue = sum / 10;
                int reminder = sum % 10;
                carry = dividebyZeroValue;
                int newnodeValue = 0;


                if(dividebyZeroValue != 0)
                {
                    newnodeValue = reminder;
                }
                else
                {
                    newnodeValue = sum;
                }
                //cretae a node
                ListNode temp = new ListNode();
                temp.Read(newnodeValue);

                if (sumList == null)
                {
                    sumList = temp;
                    ptrList = sumList;
                }
                else
                {
                    ptrList.next = temp;
                    ptrList = ptrList.next;
                }

                tempFirstList = tempFirstList.next;
                tempSecondList = tempSecondList.next;
            }

            if(carry != 0)
            {
                //cretae a node
                ListNode temp = new ListNode();
                temp.Read(carry);

                ptrList.next = temp;
                ptrList = ptrList.next;
            }



            return sumList;
        }

        private ListNode addZerostoList(ListNode list, int diff)
        {
            ListNode temp = list;

            while(temp.next != null)
            {
                temp = temp.next;
            }

            while (diff > 0)
            {
                //create a node
                ListNode ptr = new ListNode();
                temp.next = ptr;
                temp = temp.next;
                diff--;
            }

            return list;
        }

        private void checkLLSize(ListNode firstList, ListNode secondList, out int firstListSize, out int secondListSize)
        {
            firstListSize = checkLLLength(firstList);
            secondListSize = checkLLLength(secondList);
        }

        private int checkLLLength(ListNode list)
        {
            int count = 0;

            while (list != null)
            {
                count++;
                list = list.next;
            }

            return count;
        }
    }
}
