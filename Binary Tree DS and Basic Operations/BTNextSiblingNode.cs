using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations
{
    public class BTNextSiblingNode
    {
        public BTNextSiblingNode LChild;
        public int? Data;
        public BTNextSiblingNode RChild;
        public BTNextSiblingNode NextSibling;
        public BTNextSiblingNode(int data)
        {
            Data = data;
        }
    }
}
