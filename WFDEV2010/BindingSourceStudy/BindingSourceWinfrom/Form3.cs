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
    public partial class Form3 : Form
    {
        private BindingSource customersBindingSource = new BindingSource();

        // This is the DataGridView control that will display our data.
        private DataGridView customersDataGridView = new DataGridView();

        // Set up the StatusBar for displaying ListChanged events.
        private StatusBar status = new StatusBar();
        public Form3()
        {
            InitializeComponent();
            // Set up the form.
            this.Size = new Size(800, 800);
            this.Load += new EventHandler(Form1_Load);
            this.Controls.Add(status);

            // Set up the DataGridView control.
      //      this.customersDataGridView.Dock = DockStyle.Fill;
            this.Controls.Add(customersDataGridView);

            // Attach an event handler for the AddingNew event.
            this.customersBindingSource.AddingNew +=
                new AddingNewEventHandler(customersBindingSource_AddingNew);

            // Attach an event handler for the ListChanged event.
            this.customersBindingSource.ListChanged +=
                new ListChangedEventHandler(customersBindingSource_ListChanged);
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            // Add a DemoCustomer to cause a row to be displayed.
            this.customersBindingSource.AddNew();

            // Bind the BindingSource to the DataGridView 
            // control's DataSource.
            this.customersDataGridView.DataSource =
                this.customersBindingSource;
        }

        // This event handler provides custom item-creation behavior.
        void customersBindingSource_AddingNew(
            object sender,
            AddingNewEventArgs e)
        {
            e.NewObject = DemoCustomer.CreateNewCustomer();
        }

        // This event handler detects changes in the BindingSource 
        // list or changes to items within the list.
        void customersBindingSource_ListChanged(
            object sender,
            ListChangedEventArgs e)
        {
            status.Text = e.ListChangedType.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.customersBindingSource.AddNew();

        }
    }
}
