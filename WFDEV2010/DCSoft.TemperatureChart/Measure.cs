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
    /// 体温单测量数据
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [System.Runtime.InteropServices.ComVisible(false)]
    public class Measure
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public Measure()
        {
        }

        private string _RecordID = null;
        /// <summary>
        /// 记录编号
        /// </summary>
        [DefaultValue(null)]
        public string RecordID
        {
            get { return _RecordID; }
            set { _RecordID = value; }
        }

        private DateTime _ValueDate = TemperatureDocument.NullDate;
        /// <summary>
        /// 测量日期
        /// </summary>
        [DefaultValue(typeof(DateTime), TemperatureDocument.NullDateString)]
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

        private int _ValueTime = 0;
        /// <summary>
        /// 测量时刻，从0到23
        /// </summary>
        [DefaultValue( 0 )]
        public int ValueTime
        {
            get
            {
                return _ValueTime; 
            }
            set
            {
                _ValueTime = value % 24 ;
                if (_ValueTime < 0)
                {
                    _ValueTime = _ValueTime + 24;
                }
                
            }
        }

        private string _Memo = null;
        /// <summary>
        /// 标记文本
        /// </summary>
        [DefaultValue( null )]
        public string Memo
        {
            get { return _Memo; }
            set { _Memo = value; }
        }

        private float _Body_Temperature = TemperatureDocument.NullValue;
        /// <summary>
        /// 体温
        /// </summary>
        [DefaultValue( TemperatureDocument.NullValue )]
        public float Body_Temperature
        {
            get { return _Body_Temperature; }
            set { _Body_Temperature = value; }
        }

        private float _FT = TemperatureDocument.NullValue;
        [DefaultValue( TemperatureDocument.NullValue )]
        public float FT
        {
            get { return _FT; }
            set { _FT = value; }
        }

        private float _Pluse = TemperatureDocument.NullValue;
        /// <summary>
        /// 脉搏
        /// </summary>
        [DefaultValue ( TemperatureDocument.NullValue )]
        public float Pluse
        {
            get { return _Pluse; }
            set { _Pluse = value; }
        }

        private float _Breath = TemperatureDocument.NullValue;
        /// <summary>
        /// 呼吸
        /// </summary>
        [DefaultValue( TemperatureDocument.NullValue )]
        public float Breath
        {
            get { return _Breath; }
            set { _Breath = value; }
        }

        private DataRowState _RecordState = DataRowState.Unchanged;
        /// <summary>
        /// 记录状态
        /// </summary>
        [Browsable(false)]
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
            this._Body_Temperature = 37.5f;
            this._Breath = 22;
            this._FT = 37.5f;
            this._Pluse = 80;
        }

        /// <summary>
        /// 复制对象
        /// </summary>
        /// <returns>复制品</returns>
        public Measure Clone()
        {
            return (Measure)this.MemberwiseClone();
        }

    }

    /// <summary>
    /// 数据记录列表
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [System.Runtime.InteropServices.ComVisible(false)]
    public class MeasureList : List<Measure>
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public MeasureList()
        {
        }
        /// <summary>
        /// 深度复制
        /// </summary>
        /// <returns>复制品</returns>
        public MeasureList CloneDeeply()
        {
            MeasureList list = new MeasureList();
            foreach (Measure m in this)
            {
                list.Add(m.Clone());
            }
            return list;
        }
    }

    //internal class MeasureBindingList : BindingList<Measure>
    //{
    //    private MeasureList _ParentList = null;

    //    public MeasureList ParentList
    //    {
    //        get { return _ParentList; }
    //        set { _ParentList = value; }
    //    }
    //    protected override void RemoveItem(int index)
    //    {
    //        base.RemoveItem(index);
    //    }
    //    private bool _DataModified = false;

    //    public bool DataModified
    //    {
    //        get { return _DataModified; }
    //        set { _DataModified = value; }
    //    }

    //    private DateTime _CurrentDate = DateTime.Now;

    //    public DateTime CurrentDate
    //    {
    //        get { return _CurrentDate; }
    //        set { _CurrentDate = value; }
    //    }

    //    protected override void OnListChanged(ListChangedEventArgs e)
    //    {
    //        base.OnListChanged(e);
    //        if (e.ListChangedType == ListChangedType.ItemAdded)
    //        {
    //            Measure record = this[e.NewIndex];
    //            record.RecordState = DataRowState.Added;
    //            record.Val_Date = this.CurrentDate;
    //            record.SetDefaultValue();
    //        }
    //        else if (e.ListChangedType == ListChangedType.ItemChanged)
    //        {
    //            this[e.NewIndex].RecordState = DataRowState.Modified;
    //        }
    //        this.DataModified = true;
    //    }
    //}

    internal class MeasureComparer : IComparer<Measure>
    {
        public int Compare(Measure x, Measure y)
        {
            int result = DateTime.Compare(x.ValueDate, y.ValueDate);
            if (result == 0)
            {
                result = x.ValueTime - y.ValueTime;
            }
            return result;
        }
    }
}
