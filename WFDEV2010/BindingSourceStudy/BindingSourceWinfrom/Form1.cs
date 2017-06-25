using DevExpress.XtraEditors;
using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        public List<State> states { get; set; }
        private BindingSource bindSource;
        private AutoCompleteStringCollection cl;
        public State stateModel { get; set; }
        public Form1()
        {
            InitializeComponent();
            bindSource = new BindingSource();
            states = new List<State>();
            stateModel = new State("dsf", "3,1", 3);
            states.Add(new State("California", "Sacramento",2));
            states.Add(new State("Oregon", "Salem",3));
            states.Add(new State("Washington", "Olympia",4));
            //states.Add(new State("Idaho", "Boise"));
            //states.Add(new State("Utah", "Salt Lake City"));
            //states.Add(new State("Hawaii", "Honolulu"));
            //states.Add(new State("Colorado", "Denver"));
            //states.Add(new State("Montana", "Helena"));
            bindSource.DataSource = stateModel;
        //    bindSource.Filter = "Name='Montana'";
            cl = new AutoCompleteStringCollection();
        //    cl.AddRange(  sstates.Select(p => p.stateCapital).ToList();
            textBox1.TextChanged += (s,e) => 
            { 
               states.Where(p=>p.stateCapital.Contains(textBox1.Text)).ToList().ForEach
                   (Q => { cl.Add(Q.stateCapital); });
            };
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteCustomSource = cl;
            textEdit1.DataBindings.Add("EditValue", bindSource, "stateName").NullValue="dd";
            textEdit2.DataBindings.Add("EditValue", bindSource, "stateCapital");
            //radioGroup1.SelectedIndex
         //   checkedListBoxControl1.SelectedIndex
        //    checkedListBoxControl1.CheckedIndices
            //checkedListBoxControl1.Items[1].CheckState
       //    checkedListBoxControl1.SelectedIndexChanged += checkedListBoxControl1_SelectedIndexChanged;
            //checkedListBoxControl1.CheckMember
           //checkedListBoxControl1.Text
            //checkedListBoxControl1.SelectedItem
           //Binding frm=new Binding ()
           //checkedListBox1.DataBindings.Add()
            Binding b = new Binding
         ("SelectedIndex", bindSource, "stateCapital",true);
           
            b.Parse += new ConvertEventHandler(CurrencyStringToDecimal);
           checkedListBoxControl1.DataBindings.Add(b);
            radioGroup1.DataBindings.Add("SelectedIndex", bindSource, "ID", true);
            bindSource.ResetBindings(false);
       
        }

        private void CurrencyStringToDecimal(object sender, ConvertEventArgs e)
        {
            ((CheckedListBoxControl)sender).SelectedIndex = int.Parse( e.Value.ToString().Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries)[0]);
          
          

       //     throw new NotImplementedException();
        }

        void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

          // checkedListBoxControl1.SelectedItems
         //   stateModel.stateName = "fasfasdf";
        //    bindSource.ResetCurrentItem();
        //  MessageBox.Show(stateModel.stateName);
          MessageBox.Show(stateModel.ID.ToString());
         //   List<State> list = states;
            // If items remain in the list, remove the first item. 
       //     if (states.Count > 0)
       //     {
       //         states.RemoveAt(0);
       //         //

       ////使用数据绑定控件时，您有时会需要在数据源没有引发列表更改事件时，对数据源中的更改做出响应。 使用 BindingSource 控件将数据源绑定到 Windows 窗体控件时，可以通知控件已通过调用 ResetBindings 方法更改了您的数据源。
       //    //  如果数据架构已更改，则为 true；如果只有值发生了更改，则为 false。
       //         bindSource.ResetBindings(false);
       //     }
        }




    }
}
