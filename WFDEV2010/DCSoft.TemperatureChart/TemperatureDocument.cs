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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Drawing.Printing;

namespace DCSoft.TemperatureChart
{
    /// <summary>
    /// 体温信息文档对象
    /// </summary>
    ///<remarks>编制 袁永福</remarks>
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class TemperatureDocument
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public TemperatureDocument()
        {
            
        }

        private string _Title = null;
        /// <summary>
        /// 标题
        /// </summary>
        [DefaultValue( null )]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _InpatientID = null;
        /// <summary>
        /// 住院号
        /// </summary>
        [DefaultValue( null )]
        public string InpatientID
        {
            get { return _InpatientID; }
            set { _InpatientID = value; }
        }

        private string _PatientName = null;
        /// <summary>
        /// 病人姓名
        /// </summary>
        [DefaultValue( null )]
        public string PatientName
        {
            get { return _PatientName; }
            set { _PatientName = value; }
        }

        private float _PatientAge = 0f;
        /// <summary>
        /// 病人年龄
        /// </summary>
        [DefaultValue( 0f )]
        public float PatientAge
        {
            get { return _PatientAge; }
            set { _PatientAge = value; }
        }

        private string _Section = null;
        /// <summary>
        /// 病区号
        /// </summary>
        [DefaultValue( null )]
        public string Section
        {
            get { return _Section; }
            set { _Section = value; }
        }

        private string _BedID = null;
        /// <summary>
        /// 床号
        /// </summary>
        [DefaultValue( null )]
        public string BedID
        {
            get { return _BedID; }
            set { _BedID = value; }
        }

        private FooterMeasureList _FooterMeasures = new FooterMeasureList();
        /// <summary>
        /// 页脚显示的数据
        /// </summary>
        [XmlArrayItem("FooterMeasure", typeof(FooterMeasure))]
        public FooterMeasureList FooterMeasures
        {
            get
            {
                return _FooterMeasures; 
            }
            set
            {
                _FooterMeasures = value; 
            }
        }

        private MeasureList _Measures = new MeasureList();
        /// <summary>
        /// 测量数据
        /// </summary>
        [XmlArrayItem("Measure", typeof(Measure))]
        public MeasureList Measures
        {
            get
            {
                return _Measures; 
            }
            set
            {
                _Measures = value; 
            }
        }
         

        /// <summary>
        /// 更新状态
        /// </summary>
        public void UpdateState()
        {
            this.Measures.Sort(new MeasureComparer());
            this.FooterMeasures.Sort(new CMeasureComparer());

        }
         


        private int _PageIndex = 0;
        /// <summary>
        /// 从0开始计算的当前页号
        /// </summary>
        [XmlIgnore]
        [Browsable( false )]
        public int PageIndex
        {
            get
            {
                return _PageIndex;
            }
            set
            {
                _PageIndex = value;
                if (_PageIndex < 0)
                {
                    _PageIndex = 0;
                }
                if (_PageIndex >= this._NumOfPages)
                {
                    _PageIndex = this.NumOfPages - 1 ;
                }
            }
        }

        internal int _NumOfPages = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        [Browsable( false )]
        public int NumOfPages
        {
            get
            {
                return _NumOfPages;
            }
        }

        private TemperatureDocumentOptions _Options = new TemperatureDocumentOptions();
        /// <summary>
        /// 文档视图选项
        /// </summary>
        [Browsable( false )]
        [XmlIgnore]
        public TemperatureDocumentOptions Options
        {
            get
            {
                return _Options; 
            }
            set
            {
                _Options = value;
                if (_Options == null)
                {
                    _Options = new TemperatureDocumentOptions();
                }
            }
        }

        /// <summary>
        /// 更新文档的总页数
        /// </summary>
        /// <param name="maxDate">输出的数据最大日期</param>
        /// <param name="minDate">输出的数据最小日期</param>
        public void UpdateNumOfPage( out DateTime maxDate , out DateTime minDate )
        {
            // 有数据的时间区间的最大值
            maxDate = NullDate;
            // 有数据的时间区间的最小值
            minDate = NullDate;
            
            if (this.Measures.Count > 0)
            {
                // 计算总页数
                foreach (Measure m in this.Measures)
                {
                    if (maxDate == NullDate || maxDate < m.ValueDate.Date )
                    {
                        maxDate = m.ValueDate;
                    }
                    if (minDate == NullDate || minDate > m.ValueDate.Date )
                    {
                        minDate = m.ValueDate;
                    }
                }//foreach
                TimeSpan valueSpan = maxDate - minDate;
                this._NumOfPages = (int)Math.Ceiling(valueSpan.Days
                    / (double)this.Options.NumOfDaysInOnePage);
                if (this._NumOfPages == 0)
                {
                    this._NumOfPages = 1;
                }
                if (this.PageIndex >= this.NumOfPages)
                {
                    this.PageIndex = this.NumOfPages - 1;
                }
                if (this.PageIndex < 0)
                {
                    this.PageIndex = 0;
                }
            }
            else
            {
                maxDate = DateTime.Today;
                minDate = maxDate.AddDays(-this.Options.NumOfDaysInOnePage);
                this._NumOfPages = 1;
                this.PageIndex = 0;
            }
        }


        public bool Load(System.IO.Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            XmlSerializer ser = new XmlSerializer(this.GetType());
            TemperatureDocument doc = (TemperatureDocument)ser.Deserialize(stream);
            if (doc != null)
            {
                this._BedID = doc._BedID;
                this._FooterMeasures = doc._FooterMeasures;
                this._InpatientID = doc._InpatientID;
                this._Measures = doc._Measures;
                this._NumOfPages = doc._NumOfPages;
                this._Options = doc._Options;
                this._PageIndex = doc._PageIndex;
                this._PatientAge = doc._PatientAge;
                this._PatientName = doc._PatientName;
                this._Section = doc._Section;
                this._Title = doc._Title;
                return true;
            }
            return false;
        }

        public void Save(System.IO.Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            XmlSerializer ser = new XmlSerializer(this.GetType());
            ser.Serialize(stream, this);
        }

        public TemperatureDocument Clone()
        {
            TemperatureDocument doc = (TemperatureDocument)this.MemberwiseClone();
            if (this._FooterMeasures != null)
            {
                doc._FooterMeasures = this._FooterMeasures.CloneDeeply();
            }
            if (this._Measures != null)
            {
                doc._Measures = this._Measures.CloneDeeply();
            }
            return doc;
        }

        /// <summary>
        /// 表示空日期的字符串
        /// </summary>
        public const string NullDateString = "1980-1-1";
        /// <summary>
        /// 表示空的日期
        /// </summary>
        public static DateTime NullDate = new DateTime(1980, 1, 1);
        /// <summary>
        /// 表示空的数据
        /// </summary>
        public const float NullValue = -10000f;

        public static bool IsNullValue(float v)
        {
            return float.IsNaN(v) || v == NullValue;
        }
         
    }
}