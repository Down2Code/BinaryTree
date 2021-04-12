using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations
{
    public static class TreeTraversals
    {
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
                Console.WriteLine(root.Data);
                InOrderRec(root.RChild);
            }
        }
        /// <summary>
        /// LDR iterative
        /// </summary>
        public static void InOrder()
        {

        }
        #endregion
        #region PostOrder
        /// <summary>
        /// LRD Recursive
        /// </summary>
        public static void PostOrderRec()
        {

        }
       
        /// <summary>
        /// LRD Iterative
        /// </summary>
        public static void PostOrder()
        {

        }
        #endregion
        #region PreOrder
        /// <summary>
        /// DLR Iterative
        /// </summary>
        public static void PreOrder()
        {

        }
        /// <summary>
        /// DLR iteraive
        /// </summary>
        public static void PreOrderRec(BTNode root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Data);
                InOrderRec(root.LChild);
                InOrderRec(root.RChild);
            }
        }
        #endregion
        #region LevelOrder
        public static void LevelOrderRec()
        {

        }

        public static void LevelOrder()
        {

        }
        #endregion   
    }
}
