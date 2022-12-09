using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DSandPS.Models
{

    internal class BinarySearchTree
    {
        DoubleLLNode head;

        public BinarySearchTree()
        {
            head = null;
        }

        internal DoubleLLNode CreateBST(int[] items)
        {
            head = null;
            if (items.Length == 0)
            {
                return head;
            }

            for (int i = 0; i < items.Length; i++)
            {
                head = CreateBST(head, items[i]);
            }

            return head;
        }

        private DoubleLLNode CreateBST(DoubleLLNode root, int val)
        {
            if (root == null)
            {
                DoubleLLNode temp = new DoubleLLNode();
                temp.data = val;

                root = temp;
                return root;
            }

            if (root.data > val)
            {
                root.left = CreateBST(root.left, val);
            }
            else
            {
                root.right = CreateBST(root.right, val);
            }

            return root;
        }

        public void BSTTraversal()
        {
            //BFS (Level order traversal)
            //this.BFSTraversal();

            // DFS (Depth first search Traversal)
            DoubleLLNode temp = head;
            //this.DFSInorderTraversal(temp);  // Same logic for other too, just need to update root.write() position

            //Spiral order (or) Zig zag order traversal (We need to use two stacks for this one)
            this.SpiralOrderTraversal(temp);
        }

        private void SpiralOrderTraversal(DoubleLLNode root)
        {
            if (root == null) { return; }

            Stack<DoubleLLNode> stack1 = new Stack<DoubleLLNode>();
            Stack<DoubleLLNode> stack2 = new Stack<DoubleLLNode>();

            stack1.Push(root);
            while (stack1.Count > 0 || stack2.Count > 0)
            {
                while (stack1.Count > 0)
                {
                    DoubleLLNode ptr1 = stack1.Peek();
                    ptr1.Write();

                    if (ptr1.left != null) stack2.Push(ptr1.left);
                    if (ptr1.right != null) stack2.Push(ptr1.right);
                    stack1.Pop();
                }

                while (stack2.Count > 0)
                {
                    DoubleLLNode ptr2 = stack2.Peek();
                    ptr2.Write();

                    if (ptr2.right != null) stack1.Push(ptr2.right);
                    if (ptr2.left != null) stack1.Push(ptr2.left);
                    stack2.Pop();

                }
            }
        }

        private void DFSInorderTraversal(DoubleLLNode root)
        {
            if (root == null)
            {
                return;
            }

            DFSInorderTraversal(root.left);
            root.Write();
            DFSInorderTraversal(root.right);
        }

        private void BFSTraversal()
        {
            if (head == null)
            {
                Console.WriteLine("Nothing to print");
                return;
            }

            if (head.right == null)
            {
                head.Write();
                return;
            }
            DoubleLLNode temp = head;
            Queue<DoubleLLNode> queue = new Queue<DoubleLLNode>();
            queue.Enqueue(temp);

            while (queue.Count > 0)
            {
                DoubleLLNode ptr = queue.Peek();
                ptr.Write();
                if (ptr.left != null)
                {
                    queue.Enqueue(ptr.left);
                }
                if (ptr.right != null)
                {
                    queue.Enqueue(ptr.right);
                }

                queue.Dequeue();
            }

        }

        internal int FindInorderPredecessor(int num)
        {
            int result = -1;

            if (head == null) return result;
            DoubleLLNode root = head;

            DoubleLLNode predecessor = null;
            // Find the eleement from root
            while (root.data != num)
            {
                if (root.data > num)
                {
                    root = root.left;
                }
                else
                {
                    predecessor = root;
                    root = root.right;
                }
            }

            if (predecessor != null)
            {
                result = predecessor.data;
            }

            else if (predecessor == null && root.left != null)
            {
                DoubleLLNode temp = FindMax(root.left);
                result = temp.data;
            }

            return result;
        }

        private DoubleLLNode FindMax(DoubleLLNode root)
        {
            while (root.right != null)
            {
                root = root.right;
            }
            return root;
        }

        private DoubleLLNode FindMin(DoubleLLNode root)
        {
            while (root.left != null)
            {
                root = root.left;
            }
            return root;
        }

        internal void numberBSTTrees(int num)
        {
            int[] possibleArray = new int[num + 1];

            possibleArray[0] = 1;
            possibleArray[1] = 1;

            for (int i = 2; i <= num; i++)
            {
                possibleArray[i] = 0;

                for (int j = 0; j < i; j++)
                {
                    possibleArray[i] += possibleArray[j] * possibleArray[i - j - 1];
                }
            }
            Console.WriteLine("Possible BST with this num " + num + "is " + possibleArray[num]);
        }

        internal void DeleteNodeFromBST(int val)
        {
            if (head == null)
            {
                return;
            }

            head = DeleteNSTNode(head, val);
        }

        private DoubleLLNode DeleteNSTNode(DoubleLLNode head, int val)
        {
            if (head == null)
                return head;

            if (head.data > val)
                head.left = DeleteNSTNode(head.left, val);
            else if (head.data < val)
            {
                head.right = DeleteNSTNode(head.right, val);

            }

            else
            {
                if (head.left == null && head.right == null)
                {
                    head = null;
                }

                else if (head.left != null && head.right == null)
                {
                    head = head.left;
                }

                else if (head.right != null && head.left == null)
                {
                    head = head.right;
                }
                else
                {
                    DoubleLLNode maxNode = FindMax(head.left);
                    head.data = maxNode.data;
                    head.left = DeleteNSTNode(head.left, maxNode.data);
                }
            }

            return head;
        }

        internal int heightOfBST(DoubleLLNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftTreeHeight = heightOfBST(root.left);
            int rightTreeHeight = heightOfBST(root.right);

            return Math.Max(leftTreeHeight, rightTreeHeight) + 1;
        }

        internal int DiameterofaBST(DoubleLLNode root)
        {

            if (root == null)
            {
                return 0;
            }

            int leftHeight = heightOfBST(root.left);
            int rightHeight = heightOfBST(root.right);

            int leftDiameter = DiameterofaBST(root.left);
            int righDiameter = DiameterofaBST(root.right);

            int diameterResult = Math.Max(leftHeight + rightHeight + 1, Math.Max(leftDiameter, righDiameter));

            return diameterResult;
        }

        internal bool isIso(DoubleLLNode root1, DoubleLLNode root2)
        {
            if (root1 == null && root2 == null)
            {
                return true;
            }

            else if (root1 == null || root2 == null)
            {
                return false;
            }

            else if (root1.data != root2.data)
            {
                return false;
            }

            else
            {
                if ((isIso(root1.left, root2.left) && isIso(root1.right, root2.right)) || ((isIso(root1.left, root2.right) && isIso(root1.right, root2.left))))
                {
                    return true;
                }
            }

            return false;
        }

        internal int printNodesHavingKNodes(DoubleLLNode root, int key)
        {
            if(root == null)
            {
                return 0;
            }
            if(root.left == null && root.right == null)
            {
                return 1;
            }

            int leftCount = printNodesHavingKNodes(root.left, key);
            int rightCount = printNodesHavingKNodes(root.right, key);

            int totalCount = leftCount + +rightCount;

            if(totalCount == key)
            {
                Console.WriteLine(root.data +",");
            }

            return totalCount;
        }
    }
}
