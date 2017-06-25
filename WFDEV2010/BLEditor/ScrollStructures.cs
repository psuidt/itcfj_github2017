using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLEditor
{
    /// <summary>
    /// 滚动条滚动信息体
    /// </summary>
    [CLSCompliant(false)]
    public struct SCROLLINFO
    {
        /// <summary>
        /// 
        /// </summary>
        public int cbSize;
        /// <summary>
        /// 
        /// </summary>
        public UInt32 fMask;
        /// <summary>
        /// 
        /// </summary>
        public Int32 nMin;
        /// <summary>
        /// 
        /// </summary>
        public Int32 nMax;
        /// <summary>
        /// 
        /// </summary>
        public UInt32 nPage;
        /// <summary>
        /// 
        /// </summary>
        public Int32 nPos;
        /// <summary>
        /// 
        /// </summary>
        public Int32 nTrackPos;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("min{0} max{1} page{2} pos{3} track{4}", nMin, nMax, nPage, nPos, nTrackPos);
        }
    }

    /// <summary>
    /// 滚动条信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SCROLLBARINFO
    {
        /// <summary>
        /// 
        /// </summary>
        public int cbSize;
        /// <summary>
        /// 
        /// </summary>
        public Rectangle rcScrollBar;
        /// <summary>
        /// 
        /// </summary>
        public int dxyLineButton;
        /// <summary>
        /// 
        /// </summary>
        public int xyThumbTop;
        /// <summary>
        /// 
        /// </summary>
        public int xyThumbBottom;
        /// <summary>
        /// 
        /// </summary>
        public int reserved;
        /// <summary>
        /// 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public int[] rgstate;
    }
}
