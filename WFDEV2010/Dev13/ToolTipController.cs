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
using DevExpress.Utils;

namespace Dev13
{
    public partial class ToolTipController : DevExpress.XtraEditors.XtraForm
    {
        public ToolTipController()
        {
            InitializeComponent();
      
        }

        private void ToolTipController_Load(object sender, EventArgs e)
        {
            textEdit1.Properties.AutoHeight = false;
            toolTipController1.AutoPopDelay = 20000;
            ToolTipControllerShowEventArgs args = toolTipController1.CreateShowArgs();
            toolTipController1.SetToolTip(this.simpleButton1, "请选择一条记录");
            toolTipController1.SetTitle(this.simpleButton1, "提示");
            toolTipController1.SetToolTipIconType(this.simpleButton1, DevExpress.Utils.ToolTipIconType.Exclamation);
            toolTipController1.ShowBeak = true;
            toolTipController1.ShowShadow = true;
            toolTipController1.Rounded = true;
          //  toolTipController1.HideHint();
       //     toolTipController1.ShowHint("请选择一条记录", "提示");
            toolTipController1.ShowHint("A tooltip", simpleButton1, DevExpress.Utils.ToolTipLocation.RightCenter);
            args.ToolTip = "请选择一条记录";
            args.Title = "提示";
         

        }
    }
}