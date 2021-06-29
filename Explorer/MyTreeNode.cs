using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Explorer
{
    class MyTreeNode: TreeNode
    {
        private MyFile data;

        public MyTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex)
        {
        }

        public MyFile Data
        {
            get { return data; }
            set { data = value; }
        }
     


    }
}
