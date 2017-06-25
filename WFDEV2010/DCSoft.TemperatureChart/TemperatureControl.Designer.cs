namespace DCSoft.TemperatureChart
{
    partial class TemperatureControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemperatureControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboPageIndex = new System.Windows.Forms.ToolStripComboBox();
            this.btnPrintCurrentPage = new System.Windows.Forms.ToolStripButton();
            this.btnPrintAll = new System.Windows.Forms.ToolStripButton();
            this.pnlView = new System.Windows.Forms.UserControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cboPageIndex,
            this.btnPrintCurrentPage,
            this.btnPrintAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(435, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "页码：";
            // 
            // cboPageIndex
            // 
            this.cboPageIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPageIndex.Name = "cboPageIndex";
            this.cboPageIndex.Size = new System.Drawing.Size(121, 25);
            this.cboPageIndex.SelectedIndexChanged += new System.EventHandler(this.cboPageIndex_SelectedIndexChanged);
            this.cboPageIndex.Click += new System.EventHandler(this.cboPageIndex_Click);
            // 
            // btnPrintCurrentPage
            // 
            this.btnPrintCurrentPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrintCurrentPage.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintCurrentPage.Image")));
            this.btnPrintCurrentPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintCurrentPage.Name = "btnPrintCurrentPage";
            this.btnPrintCurrentPage.Size = new System.Drawing.Size(81, 22);
            this.btnPrintCurrentPage.Text = "打印当前页...";
            this.btnPrintCurrentPage.Click += new System.EventHandler(this.btnPrintCurrentPage_Click);
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPrintAll.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintAll.Image")));
            this.btnPrintAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(69, 22);
            this.btnPrintAll.Text = "打印全部...";
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // pnlView
            // 
            this.pnlView.AutoScroll = true;
            this.pnlView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(0, 25);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(435, 318);
            this.pnlView.TabIndex = 1;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlView_Paint);
            // 
            // TemperatureChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TemperatureChartControl";
            this.Size = new System.Drawing.Size(435, 343);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cboPageIndex;
        private System.Windows.Forms.ToolStripButton btnPrintCurrentPage;
        private System.Windows.Forms.UserControl pnlView;
        private System.Windows.Forms.ToolStripButton btnPrintAll;
    }
}
