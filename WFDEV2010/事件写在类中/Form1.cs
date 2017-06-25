using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 事件写在类中
{
    public partial class Form1 : Form
    {
        private OrderManger orderManger;
        public Form1()
        {
            InitializeComponent();
            orderManger = new OrderManger();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            orderManger.Refdata += orderManger_Refdata;
        }

        void orderManger_Refdata(object sender, EventArgs e)
        {
            this.textEdit1.Text = "ddfdsf";
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string> { "1", "2", "3", "2", "" };
            List<string> list1 = new List<string> { "1", "2", "6", "7" };
            List<string> list2 = list1.Except(list).ToList<string>();

            string strCrbdms = "14岁_006|乙型,012|麻疹,015|流行性乙脑炎,048|风疹,056|手足口病,031|新生儿破伤风,064|AFP";
            string[] crbbmArray = strCrbdms.Split(new char[] { ',' });
            IDictionary<string, string> nlxz = new Dictionary<string, string>(); //有年龄限制的传染病编码
            string strCrbdms1 = string.Empty;//没有年龄限制的传染病编码
            foreach (string item in crbbmArray)
            {
                string m1 = item.Split(new char[] { '|' })[0];
                if (!m1.Contains("_"))
                {
                    strCrbdms1 += "," + m1;
                }
                else
                {
                    string[] nlstr = m1.Split('_');
                    nlxz.Add(nlstr[0].Replace("岁", ""), nlstr[1]);
                }
            }
            //new Form2(this.orderManger).ShowDialog();
            //  orderManger.NewData();
        }
    }
}
