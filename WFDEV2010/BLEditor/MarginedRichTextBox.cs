using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BLEditor;

namespace Winning.Emr.EmrEditor
{
    /// <summary>
    /// 在RTF编辑器的左右两边加上固定的空白区域，以覆盖滚动条(现在只处理垂直滚动条)
    /// </summary>
    public partial class MarginedRichTextBox : UserControl
    {
        #region public properties
        ///// <summary>
        ///// RTF编辑器真实的尺寸
        ///// </summary>
        //public Size TreeEditorTrueSize
        //{
        //   get { return treeEditor.Size; }
        //   set
        //   {
        //      treeEditor.Size = value;
        //   }
        //}

        /// <summary>
        /// 原始的控件
        /// </summary>
        public RichTextBox IncludedBox
        {
            get { return _includedBox; }
            set
            {
                IScrollNotify scrollBox = (value as IScrollNotify);
                if (scrollBox == null)
                    throw new ArgumentException("必须是支持IScrollNotify的编辑控件");

                UnSetIncludedBox();

                _includedBox = value;

                SetIncludedBox();

            }
        }
        private RichTextBox _includedBox;

        /// <summary>
        /// 固定边距的宽度
        /// </summary>
        public int MarginWidth
        {
            get { return panelCoverVScroll.Width; }
        }
        #endregion

        #region ctors
        /// <summary>
        /// 
        /// </summary>
        public MarginedRichTextBox()
        {
            InitializeComponent();

            CustomInitialize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="box"></param>
        public MarginedRichTextBox(RichTextBox box)
            : this()
        {
            IncludedBox = box;
        }
        #endregion

        //#region custom event handler
        ///// <summary>
        ///// 垂直滚动条发生改变事件
        ///// </summary>
        //public event EventHandler<ScrollArgs> VScrollChanged;
        //#endregion

        //#region public methods
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pos"></param>
        //public void SetVScrollPos(int pos)
        //{
        //    IncludedBox.SetVScrollPos(pos);
        //}
       // #endregion

        #region private methods
        private void SetIncludedBox()
        {
            if (_includedBox != null)
            {
                this.SuspendLayout();
                _includedBox.BorderStyle = BorderStyle.None;
                _includedBox.Dock = DockStyle.Fill;
                _includedBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
                _includedBox.SizeChanged += new EventHandler(realControl_SizeChanged);
                //(_includedBox as IScrollNotify).VScrollChanged += new EventHandler<ScrollArgs>(realControl_VScrollChanged);
                this.Controls.Remove(panelMarginLeft);
                this.Controls.Add(_includedBox);
                this.Controls.Add(panelMarginLeft);
                this.ResumeLayout();
            }
        }

        private void UnSetIncludedBox()
        {

            if (_includedBox != null)
            {
                _includedBox.SizeChanged -= new EventHandler(realControl_SizeChanged);
                //(_includedBox as IScrollNotify).VScrollChanged -= new EventHandler<ScrollArgs>(realControl_VScrollChanged);
            }
        }

        private void CustomInitialize()
        {
            panelCoverVScroll.Width = SystemInformation.VerticalScrollBarWidth;
            panelMarginLeft.Width = panelCoverVScroll.Width;
        }

        private void ResetControlSize()
        {
            this.Size = new Size(IncludedBox.Size.Width + MarginWidth, IncludedBox.Height);
            panelCoverVScroll.Height = IncludedBox.Height;
        }

        private void ResetCoverPanelLocation()
        {
            // 位置（从editor的vScrollBar的左上角开始）
            panelCoverVScroll.Location = new Point(IncludedBox.Left + IncludedBox.Width - SystemInformation.VerticalScrollBarWidth
               , IncludedBox.Top);
        }
        #endregion

        private void realControl_SizeChanged(object sender, EventArgs e)
        {
            ResetControlSize();
            ResetCoverPanelLocation();
        }

        //private void realControl_VScrollChanged(object sender, ScrollArgs e)
        //{
        //   if (VScrollChanged != null)
        //      VScrollChanged(this, e);
        //}
    }
}
