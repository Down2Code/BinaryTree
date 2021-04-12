using System;

namespace Binary_Tree_DS_and_Basic_Operations
{
    class Program
    {
        static BTNode root;
        static void Main(string[] args)
        {
            root = new BTNode(1);
        }

        private static void CreateHardCodedBinaryTree(BTNode root)
        {
            root.LChild = new BTNode(2);
            root.RChild = new BTNode(3);
            root.LChild.LChild = new BTNode(4);
            root.LChild.RChild = new BTNode(5);
            root.RChild.LChild = new BTNode(6);
            root.RChild.RChild = new BTNode(7);
        }
    }
}
