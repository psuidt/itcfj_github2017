using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLEditor
{
    public partial class FrmRTF : Form
    {
        public FrmRTF()
        {
            InitializeComponent();
            richTextBox1.Rtf = @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fmodern\fprq6\fcharset134   \ 'cb\ 'ce\ 'cc\ 'e5;}{\f1\fnil\fcharset134   \ 'cb\ 'ce\ 'cc\ 'e5;}}"
                + @"{\colortbl   ;\red0\green0\blue0;\red255\green0\blue0;\red0\green0\blue255;}"
                + @"\viewkind4\uc1\pard\cf1\lang2052\f0\fs20 \cf1 黑色字\cf2 红色字\cf0\f1\fs18\par } ";

        }
        private Hashtable hs = new Hashtable();

        private void FrmRTF_Load(object sender, EventArgs e)
        {

            /*
            Hashtable hs2 = new Hashtable();
            hs2.Add("url", "http://www.163.com");
            hs2.Add("start", -1);
            hs2.Add("end", -1);
            hs.Add("163", hs2);
            string a = @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fmodern\fprq6\fcharset134    'cb 'ce 'cc 'e5;}{\f1\fnil\fcharset134    'cb 'ce 'cc 'e5;}}
{\colortbl ;\red0\green0\blue0;\red255\green0\blue0;\red0\green0\blue255;}
{\*\generator Msftedit 5.41.15.1515;}\viewkind4\uc1\pard\cf1\lang2052\f0\fs20\'ba\'da\'c9\'ab\'d7\'d6\cf2\'ba\'ec\'c9\'ab\'d7\'d6\cf3\ul\f1\fs18 163\cf0\ulnone  \par
}";
            richTextBox1.Rtf = a;
            IDictionaryEnumerator ide = hs.GetEnumerator();
            while (ide.MoveNext())
            {
                Hashtable hs3 = (Hashtable)ide.Value;
                string key = Convert.ToString(ide.Key);
                int p = richTextBox1.Text.IndexOf(key);
                if (p > -1)
                {
                    hs3["start"] = p;
                    hs3["end"] = p + key.Length;
                }
            }
             */
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            /*
            IDictionaryEnumerator ide = hs.GetEnumerator();
            while (ide.MoveNext())
            {
                Hashtable hs3 = (Hashtable)ide.Value;
                string key = Convert.ToString(ide.Key);
                string url = Convert.ToString(hs3["url"]);
                int start = Convert.ToInt32(hs3["start"]);
                int end = Convert.ToInt32(hs3["end"]);
                if (start <= richTextBox1.SelectionStart || richTextBox1.SelectionStart >= end)
                {
                    System.Diagnostics.Process.Start(@"iexplore.exe", url);
                }
            }*/
        }
             
    }
}
