using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations
{
    public class TreeTraversals
    {
        #region fields
        private static Stack<BTNode> btNodeStack;
        #endregion
        #region PreOrder
        /// <summary>
        /// DLR iteraive
        /// </summary>
        public static void PreOrderRec(BTNode root)
        {
            if (root != null)
            {
                Console.Write($"{ root.Data} ");
                InOrderRec(root.LChild);
                InOrderRec(root.RChild);
            }
        }
        /// <summary>
        /// DLR Iterative
        /// </summary>
        public static void PreOrder(BTNode root)
        {
            btNodeStack = new Stack<BTNode>();
            while (true)
            {
                while (root != null)
                {
                    Console.Write($"{ root.Data} ");
                    btNodeStack.Push(root);
                    root = root.LChild;
                }
                if (btNodeStack.Count == 0)
                    break;
                root = btNodeStack.Pop();
                root = root.RChild;
            }
        }
        #endregion
        #region InOrder
        /// <summary>
        /// LDR Recursive
        /// </summary>
        /// <param name="root"></param>
        public static void InOrderRec(BTNode root)
        {
            if (root != null)
            {
                InOrderRec(root.LChild);
                Console.Write($"{ root.Data} ");
                InOrderRec(root.RChild);
            }
        }
        /// <summary>
        /// LDR iterative
        /// </summary>
        public static void InOrder(BTNode root)
        {
            btNodeStack = new Stack<BTNode>();
            while (true)
            {
                while (root != null)
                {
                    btNodeStack.Push(root);
                    root = root.LChild;
                }
                if (btNodeStack.Count == 0)
                    break;
                root = btNodeStack.Pop();
                Console.Write($"{root.Data} ");
                root = root.RChild;
            }

        }
        #endregion
        #region PostOrder
        /// <summary>
        /// LRD Recursive
        /// </summary>
        public static void PostOrderRec(BTNode root)
        {
            if (root != null)
            {
                InOrderRec(root.LChild);
                InOrderRec(root.RChild);
                Console.Write($"{ root.Data} ");
            }
        }

        /// <summary>
        /// LRD Iterative
        /// </summary>
        public static void PostOrder(BTNode root)
        {
            btNodeStack = new Stack<BTNode>();
            BTNode previous = null;
            do
            {
                while (root != null)
                {
                    btNodeStack.Push(root);
                    root = root.LChild;
                }
                while (root == null && btNodeStack.Count != 0)
                {
                    root = btNodeStack.Peek();
                    if (root.RChild == null || root.RChild == previous)
                    {
                        Console.Write($"{root.Data} ");
                        previous = root;
                        btNodeStack.Pop();
                        root = null;
                    }
                    else
                        root = root.RChild;
                }

            } while (btNodeStack.Count != 0);
        }
        #endregion
        #region LevelOrder
        /// <summary>
        /// Level Order Iterative
        /// </summary>
        public static void LevelOrder(BTNode root)
        {
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            if (root != null)
            {
                btNodeQueue.Enqueue(root);
                while (btNodeQueue.Count > 0)
                {
                    var temp = btNodeQueue.Dequeue();
                    Console.Write($"{temp.Data} ");
                    if (temp.LChild != null) btNodeQueue.Enqueue(temp.LChild);
                    if (temp.RChild != null) btNodeQueue.Enqueue(temp.RChild);
                }
            }
        }
        #endregion   
    }
}
