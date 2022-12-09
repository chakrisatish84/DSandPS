using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class DoubleLL
    {
        private DoubleLLNode head;

        public DoubleLL()
        {
            head = null;
        }

        public DoubleLLNode Create(int[] arrayItems)
        {
            if (arrayItems.Length == 0) return head;

            DoubleLLNode temp = new DoubleLLNode();
            temp.data = arrayItems[0];

            head = temp;

            for (int i = 1; i < arrayItems.Length; i++)
            {
                temp.right = new DoubleLLNode();
                temp.right.data = arrayItems[i];
                temp.right.left = temp;
                temp = temp.right;
            }

            return head;
        }

        public void traverseDoubleLLFromStart()
        {
            if (head == null) return;

            DoubleLLNode ptr = head;

            while (ptr != null)
            {
                ptr.Write();
                ptr = ptr.right;
            }
        }

        public void InsertAtStart()
        {
            Console.WriteLine("\n Please enter a value to insert");

            int value = Convert.ToInt32(Console.ReadLine());

            DoubleLLNode temp = new DoubleLLNode();
            temp.data = value;

            if (head == null)
            {
                head = temp;
                return;
            }

            temp.right = head;
            temp.right.left = temp;
            head = temp;
        }


        public void InsertAtEnd()
        {
            Console.WriteLine("\n Please enter a value to insert");

            int value = Convert.ToInt32(Console.ReadLine());

            DoubleLLNode temp = new DoubleLLNode();
            temp.data = value;

            if (head == null)
            {
                head = temp;
                return;
            }

            DoubleLLNode ptr = head;

            while (ptr.right != null)
            {
                ptr = ptr.right;
            }

            ptr.right = temp;
            temp.left = ptr;
        }

        public void reverseLL()
        {
            if (head == null) return;

            DoubleLLNode p = head;
            DoubleLLNode q = null;

            while(p != null)
            {
                q = p.right;

                p.right = p.left;
                p.left = q;
                if(p.left == null)
                {
                    head = p;
                }
                p = p.left;
            }
        }

    }
}
