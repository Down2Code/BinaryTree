using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_DS_and_Basic_Operations
{
    public class BTNode:IDisposable
    {
        public BTNode LChild;
        public int? Data;
        public BTNode RChild;

        public BTNode(int data)
        {
            Data = data;
        }
        public void Dispose()
        {
            this.Data = null;
            this.LChild = null;
            this.RChild = null;
        }
    }
}
