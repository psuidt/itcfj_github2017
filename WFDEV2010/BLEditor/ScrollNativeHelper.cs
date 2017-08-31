using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEditor
{

    /// <summary>
    /// 滚动条API处理封装
    /// </summary>
    internal static class ScrollNativeHelper
    {
        #region message
        /// <summary>
        /// 
        /// </summary>
        public const int WM_PAINT = 0x000F;
        public const int WM_VSCROLL = 0x0115;

        public const int SIF_RANGE = 0x0001;
        public const int SIF_PAGE = 0x0002;
        public const int SIF_POS = 0x0004;
        public const int SIF_DISABLENOSCROLL = 0x0008;
        public const int SIF_TRACKPOS = 0x0010;
        public const int SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS);
        #endregion

        #region Scroll Bar type
        public const int SB_HORZ = 0;
        public const int SB_VERT = 1;
        public const int SB_CTL = 2;
        public const int SB_BOTH = 3;
        #endregion

        #region V Scroll Bar Commands
        public const int SB_LINEUP = 0;
        public const int SB_LINEDOWN = 1;
        public const int SB_PAGEUP = 2;
        public const int SB_PAGEDOWN = 3;
        public const int SB_TOP = 6;
        public const int SB_BOTTOM = 7;
        #endregion

        #region Scroll Bar Common Commands
        public const int SB_THUMBPOSITION = 4;
        public const int SB_THUMBTRACK = 5;
        #endregion

        #region Reserved IDs for system objects
        public const uint OBJID_CLIENT = 0xFFFFFFFC;
        public const uint OBJID_VSCROLL = 0xFFFFFFFB;
        public const uint OBJID_HSCROLL = 0xFFFFFFFA;
        #endregion

        #region state of a scroll bar component
        public const int STATE_SYSTEM_INVISIBLE = 0x00008000;
        public const int STATE_SYSTEM_OFFSCREEN = 0x00010000;
        public const int STATE_SYSTEM_PRESSED = 0x00000008;
        public const int STATE_SYSTEM_UNAVAILABLE = 0x00000001;
        #endregion

        #region others
        public const int CCHILDREN_SCROLLBAR = 5;
        public const int SMALLCHANGE = 16;
        #endregion

        #region dllimport
        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, EntryPoint = "GetLastError")]
        private static extern int GetLastError();

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "GetScrollInfo")]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SetScrollInfo")]
        //private static extern int SetScrollInfo(IntPtr hwnd, int fnBar, SCROLLINFO lpsi, bool fRedraw);
        private static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref SCROLLINFO lpsi, bool fRedraw);

        //[DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "GetScrollBarInfo")]
        //private static extern bool GetScrollBarInfo(IntPtr hwnd, uint idObject, out SCROLLBARINFO psbi);
        [DllImport("user32.dll", SetLastError = true, EntryPoint = "GetScrollBarInfo")]
        private static extern int GetScrollBarInfo(IntPtr hWnd, uint idObject, ref SCROLLBARINFO psbi);
        #endregion

        #region public methods
        /// <summary>
        /// 创建滚动条滚动信息结构体
        /// </summary>
        /// <returns></returns>
        public static SCROLLINFO CreateScrollInfo()
        {
            SCROLLINFO info = new SCROLLINFO();
            info.cbSize = Marshal.SizeOf(info);
            info.fMask = SIF_ALL;
            return info;
        }

        /// <summary>
        /// 创建滚动条信息结构体
        /// </summary>
        /// <returns></returns>
        public static SCROLLBARINFO CreateScrollBarInfo()
        {
            SCROLLBARINFO info = new SCROLLBARINFO();
            info.cbSize = Marshal.SizeOf(info);
            return info;
        }

        /// <summary>
        /// 获得指定控件垂直滚动条的信息
        /// </summary>
        /// <param name="scrollCtrl">Scrollable控件</param>
        public static SCROLLINFO GetControlVScrollInfo(Control scrollCtrl)
        {
            if (scrollCtrl == null)
                throw new ArgumentNullException("object is null");

            SCROLLINFO info = CreateScrollInfo();
            GetControlVScrollInfo(scrollCtrl, ref info);
            return info;
        }

        /// <summary>
        /// 获得指定控件垂直滚动条的滚动信息
        /// </summary>
        /// <param name="scrollCtrl">Scrollable控件</param>
        /// <param name="scrollInfo">用来保存信息的结构体，为减少内存垃圾，可以创建一个固定的变量来保存数据</param>
        public static void GetControlVScrollInfo(Control scrollCtrl, ref SCROLLINFO scrollInfo)
        {
            if (scrollCtrl == null)
                throw new ArgumentNullException("object is null");

            if (!GetScrollInfo(scrollCtrl.Handle, SB_VERT, ref scrollInfo))
                throw new ApplicationException(GetLastError().ToString());
        }

        /// <summary>
        /// 获取指定的vScrollBar控件的滚动信息
        /// </summary>
        /// <returns></returns>
        public static SCROLLINFO GetVScrollBarControlScrollInfo(VScrollBar vScrollBar)
        {
            if (vScrollBar == null)
                throw new ArgumentNullException("object is null");

            SCROLLINFO info = CreateScrollInfo();
            if (!GetScrollInfo(vScrollBar.Handle, SB_CTL, ref info))
                throw new ApplicationException(GetLastError().ToString());
            else
                return info;
        }

        /// <summary>
        /// 获取指定控件垂直滚动条的信息
        /// </summary>
        /// <param name="scrollCtrl">Scrollable控件</param>
        /// <returns></returns>
        public static SCROLLBARINFO GetControlVScrollBarInfo(Control scrollCtrl)
        {
            if (scrollCtrl == null)
                throw new ArgumentNullException("object is null");

            SCROLLBARINFO info = CreateScrollBarInfo();
            GetControlVScrollBarInfo(scrollCtrl, ref info);
            return info;
        }

        /// <summary>
        /// 获取指定控件垂直滚动条的信息
        /// </summary>
        /// <param name="scrollCtrl">Scrollable控件</param>
        /// <param name="barInfo">用来保存信息的结构体，为减少内存垃圾，可以创建一个固定的变量来保存数据</param>
        /// <returns></returns>
        public static void GetControlVScrollBarInfo(Control scrollCtrl, ref SCROLLBARINFO barInfo)
        {
            if (scrollCtrl == null)
                throw new ArgumentNullException("object is null");

            if (GetScrollBarInfo(scrollCtrl.Handle, OBJID_VSCROLL, ref barInfo) == 0)
                throw new ApplicationException(GetLastError().ToString());
        }

        /// <summary>
        /// 设置指定的vScrollBar控件的滚动信息
        /// </summary>
        /// <param name="vScrollBar">垂直滚动条控件</param>
        /// <param name="scrollInfo"></param>
        /// <returns>vScrollBar滚动框当前位置</returns>
        public static int SetVScrollBarControlScrollInfo(VScrollBar vScrollBar, SCROLLINFO scrollInfo)
        {
            if (vScrollBar == null)
                throw new ArgumentNullException("object is null");

            vScrollBar.Minimum = scrollInfo.nMin;
            vScrollBar.Maximum = scrollInfo.nMax;
            vScrollBar.LargeChange = Convert.ToInt32(scrollInfo.nPage);
            vScrollBar.SmallChange = SMALLCHANGE;
            vScrollBar.Value = scrollInfo.nPos;

            return vScrollBar.Value;
        }

        /// <summary>
        /// 设置指定控件的滚动信息
        /// </summary>
        /// <param name="scrollCtrl">Scrollable控件</param>
        /// <param name="scrollInfo"></param>
        /// <param name="barType">要设置的滚动条类型: SB_VERT SB_HORZ</param>
        /// <returns></returns>
        public static int SetControlScrollInfo(Control scrollCtrl, SCROLLINFO scrollInfo, int barType)
        {
            if (scrollCtrl == null)
                throw new ArgumentNullException("object is null");

            return SetScrollInfo(scrollCtrl.Handle, barType, ref scrollInfo, true);
        }
        #endregion
    }

}
