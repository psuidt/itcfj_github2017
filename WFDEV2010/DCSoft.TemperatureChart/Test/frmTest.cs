/*

  本开源体温单程序是南京都昌信息科技有限公司（http://www.dcwriter.cn）自主研发的，
具有自主知识产权。使用C#2.0开发的，使用的IDE为VS.NET2010。发布日期：2013-6-13。

任何单位和个人都可以任意修改和使用这些代码，不过前提是遵循以下条款：

1.任何情况下都不得删除南京都昌信息科技有限公司的版权声明。
2.对体温单程序的任何改进，当新增、修改的源代码行数小于3000行的，请将新版体温单代码
  发给都昌公司。都昌公司可任意使用这部分代码而不通知代码作者。若修改量超过3000行的
  无需如此。
  
  若不能遵循上述条款，请不要使用该开源软件。

    南京都昌信息科技有限公司是一家新兴的技术型软件开发企业。公司虽然年轻，但成员却
是长期从事于电子病历行业，深刻认识电子病历行业规律，并掌握了不可替代的核心技术。
    都昌公司作为一家新兴的公司以创新和实干为企业文化，在特定行业中追求卓越。目前主
打产品为DCWriter电子病历编辑器软件，为电子病历行业市场中的新兴产品，虽然入市不久，
但已经迅速得到市场的认可，并被多家医疗信息化软件厂商采购和使用。

	DCWriter电子病历文本编辑器软件（简称DCWriter）是南京都昌信息科技有限公司自主开
发的，它是完全用C#编写的、运行在微软.NET平台上的软件组件，没有使用MS Word、RichTextBox
等其他任何文本编辑器组件，完全自主实现了带格式文本编辑功能。可以非常完美的集成到各类.NET
应用系统中，包括WinForm.NET、WPF、ASP.NET、命令行程序或者后台服务程序。此外提供COM接口可
用于VB、PB、DELPHI、VC的开发中。
    DCWriter除了实现了强大的通用文本编辑功能外，还针对电子病历业务添加了续打、输入域、
半结构化文档、级联模板、三级查房权限控制、痕迹保留、医学表达式等功能，是开发电子病历应
用系统的理想基础。

公司官方网站 http://www.dcwriter.cn。
DCWriter试用版下载地址：http://www.dcwriter.cn/download/DCSoft.Writer.Demo.rar
邮箱 28348092@qq.com,
博客网站 http://www.cnblogs.com/xdesigner

    公司创始人袁永福，2001年南京东南大学毕业，2008年度微软MVP，从事计算机软件行业10多年，
经验丰富，富有实干创新精神。
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DCSoft.TemperatureChart.Test
{
    [System.Runtime.InteropServices.ComVisible(false)]
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private string strFileName = null;
        /// <summary>
        /// 表格配置信息对象
        /// </summary>
        private TemperatureDocumentOptions temDocumentOptions=null;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "XML文件(*.xml)|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.Stream stream = dlg.OpenFile())
                    {
                        strFileName = dlg.FileName;
                        myTemperatureChartControl.LoadDocument(stream);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "XML文件(*.xml)|*.xml";
                dlg.CheckPathExists = true;
                dlg.OverwritePrompt = true;
                dlg.FileName = strFileName;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.Stream stream = dlg.OpenFile())
                    {
                        strFileName = dlg.FileName;
                        myTemperatureChartControl.SaveDocument(stream);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (dlgTemperatureData dlg = new dlgTemperatureData())
            {
                dlg.Document = myTemperatureChartControl.Document;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    myTemperatureChartControl.RefreshView();
                }
            }
        }

        private void btnTestData_Click(object sender, EventArgs e)
        {
            // 创建文档选项
            if (temDocumentOptions == null)
            {
                TemperatureDocumentOptions opts = new TemperatureDocumentOptions();
                temDocumentOptions = opts;
            }
            myTemperatureChartControl.DocumentOptions = temDocumentOptions;
            // 页眉标题行
            temDocumentOptions.HeaderLines.Add(new TitleLineInfo(
                "日期",
                TemperatureDocument.NullDate,
                TitleLineValueType.SerialDate));
            temDocumentOptions.HeaderLines.Add(new TitleLineInfo(
                "住院天数",
                TemperatureDocument.NullDate,
                TitleLineValueType.InDayIndex));
            temDocumentOptions.HeaderLines.Add(new TitleLineInfo(
                "术后天数",
                TemperatureDocument.NullDate,
                TitleLineValueType.DayIndex,
                "手术"));
            temDocumentOptions.HeaderLines.Add(new TitleLineInfo(
                "产后天数",
                TemperatureDocument.NullDate,
                TitleLineValueType.DayIndex));
            temDocumentOptions.HeaderLines.Add(new TitleLineInfo(
                "时刻",
                TemperatureDocument.NullDate,
                TitleLineValueType.HourTick));
            // 数值信息
            temDocumentOptions.YAxisInfos.Add(new YAxisInfo(
                "体温",
                ValueMemberType.Body_Temperature,
                42,
                34,
                PointSymbolStyle.Cross,
                Color.Blue));
            temDocumentOptions.YAxisInfos.Add(new YAxisInfo(
                "脉搏",
                ValueMemberType.Pluse,
                180,
                20,
                PointSymbolStyle.SolidCicle,
                Color.Red));
            // 页脚标题行
            temDocumentOptions.FooterLines.Add(new TitleLineInfo(
                "小便  ml",
                TemperatureDocument.NullDate,
                TitleLineValueType.Pee));
            temDocumentOptions.FooterLines.Add(new TitleLineInfo(
                "大便次数",
                TemperatureDocument.NullDate,
                TitleLineValueType.Stool));
            temDocumentOptions.FooterLines.Add(new TitleLineInfo(
                "液入量ml",
                TemperatureDocument.NullDate,
                TitleLineValueType.Liquid_In));
            temDocumentOptions.FooterLines.Add(new TitleLineInfo(
                "血压 　早",
                TemperatureDocument.NullDate,
                TitleLineValueType.Blood_PressureP));
            temDocumentOptions.FooterLines.Add(new TitleLineInfo(
                "mmHg 　晚",
                TemperatureDocument.NullDate,
                TitleLineValueType.Blood_PressureA));
            temDocumentOptions.FooterLines.Add(new TitleLineInfo(
                "体重　Kg",
                TemperatureDocument.NullDate,
                TitleLineValueType.Body_Weight));
            temDocumentOptions.FooterLines.Add(new TitleLineInfo(
                "腹　　围",
                TemperatureDocument.NullDate,
                TitleLineValueType.Abdomen_Circumference));
            temDocumentOptions.FooterLines.Add(new TitleLineInfo(
                "引流　ml",
                TemperatureDocument.NullDate,
                TitleLineValueType.Liquid_Out));
            // 创建文档
            TemperatureDocument document = new TemperatureDocument();
            // 设置病人基本信息
            document.PatientName = "张三";
            document.PatientAge = 43;
            document.Section = "第三病区";
            document.Title = "南京都昌信息科技有限公司体温单";
            document.BedID = "20";
            document.InpatientID = "0001234";

            document.Measures = new MeasureList();
            // 创建一个记录
            Measure m = new Measure();
            m.ValueDate = new DateTime(2013, 2, 18);// 记录日期
            m.ValueTime = 8; // 记录时刻，从0到23
            m.Memo = "上午十时入院"; // 标注的文本
            m.Body_Temperature = 37.5f;// 体温
            m.FT = 37.5f;
            m.Pluse = 80;// 脉搏
            m.Breath = 22;// 呼吸
            document.Measures.Add(m);
            // 创建第二条记录
            m = new Measure();
            m.ValueDate = new DateTime(2013, 2, 19);
            m.ValueTime = 12;
            m.Memo = "手术";
            m.Body_Temperature = 39f;
            m.FT = 33;
            m.Pluse = 88;
            m.Breath = 22;
            document.Measures.Add(m);
            // 创建第三条记录
            m = new Measure();
            m.ValueDate = new DateTime(2013, 2, 19);
            m.ValueTime = 20;
            m.Memo = "";
            m.FT = 33;
            m.Pluse = 80;
            m.Breath = 22;
            document.Measures.Add(m);
            // 创建第四条记录
            m = new Measure();
            m.ValueDate = new DateTime(2013, 2, 20);
            m.ValueTime = 18;
            m.Memo = "主任查房";
            m.Body_Temperature = 39.6f;
            m.FT = 33;
            m.Pluse = 90;
            m.Breath = 22;
            document.Measures.Add(m);
            // 创建第五条记录
            m = new Measure();
            m.ValueDate = new DateTime(2013, 2, 21);
            m.ValueTime = 8;
            m.Body_Temperature = 37.6f;
            m.FT = 37;
            m.Pluse = 85;
            m.Breath = 20;
            document.Measures.Add(m);

            // 创建页脚数据
            document.FooterMeasures = new FooterMeasureList();
            // 创建第一条记录
            FooterMeasure fm = new FooterMeasure();
            fm.ValueDate = new DateTime(2013, 2, 19);// 测量日期
            fm.Pee = "100";// 尿量
            fm.Stool = "2";// 大便次数
            fm.Liquid_In = "1000";// 液体入量
            fm.Liquid_Out = "900";// 液体出量
            fm.Blood_PressureA = "90";// A血压
            fm.Blood_PressureP = "90";// P血压
            fm.Body_Weight = "80";// 体重
            fm.Abdomen_Circumference = "80";// 腹围
            document.FooterMeasures.Add(fm);
            // 创建第二条记录
            fm = new FooterMeasure();
            fm.ValueDate = new DateTime(2013, 2, 20);// 测量日期
            fm.Pee = "100";// 尿量
            fm.Stool = "2";// 大便次数
            fm.Liquid_In = "1000";// 液体入量
            fm.Liquid_Out = "900";// 液体出量
            fm.Blood_PressureA = "90";// A血压
            fm.Blood_PressureP = "90";// P血压
            fm.Body_Weight = "80";// 体重
            fm.Abdomen_Circumference = "80";// 腹围
            document.FooterMeasures.Add(fm);

            myTemperatureChartControl.Document = document;
            myTemperatureChartControl.RefreshView();

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Exit();
        }

        private void btnConfigEdit_Click(object sender, EventArgs e)
        {
            using (dlgTCOptions dlg = new dlgTCOptions())
            {
                if (temDocumentOptions == null)
                {
                    TemperatureDocumentOptions opts = new TemperatureDocumentOptions();
                    dlg.OptionsInstance = opts;
                }
                else 
                {
                    dlg.OptionsInstance = temDocumentOptions;  
                }
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    temDocumentOptions = dlg.OptionsInstance ;
                    myTemperatureChartControl.DocumentOptions = temDocumentOptions;
                    myTemperatureChartControl.Refresh();
                }
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("本开源体温单程序是南京都昌信息科技有限公司提供的。\r\n都昌科技，专业的电子病历编辑器提供者!");
        }
    }
}
