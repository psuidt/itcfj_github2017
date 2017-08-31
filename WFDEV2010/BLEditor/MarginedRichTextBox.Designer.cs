namespace Winning.Emr.EmrEditor
{
    partial class MarginedRichTextBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelCoverVScroll = new System.Windows.Forms.Panel();
            this.panelMarginLeft = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelCoverVScroll
            // 
            this.panelCoverVScroll.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelCoverVScroll.Location = new System.Drawing.Point(377, 28);
            this.panelCoverVScroll.Name = "panelCoverVScroll";
            this.panelCoverVScroll.Size = new System.Drawing.Size(21, 190);
            this.panelCoverVScroll.TabIndex = 4;
            // 
            // panelMarginLeft
            // 
            this.panelMarginLeft.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelMarginLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMarginLeft.Location = new System.Drawing.Point(0, 0);
            this.panelMarginLeft.Name = "panelMarginLeft";
            this.panelMarginLeft.Size = new System.Drawing.Size(19, 409);
            this.panelMarginLeft.TabIndex = 3;
            // 
            // MarginedRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCoverVScroll);
            this.Controls.Add(this.panelMarginLeft);
            this.Name = "MarginedRichTextBox";
            this.Size = new System.Drawing.Size(520, 409);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCoverVScroll;
        private System.Windows.Forms.Panel panelMarginLeft;

    }
}
