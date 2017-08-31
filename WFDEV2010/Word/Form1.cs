using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word1 = Microsoft.Office.Interop.Word;

namespace Word
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //using Word1 = Microsoft.Office.Interop.Word;
            object missingValue = System.Reflection.Missing.Value;
            object myTrue = false;                  //不显示Word窗口
            object fileName = @"E:\云端TFS\BuildProcessTemplates\WFDEV2010\Word\预防用药.doc";
            Word1._Application oWord = new Word1.ApplicationClass();
            Word1._Document oDoc;
            oDoc = oWord.Documents.Open(ref fileName, ref missingValue,
               ref myTrue, ref missingValue, ref missingValue, ref missingValue,
               ref missingValue, ref missingValue, ref missingValue,
               ref missingValue, ref missingValue, ref missingValue,
               ref missingValue, ref missingValue, ref missingValue,
               ref missingValue);
            oDoc.Activate();
            object tmp = "ksmc";
            Word1.Bookmark startRange = oWord.ActiveDocument.Bookmarks.get_Item(ref tmp);
            startRange.Select();
            startRange.Range.Text = "的发的发的撒";
            object IsSave = true;
            object savefilename = "D:\\a.doc";
            oDoc.SaveAs(ref savefilename, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue,
 ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue); 
            oDoc.Close(ref IsSave, ref missingValue, ref missingValue);

        }
        /*
         2object omissing = system.reflection.missing.value; 
 3word.applicationclass wordapp= new microsoft.office.interop.word.applicationclass(); 
 4object readonly = false; 
 5object template = templatepath; 
 6word._document doc = wordapp.documents.open(ref template, ref omissing,ref readonly, 
 7ref omissing, ref omissing, ref omissing, ref omissing, ref omissing, ref omissing, 
 8ref omissing, ref omissing, ref omissing,ref omissing,ref omissing,ref omissing,ref omissing); 
 9// modify 
10for (int i = 1; i <= doc.bookmarks.count; i++) 
11{ 
12object j = i; 
13word.range wordrng = doc.bookmarks.get_item(ref j).range; 
14wordrng.text = "这是第" + i + "个标签，名称为" + doc.bookmarks.get_item(ref j).name; 
15} 
16
17// save 
18object savefilename = mappath(request.applicationpath + "/document") + "/" + guid.newguid().tostring() + ".doc"; 
19doc.saveas(ref savefilename,ref omissing,ref omissing,ref omissing,ref omissing,ref omissing,ref omissing,ref omissing,ref omissing, 
20ref omissing,ref omissing,ref omissing,ref omissing,ref omissing,ref omissing,ref omissing); 
21doc.close( ref omissing, ref omissing, ref omissing ); 
22wordapp.quit( ref omissing, ref omissing, ref omissing );
23
         
         
         */
    }
}
