using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace WFDEV2010
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CreateCheckedListBoxControl(CheckedListBoxItem[] items)
        {
            CheckedListBoxControl checkedListBoxControl = new CheckedListBoxControl();
            Controls.Add(checkedListBoxControl);
            checkedListBoxControl.Left = 20;
            checkedListBoxControl.Top = 20;
            checkedListBoxControl.Width = 200;
            checkedListBoxControl.Height = 150;
            checkedListBoxControl.Items.AddRange(items);
        }

        private void CheckedListBoxItem()
        {
            CheckedListBoxItem[] items = {
                                 new CheckedListBoxItem("January", false),
                                 new CheckedListBoxItem("February", false),
                                 new CheckedListBoxItem("March", true),
                                 new CheckedListBoxItem("April", false),
                                 new CheckedListBoxItem("May", false),
                                 new CheckedListBoxItem("June", true),
                                 new CheckedListBoxItem("July", true),
                                 new CheckedListBoxItem("August", false),
                                 new CheckedListBoxItem("September", false),
                                 new CheckedListBoxItem("October", false),
                                 new CheckedListBoxItem("November", false),
                                 new CheckedListBoxItem("December", false)
                              };
                          CreateCheckedListBoxControl(items);
        }
        private void checkedComboBoxEdit()
        {
            List<Person> list = new List<Person>();
            list.Add(new Person() { ID = "1", Name = "AAA" });
            list.Add(new Person() { ID = "2", Name = "BBB" });
            list.Add(new Person() { ID = "3", Name = "CCC" });
            list.Add(new Person() { ID = "4", Name = "DDD" });
            list.Add(new Person() { ID = "5", Name = "EEE" });
            checkedComboBoxEdit1.Properties.Items.AddRange(list.ToArray());
            checkedComboBoxEdit1.CheckAll();
            //
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkedComboBoxEdit();
           // CheckedListBoxItem();
        }
    }
}
