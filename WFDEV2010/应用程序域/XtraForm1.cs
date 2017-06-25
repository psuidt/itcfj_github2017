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

namespace 应用程序域
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
            WindowZoomIn(this.Handle);
        }
        #region 窗体显示特效
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        //dwflag的取值如下
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        //从左到右显示
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        //从右到左显示
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        //从上到下显示
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        //从下到上显示
        public const Int32 AW_CENTER = 0x00000010;
        //若使用了AW_HIDE标志，则使窗口向内重叠，即收缩窗口；否则使窗口向外扩展，即展开窗口
        public const Int32 AW_HIDE = 0x00010000;
        //隐藏窗口，缺省则显示窗口
        public const Int32 AW_ACTIVATE = 0x00020000;
        //激活窗口。在使用了AW_HIDE标志后不能使用这个标志
        public const Int32 AW_SLIDE = 0x00040000;
        //使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        public const Int32 AW_BLEND = 0x00080000;

        /// <summary>
        /// 窗体由中心点放大
        /// </summary>
        /// <param name="hwnd"></param>
        public static void WindowZoomIn(IntPtr hwnd)
        {
            AnimateWindow(hwnd, 200, AW_CENTER | AW_ACTIVATE);
        }
        /// <summary>
        /// 窗体由下往上收缩
        /// </summary>
        /// <param name="hwnd"></param>
        public static void WindowZoomOut(IntPtr hwnd)
        {
            //窗体由下往上收缩
            AnimateWindow(hwnd, 1000, AW_SLIDE | AW_HIDE | AW_VER_NEGATIVE);
        }
        /// <summary>
        /// 窗体由四周往中心收缩
        /// </summary>
        /// <param name="hwnd"></param>
        public static void WindowContractIn(IntPtr hwnd)
        {
            //窗体由四周往中心收缩
            AnimateWindow(hwnd, 400, AW_CENTER | AW_HIDE | AW_VER_NEGATIVE);
        }
        #endregion 窗体显示特效

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void XtraForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowContractIn(this.Handle);
        }
    }
}