using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations
{
    public static class TreeTraversals
    {
        public static void InOrderRec(BTNode root)
        {
            if (root != null)
            {
                InOrderRec(root.LChild);
                Console.WriteLine(root.Data);
                InOrderRec(root.RChild);
            }
        }
        public static void PreOrderRec()
        {

        }
        public static void LevelOrderRec()
        {

        }
        public static void PostOrderRec()
        {

        }
        public static void InOrder()
        {

        }
        public static void PreOrder()
        {

        }
        public static void PostOrder()
        {

        }
        public static void LevelOrder()
        {

        }
    }
}
