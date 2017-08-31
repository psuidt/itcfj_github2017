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
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Drawing;

namespace DCSoft.TemperatureChart
{
    /// <summary>
    /// 体温单设置
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [System.Runtime.InteropServices.ComVisible(false)]
    public class TemperatureDocumentOptions
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public TemperatureDocumentOptions()
        {
        }

        private float _Left = 0f;
        /// <summary>
        /// 左端位置
        /// </summary>
        [DefaultValue(0f)]
        [XmlIgnore]
        public float Left
        {
            get { return _Left; }
            set { _Left = value; }
        }

        private float _Top = 0f;
        /// <summary>
        /// 顶端位置
        /// </summary>
        [DefaultValue(0)]
        [XmlIgnore]
        public float Top
        {
            get { return _Top; }
            set { _Top = value; }
        }

        private float _Width = 750;
        /// <summary>
        /// 宽度
        /// </summary>
        [DefaultValue(750)]
        [XmlIgnore]
        public float Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        private float _Height = 1020;
        /// <summary>
        /// 高度
        /// </summary>
        [DefaultValue(1020)]
        [XmlIgnore]
        public float Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        /// <summary>
        /// 边界
        /// </summary>
        [Browsable(false)]
        [System.Xml.Serialization.XmlIgnore]
        public RectangleF Bounds
        {
            get
            {
                return new RectangleF(
                    this._Left, 
                    this._Top,
                    this._Width,
                    this._Height);
            }
            set
            {
                this._Left = value.Left;
                this._Top = value.Top;
                this._Width = value.Width;
                this._Height = value.Height;
            }
        }


        private int[] _HourTicks = new int[] { 4, 8, 12, 16, 20, 24 };
        /// <summary>
        /// 显示的时刻数
        /// </summary>
        public int[] HourTicks
        {
            get
            {
                return _HourTicks;
            }
            set
            {
                _HourTicks = value;
            }
        }

        private int _YSplitNum = 8;
        /// <summary>
        /// Y轴分割区域数量
        /// </summary>
        [DefaultValue(8)]
        public int YSplitNum
        {
            get
            {
                return _YSplitNum;
            }
            set
            {
                _YSplitNum = value;
            }
        }

        private float _SymbolSize = 10;
        /// <summary>
        /// 数据点符号大小
        /// </summary>
        [DefaultValue(10)]
        public float SymbolSize
        {
            get
            {
                return _SymbolSize; 
            }
            set
            {
                _SymbolSize = value; 
            }
        }

        private string _FontName = "宋体";
        /// <summary>
        /// 字体名称
        /// </summary>
        [DefaultValue("宋体")]
        public string FontName
        {
            get
            {
                return _FontName;
            }
            set
            {
                _FontName = value;
            }
        }

        private float _FontSize = 9f;
        /// <summary>
        /// 字体的大小
        /// </summary>
        [DefaultValue(9f)]
        public float FontSize
        {
            get
            {
                return _FontSize;
            }
            set
            {
                _FontSize = value;
            }
        }

        private List<TitleLineInfo> _HeaderLines = new List<TitleLineInfo>();
        /// <summary>
        /// 标题行信息
        /// </summary>
        [XmlArrayItem("Line", typeof(TitleLineInfo))]
        public List<TitleLineInfo> HeaderLines
        {
            get
            {
                return _HeaderLines;
            }
            set
            {
                _HeaderLines = value;
            }
        }

        private List<TitleLineInfo> _FooterLines = new List<TitleLineInfo>();
        /// <summary>
        /// 页脚行信息
        /// </summary>
        [XmlArrayItem("Line", typeof(TitleLineInfo))]
        public List<TitleLineInfo> FooterLines
        {
            get
            {
                return _FooterLines;
            }
            set
            {
                _FooterLines = value;
            }
        }


        private YAxisInfoList _YAxisInfos = new YAxisInfoList();
        /// <summary>
        /// Y坐标轴信息列表
        /// </summary>
        [XmlArrayItem("YAxis", typeof(YAxisInfo))]
        public YAxisInfoList YAxisInfos
        {
            get
            {
                return _YAxisInfos;
            }
            set
            {
                _YAxisInfos = value;
            }
        }


