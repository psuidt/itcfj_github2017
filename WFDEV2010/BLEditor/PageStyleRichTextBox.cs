using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Winning.Emr.EmrEditor
{
    /// <summary>
    /// 让RichTextbox以Word页面样式展现(编辑器可以在编辑区域内居中显示，编辑器和区域之间留有空白，通过编辑器区域的垂直滚动条来控制编辑器)
    /// TODO: 现在独立的垂直滚动条用的是WindowsForm的，若使用Dev的控件，在控制的时候好像有点误差，待确认
    /// </summary>
    public partial class PageStyleRichTextBox : UserControl
    {
        #region public properties
        ///// <summary>
        ///// RTF编辑器的尺寸。在设置尺寸时Height属性无效，高度会随容器的高度动态改变
        ///// 设置编辑器尺寸时不用考虑边距问题
        ///// </summary>
        //public Size EditorSize
        //{
        //   get { return RealEditor.Size; }
        //   set { ResetTreeEditorSize(value.Width); }
        //}

        /// <summary>
        /// RTF编辑器的宽度
        /// </summary>
        public int WidthOfRealBox
        {
            get
            {
                if (RealBox != null)
                    return RealBox.Width;
                else
                    return 0;
            }
            set { ResetRealBoxSize(value); }
        }

        /// <summary>
        /// 真正的RTF编辑器对象
        /// </summary>
        public RichTextBox RealBox
        {
            get
            {
                if (MarginedBox != null)
                    return MarginedBox.IncludedBox;
                else
                    return null;
            }
        }

        /// <summary>
        /// 带固定边距的RTF编辑器
        /// </summary>
        public MarginedRichTextBox MarginedBox
        {
            get { return _marginedBox; }
            set
            {
                UnSetMarginedBox();
                _marginedBox = value;
                SetMarginedBox();
            }
        }
        private MarginedRichTextBox _marginedBox;
        #endregion

        #region private properties
        /// <summary>
        /// 区域最大宽度
        /// </summary>
        private int MaxRegionWidth
        {
            get { return panelEditor.Width; }
        }
        /// <summary>
        /// MarginedEditor是否超过了可显示区域的宽度
        /// </summary>
        private bool IsOverRegionWidth
        {
            get
            {
                if (MarginedBox == null)
                    return false;
                else
                    return (MarginedBox.Width >= MaxRegionWidth);
            }
        }
        #endregion

        #region ctors
        /// <summary>
        /// 
        /// </summary>
        public PageStyleRichTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="margiedBox"></param>
        public PageStyleRichTextBox(MarginedRichTextBox margiedBox)
            : this()
        {
            MarginedBox = margiedBox;
        }
        #endregion

        #region private methods
        private void SetMarginedBox()
        {
            if (MarginedBox != null)
            {
                panelEditor.SuspendLayout();

                MarginedBox.SizeChanged += new EventHandler(marginedBox_SizeChanged);
                panelEditor.Controls.Add(MarginedBox);

                if (RealBox != null)
                {
                //    (RealBox as IScrollNotify).VScrollChanged += new EventHandler<ScrollArgs>(richTextBox_VScrollChanged);
                    ResetRealBoxSize(WidthOfRealBox);
                }
                ResetMarginedBoxLocation();

                panelEditor.ResumeLayout();
            }
        }

        private void UnSetMarginedBox()
        {
            if (MarginedBox != null)
            {
                if (RealBox != null)
                //    (RealBox as IScrollNotify).VScrollChanged -= new EventHandler<ScrollArgs>(richTextBox_VScrollChanged);
                MarginedBox.SizeChanged -= new EventHandler(marginedBox_SizeChanged);
            }
        }

        private void ResetRealBoxSize(int newWidth)
        {
            if (RealBox == null)
                return;

            this.SuspendLayout();

            int newHeight = panelEditor.Height;

            // 如果宽度超过Panel(这里要加上边距)，则Panel会显示水平滚动条，而编辑器此时的高度是和Panel一样的，
            // 会导致Panel出现垂直滚动条，所以要减小editor的高度，以避免panel出现垂直滚动条
            if ((newWidth + MarginedBox.MarginWidth) > MaxRegionWidth)
                newHeight -= SystemInformation.HorizontalScrollBarHeight;

            RealBox.Size = new Size(newWidth, newHeight);

            this.ResumeLayout();
        }

        /// <summary>
        /// 计算TreeEditor的显示位置（默认居中显示）
        /// </summary>
        /// <returns></returns>
        private Point CalcMarginedBoxLocation()
        {
            // 默认居中显示，Top从0开始
            // 如果editor宽度超过Panel宽度，则从(0,0)开始
            if (IsOverRegionWidth)
                return new Point(0, 0);
            else
            {
                int margin = (panelEditor.Width - MarginedBox.Width) / 2;
                return new Point(margin, 0);
            }
        }

        private void ResetMarginedBoxLocation()
        {
            // 计算editor的位置
            if (MarginedBox != null)
                MarginedBox.Location = CalcMarginedBoxLocation();
        }

        private void ResetRealBoxVScrollPos()
        {
            // 位置改变后要同步设置RTF编辑器的滚动条
            //if (RealBox != null)
          //      (RealBox as IScrollNotify).SetVScrollPos(vScrollBarNew.Value);
        }
        #endregion

        #region control events
        private void PageStyleRichTextBox_SizeChanged(object sender, System.EventArgs e)
        {
            // 容器尺寸改变后，有可能会导致宽度小于编辑器的宽度，所以通过重设尺寸来进行相关检查和处理
            ResetRealBoxSize(WidthOfRealBox);

            ResetMarginedBoxLocation();
        }

        private void marginedBox_SizeChanged(object sender, EventArgs e)
        {
            ResetMarginedBoxLocation();
        }

        //private void richTextBox_VScrollChanged(object sender, ScrollArgs e)
        //{
        //    vScrollBarNew.Enabled = (e.ScrollBarEnabled);
        //    if (e.ScrollBarEnabled)
        //    {
        //        ScrollNativeHelper.SetVScrollBarControlScrollInfo(vScrollBarNew, e.ScrollInfo);
        //    }
        //    else
        //    {
        //        vScrollBarNew.Maximum = 0;
        //    }
        //}

        private void vScrollBarNew_ValueChanged(object sender, EventArgs e)
        {
            ResetRealBoxVScrollPos();
        }
        #endregion

        #region internal debug method
        internal string GetControlInfo()
        {
            StringBuilder infos = new StringBuilder();
            infos.AppendLine(String.Format("Editor:{0}", RealBox.Location));
            infos.AppendLine(String.Format("Editor:{0}", RealBox.Size));
            infos.AppendLine(String.Format("Panel:{0}", panelEditor.Size));
            infos.AppendLine("Editor:vScrollBar");
           // infos.AppendLine(ScrollNativeHelper.GetControlVScrollInfo(RealBox).ToString());
            infos.AppendLine("vScrollBarNew");
          //  infos.AppendLine(ScrollNativeHelper.GetVScrollBarControlScrollInfo(vScrollBarNew).ToString());
            return infos.ToString();
        }
        #endregion
    }
}
