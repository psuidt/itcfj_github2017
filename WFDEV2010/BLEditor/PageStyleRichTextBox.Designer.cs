namespace Winning.Emr.EmrEditor
{
    partial class PageStyleRichTextBox
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
            this.panelEditor = new System.Windows.Forms.Panel();
            this.vScrollBarNew = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // panelEditor
            // 
            this.panelEditor.AutoScroll = true;
            this.panelEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEditor.Location = new System.Drawing.Point(0, 0);
            this.panelEditor.Margin = new System.Windows.Forms.Padding(0);
            this.panelEditor.Name = "panelEditor";
            this.panelEditor.Size = new System.Drawing.Size(1001, 442);
            this.panelEditor.TabIndex = 6;
            // 
            // vScrollBarNew
            // 
            this.vScrollBarNew.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBarNew.Enabled = false;
            this.vScrollBarNew.LargeChange = 1;
            this.vScrollBarNew.Location = new System.Drawing.Point(1001, 0);
            this.vScrollBarNew.Maximum = 0;
            this.vScrollBarNew.Name = "vScrollBarNew";
            this.vScrollBarNew.Size = new System.Drawing.Size(16, 442);
            this.vScrollBarNew.TabIndex = 5;
            // 
            // PageStyleRichTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEditor);
            this.Controls.Add(this.vScrollBarNew);
            this.Name = "PageStyleRichTextBox";
            this.Size = new System.Drawing.Size(1017, 442);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEditor;
        private System.Windows.Forms.VScrollBar vScrollBarNew;
    }
}
