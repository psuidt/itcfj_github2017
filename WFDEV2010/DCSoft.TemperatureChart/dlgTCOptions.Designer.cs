namespace DCSoft.TemperatureChart
{
    partial class dlgTCOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHourTicks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYSplitNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSymbolSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvHeaderLines = new System.Windows.Forms.DataGridView();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDateKeyword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvYAxisInfos = new System.Windows.Forms.DataGridView();
            this.TitleY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueMember = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SymbolStyle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SymbolColor = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvFooterLines = new System.Windows.Forms.DataGridView();
            this.TextH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueTypeH = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDateFormatString = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNumOfDaysInOnePage = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFontName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBackColor = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaderLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYAxisInfos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFooterLines)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "时刻数序列：";
            // 
            // txtHourTicks
            // 
            this.txtHourTicks.Location = new System.Drawing.Point(125, 20);
            this.txtHourTicks.Name = "txtHourTicks";
            this.txtHourTicks.Size = new System.Drawing.Size(115, 21);
            this.txtHourTicks.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Y轴分割区域数量：";
            // 
            // txtYSplitNum
            // 
            this.txtYSplitNum.Location = new System.Drawing.Point(125, 54);
            this.txtYSplitNum.Name = "txtYSplitNum";
            this.txtYSplitNum.Size = new System.Drawing.Size(115, 21);
            this.txtYSplitNum.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数据点符号大小：";
            // 
            // txtSymbolSize
            // 
            this.txtSymbolSize.Location = new System.Drawing.Point(447, 54);
            this.txtSymbolSize.Name = "txtSymbolSize";
            this.txtSymbolSize.Size = new System.Drawing.Size(100, 21);
            this.txtSymbolSize.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "字体：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "标题行：";
            // 
            // dgvHeaderLines
            // 
            this.dgvHeaderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHeaderLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Text,
            this.StartDateKeyword,
            this.ValueType});
            this.dgvHeaderLines.Location = new System.Drawing.Point(71, 182);
            this.dgvHeaderLines.Name = "dgvHeaderLines";
            this.dgvHeaderLines.RowTemplate.Height = 23;
            this.dgvHeaderLines.Size = new System.Drawing.Size(492, 106);
            this.dgvHeaderLines.TabIndex = 80;
            // 
            // Text
            // 
            this.Text.DataPropertyName = "Text";
            this.Text.HeaderText = "文本";
            this.Text.Name = "Text";
            // 
            // StartDateKeyword
            // 
            this.StartDateKeyword.DataPropertyName = "StartDateKeyword";
            this.StartDateKeyword.HeaderText = "起始关键字";
            this.StartDateKeyword.Name = "StartDateKeyword";
            // 
            // ValueType
            // 
            this.ValueType.DataPropertyName = "ValueType";
            this.ValueType.HeaderText = "数据类型";
            this.ValueType.Name = "ValueType";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Y坐标轴：";
            // 
            // dgvYAxisInfos
            // 
            this.dgvYAxisInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYAxisInfos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleY,
            this.ValueMember,
            this.MaxValue,
            this.MinValue,
            this.SymbolStyle,
            this.SymbolColor});
            this.dgvYAxisInfos.Location = new System.Drawing.Point(71, 429);
            this.dgvYAxisInfos.Name = "dgvYAxisInfos";
            this.dgvYAxisInfos.RowTemplate.Height = 23;
            this.dgvYAxisInfos.Size = new System.Drawing.Size(665, 127);
            this.dgvYAxisInfos.TabIndex = 90;
            this.dgvYAxisInfos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYAxisInfos_CellClick);
            // 
            // TitleY
            // 
            this.TitleY.DataPropertyName = "Title";
            this.TitleY.HeaderText = "标题";
            this.TitleY.Name = "TitleY";
            // 
            // ValueMember
            // 
            this.ValueMember.DataPropertyName = "ValueMember";
            this.ValueMember.HeaderText = "数据类型";
            this.ValueMember.Name = "ValueMember";
            // 
            // MaxValue
            // 
            this.MaxValue.DataPropertyName = "MaxValue";
            this.MaxValue.HeaderText = "最大值";
            this.MaxValue.Name = "MaxValue";
            // 
            // MinValue
            // 
            this.MinValue.DataPropertyName = "MinValue";
            this.MinValue.HeaderText = "最小值";
            this.MinValue.Name = "MinValue";
            // 
            // SymbolStyle
            // 
            this.SymbolStyle.DataPropertyName = "SymbolStyle";
            this.SymbolStyle.HeaderText = "符号类型";
            this.SymbolStyle.Name = "SymbolStyle";
            // 
            // SymbolColor
            // 
            this.SymbolColor.DataPropertyName = "SymbolColor";
            this.SymbolColor.HeaderText = "颜色";
            this.SymbolColor.Name = "SymbolColor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "页脚行：";
            // 
            // dgvFooterLines
            // 
            this.dgvFooterLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFooterLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TextH,
            this.ValueTypeH});
            this.dgvFooterLines.Location = new System.Drawing.Point(71, 304);
            this.dgvFooterLines.Name = "dgvFooterLines";
            this.dgvFooterLines.RowTemplate.Height = 23;
            this.dgvFooterLines.Size = new System.Drawing.Size(493, 110);
            this.dgvFooterLines.TabIndex = 100;
            // 
            // TextH
            // 
            this.TextH.DataPropertyName = "Text";
            this.TextH.HeaderText = "文本";
            this.TextH.Name = "TextH";
            // 
            // ValueTypeH
            // 
            this.ValueTypeH.DataPropertyName = "ValueType";
            this.ValueTypeH.HeaderText = "数据类型";
            this.ValueTypeH.Name = "ValueTypeH";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "日期格式化字符串：";
            // 
            // txtDateFormatString
            // 
            this.txtDateFormatString.Location = new System.Drawing.Point(125, 91);
            this.txtDateFormatString.Name = "txtDateFormatString";
            this.txtDateFormatString.Size = new System.Drawing.Size(115, 21);
            this.txtDateFormatString.TabIndex = 40;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "每页显示的天数：";
            // 
            // txtNumOfDaysInOnePage
            // 
            this.txtNumOfDaysInOnePage.Location = new System.Drawing.Point(447, 91);
            this.txtNumOfDaysInOnePage.Name = "txtNumOfDaysInOnePage";
            this.txtNumOfDaysInOnePage.Size = new System.Drawing.Size(100, 21);
            this.txtNumOfDaysInOnePage.TabIndex = 50;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(279, 566);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(381, 566);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFontName
            // 
            this.txtFontName.Location = new System.Drawing.Point(125, 127);
            this.txtFontName.Name = "txtFontName";
            this.txtFontName.Size = new System.Drawing.Size(115, 21);
            this.txtFontName.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(332, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "背景色：";
            // 
            // txtBackColor
            // 
            this.txtBackColor.Location = new System.Drawing.Point(447, 127);
            this.txtBackColor.Name = "txtBackColor";
            this.txtBackColor.Size = new System.Drawing.Size(100, 21);
            this.txtBackColor.TabIndex = 70;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(649, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 101;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dlgTCOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 601);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBackColor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFontName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvFooterLines);
            this.Controls.Add(this.dgvYAxisInfos);
            this.Controls.Add(this.dgvHeaderLines);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNumOfDaysInOnePage);
            this.Controls.Add(this.txtDateFormatString);
            this.Controls.Add(this.txtSymbolSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYSplitNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHourTicks);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgTCOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.dlgTCOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaderLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYAxisInfos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFooterLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHourTicks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYSplitNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSymbolSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvHeaderLines;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvYAxisInfos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvFooterLines;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDateFormatString;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNumOfDaysInOnePage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFontName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBackColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleY;
        private System.Windows.Forms.DataGridViewComboBoxColumn ValueMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn SymbolStyle;
        private System.Windows.Forms.DataGridViewButtonColumn SymbolColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDateKeyword;
        private System.Windows.Forms.DataGridViewComboBoxColumn ValueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextH;
        private System.Windows.Forms.DataGridViewComboBoxColumn ValueTypeH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
    }
}