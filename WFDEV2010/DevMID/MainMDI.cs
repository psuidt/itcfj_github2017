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
using DevExpress.XtraTab.ViewInfo;

namespace DevMID
{
    public partial class MainMDI : DevExpress.XtraEditors.XtraForm
    {
        public MainMDI()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmPatInfo frm = new FrmPatInfo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TabMdi_MouseDown(object sender, MouseEventArgs e)
        {
            //点左键无效, 必须是点右键弹出菜单
            if (e.Button != MouseButtons.Right) return;
            BaseTabHitInfo hint = TabMdi.CalcHitInfo(e.Location);

            //点击有效,且点击在TabPage标题上
            if (hint.IsValid && (hint.Page != null))
            {
                //有效子窗体
                if (TabMdi.SelectedPage.MdiChild != null)
                {
                    popupMenu1.ShowPopup(barManager1, Control.MousePosition); 

                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TabMdi.SelectedPage.MdiChild.Close();
        }

       
    }
}