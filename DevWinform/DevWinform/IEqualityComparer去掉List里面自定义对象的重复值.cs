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
    public partial class IEqualityComparer去掉List里面自定义对象的重复值 : Form
    {
        public IEqualityComparer去掉List里面自定义对象的重复值()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CFDP_DPJLK> list1 = new List<CFDP_DPJLK>

            {
                  new CFDP_DPJLK{ CFXH="a55" , ID="1", YPM="3", CFXH1="m22m", CFXH2="32233"},
                  new CFDP_DPJLK{ CFXH="a" , ID="1", YPM="3", CFXH1="mm", CFXH2="33322"},
                  new CFDP_DPJLK{ CFXH="a" , ID="2", YPM="3", CFXH1="m22m", CFXH2="333"},
                  new CFDP_DPJLK{ CFXH="aa" , ID="5", YPM="3", CFXH1="mm", CFXH2="3rrr33"},
                  new CFDP_DPJLK{ CFXH="aaaa" , ID="1", YPM="3", CFXH1="mm", CFXH2="3rrrrr33"},
                     new CFDP_DPJLK{ CFXH="a" , ID="335", YPM="3", CFXH1="mm", CFXH2="3rrr33"},
                  new CFDP_DPJLK{ CFXH="a" , ID="331", YPM="3", CFXH1="mm", CFXH2="3rrrrr33"}
            };
            //List<string> liststr = new List<string>();
            //liststr.Add("1");
            //liststr.Add("2");
            //liststr.Add("3");
            //liststr.Add("4");
            //liststr.Add("5");

            //List<CFDP_DPJLK> list5 = list1.Where(P => liststr.Contains(P.ID)).ToList();

            List<CFDP_DPJLK> list2 = list1.Distinct(new PerComparintMTYCCFBZ()).ToList();

            new Form1().Show();


        }
    }


    internal class PerComparintMTYCCFBZ : IEqualityComparer<CFDP_DPJLK>
    {
        public bool Equals(CFDP_DPJLK x, CFDP_DPJLK y)
        {
            if (x == null && y == null)
                return false;
            return x.CFXH == y.CFXH;
        }
        public int GetHashCode(CFDP_DPJLK obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
