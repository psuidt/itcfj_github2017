using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLEditor
{

    /// <summary>
    /// 滚动条发生滚动事件参数
    /// </summary>
    public class ScrollArgs : EventArgs
    {
        /// <summary>
        /// 滚动条是否启用
        /// </summary>
        public bool ScrollBarEnabled
        {
            get { return _scrollBarEnabled; }
            set { _scrollBarEnabled = value; }
        }
        private bool _scrollBarEnabled;

        /// <summary>
        /// 滚动条是否可见
        /// </summary>
        public bool ScrollBarVisiable
        {
            get { return _scrollBarVisiable; }
            set { _scrollBarVisiable = value; }
        }
        private bool _scrollBarVisiable;

        /// <summary>
        /// 滚动条信息
        /// </summary>
        [CLSCompliant(false)]
        public SCROLLINFO ScrollInfo
        {
            get { return _scrollInfo; }
            set { _scrollInfo = value; }
        }
        private SCROLLINFO _scrollInfo;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="barInfo"></param>
        /// <param name="info"></param>
        [CLSCompliant(false)]
        public ScrollArgs(SCROLLBARINFO barInfo, SCROLLINFO info)
        {
            ScrollBarVisiable = ((barInfo.rgstate[0] & ScrollNativeHelper.STATE_SYSTEM_INVISIBLE) == 0);
            ScrollBarEnabled = ((barInfo.rgstate[0] & ScrollNativeHelper.STATE_SYSTEM_UNAVAILABLE) == 0)
               && ScrollBarVisiable;
            ScrollInfo = info;
        }
    }
}

