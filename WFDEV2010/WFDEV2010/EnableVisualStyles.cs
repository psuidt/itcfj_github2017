using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFDEV2010
{
    public partial class EnableVisualStyles : Form
    {
        private System.Windows.Forms.Button button1;

        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.Run(new EnableVisualStyles());
        //}

        public EnableVisualStyles()
        {
       InitializeComponent();
            this.button1 = new System.Windows.Forms.Button();
            this.button1.Location = new System.Drawing.Point(24, 16);
            this.button1.Size = new System.Drawing.Size(120, 100);
            this.button1.FlatStyle = FlatStyle.System;
            this.button1.Text = "I am themed.";

            // Sets up how the form should be displayed and adds the controls to the form.
            this.ClientSize = new System.Drawing.Size(300, 286);
            this.Controls.Add(this.button1);

            this.Text = "Application.EnableVisualStyles Example";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);
            

            MessageBox.Show(Application.UserAppDataPath+"  "+Application.StartupPath+""+Application.ExecutablePath+"  "+Application. LocalUserAppDataPath );
           // Application.Restart();
        }

    }
}
