using System;

namespace Binary_Tree_DS_and_Basic_Operations
{
    class Program
    {
        static BTNode root;
        static void Main(string[] args)
        {
            root = new BTNode(1);
            CreateHardCodedBinaryTree(root);
            TreeTraversals.InOrderRec(root);
        }

        private static void CreateHardCodedBinaryTree(BTNode root)
        {
            root.LChild = new BTNode(2);
            root.RChild = new BTNode(3);
        }
    }
}
