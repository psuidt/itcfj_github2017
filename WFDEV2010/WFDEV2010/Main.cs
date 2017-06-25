using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;

namespace WFDEV2010
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            MessageBox.Show(StaticClass.UserName);
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            mdi.MdiParent = this;
            NavBAr frmMoney = new NavBAr();
            frmMoney.MdiParent = this;
            frmMoney.Show();
      //   mdi.Pages.Add(new DevExpress.XtraTabbedMdi.XtraMdiTabPage (new 
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            mdi.MdiParent = this;
            WFDEV2010.GridControl frmMoney = new WFDEV2010.GridControl();
            frmMoney.MdiParent = this;
            frmMoney.Show();
        }
        private int targetOpacity = 100;
        private int fadeTime = 2;
        private Message heldMessage;
 

 

        private void timer1_Tick(object sender, EventArgs e)
        {
            double num = ((this.uTime.Interval * 1.0) / 1000.0) / ((double)this.fadeTime);
            if (Math.Abs((double)(this.targetOpacity - base.Opacity)) < num)
            {
                if (this.targetOpacity == 1)
                {
                    base.Opacity = 0.999;
                }
                else
                {
                    base.Opacity = this.targetOpacity;
                }
                base.WndProc(ref this.heldMessage);
                this.heldMessage = new Message();
                this.uTime.Stop();
                for (int i = 0; i < base.MdiChildren.Length; i++)
                {
                    base.MdiChildren[i].Refresh();
                }
            }
            else if (this.targetOpacity > base.Opacity)
            {
                base.Opacity += num;
            }
            else if (this.targetOpacity < base.Opacity)
            {
                base.Opacity -= num;
            }

        }
    }
}
