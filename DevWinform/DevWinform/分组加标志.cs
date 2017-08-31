using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevWinform
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list1 = new List<string>();
            List<Test> ListTest = new List<Test>() 
            { 
                new Test { XH = 10, FZXH = 8,  GroupState =string.Empty} ,//Null
                new Test { XH = 11, FZXH = 9 ,  GroupState =string.Empty} ,//Begin
                new Test { XH = 12, FZXH = 9,  GroupState =string.Empty } ,//End
                new Test { XH = 13, FZXH =12  ,  GroupState =string.Empty } ,//Begin
                new Test { XH = 14, FZXH = 12 ,  GroupState =string.Empty } ,//Middle
                new Test { XH =15, FZXH =12  ,  GroupState =string.Empty } ,//End
                new Test { XH = 16, FZXH = 14 ,  GroupState =string.Empty } //
            };
            //ListTest = ListTest.OrderBy(P => new { P.XH, P.FZXH }).ToList();
            int tmpFzxh = -1;
            int n = 1;
            for (int i = 0; i < ListTest.Count; i++)
            {
                var item = ListTest[i];
                if (tmpFzxh == item.FZXH)
                {
                    if (n != 0)
                        item.GroupState = "Middle";
                    n++;
                }
                else
                {
                    if ((i - 1) >= 0)
                        ListTest[i - 1].GroupState = (n == 1) ? "Null" : "End";
                    n = 1;
                    item.GroupState = (i + 1 == ListTest.Count) ? "Null" : "Begin";
                }
                tmpFzxh = item.FZXH;
            }

            var var1 = ListTest.GroupBy(P => P.FZXH).Where(P => P.Count() > 1).Select(m => m.Key);
            foreach (var item in var1)
            {
                //   ListTest.Where(P=>P.FZXH=item)
                list1.Add(item.ToString());
            }

            foreach (var item in ListTest)
            {

            }


        }
    }
    public class Test
    {
        public int XH { get; set; }
        public int FZXH { get; set; }
        public string GroupState { get; set; }
    }
}
