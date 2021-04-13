using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations.BTProblems
{
    public class FindMaxInBTree
    {
        public static int FindMaxRecursive(BTNode root)
        {
            int max = 0;
            int leftMax=0, rightMax = 0;
            if(root!=null)
            {
                leftMax = FindMaxRecursive(root.LChild);
                rightMax = FindMaxRecursive(root.RChild);
                if (leftMax > rightMax)
                    max = leftMax;
                else
                    max = rightMax;
                if (root.Data > max)
                    max = root.Data;
            }
            return max;
        }
        public static int FinMaxIterative(BTNode root)
        {
            int max = 0;
            Queue<BTNode> btNodesQueue = new Queue<BTNode>();
            if(root!=null)
            {
                btNodesQueue.Enqueue(root);
                while(btNodesQueue.Count>0)
                {
                    var temp = btNodesQueue.Dequeue();
                    if (temp.Data > max)
                        max = temp.Data;
                    if (temp.LChild!=null) btNodesQueue.Enqueue(temp.LChild);
                    if (temp.RChild != null) btNodesQueue.Enqueue(temp.RChild);
                }
            }
            return max;
        }
    }
}
