using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingSourceWinfrom
{
    public partial class Form2 : Form
    {
        private BindingSource bindSource;
        public Form2()
        {
            InitializeComponent();
            bindSource = new BindingSource();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataSet set1 = new DataSet();
            set1.Tables.Add("Menu");
            set1.Tables[0].Columns.Add("Beverages");
            // Add some rows to the table.
            set1.Tables[0].Rows.Add("coffee");
            set1.Tables[0].Rows.Add("tea");
            set1.Tables[0].Rows.Add("hot chocolate");
            set1.Tables[0].Rows.Add("milk");
            set1.Tables[0].Rows.Add("orange juice");
            bindSource.DataSource = set1;
            bindSource.DataMember = "Menu";
            gridControl1.DataSource = bindSource;

            textEdit1.DataBindings.Add("Text", bindSource,
        "Beverages");
            textEdit2.DataBindings.Add("Text", bindSource,
                "Beverages");
        }
    }
}
