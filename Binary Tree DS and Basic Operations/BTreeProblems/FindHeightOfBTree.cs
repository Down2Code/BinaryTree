using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations.BTreeProblems
{
    public class FindHeightOfBTree
    {
        public static int FindHeightRecursive(BTNode root)
        {
            int leftHeight, rightHeight;
            if (root == null)
                return 0;
            else
            {
                leftHeight = FindHeightRecursive(root.LChild);
                rightHeight = FindHeightRecursive(root.RChild);
                if (leftHeight>rightHeight)
                    return leftHeight + 1;
                else
                    return rightHeight + 1;
            }
        }
        public static int FindHeight(BTNode root)
        {
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            int height = 0;
            if(root!=null)
            {
                btNodeQueue.Enqueue(root);
                btNodeQueue.Enqueue(null);
                while(btNodeQueue.Count>0)
                {
                    var temp = btNodeQueue.Dequeue();
                    if(temp==null)
                    {
                        height++;
                        if (btNodeQueue.Count>0)    
                            btNodeQueue.Enqueue(null);
                        
                    }
                    else
                    {
                        if (temp.LChild != null)
                            btNodeQueue.Enqueue(temp.LChild);
                        if (temp.RChild != null)
                            btNodeQueue.Enqueue(temp.RChild);
                    }
                }
            }
            return height;
        }
    }
}
