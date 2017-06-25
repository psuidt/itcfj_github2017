using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingSourceWinfrom
{
    public partial class 主从表 : Form
    {
        
        public 主从表()
        {
            InitializeComponent();
        }

        private void 主从表_Load(object sender, EventArgs e)
        {

            Userinfo user = new Userinfo
            {
                UserAge = "33",
                UserID = "11",
                UserNAME = "张三" ,
                listEmailP = new List<Emial> {  new Emial{ EmialID="2", EmialNAME="aa.com", UserID="22"}}
            };
            BindingSource b1 = new BindingSource();
            b1.DataSource = user;
            b1.DataMember = "";
        }
    }

    public class Userinfo
    {
        public string UserID { get; set; }
        public string UserNAME { get; set; }
        public string UserAge { get; set; }
        public List<Emial> listEmailP { get; set; }
     
    }

    public class Emial
    {
        public string EmialID { get; set; }
        public string UserID { get; set; }
        public string EmialNAME { get; set; }
    }
}
