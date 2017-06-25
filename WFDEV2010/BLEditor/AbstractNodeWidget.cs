using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winning.Emr.EmrEditor;

namespace BLEditor
{
    public class AbstractNodeWidget : Panel
    {
        PageStyleRichTextBox m_PageStyleBox;
        public AbstractNodeWidget()
        {
        //    InitializeComponent();
            InitializePanel();
        }
        /// <summary>
        /// 初始化面板
        /// </summary>
        private void InitializePanel()
        {
            this.Location = new System.Drawing.Point(1, 1);
            this.Size = new System.Drawing.Size(50, 30);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Margin = new Padding(0);

            m_PageStyleBox = new PageStyleRichTextBox(new MarginedRichTextBox(new Editor() { Text = "病历编辑器" }));
            m_PageStyleBox.Dock = DockStyle.Fill;
            m_PageStyleBox.WidthOfRealBox = 646;
            this.Controls.Add(m_PageStyleBox);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }


}
