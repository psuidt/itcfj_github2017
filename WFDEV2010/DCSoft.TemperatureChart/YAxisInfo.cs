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
using System.Reflection ;
using System.Drawing;
using System.ComponentModel;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
    /// <summary>
    /// Y坐标轴信息
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class YAxisInfo
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public YAxisInfo()
        {
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_valueMember"></param>
        /// <param name="_maxValue"></param>
        /// <param name="_minValue"></param>
        /// <param name="_symbolStyle"></param>
        /// <param name="_symbolColor"></param>
        public YAxisInfo(
            string _title,
            ValueMemberType _valueMember,
            float _maxValue, 
            float _minValue,
            PointSymbolStyle _symbolStyle ,
            Color _symbolColor )
        {
            this.Title = _title;
            this.ValueMember = _valueMember;
            this.MaxValue = _maxValue;
            this.MinValue = _minValue;
            this.SymbolStyle = _symbolStyle;
            this.SymbolColor = _symbolColor;
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

        private ValueMemberType _ValueMember = ValueMemberType.Body_Temperature ;
        /// <summary>
        /// 数据成员
        /// </summary>
        [DefaultValue( ValueMemberType.Body_Temperature )]
        public ValueMemberType ValueMember
        {
            get { return _ValueMember; }
            set { _ValueMember = value; }
        }

        private float _MaxValue = 0f;
        /// <summary>
        /// 最大值
        /// </summary>
        [DefaultValue( 0f )]
        public float MaxValue
        {
            get { return _MaxValue; }
            set { _MaxValue = value; }
        }

        private float _MinValue = 0;
        /// <summary>
        /// 最小值
        /// </summary>
        [DefaultValue( 0f)]
        public float MinValue
        {
            get { return _MinValue; }
            set { _MinValue = value; }
        }

        private PointSymbolStyle _SymbolStyle = PointSymbolStyle.SolidCicle;
        /// <summary>
        /// 数据点符号类型
        /// </summary>
        [DefaultValue( PointSymbolStyle.SolidCicle )]
        public PointSymbolStyle SymbolStyle
        {
            get { return _SymbolStyle; }
            set { _SymbolStyle = value; }
        }

        private Color _SymbolColor = Color.Red;
        /// <summary>
        /// 数据点符号颜色
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public Color SymbolColor
        {
            get { return _SymbolColor; }
            set { _SymbolColor = value; }
        }

        /// <summary>
        /// 文本形式的颜色值
        /// </summary>
        [Browsable( false )]
        [XmlElement]
        [DefaultValue("Red")]
        public string SymbolColorValue
        {
            get
            {
                return ColorTranslator.ToHtml(this.SymbolColor);
            }
            set
            {
                this.SymbolColor = ColorTranslator.FromHtml(value);
            }
        }


        //private float _SymbolSize = 20;
        ///// <summary>
        ///// 数据点符号大小
        ///// </summary>
        //[DefaultValue( 20 )]
        //public float SymbolSize
        //{
        //    get { return _SymbolSize; }
        //    set { _SymbolSize = value; }
        //}

        /// <summary>
        /// Y坐标轴区域左边界位置
        /// </summary>
        [NonSerialized]
        internal float ViewLeft = 0f;
        /// <summary>
        /// Y坐标轴文本在视图中占据的宽度
        /// </summary>
        [NonSerialized]
        internal float ViewWidth = 0f;

        public float GetPosition(float maxPos, float minPos , float value )
        {
            if( float.IsNaN( value ))
            {
                return float.NaN ;
            }
            if (maxPos > minPos)
            {
                float rate = (maxPos - minPos) / (_MaxValue - _MinValue);
                return minPos + (value - _MinValue) * rate;
            }
            else
            {
                return maxPos;
            }
        }

        /// <summary>
        /// 上一次数据点
        /// </summary>
        [NonSerialized]
        internal PointF LastPoint = new PointF(float.NaN, float.NaN);
        
        internal float GetValue(Measure instance)
        {
            if (instance == null)
            {
                return float.NaN;
            }
            switch (this.ValueMember)
            {
                case ValueMemberType.Body_Temperature  :
                    return instance.Body_Temperature;
                case ValueMemberType.Breath :
                    return instance.Breath;
                case ValueMemberType.FT :
                    return instance.FT;
                case ValueMemberType.Pluse :
                    return instance.Pluse;
            }
            return float.NaN;
        }

    }

    /// <summary>
    /// Y坐标轴信息列表
    /// </summary>
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(false)]
    public class YAxisInfoList : List<YAxisInfo>
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public YAxisInfoList()
        {
        }

        /// <summary>
        /// 获得指定数据类型的坐标轴信息
        /// </summary>
        /// <param name="type">指定的数据类型</param>
        /// <returns>获得的坐标轴信息</returns>
        public YAxisInfo GetItem(ValueMemberType type)
        {
            foreach (YAxisInfo info in this)
            {
                if (info.ValueMember == type)
                {
                    return info;
                }
            }
            return null;
        }

        /// <summary>
        /// 为取值范围而修正对象数值
        /// </summary>
        /// <param name="m">数据</param>
        /// <returns>操作是否修改了对象数据</returns>
        public bool FixRange(Measure m)
        {
            bool result = false;
            foreach (YAxisInfo info in this)
            {
                float v = info.GetValue( m );
                bool changed = false ;
                if( float.IsNaN( v ) == false )
                {
                    if( float.IsNaN( info.MaxValue ) == false 
                        && v >info.MaxValue )
                    {
                        v = info.MaxValue ;
                        changed = true ;
                    }
                    else if( float.IsNaN( info.MinValue ) == false 
                        && v < info.MinValue )
                    {
                        v = info.MinValue ;
                        changed = true ;
                    }
                    if( changed )
                    {
                        switch( info.ValueMember )
                        {
                            case  ValueMemberType.Body_Temperature :
                                result = true ;
                                m.Body_Temperature = v ;
                                break;
                            case  ValueMemberType.Breath :
                                result = true ;
                                m.Breath = v ;
                                break;
                            case ValueMemberType.FT :
                                result = true ;
                                m.FT = v ;
                                break;
                            case ValueMemberType.Pluse :
                                result = true ;
                                m.Pluse = v ;
                                break;
                        }
                    }
                }//if
            }//foreach
            return result;
        }

    }

    /// <summary>
    /// 点符号样式
    /// </summary>
    [System.Runtime.InteropServices.ComVisible(false)]
    public enum PointSymbolStyle
    {
        /// <summary>
        /// 实心圆
        /// </summary>
        SolidCicle ,
        /// <summary>
        /// 空心圆
        /// </summary>
        HollowCicle,
        /// <summary>
        /// 交叉线
        /// </summary>
        Cross
    }

    [System.Runtime.InteropServices.ComVisible(false)]
    public enum ValueMemberType
    {
        /// <summary>
        /// 体温
        /// </summary>
        Body_Temperature,
        FT,
        /// <summary>
        /// 脉搏
        /// </summary>
        Pluse,
        /// <summary>
        /// 呼吸
        /// </summary>
        Breath
    }
    
}
