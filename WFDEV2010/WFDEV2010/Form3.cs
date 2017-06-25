using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace WFDEV2010
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void CreateColumns(TreeList tl)
        {
            // Create three columns.
            tl.BeginUpdate();
            tl.Columns.Add();
            tl.Columns[0].Caption = "Customer";
            tl.Columns[0].VisibleIndex = 0;
            tl.Columns.Add();
            tl.Columns[1].Caption = "Location";
            tl.Columns[1].VisibleIndex = 1;
            tl.Columns.Add();
            tl.Columns[2].Caption = "Phone";
            tl.Columns[2].VisibleIndex = 2;
            tl.EndUpdate();
        }

        private void CreateNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();
            // Create a root node .
            TreeListNode parentForRootNodes = null;
            TreeListNode rootNode = tl.AppendNode(
                new object[] { "Alfreds Futterkiste", "Germany, Obere Str. 57", "030-0074321" },
                parentForRootNodes);
            // Create a child of the rootNode
            tl.AppendNode(new object[] { "Suyama, Michael", "Obere Str. 55", "030-0074263" }, rootNode);
            // Creating more nodes
            // ...
            tl.EndUnboundLoad();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CreateColumns(treeList1);
            CreateNodes(treeList1);

        }

    }
}
