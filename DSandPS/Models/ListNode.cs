using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class ListNode
    {
        public int data { get; set; }
        public ListNode next { get; set; }

        public ListNode()
        {
            this.data = 0;
            next = null;
        }

        public void Read(int value)
        {
            this.data = value;
        }

        public void Print()
        {
            Console.WriteLine("\t" + this.data);
        }
    }
}
