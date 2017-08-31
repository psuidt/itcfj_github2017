using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevWinfrom
{
    public partial class ItemRadioGroup1多列标题 : DevExpress.XtraEditors.XtraForm
    {
      
        public ItemRadioGroup1多列标题()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }

        void Form2_Load(object sender, EventArgs e)
        {
            List<UserInfo> list = new List<UserInfo> 
            {
              new UserInfo{ checkID=1,Name="历史1"},
                new UserInfo{ checkID=3,Name="历史3"},
                  new UserInfo{ checkID=2,Name="历史2"},
            };
            gridControl1.DataSource = list;
            RepositoryItemCustomComboBoxEdit combox3 = new RepositoryItemCustomComboBoxEdit();
            gridColumn3.ColumnEdit = combox3;
            combox3.Properties.Items.Add("北京");
            combox3.Properties.Items.Add("北平");
            combox3.Properties.Items.Add("上海");
            combox3.Properties.Items.Add("北京");
            combox3.Properties.Items.Add("北京");
            combox3.Properties.Items.Add("北京");
            combox3.Properties.Items.Add("北京");
            combox3.Properties.Items.Add("北京");
            combox3.Properties.Items.Add("北京");
            combox3.Properties.Items.Add("北京");
            combox3.Properties.Items.Add("河南");
            combox3.Properties.Items.Add("河北");
            combox3.Properties.Items.Add("天津");
            combox3.Properties.Items.Add("天朝");
        }

        private void repositoryItemRadioGroup1_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {

        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.Name=="gridColumn3")
            {
            
            }
        }
    }
    public class UserInfo
    {
        public string Name { get; set; }
        public int checkID { get; set; }
    }
}
