using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds=new DataSet ();
            System.Data.SqlClient.SqlConnection sqlcon = new System.Data.SqlClient.SqlConnection("Data Source=.;Initial Catalog=CISDB;User ID=sa;Password=123");
            sqlcon.Open();
            System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter("SELECT cb.EMRXH,cb.HZXM FROM CPOE_BRSYK cb", sqlcon);
            sda.Fill(ds);

            FastReport.Report frt = new Report();

            frt.RegisterData(ds, "Table");
            frt.Load(@"E:\MyWork\C#AndWinform开发\DevProject\WFDEV2010\FastReport\bin\Debug\frt.frx");
            frt.Print();
            //frt.Design();

        }
    }
}
