using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class SingleLLNode
    {
        public int data { get; set; }
        public SingleLLNode next { get; set; }

        public void Read(int val)
        {
            this.data = val;
            this.next = null;
        }

        public void Write()
        {
            Console.Write(this.data +"-> ");
        }
    }
}
