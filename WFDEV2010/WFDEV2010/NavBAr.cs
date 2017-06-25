using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFDEV2010
{
    public partial class NavBAr : Form
    {
        public NavBAr()
        {
            InitializeComponent();
            MessageBox.Show(StaticClass.UserName);  
        }

        private void navBarControl1_Click(object sender, EventArgs e)
        {

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popupContainerEdit1.EditValue = radioGroup1.Properties.Items[1].Description.ToString();
            popupContainerEdit1.ClosePopup();
        }
    }
}