        private Color _BackColor = Color.Transparent;
        /// <summary>
        /// 背景色
        /// </summary>
        [DefaultValue(typeof(Color), "Transparent")]
        [XmlIgnore]
        public Color BackColor
        {
            get
            {
                return _BackColor;
            }
            set
            {
                _BackColor = value;
            }
        }


        private string _DateFormatString = "yyyy-MM-dd";
        /// <summary>
        /// 输出日期数据使用的格式化字符串
        /// </summary>
        [DefaultValue("yyyy-MM-dd")]
        public string DateFormatString
        {
            get
            {
                return _DateFormatString;
            }
            set
            {
                _DateFormatString = value;
            }
        }


        private int _NumOfDaysInOnePage = 7;
        /// <summary>
        /// 每页显示的天数
        /// </summary>
        [DefaultValue(7)]
        public int NumOfDaysInOnePage
        {
            get
            {
                return _NumOfDaysInOnePage;
            }
            set
            {
                _NumOfDaysInOnePage = value;
            }
        }


        /// <summary>
        /// 设置为默认的设置
        /// </summary>
        public void InitDefaultSettings()
        {
            // 页眉标题行
            this.HeaderLines.Add(new TitleLineInfo(
                "日期",
                TemperatureDocument.NullDate,
                TitleLineValueType.SerialDate ));
            this.HeaderLines.Add(new TitleLineInfo(
                "住院天数",
                TemperatureDocument.NullDate,
                TitleLineValueType.InDayIndex  ));
            this.HeaderLines.Add(new TitleLineInfo(
                "术后天数",
                TemperatureDocument.NullDate,
                TitleLineValueType.DayIndex,
                "手术"));
            this.HeaderLines.Add(new TitleLineInfo(
                "产后天数",
                TemperatureDocument.NullDate,
                TitleLineValueType.DayIndex ));
            this.HeaderLines.Add(new TitleLineInfo(
                "时刻",
                TemperatureDocument.NullDate,
                TitleLineValueType.HourTick ));
            // 数值信息
            this.YAxisInfos.Add(new YAxisInfo(
                "体温",
                ValueMemberType.Body_Temperature,
                42,
                34,
                PointSymbolStyle.Cross,
                Color.Blue));
            this.YAxisInfos.Add(new YAxisInfo(
                "脉搏",
                ValueMemberType.Pluse,
                180,
                20,
                PointSymbolStyle.SolidCicle,
                Color.Red));
            // 页脚标题行
            this.FooterLines.Add(new TitleLineInfo(
                "小便  ml",
                TemperatureDocument.NullDate,
                TitleLineValueType.Pee));
            this.FooterLines.Add(new TitleLineInfo(
                "大便次数",
                TemperatureDocument.NullDate,
                TitleLineValueType.Stool));
            this.FooterLines.Add(new TitleLineInfo(
                "液入量ml",
                TemperatureDocument.NullDate,
                TitleLineValueType.Liquid_In));
            this.FooterLines.Add(new TitleLineInfo(
                "血压 　早",
                TemperatureDocument.NullDate,
                TitleLineValueType.Blood_PressureP));
            this.FooterLines.Add(new TitleLineInfo(
                "mmHg 　晚",
                TemperatureDocument.NullDate,
                TitleLineValueType.Blood_PressureA));
            this.FooterLines.Add(new TitleLineInfo(
                "体重　Kg",
                TemperatureDocument.NullDate,
                TitleLineValueType.Body_Weight));
            this.FooterLines.Add(new TitleLineInfo(
                "腹　　围",
                TemperatureDocument.NullDate,
                TitleLineValueType.Abdomen_Circumference));
            this.FooterLines.Add(new TitleLineInfo(
                "引流　ml",
                TemperatureDocument.NullDate,
                TitleLineValueType.Liquid_Out));
        }
    }
}
