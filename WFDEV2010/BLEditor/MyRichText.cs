using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEditor
{
    public partial class MyRichText : RichTextBox
    {
        public MyRichText()
        {
            InitializeComponent();
            //    GetCharIndexFromPosition()

        }
        Button btn = null;
        private void MyRichText_MouseDown(object sender, MouseEventArgs e)
        {
            int charIndex = GetCharIndexFromPosition(e.Location);
            Select(charIndex, charIndex + 10);
            if (btn == null)
            {
                btn = new Button { Text = "aaa" };
                this.Controls.Add(btn);
                btn.Location = GetPositionFromCharIndex(this.SelectionStart); ;
            }
            //bt.Location = new Point(charIndex,e.Y);


            btn.Location = GetPositionFromCharIndex(this.SelectionStart); ;



            //   EditNodeFindResult enfr = HelperOfIndex.FindLowestNode(charIndex);
        }
    }
}
