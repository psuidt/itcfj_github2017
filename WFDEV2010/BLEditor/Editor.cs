using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEditor
{
    public class Editor : RichTextBox, IScrollNotify
    {
        private SCROLLBARINFO m_VScrollBarInfo;
        private SCROLLINFO m_VScrollInfo;
        /// <summary>
        /// 正在更新独立的滚动条控件(通过此变量来避免编辑器和独立的垂直循环影响)
        /// </summary>
        private bool m_IsUpdateScrollBar;
        /// <summary>
        /// 需要更新独立的滚动条(通过此变量来实现延迟发送滚动条改变事件，即在RichTextBox重画后再发送)
        /// </summary>
        private bool m_NeedUpdateScroll;
        #region custom event handler
        /// <summary>
        /// 垂直滚动条发生改变事件
        /// </summary>
        public event EventHandler<ScrollArgs> VScrollChanged;
        private void CallVScrollChanged()
        {
            if (VScrollChanged != null)
            {
                m_IsUpdateScrollBar = true;
                // 获得滚动条是否显示信息，获得滚动条位置信息
                ScrollNativeHelper.GetControlVScrollBarInfo(this, ref m_VScrollBarInfo);
                m_VScrollInfo.fMask = ScrollNativeHelper.SIF_ALL;
                ScrollNativeHelper.GetControlVScrollInfo(this, ref m_VScrollInfo);

                VScrollChanged(this, new ScrollArgs(m_VScrollBarInfo, m_VScrollInfo));
                m_IsUpdateScrollBar = false;
            }
        }
        #endregion
        public void SetVScrollPos(int pos)
        {
            if (m_IsUpdateScrollBar)
                return;

            if (pos == m_VScrollInfo.nPos)
                return;
            // 最初是通过计算滚动的页数和行数来重设编辑器的滚动条参数，但是两种滚动条默认的控制参数有不一样(主要是在翻页时是否会减少一行高度上)，
            // 因此现在直接发消息重设编辑器的滚动条参数
            ScrollNativeHelper.SendMessage(this.Handle, ScrollNativeHelper.WM_VSCROLL, new IntPtr(ScrollNativeHelper.SB_THUMBPOSITION + (pos << 16)), new IntPtr());
            m_VScrollInfo.nPos = pos;
        }
    }
}
