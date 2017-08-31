using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winning.Emr.EmrEditor;

namespace BLEditor
{
    public partial class Form1 : Form
    {
        PageStyleRichTextBox m_PageStyleBox;
        public Form1()
        {
            InitializeComponent();
            AbstractNodeWidget a = new AbstractNodeWidget();
            a.Dock = DockStyle.Fill;
            a.Dock = DockStyle.Fill; // 现在直接Dock即可
            this.Controls.Add(a);
            //m_PageStyleBox = new PageStyleRichTextBox(new MarginedRichTextBox(new Editor() { Text = "fadsfdsa" }));
            //m_PageStyleBox.Dock = DockStyle.Fill;
            //m_PageStyleBox.WidthOfRealBox = 646;
            //this.Controls.Add(m_PageStyleBox);
        }
    }
}
