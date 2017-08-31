using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 换肤
{
    

    public partial class Form1 : Form
    {
        public string defaultSkinName;//皮肤
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1);
            CheckFile();//检查文件
            GetXmlSkin();//获取xml主题
            UserLookAndFeel.Default.SetSkinStyle(defaultSkinName);//设置主题样式
            ribbonGalleryBarItem1.Caption = "主题：" + defaultSkinName;
        }

        private void ribbonGalleryBarItem1_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            string name = string.Empty;
            string caption = string.Empty;
            if (ribbonGalleryBarItem1.Gallery == null) return;
            caption = ribbonGalleryBarItem1.Gallery.GetCheckedItems()[0].Caption;//主题的描述
            caption = caption.Replace("主题：", "");
            //name = bsiPaintStyle.Manager.PressedLink.Item.Tag.ToString();//主题的名称
            ribbonGalleryBarItem1.Caption = "主题：" + caption;

            XmlDocument doc = new XmlDocument();
            doc.Load("SkinInfo.xml");
            XmlNodeList nodelist = doc.SelectSingleNode("SetSkin").ChildNodes;
            foreach (XmlNode node in nodelist)
            {
                XmlElement xe = (XmlElement)node;//将子节点类型转换为XmlElement类型 
                if (xe.Name == "Skinstring")
                {
                    xe.InnerText = caption;
                }
            }

            doc.Save("SkinInfo.xml");
        }
        #region 检查XML文件是否存在
        public void CheckFile()
        {
            try
            {
                if (System.IO.File.Exists("SkinInfo.xml") == false)
                {
                    //XtraMessageBox.Show("不存在XML");
                    CreateXml();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region 创建XML文件

        public void CreateXml()
        {
            XmlDocument doc = new XmlDocument();
            //建立xml定义声明
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);

            //创建根节点
            XmlElement root = doc.CreateElement("SetSkin");
            XmlElement rootone = doc.CreateElement("Skinstring");//皮肤


            //将one，two，插入到root节点下
            doc.AppendChild(root);
            root.AppendChild(rootone);
            doc.Save("SkinInfo.xml");
        }

        #endregion
        #region 读取Xml节点内容

        public void GetXmlSkin()
        {
            try
            {
                XmlDocument mydoc = new XmlDocument();
                mydoc.Load("SkinInfo.xml");
                XmlNode ressNode = mydoc.SelectSingleNode("SetSkin");
                defaultSkinName = ressNode.SelectSingleNode("Skinstring").InnerText;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        #endregion
    
    }
}
