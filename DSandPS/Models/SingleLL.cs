using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class SingleLL
    {
        private SingleLLNode head = null;
        internal SingleLLNode CreateList(int[] listItems)
        {
            if (listItems == null)
                return head;

            SingleLLNode temp = new SingleLLNode();
            temp.data = listItems[0];

            head = temp;

            for (int i = 1; i < listItems.Length; i++)
            {
                temp.next = new SingleLLNode();
                temp.next.data = listItems[i];

                temp = temp.next;
            }

            return head;
        }

        internal void TraverseAndPrintLL()
        {
            if (head == null) return;

            SingleLLNode temp = head;

            while (temp != null)
            {
                temp.Write();
                temp = temp.next;
            }
        }

        internal void TraverseAndPrintLLInReverse()
        {

            SingleLLNode temp = head;
            TraversesInReverse(temp);

        }

        private void TraversesInReverse(SingleLLNode temp)
        {
            if (temp == null) return;

            TraversesInReverse(temp.next);

            temp.Write();
        }

        internal void InserAtStart()
        {
            Console.WriteLine("Please enter a value to Insert");
            int num = Convert.ToInt32(Console.ReadLine());

            SingleLLNode temp = new SingleLLNode();
            temp.Read(num);

            if (head == null)
            {
                head = temp;
                return;
            }

            temp.next = head;

            head = temp;
        }

        internal void InsertAtEnd()
        {
            Console.WriteLine("Please enter a value to Insert");
            int num = Convert.ToInt32(Console.ReadLine());

            SingleLLNode temp = new SingleLLNode();
            temp.Read(num);

            if (head == null)
            {
                head = temp;
                return;
            }

            else
            {
                SingleLLNode ptr = head;

                while (ptr.next != null)
                {
                    ptr = ptr.next;
                }

                ptr.next = temp;
            }
        }

        internal void InsertAtSpecificPosition(int pos)
        {
            Console.WriteLine("Please enter a value to Insert");
            int num = Convert.ToInt32(Console.ReadLine());

            SingleLLNode temp = new SingleLLNode();
            temp.Read(num);

            if (head == null && pos != 1)
            {
                return;
            }
            else if (head == null && pos == 1)
            {
                head = temp;
                return;
            }
            else
            {
                SingleLLNode ptr = head;
                SingleLLNode x = null;

                int currentPostion = 1;

                while (pos != currentPostion)
                {

                    x = ptr;
                    ptr = ptr.next;
                    currentPostion++;
                }
                x.next = temp;
                temp.next = ptr;
            }

        }

        internal void InsertAtMiddle()
        {
            Console.WriteLine("Please enter a value to Insert");
            int num = Convert.ToInt32(Console.ReadLine());

            SingleLLNode temp = new SingleLLNode();
            temp.Read(num);

            if (head == null)
            {
                head = temp;
                return;
            }

            SingleLLNode p = head;
            SingleLLNode q = p;
            SingleLLNode x = null;

            while (q.next != null && q.next.next != null)
            {
                x = p;
                p = p.next;
                q = q.next.next;
            }

            if (q.next == null)
            {
                x.next = temp;
                temp.next = p;
            }
            else
            {
                x = p.next;
                p.next = temp;
                temp.next = x;
            }
        }

        internal void ReverstLL()
        {
            if (head == null || head.next == null)
                return;

            //Using Recursive
            SingleLLNode temp = head;
            ReverseLLRecursive(temp);

            //SingleLLNode current = head;
            //SingleLLNode prev = null;
            //SingleLLNode next = current.next;

            //while(current != null)
            //{
            //    next = current.next;
            //    current.next = prev;
            //    prev = current;
            //    current = next;
            //}

            //head = prev;
        }

        private SingleLLNode ReverseLLRecursive(SingleLLNode temp)
        {
            if (temp.next == null)
            {
                head = temp;
                return head;
            }

            ReverseLLRecursive(temp.next);

            SingleLLNode q = temp.next;
            q.next = temp;
            temp.next = null;

            return head;
        }

        internal SingleLLNode Merge(SingleLLNode list1, SingleLLNode list2)
        {
            SingleLLNode ptr = null;
            SingleLLNode head = null;

            if (list1 == null && list2 == null)
            {
                return ptr;
            }

            else if (list1 == null && list2 != null)
            {
                return list2;
            }

            else if (list1 != null && list2 == null)
            {
                return list1;
            }

            else
            {
                if (list1.data <= list2.data)
                {
                    head = list1;
                    ptr = head;
                    list1 = list1.next;
                }

                else
                {
                    head = list2;
                    ptr = head;
                    list2 = list2.next;
                }

                while (list1 != null && list2 != null)
                {
                    if (list1.data <= list2.data)
                    {
                        ptr.next = list1;
                        ptr = list1;
                        list1 = list1.next;
                    }

                    else
                    {
                        ptr.next = list2;
                        ptr = list2;
                        list2 = list2.next;
                    }

                }

                if (list1 != null)
                {
                    ptr.next = list1;
                }

                if (list2 != null)
                {
                    ptr.next = list2;
                }
            }

            return head;
        }

        public SingleLLNode SwapNodeInPairs(SingleLLNode list)
        {
            if (list == null || list.next == null)
            {
                return list;
            }
            SingleLLNode p = list;
            SingleLLNode q = null, new_head = null, ptr = null;

            if (p.next != null)
            {
                q = p.next;
                new_head = q;

                ptr = q.next;

                q.next = p;
                if (ptr != null && ptr.next == null)
                {
                    p.next = ptr;
                    return new_head;
                }
                if (ptr == null || ptr.next == null)
                {
                    p.next = ptr;
                    return new_head;
                };

                p.next = ptr.next;

                p = ptr;
            }

            while (p.next != null)
            {
                q = p.next;

                ptr = q.next;

                q.next = p;

                if (ptr != null && ptr.next == null)
                {
                    p.next = ptr;
                    return new_head;
                }
                if (ptr == null || ptr.next == null)
                {
                    p.next = null;
                    return new_head;
                }

                p.next = ptr.next;

                p = ptr;
            }

            return new_head;
        }

        internal SingleLLNode ReverseNodesInKGroup(SingleLLNode list, int k)
        {
            if (list == null || k < 1)
                return list;
            SingleLLNode p = list, q = list, new_head = null, ptr = null, temp;

            int count = 1;
            while (count < k)
            {
                if (q == null)
                {
                    return list;
                }

                count++;
                q = q.next;
            }

            new_head = q;
            ptr = q.next;
            q.next = null;

            p = ReverseLL(p);

            while (q.next != null)
            {
                q = q.next;
            }

            q.next = ptr;

            temp = q;
            p = ptr;
            q = p;

            count = 1;
            while (q != null)
            {
                if (count == k)
                {
                    count = 1;
                    ptr = q.next;
                    q.next = null;
                    p = ReverseLL(p);
                    temp.next = p;

                    while (q.next != null)
                    {
                        q = q.next;
                    }
                    temp = q;
                    q.next = ptr;
                    q = ptr;
                    p = ptr;
                }

                count++;

                if (q == null)
                {
                    return new_head;
                }
                q = q.next;

            }

            return new_head;
        }

        private SingleLLNode ReverseLL(SingleLLNode temp)
        {
            if (temp == null || temp.next == null)
                return temp;

            SingleLLNode current = temp;
            SingleLLNode prev = null;
            SingleLLNode next = current.next;

            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            temp = prev;

            return temp;
        }

        internal SingleLLNode RotateRight(SingleLLNode head, int k)
        {
            // Check if list is empty (or) having only one element.
            if (head == null || head.next == null || k <= 0)
            {
                return head;
            }

            SingleLLNode p = head;
            SingleLLNode q = null;

            // If K element is greater than length of the list then we need loop only k % length times (as it repats the same)
            // Get length of the list
            int length = LinkedListLength(head);

            k = k > length ? k % length : k;
            // Loop through K times and rotate the list.
            while (k > 0)
            {
                k--;
                while (p.next != null)
                {
                    q = p;
                    p = p.next;
                }
                q.next = null; // Removing Last element.
                               //Insert the removed node (p) at the begining
               head = insertAtBegining(head, p);

            }

            return head;
        }

        private int LinkedListLength(SingleLLNode head)
        {
            SingleLLNode temp = head;
            int result = 0;

            while (temp != null)
            {
                result++;

                temp = temp.next;
            }

            return result;
        }

        public SingleLLNode insertAtBegining(SingleLLNode head, SingleLLNode val)
        {
            if (head == null)
            {
                head = val;
                return head;
            }

            if (val == null)
            {
                return head;
            }

            val.next = head;
            head = val;

            return head;

        }
    }
}
