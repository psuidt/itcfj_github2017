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
using System.Data;

namespace DCSoft.TemperatureChart
{
    /// <summary>
    /// 测量点的值
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class FooterMeasure
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public FooterMeasure()
        {
        }

        private string _RecordID = null;
        /// <summary>
        /// 记录编号
        /// </summary>
        [DefaultValue( null )]
        public string RecordID
        {
            get
            {
                return _RecordID; 
            }
            set
            {
                _RecordID = value; 
            }
        }

        private string _Pee = null;
        /// <summary>
        /// 尿量
        /// </summary>
        [DefaultValue( null )]
        public string Pee
        {
            get
            {
                return _Pee; 
            }
            set
            {
                _Pee = value; 
            }
        }

        private string _Stool = null;
        /// <summary>
        /// 大便次数
        /// </summary>
        [DefaultValue( null )]
        public string Stool
        {
            get
            {
                return _Stool; 
            }
            set
            {
                _Stool = value; 
            }
        }

        private string _Liquid_In = null;
        /// <summary>
        /// 液体进量
        /// </summary>
        [DefaultValue( null )]
        public string Liquid_In
        {
            get { return _Liquid_In; }
            set { _Liquid_In = value; }
        }

        private string _Liquid_Out = null;
        /// <summary>
        /// 液体出量
        /// </summary>
        [DefaultValue( null )]
        public string Liquid_Out
        {
            get { return _Liquid_Out; }
            set { _Liquid_Out = value; }
        }

        private string _Blood_PressureA = null;
        /// <summary>
        /// A血压
        /// </summary>
        [DefaultValue( null )]
        public string Blood_PressureA
        {
            get { return _Blood_PressureA; }
            set { _Blood_PressureA = value; }
        }

        private string _Blood_PressureP = null;
        /// <summary>
        /// P血压
        /// </summary>
        [DefaultValue( null )]
        public string Blood_PressureP
        {
            get { return _Blood_PressureP; }
            set { _Blood_PressureP = value; }
        }

        private string _Body_Weight = null;
        /// <summary>
        /// 体重
        /// </summary>
        [DefaultValue( null )]
        public string Body_Weight
        {
            get { return _Body_Weight; }
            set { _Body_Weight = value; }
        }

        private string _Abdomen_Circumference = null;
        /// <summary>
        /// 腹围
        /// </summary>
        [DefaultValue( null )]
        public string Abdomen_Circumference
        {
            get { return _Abdomen_Circumference; }
            set { _Abdomen_Circumference = value; }
        }

        private DateTime _ValueDate = TemperatureDocument.NullDate;
        /// <summary>
        /// 测量日期
        /// </summary>
        [DefaultValue( typeof( DateTime ) , TemperatureDocument.NullDateString )]
        public DateTime ValueDate
        {
            get
            {
                return _ValueDate.Date ; 
            }
            set
            {
                _ValueDate = value.Date ; 
            }
        }

        private DataRowState _RecordState = DataRowState.Unchanged;
        /// <summary>
        /// 记录状态
        /// </summary>
        [Browsable( false )]
        [System.Xml.Serialization.XmlIgnore]
        public DataRowState RecordState
        {
            get { return _RecordState; }
            set { _RecordState = value; }
        }

        /// <summary>
        /// 设置默认值
        /// </summary>
        public void SetDefaultValue()
        {
            this._Abdomen_Circumference = "80CM";
            this._Blood_PressureA = "90";
            this._Blood_PressureP = "90";
            this._Body_Weight = "80";
            this._Liquid_In = "1000";
            this._Liquid_Out = "1000";
            this._Pee = "100";
            this._Stool = "100";
        }

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>复制品</returns>
        public FooterMeasure Clone()
        {
            return (FooterMeasure)this.MemberwiseClone();
        }
    }

    /// <summary>
    /// 数据记录列表
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [System.Runtime.InteropServices.ComVisible(false)]
    public class FooterMeasureList : List<FooterMeasure>
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public FooterMeasureList()
        {
        }

        /// <summary>
        /// 深度复制
        /// </summary>
        /// <returns>复制品</returns>
        public FooterMeasureList CloneDeeply()
        {
            FooterMeasureList list = new FooterMeasureList();
            foreach (FooterMeasure m in this)
            {
                list.Add(m.Clone());
            }
            return list;
        }
    }

    internal class CMeasureComparer :IComparer<FooterMeasure>
    {
        public int Compare(FooterMeasure x, FooterMeasure y)
        {
            return DateTime.Compare(x.ValueDate, y.ValueDate);
        }
    }
}
