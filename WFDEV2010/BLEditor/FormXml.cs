using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BLEditor
{
    public partial class FormXml : Form
    {
        public FormXml()
        {
            InitializeComponent();
        }

        private void FormXml_Load(object sender, EventArgs e)
        {
            string str = @"{\rtf1\ansi\deff0{\fonttbl{\f0\fnil\fcharset134 \'cb\'ce\'cc\'e5;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\lang2052\f0\fs22\'b2\'a1\'ca\'b7\'cc\'e1\'b9\'a9\'b7\'c9\'b7\'c9\'b7\'c9\'c8\'cb\'a3\'ba                       \'ca\'b1\'bc\'e4\'a3\'ba    \par
\'d2\'bb\'b0\'e3\'c7\'e9\'bf\'f6\'a3\'ba                         \'c9\'f1\'d6\'be\'a3\'ba    \par
\'b6\'d4\'b2\'df\'b6\'fe\'b4\'ce\'b4\'b2\par
 \'c8\'eb\'d4\'ba\'b2\'a1\'c7\'f8 \par
 \'c8\'eb\'d4\'ba\'bf\'c6\'ca\'d2          \'d0\'d5\'a1\'a1\'c3\'fb\'a3\'ba           \'c8\'eb\'d4\'ba\'c8\'d5\'c6\'da\'a3\'ba    \par
         \'d0\'d4\'a1\'a1\'b1\'f0\'a3\'ba           \'cb\'c0\'cd\'f6\'ca\'b1\'bc\'e4\'a3\'ba    \par
         \'c4\'ea\'a1\'a1\'c1\'e4\'a3\'ba           \'d7\'a1\'d4\'ba\'cc\'ec\'ca\'fd\'a3\'ba    \'cc\'ec\par
 \'c8\'eb\'d4\'ba\'bf\'c6\'ca\'d2 \par
\'cc\'e5\'ce\'c2\'a3\'ba    \'a1\'e6\'a1\'a1\'a1\'a1\'c2\'f6\'b2\'ab\'a3\'ba    \'b4\'ce/\'b7\'d6\'a1\'a1\'a1\'a1\'ba\'f4\'ce\'fc\'a3\'ba    \'b4\'ce/\'b7\'d6\'a1\'a1\'a1\'a1\'d1\'aa\'d1\'b9\'a3\'ba    /   mmHg\par
\'d6\'f7\'cb\'df\'a3\'ba \'b2\'a1\'c8\'cb\'d0\'d5\'c3\'fb   \'b2\'a1\'c8\'cb\'c4\'ea\'c1\'e4  \'d6\'b0\'d2\'b5  \'c8\'eb\'d4\'ba\'c8\'d5\'c6\'da  \'bc\'ae\'b9\'e1    \'be\'d3\'d7\'a1\'b5\'d8\'d6\'b7  \'ca\'c7\'b7\'f1\'b8\'df\'ce\'a3  \'ca\'f4\'b5\'d8  \'c1\'aa\'cf\'b5\'b5\'e7\'bb\'b0  \'d3\'d0\'ce\'de\'c9\'fa\'d3\'fd\'b7\'fe\'ce\'f1\'d6\'a4  \'d3\'d0\'ce\'de\'d2\'bd\'d1\'a7\'d5\'ef\'b6\'cf\'d6\'a4\'c3\'f7  \'d3\'d0\'ce\'de\'bc\'c6\'c9\'fa\'b2\'bf\'c3\'c5\'d6\'a4\'c3\'f7 \par
\'bc\'f2\'d2\'aa\'b2\'a1\'ca\'b7\'a3\'ba\par
\'bc\'c8\'cd\'f9\'b2\'a1\'ca\'b7\'a3\'ba\par
\'cc\'e5\'b8\'f1\'bc\'ec\'b2\'e9\'a3\'ba\par
\'bb\'e1\'d5\'ef\'c7\'e9\'bf\'f6\'bc\'b0\'d5\'ef\'d6\'ce\'d2\'e2\'bc\'fb\'a3\'ba\par
\'bb\'af\'d1\'e9\'bc\'ec\'b2\'e9\'bc\'b0\'bd\'e1\'b9\'fb\'a3\'ba\par
\'d2\'bd\'d1\'a7\'d3\'b0\'cf\'f1\'bc\'ec\'b2\'e9\'bc\'b0\'bd\'e1\'b9\'fb\'a3\'ba\par
\'b3\'f5\'b2\'bd\'d3\'a1\'cf\'f3\'bb\'f2\'d5\'ef\'b6\'cf\'a3\'ba\par
\'b4\'a6\'c0\'ed\'d2\'e2\'bc\'fb\'a3\'ba\par
\'d7\'aa\'b9\'e9\'ca\'b1\'bc\'e4\'a3\'ba\'a1\'a1 \'d7\'aa\'b9\'e9\'ca\'b1\'bc\'e4 \par
\'d7\'aa\'b9\'e9\'c7\'e9\'bf\'f6\'a3\'ba\par
                                      \'be\'ad\'d6\'ce\'d2\'bd\'ca\'a6\'c7\'a9\'c3\'fb\'a3\'ba \'d2\'bd\'ca\'a6\'c7\'a9\'c3\'fb \par
\par
\'c1\'dc\'b0\'cd\'bd\'e1\par
}
 
";
           richTextBox1.Rtf = str;
            richTextBox1.SelectedRtf=
 @"{\rtf1\ansi\ansicpg936\deff0\deflang1033\deflangfe2052{\fonttbl{\f0\fswiss\fcharset134 \'cb\'ce\'cc\'e5;}}
{\colortbl ;\red0\green0\blue0;}
\uc1\pard\cf1\lang2052\f0\fs22\'c1\'dc\'b0\'cd\'bd\'e1\'a3\'ba}
";














            /*
            XmlDocument xmlDoc = new XmlDocument();//创建一个XML文档对象  
            xmlDoc.Load(@"E:\MyWork\C#AndWinform开发\病历编辑器\SolutionEditor\BLEditor\a.xml");//加载XML文档  
            StringWriter tw = new StringWriter();//定义一个StringWriter  
            XmlTextWriter tw2 = new XmlTextWriter(tw);//创建一个StringWriter实例的XmlTextWriter  
            tw2.Formatting = Formatting.Indented;//设置缩进  
            tw2.Indentation = 1;//设置缩进字数  
            tw2.IndentChar = '\t';//用\t字符作为缩进  
            xmlDoc.WriteTo(tw2);
            // tw.Close();//关闭StringWriter  
            IDataObject dataObject = new DataObject();
            dataObject.SetData("TreeEditorInternalDragFormat");
            //  richTextBox1.Text = "问答切题，口齿清楚，查体合作。全身皮肤粘膜未及黄染，全身浅表淋巴结无肿大。颈软，无抵抗，气管居中，双肺呼吸音";
            richTextBox1.Rtf = "\'ce\'ca\'b4\'f0\'c7\'d0\'cc\'e2\'a3\'ac\'bf\'da\'b3\'dd\'c7\'e5\'b3\'fe\'a3\'ac\'b2\'e9\'cc\'e5\'ba\'cf\'d7\'f7\'a1\'a3\'c8\'ab\'c9\'ed\'c6\'a4\'b7\'f4\'d5\'b3\'c4\'a4\'ce\'b4\'bc\'b0\'bb\'c6\'c8\'be\'a3\'ac\'c8\'ab\'c9\'ed\'c7\'b3\'b1\'ed\'c1\'dc\'b0\'cd\'bd\'e1\'ce\'de\'d6\'d7\'b4\'f3\'a1\'a3\'be\'b1\'c8\'ed\'a3\'ac\'ce\'de\'b5\'d6\'bf\'b9\'a3\'ac\'c6\'f8\'b9\'dc\'be\'d3\'d6\'d0\'a3\'ac\'cb\'ab\'b7\'ce\'ba\'f4\'ce\'fc\'d2\'f4";

            //richTextBox1.
             * */
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
   
        }
    }
}
