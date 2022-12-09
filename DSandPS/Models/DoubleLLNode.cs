using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{
    internal class DoubleLLNode
    {
        public int data { get; set; }
        public DoubleLLNode right { get; set; }
        public DoubleLLNode left { get; set; }

        public void Read(int val)
        {
            this.data = val; ;
            this.right = null;
            this.left = null;
        }

        public void Write()
        {
            Console.WriteLine(this.data + " -->");
        }
    }
}
