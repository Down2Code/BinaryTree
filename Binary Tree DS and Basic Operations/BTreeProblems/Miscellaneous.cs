using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations.BTreeProblems
{
    /// <summary>
    /// 
    /// </summary>
    public class Miscellaneous
    {
        /// <summary>
        /// If level order traversal is 1 2 3 4 5 6 7 then print 4 5 6 7 2 3 1
        ///           1
        ///          / \
        ///         2   3
        ///        /\   /\
        ///       4  5 6  7
        /// </summary>
        public static void PrintLevelOrderInReverse(BTNode root)
        {
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            Stack<BTNode> btNodeStack = new Stack<BTNode>();
            btNodeQueue.Enqueue(root);
            while(btNodeQueue.Count>0)
            {
                var temp = btNodeQueue.Dequeue();
                if (temp.RChild != null)
                    btNodeQueue.Enqueue(temp.RChild);
                if (temp.LChild != null)
                    btNodeQueue.Enqueue(temp.LChild);
                btNodeStack.Push(temp);
            }
            while(btNodeStack.Count>0)
            {
                Console.WriteLine(btNodeStack.Pop().Data);
            }
        }
        public static void DeleteBTree(ref BTNode root)
        {
            if (root == null) return;
            DeleteBTree(ref root.LChild);
            DeleteBTree(ref root.RChild);
            root = null;
        }
        public static BTNode FindDeepestNode(BTNode root)
        {
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            btNodeQueue.Enqueue(root);
            BTNode deepNode = null;
            while(btNodeQueue.Count>0)
            {
                deepNode = btNodeQueue.Dequeue();
                if (deepNode.LChild != null)
                    btNodeQueue.Enqueue(deepNode.LChild);
                if (deepNode.RChild != null)
                    btNodeQueue.Enqueue(deepNode.RChild);
            }
            return deepNode;
        }
        public static void DeleteSingleNode(BTNode root,int data)
        {
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            btNodeQueue.Enqueue(root);
            while(btNodeQueue.Count>0)
            {
                var temp = btNodeQueue.Dequeue();
                if(temp.Data==data)
                {
                    //If the node to be deleted is Leaf node then delete it
                    if (temp.LChild == null && temp.RChild == null)
                        temp.Dispose();
                    else
                    { 
                        //If node to be deleted is not leaf node then find deepest node 
                        //replace the current node's data with deepest node free the deepest node
                        var DeepNode = FindDeepestNode(root);
                        if (temp.Data != DeepNode.Data)
                        {
                            temp.Data = DeepNode.Data;
                            DeepNode.Dispose();
                        }
                    }
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
        public static int CountNoOfLeafNodes(BTNode root)
        {
            int count = 0;
            Queue<BTNode> bTNodeQueue = new Queue<BTNode>();
            bTNodeQueue.Enqueue(root);
            while(bTNodeQueue.Count>0)
            {
                if(bTNodeQueue.Count>0)
                {
                    var temp = bTNodeQueue.Dequeue();
                    if (temp.LChild == null && temp.RChild == null)
                        count++;
                    else
                    {
                        if (temp.LChild != null)
                            bTNodeQueue.Enqueue(temp.LChild);
                        if (temp.RChild != null)
                            bTNodeQueue.Enqueue(temp.RChild);
                    }
                }
            }
            return 1;
        }
        public static bool AreStructurallyIdentical(BTNode root1,BTNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;
            return (root1.Data == root2.Data 
                && AreStructurallyIdentical(root1.LChild, root2.LChild)
                && AreStructurallyIdentical(root1.RChild, root2.RChild));
        }
        /// <summary>
        /// The number of nodes on the longest path of Binary tree
        /// This longest path may or may not pass throught the root of the tree
        /// </summary>
        public static int DiameterOfBinaryTree(BTNode root)
        {
            if (root == null)
                return 0;
            int lHt = FindHeightOfBTree.FindHeight(root.LChild);
            int rHt = FindHeightOfBTree.FindHeight(root.RChild);
            int lDiameter = DiameterOfBinaryTree(root.LChild);
            int rDiameter = DiameterOfBinaryTree(root.RChild);
            return Math.Max(lHt + rHt + 1, Math.Max(lDiameter,rDiameter));
        }
        public static int FindLevelWithMaxSum(BTNode root)
        {
            int maxSum = 0;
            int levelSum = 0;
            int level = 0;
            int maxLevel = 0;
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            if (root != null)
            {
                btNodeQueue.Enqueue(root);
                btNodeQueue.Enqueue(null);
                while(btNodeQueue.Count>0)
                {
                    var temp = btNodeQueue.Dequeue();
                    if(temp==null)
                    {
                        if (levelSum > maxSum)
                        {
                            maxSum = levelSum;
                            maxLevel = level;
                        }
                        levelSum = 0;
                        if (btNodeQueue.Count > 0)
                        {
                            btNodeQueue.Enqueue(null);
                        }
                        level++;
                        
                    }
                    else
                    {
                        levelSum += temp.Data??0;
                        if (temp.LChild != null)
                            btNodeQueue.Enqueue(temp.LChild);
                        if (temp.RChild != null)
                            btNodeQueue.Enqueue(temp.RChild);
                    }
                }
            }
            return level;
        }
        public static void PrintAllPathsToLeaf(BTNode root,int[] path,int pathLen)
        {
            if (root == null)
                return;
            path[pathLen] = root.Data??0;
            pathLen++;
            if (root.LChild == null && root.RChild == null)
                PrintPath(path,pathLen);
            else
            {
                PrintAllPathsToLeaf(root.LChild, path, pathLen);
                PrintAllPathsToLeaf(root.RChild, path, pathLen);
            }
        }
        public static void PrintPath(int[] path,int pathLen)
        {
            for (int i = 0; i < pathLen; i++)
            {
                Console.Write($"{path[i]} ");
            }
            Console.WriteLine();
        }
        public static bool CheckIfSomeExists(BTNode root,int sum)
        {
            if (root == null)
                return sum == 0;
            else
            {
                int remsum = sum - root.Data ?? 0;
                if ((root.LChild != null && root.RChild != null) || (root.LChild == null && root.RChild == null))
                    return (CheckIfSomeExists(root.LChild, remsum) || CheckIfSomeExists(root.RChild, remsum));
                if (root.LChild != null)
                    return (CheckIfSomeExists(root.LChild, remsum));
                else
                    return (CheckIfSomeExists(root.RChild, remsum));
            }
        }
        public static int SumOfBTRecursive(BTNode root)
        {
            if (root == null)
                return 0;
            else
                return ((root.Data??0) + SumOfBTRecursive(root.LChild) + SumOfBTRecursive(root.RChild));
        }
        public static int SumOfBTIterative(BTNode root)
        {
            int sum = 0;
            Queue<BTNode> btNodeQueue = new Queue<BTNode>();
            if (root != null)
            {
                btNodeQueue.Enqueue(root);
                while(btNodeQueue.Count>0)
                {
                    var temp = btNodeQueue.Dequeue();
                    sum += temp.Data ?? 0;
                    if (temp.LChild != null)
                        btNodeQueue.Enqueue(temp.LChild);
                    if (temp.RChild != null)
                        btNodeQueue.Enqueue(temp.RChild);
                }
            }
            return sum;
        }
        /// <summary>
        /// Post order traversal similar
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static void CreateMirror(BTNode root)
        {
            if (root == null)
                return;
            CreateMirror(root.LChild);
            CreateMirror(root.RChild);
            //swap lchild and rchild
            var temp = root.LChild;
            root.LChild = root.RChild;
            root.RChild = temp;
        }
        public static bool AreMirrors(BTNode root1,BTNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;
            if (root1.Data != root2.Data)
                return false;
            return (AreMirrors(root1.LChild, root2.RChild) && AreMirrors(root1.RChild, root2.LChild));
        }
        public static BTNode FindLCA(BTNode root,BTNode first,BTNode second)
        {
            BTNode left, right;
            if (root == null)
                return root;
            if (root == first || root == second)
                return root;
            left = FindLCA(root.LChild, first, second);
            right = FindLCA(root.RChild, first, second);
            if (left != null && right != null)
                return root;
            return left != null ? left : right;
        }
        public static bool PrintAllAncestors(BTNode root,BTNode target)
        {
            if (root == null) return false;
            if (root.LChild == target || root.RChild == target || PrintAllAncestors(root.LChild, target)
                || PrintAllAncestors(root.RChild, target))
            {
                Console.WriteLine(root.Data);
                return true;
            }
            else return false;   
        }
        public static int preOrderIndex;
        public static BTNode BuildBinaryTreeFromInPre(int[] preOrder,int[] inOrder,int inOrderStart,int inOrderEnd)
        {
            
            if (inOrderStart > inOrderEnd)
                return null;
            BTNode newNode = new BTNode(preOrder[preOrderIndex]);
            preOrderIndex++;
            if (inOrderStart == inOrderEnd)
                return newNode;
            int inOrderIndex = Search(preOrder[preOrderIndex], inOrder);
            
            newNode.LChild = BuildBinaryTreeFromInPre(preOrder, inOrder, inOrderStart, inOrderIndex - 1);
            newNode.RChild = BuildBinaryTreeFromInPre(preOrder, inOrder, inOrderIndex + 1, inOrderEnd);
            return newNode;
        }
        public static int Search(int key,int[]array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == key)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Given a tree with a special property where leaves are represented with ‘L’ and
        /// internal node with ‘I’. Also, assume that each node has either 0 or 2 children.Given
        /// preorder traversal of this tree, construct the tree.
        /// ILILL
        ///             I
        ///            / \
        ///           L   I
        ///              / \
        ///             L   L
        /// </summary>
        /// <param name="input"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static BTNode BuildBinaryTreeFromPre(char[] input,int i)
        {
            BTNode newNode = new BTNode(input[i]);
            if (input[i] == 'L')
                return newNode;
            newNode.LChild = BuildBinaryTreeFromPre(input, i++);
            newNode.RChild = BuildBinaryTreeFromPre(input, i++);
            return newNode;
        }
        public static void ZigZagTraversal(BTNode root)
        {
            Stack<BTNode> curStack = new Stack<BTNode>();
            Stack<BTNode> nextStack = new Stack<BTNode>();
            bool leftToRight = true;
            curStack.Push(root);
            while(curStack.Count>0)
            {
                var temp = curStack.Pop();
                Console.WriteLine(temp.Data);
                if(leftToRight)
                {
                    if (temp.LChild != null)
                        nextStack.Push(temp.LChild);
                    if (temp.RChild != null)
                        nextStack.Push(temp.RChild);
                }
                else
                {
                    if (temp.RChild != null)
                        nextStack.Push(temp.RChild);
                    if (temp.LChild != null)
                        nextStack.Push(temp.LChild);
                }
                if(curStack.Count==0)
                {
                    leftToRight = !leftToRight;
                    var tempStack = nextStack;
                    nextStack = curStack;
                    curStack = tempStack;
                }
            }
        }

        public static Dictionary<int, int> verticalSum = new Dictionary<int, int>();
        /// <summary>
        /// Makes use of InOrder Traversal Style, We call PrintVerticalSum with column value as 0
        /// </summary>
        /// <param name="root"></param>
        /// <param name="column"></param>
        public static void CalcVerticalSum(BTNode root,int column)
        {
            if (root != null)
            {
                CalcVerticalSum(root.LChild, column - 1);
                if (verticalSum.ContainsKey(column))
                    verticalSum[column] += root.Data ?? 0;
                else
                    verticalSum.Add(column, root.Data ?? 0);
                CalcVerticalSum(root.RChild, column + 1);
            }
        }
        public static void NextSiblingBinaryTree(BTNextSiblingNode root)
        {
            Queue<BTNextSiblingNode> btNodeQueue = new Queue<BTNextSiblingNode>();
            if(root!=null)
            {
                btNodeQueue.Enqueue(root);
                btNodeQueue.Enqueue(null);
                while(btNodeQueue.Count>0)
                {
                    var temp = btNodeQueue.Dequeue();
                    if(temp==null)
                    {
                        if (btNodeQueue.Count != 0)
                            btNodeQueue.Enqueue(null);
                    }
                    else
                    {
                        temp.NextSibling = btNodeQueue.Peek();
                        if (temp.LChild != null)
                            btNodeQueue.Enqueue(temp.LChild);
                        if (temp.RChild != null)
                            btNodeQueue.Enqueue(temp.RChild);
                    }
                }
            }
        }
        public static void NextSiblingBinartyTreeRecursive(BTNextSiblingNode root)
        {
            if (root == null)
                return;
            if (root.LChild != null)
                root.LChild.NextSibling = root.RChild;
            if (root.RChild != null)
                root.RChild.NextSibling = root.NextSibling != null ? root.NextSibling.LChild : null;
            NextSiblingBinartyTreeRecursive(root.LChild);
            NextSiblingBinartyTreeRecursive(root.RChild);
        }
    }
}
