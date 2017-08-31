using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;

namespace BarEditors
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        string skinMask = "Skin: ";
        public frmMain()
        {
            InitializeComponent();

            DBFileName = DevExpress.Utils.FilesHelper.FindingFileName(@"E:\云端TFS\BuildProcessTemplates\WFDEV2010\BarEditors\", "Products.xml");

            if (DBFileName != "")
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(DBFileName);
                gridControl1.DataSource = dataView = dataSet.Tables[0].DefaultView;
            }


            string[] s = new String[] {"Beverages", "Condiments", "Confections", "Dairy Products", 
										  "Grains/Cereals", "Meat/Poultry", "Produce", "Seafood"};
            for (int i = 0; i < s.Length; i++)
                repositoryItemImageComboBox1.Items.Add(new ImageComboBoxItem(s[i], i + 1, i));
            barManager1.ForceInitialize();

            RepositoryItem ri = repositoryItemImageComboBox1.Clone() as RepositoryItem;
            gridControl1.RepositoryItems.Add(ri);
            colCategoryID.ColumnEdit = ri;
            foreach (DevExpress.Skins.SkinContainer cnt in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarButtonItem item = new BarButtonItem(barManager1, skinMask + cnt.SkinName);
                iPaintStyle1.AddItem(item);
                item.ItemClick += item_ItemClick;

            }


        }

        void item_ItemClick(object sender, ItemClickEventArgs e)
        {
            string skinName = e.Item.Caption.Replace(skinMask, "");
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinName);
            iPaintStyle1.Caption = iPaintStyle1.Hint = e.Item.Caption;
            iPaintStyle1.Hint = iPaintStyle1.Caption;
            iPaintStyle1.ImageIndex = -1;
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinName);
            //barManager1.GetController().PaintStyleName = "Skin";
            //iPaintStyle.Caption = iPaintStyle.Hint = e.Item.Caption;
            //iPaintStyle.Hint = iPaintStyle.Caption;
            //iPaintStyle.ImageIndex = -1;
        }

        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {

        }

        public string DBFileName { get; set; }

        public DataView dataView { get; set; }
        string[] filter = new string[3];
        private void Categories_EditValueChanged(object sender, EventArgs e)
        {
            if (Categories.EditValue == null)
                filter[2] = "";
            else
                filter[2] = "[CategoryID] = " + Categories.EditValue.ToString();
            SetFilter();
        }
        private void SetFilter()
        {
            string f = "";
            foreach (string s in filter)
            {
                if (f != "" && (s != null && s != "")) f += " AND ";
                if (s != "") f += s;
            }
            dataView.RowFilter = f;
         //   iFilter.Caption = (f == "") ? "No Filter" : "Filter: " + f;
       //     iRecords.Caption = "Records: " + dataView.Count.ToString();
        }
    }
}