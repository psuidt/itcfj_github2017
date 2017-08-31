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
using System.ComponentModel ;

namespace DCSoft.TemperatureChart
{
    /// <summary>
    /// 网格线标题行信息
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [Serializable]
    [System.Xml.Serialization.XmlType]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class TitleLineInfo
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public TitleLineInfo()
        {
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dtmStart"></param>
        /// <param name="style"></param>
        /// <param name="startDateKeyword"></param>
        public TitleLineInfo(string text, DateTime dtmStart , TitleLineValueType style , string startDateKeyword )
        {
            this.Text = text;
            this.StartDate = dtmStart;
            this.ValueType = style;
            this.StartDateKeyword = startDateKeyword;
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="text"></param>
        /// <param name="dtmStart"></param>
        /// <param name="style"></param>
        /// <param name="startDateKeyword"></param>
        public TitleLineInfo(string text, DateTime dtmStart, TitleLineValueType style )
        {
            this.Text = text;
            this.StartDate = dtmStart;
            this.ValueType = style;
        }

        private string _Text = null;
        /// <summary>
        /// 标题文本
        /// </summary>
        [DefaultValue( null )]
        public string Text
        {
            get
            {
                return _Text; 
            }
            set
            {
                _Text = value; 
            }
        }

        private DateTime _StartDate = TemperatureDocument.NullDate;
        /// <summary>
        /// 开始计算的日期
        /// </summary>
        [DefaultValue( typeof( DateTime ) , TemperatureDocument.NullDateString )]
        public DateTime StartDate
        {
            get
            {
                return _StartDate; 
            }
            set
            {
                _StartDate = value; 
            }
        }

        private string _StartDateKeyword = null;
        /// <summary>
        /// 判断开始计算日期的关键字
        /// </summary>
        [DefaultValue( null )]
        public string StartDateKeyword
        {
            get
            {
                return _StartDateKeyword; 
            }
            set
            {
                _StartDateKeyword = value; 
            }
        }

        private DateTime _RuntimeStartDate = TemperatureDocument.NullDate;
        /// <summary>
        /// 运行时使用的开始计算的日期
        /// </summary>
        [Browsable(false)]
        [System.Xml.Serialization.XmlIgnore]
        public DateTime RuntimeStartDate
        {
            get
            {
                return _RuntimeStartDate; 
            }
            set
            {
                _RuntimeStartDate = value; 
            }
        }

        private TitleLineValueType _ValueType = TitleLineValueType.SerialDate;
        /// <summary>
        /// 样式
        /// </summary>
        [DefaultValue( TitleLineValueType.SerialDate )]
        public TitleLineValueType ValueType
        {
            get
            {
                return _ValueType; 
            }
            set
            {
                _ValueType = value; 
            }
        }

        /// <summary>
        /// 标题行在文档视图中的Y坐标值
        /// </summary>
        [NonSerialized]
        internal float Top = float.NaN;

        internal string GetText(FooterMeasure cm)
        {
            switch (this.ValueType)
            {
                case TitleLineValueType.Abdomen_Circumference:
                    return cm.Abdomen_Circumference;
                case TitleLineValueType.Blood_PressureA:
                    return cm.Blood_PressureA;
                case TitleLineValueType.Blood_PressureP:
                    return cm.Blood_PressureP;
                case TitleLineValueType.Body_Weight:
                    return cm.Body_Weight;
                case TitleLineValueType.Liquid_In:
                    return cm.Liquid_In;
                case TitleLineValueType.Liquid_Out:
                    return cm.Liquid_Out;
                case TitleLineValueType.Pee:
                    return cm.Pee;
                case TitleLineValueType.Stool:
                    return cm.Stool;
            }
            return null;
        }
    }

    /// <summary>
    /// 标题行数据类型
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(false)]
    public enum TitleLineValueType
    {
        /// <summary>
        /// 一系列的日期数
        /// </summary>
        SerialDate ,
        /// <summary>
        /// 住院天数
        /// </summary>
        InDayIndex,
        /// <summary>
        /// 天数
        /// </summary>
        DayIndex,
        /// <summary>
        /// 小时刻数
        /// </summary>
        HourTick,
        /// <summary>
        /// 文本
        /// </summary>
        Text,
        /// <summary>
        /// 尿量
        /// </summary>
        Pee ,
        /// <summary>
        /// 粪便量
        /// </summary>
        Stool,
        /// <summary>
        /// 液体输入
        /// </summary>
        Liquid_In,
        /// <summary>
        /// 液体输出
        /// </summary>
        Liquid_Out,
        /// <summary>
        /// 下午血压
        /// </summary>
        Blood_PressureA,
        /// <summary>
        /// 上午血压
        /// </summary>
        Blood_PressureP,
        /// <summary>
        /// 体重
        /// </summary>
        Body_Weight,
        /// <summary>
        /// 腹围
        /// </summary>
        Abdomen_Circumference,
    }
}
