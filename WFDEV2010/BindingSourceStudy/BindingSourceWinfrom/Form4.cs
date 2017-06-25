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
    //如何：使用 BindingSource 和 INotifyPropertyChanged 接口引发更改通知
    public partial class Form4 : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private Button changeItemBtn = new Button();

        // This DataGridView control displays the contents of the list.
        private DataGridView customersDataGridView = new DataGridView();

        // This BindingSource binds the list to the DataGridView control.
        private BindingSource customersBindingSource = new BindingSource();
        public Form4()
        {
            InitializeComponent();  // Set up the "Change Item" button.
            this.changeItemBtn.Text = "Change Item";
            this.changeItemBtn.Dock = DockStyle.Bottom;
            this.changeItemBtn.Click +=
                new EventHandler(changeItemBtn_Click);
            this.Controls.Add(this.changeItemBtn);

            // Set up the DataGridView.
            customersDataGridView.Dock = DockStyle.Top;
            this.Controls.Add(customersDataGridView);

            this.Size = new Size(400, 200);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Create and populate the list of DemoCustomer objects
            // which will supply data to the DataGridView.
            BindingList<DemoCustomer1> customerList = new BindingList<DemoCustomer1>();
            customerList.Add(DemoCustomer1.CreateNewCustomer());
            customerList.Add(DemoCustomer1.CreateNewCustomer());
            customerList.Add(DemoCustomer1.CreateNewCustomer());

            // Bind the list to the BindingSource.
            this.customersBindingSource.DataSource = customerList;

            // Attach the BindingSource to the DataGridView.
            this.customersDataGridView.DataSource =
                this.customersBindingSource;
        }
        // Change the value of the CompanyName property for the first 
        // item in the list when the "Change Item" button is clicked.
        void changeItemBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the list from the BindingSource.
            BindingList<DemoCustomer1> customerList =
                this.customersBindingSource.DataSource as BindingList<DemoCustomer1>;

            // Change the value of the CompanyName property for the 
            // first item in the list.
            customerList[0].CustomerName = "Tailspin Toys33333";
            customerList[0].PhoneNumber = "(708)555-0150";
        }

    }
}
