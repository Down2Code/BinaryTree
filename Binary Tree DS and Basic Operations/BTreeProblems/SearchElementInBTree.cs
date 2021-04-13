using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations.BTreeProblems
{
    public class SearchElementInBTree
    {
        public static int SearchRecursive(BTNode root,int key)
        {
            if (root == null)
                return 0;
            else
            {
                if (root.Data == key)
                    return 1;
                int temp = SearchRecursive(root.LChild, key);
                if (temp != 0)
                    return temp;
                else
                    return SearchRecursive(root.RChild, key);
            }
        }
        public static int SearchIterative(BTNode root,int key)
        {
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            if(root!=null)
            {
                btNodeQueue.Enqueue(root);
                while(btNodeQueue.Count>0)
                {
                    var temp = btNodeQueue.Dequeue();
                    if (temp.Data == key)
                        return 1;
                    if (temp.LChild != null)
                        btNodeQueue.Enqueue(temp.LChild);
                    if (temp.RChild != null)
                        btNodeQueue.Enqueue(temp.RChild);
                }
            }
            return 0;
        }
    }
}
