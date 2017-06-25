namespace Dev13
{
    partial class ToolTipController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.popupGalleryEdit1 = new DevExpress.XtraEditors.PopupGalleryEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupGalleryEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController1
            // 
            this.toolTipController1.AllowHtmlText = true;
            this.toolTipController1.AutoPopDelay = 9000;
            this.toolTipController1.ToolTipLocation = DevExpress.Utils.ToolTipLocation.TopCenter;
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "ddd ";
            this.textEdit1.Location = new System.Drawing.Point(21, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AutoHeight = false;
            this.textEdit1.Size = new System.Drawing.Size(393, 105);
            this.textEdit1.TabIndex = 0;
            this.textEdit1.ToolTipController = this.toolTipController1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(174, 28);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(240, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.ToolTipController = this.toolTipController1;
            this.simpleButton1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Exclamation;
            this.simpleButton1.ToolTipTitle = "dddd";
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(420, 31);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(100, 20);
            this.textEdit2.TabIndex = 2;
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = "fasfdsf";
            this.memoEdit1.Location = new System.Drawing.Point(6, 123);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.memoEdit1.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.memoEdit1.Size = new System.Drawing.Size(559, 179);
            this.memoEdit1.TabIndex = 3;
            this.memoEdit1.UseOptimizedRendering = true;
            // 
            // popupGalleryEdit1
            // 
            this.popupGalleryEdit1.Location = new System.Drawing.Point(153, 330);
            this.popupGalleryEdit1.Name = "popupGalleryEdit1";
            this.popupGalleryEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupGalleryEdit1.Size = new System.Drawing.Size(100, 20);
            this.popupGalleryEdit1.TabIndex = 4;
            // 
            // ToolTipController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 415);
            this.Controls.Add(this.popupGalleryEdit1);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textEdit1);
            this.Name = "ToolTipController";
            this.Text = "ToolTipController";
            this.Load += new System.EventHandler(this.ToolTipController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupGalleryEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.PopupGalleryEdit popupGalleryEdit1;
    }
}