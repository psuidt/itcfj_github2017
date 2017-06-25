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

namespace DCSoft.TemperatureChart
{
    [System.Runtime.InteropServices.ComVisible(false)]
    public partial class dlgTemperatureData : Form
    {
        public dlgTemperatureData()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private TemperatureDocument _Document = null;

        public TemperatureDocument Document
        {
            get { return _Document; }
            set { _Document = value; }
        }

        private bool _DataModified = false;
        /// <summary>
        /// 数据发生改变标记
        /// </summary>
        public bool DataModified
        {
            get { return _DataModified; }
            set { _DataModified = value; }
        }

        //private MeasureList _Measures = null;
        //private CMeasureList _CMeasures = null;

        private void dlgInputData_Load(object sender, EventArgs e)
        {
            RefreshView(this.Document);
        }

        private MeasureList _Measures = new MeasureList();
        private FooterMeasureList _CMeasures = new FooterMeasureList();
        private void RefreshView( TemperatureDocument document )
        {
            if (document == null)
            {
                return;
            }
            if (document.Measures == null)
            {
                _Measures = new MeasureList();
            }
            else
            {
                _Measures = document.Measures.CloneDeeply();
            }
            if (document.FooterMeasures == null)
            {
                _CMeasures = new FooterMeasureList();
            }
            else
            {
                _CMeasures = document.FooterMeasures.CloneDeeply();
            }

            dgvCMeasure.AutoGenerateColumns = false;
            dgvMeasure.AutoGenerateColumns = false;
            document.UpdateState();
            UpdateBoldDate( true );
            txtTitle.Text = document.Title;
            txtInpatientID.Text = document.InpatientID;
            txtName.Text = document.PatientName;
            nudAge.Value = Convert.ToDecimal(document.PatientAge);
            cboSection.Text = document.Section;
            cboBed.Text = document.BedID;
            EventHandler valueChanged = delegate(object sender2, EventArgs args2)
                {
                    this.DataModified = true;
                };

            txtInpatientID.TextChanged += valueChanged ;
            txtName.TextChanged += valueChanged;
            nudAge.ValueChanged += valueChanged;
            cboSection.SelectedIndexChanged += valueChanged;
            cboBed.SelectedIndexChanged += valueChanged;

            mcDate_DateChanged(null, null);
        }

        private void UpdateBoldDate( bool setCurrentDate )
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Measure m in this._Measures)
            {
                if (dates.Contains(m.ValueDate ) == false)
                {
                    dates.Add(m.ValueDate );
                }
            }
            foreach (FooterMeasure cm in this._CMeasures)
            {
                if (dates.Contains(cm.ValueDate) == false)
                {
                    dates.Add(cm.ValueDate);
                }
            }
            dates.Sort();
            mcDate.BoldedDates = dates.ToArray();
            if (dates.Count > 0 && setCurrentDate )
            {
                mcDate.SelectionRange = new SelectionRange(dates[dates.Count - 1], dates[dates.Count - 1]);
            }
        }

        private void mcDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            FillList();
            UpdateBoldDate( false );
        }

        private void FillList()
        {
            DateTime curDate = mcDate.SelectionStart;

            BindingList<Measure> ms = new BindingList<Measure>(); ;
            ms.ListChanged +=new ListChangedEventHandler(ms_ListChanged);
            foreach (Measure m in _Measures)
            {
                if (m.ValueDate == curDate)
                {
                    ms.Add(m);
                }
            }
            dgvMeasure.DataSource = ms;

            BindingList<FooterMeasure> cms = new BindingList<FooterMeasure>();
            cms.ListChanged +=new ListChangedEventHandler(cms_ListChanged);
            foreach (FooterMeasure cm in this._CMeasures)
            {
                if (cm.ValueDate == curDate)
                {
                    cms.Add(cm);
                }
            }
            dgvCMeasure.DataSource = cms;
        }

        private void ApplyList()
        {
            DateTime curDate = mcDate.SelectionStart;
            for (int iCount = _Measures.Count - 1; iCount >= 0; iCount--)
            {
                if (_Measures[iCount].ValueDate == curDate)
                {
                    _Measures.RemoveAt(iCount);
                }
            }
            _Measures.AddRange((BindingList<Measure>)dgvMeasure.DataSource);

            for (int iCount = _CMeasures.Count - 1; iCount >= 0; iCount--)
            {
                if (_CMeasures[iCount].ValueDate == curDate)
                {
                    _CMeasures.RemoveAt(iCount);
                }
            }
            _CMeasures.AddRange((BindingList<FooterMeasure>)dgvCMeasure.DataSource);
        }

        void cms_ListChanged(object sender, ListChangedEventArgs e)
        {
            BindingList<FooterMeasure> list = (BindingList<FooterMeasure>)sender;
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                FooterMeasure record = list[e.NewIndex];
                record.RecordState = DataRowState.Added;
                record.ValueDate = mcDate.SelectionStart;
                record.SetDefaultValue();
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                list[e.NewIndex].RecordState = DataRowState.Modified;
            }
            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                if (e.NewIndex < list.Count)
                {
                    list[e.NewIndex].RecordState = DataRowState.Deleted;
                }
            }
            this.DataModified = true;
        }

        void ms_ListChanged(object sender, ListChangedEventArgs e)
        {
            BindingList<Measure> list = ( BindingList < Measure >) sender;
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                Measure record = list[e.NewIndex];
                record.RecordState = DataRowState.Added;
                record.ValueDate = mcDate.SelectionStart;
                record.SetDefaultValue();
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                list[e.NewIndex].RecordState = DataRowState.Modified;
            }
            else if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                if (e.NewIndex < list.Count)
                {
                    list[e.NewIndex].RecordState = DataRowState.Deleted;
                }
            }
            this.DataModified = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Document == null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
                return;
            }
            dgvCMeasure.EndEdit();
            dgvMeasure.EndEdit();
            ApplyList();
            this.Document.Title = txtTitle.Text;
            this.Document.InpatientID = txtInpatientID.Text;
            this.Document.PatientName = txtName.Text;
            this.Document.PatientAge = Convert.ToSingle( nudAge.Value );
            this.Document.Section = cboSection.Text;
            this.Document.BedID = cboBed.Text;
            this.Document.Measures = _Measures;
            this.Document.FooterMeasures = _CMeasures;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMeasure_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "XML文件(*.xml)|*.xml";
                dlg.CheckFileExists = true;
                if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    using (System.IO.Stream stream = dlg.OpenFile())
                    {
                        TemperatureDocument tdoc = new TemperatureDocument();
                        if (tdoc.Load(stream))
                        {
                            RefreshView(tdoc);
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //using (SaveFileDialog dlg = new SaveFileDialog())
            //{
            //    dlg.Filter = "XML文件(*.xml)|*.xml";
            //    dlg.CheckPathExists = true;
            //    dlg.OverwritePrompt = true;
            //    if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        using (System.IO.Stream stream = dlg.OpenFile())
            //        {

            //        }
            //    }
            //}
        }
    }
}
