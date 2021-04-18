using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations.BTreeProblems
{
    /// <summary>
    /// Level order traversal to insert node which has LChild or RChild null 
    /// </summary>
    public class InsertIntoBinaryTree
    {
        public static void InsertNode(BTNode root, int data)
        {
            if (root == null)
            {
                root = new BTNode(data);
                return;
            }
            else
            {
                Queue<BTNode> btNodeQueue = new Queue<BTNode>();
                btNodeQueue.Enqueue(root);
                while (btNodeQueue.Count > 0)
                {
                    var temp = btNodeQueue.Dequeue();
                    if (temp.LChild != null)
                        btNodeQueue.Enqueue(temp.LChild);
                    else
                    {
                        temp.LChild = new BTNode(data);
                        return;
                    }
                    if (temp.RChild != null)
                        btNodeQueue.Enqueue(temp.RChild);
                    else
                    {
                        temp.RChild = new BTNode(data);
                        return;
                    }
                }
            }
        }
    }
}
