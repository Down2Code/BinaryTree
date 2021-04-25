using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations.BTreeProblems
{
    public class FindSizeOfBinaryTree
    {
        public static int FindSizeRecursive(BTNode root)
        {
            if (root == null)
                return 0;
            else return (FindSizeRecursive(root.LChild) + 1 + FindSizeRecursive(root.RChild));

        }
        public static int FindSizeIterative(BTNode root)
        {
            int count = 0;
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            btNodeQueue.Enqueue(root);
            while (btNodeQueue.Count>0)
            {
                var temp = btNodeQueue.Dequeue();
                if (temp != null) count++;
                if (temp?.LChild != null)
                    btNodeQueue.Enqueue(temp.LChild); 
                if (temp?.RChild != null)
                    btNodeQueue.Enqueue(temp.RChild);
            }
            return count;
        }
    }
}
