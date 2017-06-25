using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winning.FrameWork.Kernel;

namespace Winning.Cpoe.UI.PreviewFile
{
    public class StartUp : IAddins
    {
        public void Run(string uCaption, string uParameter)
        {
            FrmPreviewFile frm = new FrmPreviewFile();
            frm.Text = uCaption;
            //  frm.MdiParent = SysHelper.GetHisSystem().OnlineShell;
            frm.ShowDialog();
        }
    }
}
