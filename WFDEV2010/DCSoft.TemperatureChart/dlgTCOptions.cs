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
    public partial class dlgTCOptions : Form
    {
        public dlgTCOptions()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private TemperatureDocumentOptions _OptionsInstance = null;
        /// <summary>
        /// 选项信息对象
        /// </summary>
        public TemperatureDocumentOptions OptionsInstance
        {
            get
            {
                return _OptionsInstance; 
            }
            set
            {
                _OptionsInstance = value; 
            }
        }
        /// <summary>
        /// 加载选项信息对象数据至窗体控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ((DataGridViewComboBoxColumn)this.dgvHeaderLines.Columns["ValueType"]).DataSource = Enum.GetValues(typeof(TitleLineValueType));
            ((DataGridViewComboBoxColumn)this.dgvYAxisInfos.Columns["ValueMember"]).DataSource = Enum.GetValues(typeof(ValueMemberType));
            ((DataGridViewComboBoxColumn)this.dgvYAxisInfos.Columns["SymbolStyle"]).DataSource = Enum.GetValues(typeof(PointSymbolStyle));
            ((DataGridViewComboBoxColumn)this.dgvFooterLines.Columns["ValueTypeH"]).DataSource = Enum.GetValues(typeof(TitleLineValueType));
            //((DataGridViewComboBoxColumn)this.dgvFooterLines.Columns["
            this.txtBackColor.Text = _OptionsInstance.BackColor.Name;
            this.txtDateFormatString.Text = _OptionsInstance.DateFormatString;
            this.txtFontName.Text = _OptionsInstance.FontName;
            StringBuilder hourticks = new StringBuilder();
            foreach (int tick in _OptionsInstance.HourTicks)
            {
                hourticks.Append(tick).Append(",");
            }
            this.txtHourTicks.Text = hourticks.ToString();
            this.txtNumOfDaysInOnePage.Text = _OptionsInstance.NumOfDaysInOnePage.ToString();
            this.txtSymbolSize.Text = _OptionsInstance.SymbolSize.ToString();
            this.txtYSplitNum.Text = _OptionsInstance.YSplitNum.ToString();

            this.dgvHeaderLines.DataSource = _OptionsInstance.HeaderLines;
            this.dgvHeaderLines.Columns["StartDate"].Visible = false;
            this.dgvYAxisInfos.DataSource = _OptionsInstance.YAxisInfos;
            this.dgvFooterLines.DataSource = _OptionsInstance.FooterLines;
            this.dgvFooterLines.Columns["StartDateKeyword"].Visible = false;
            this.dgvFooterLines.Columns["StartDate"].Visible = false;

        }

        private void dlgTCOptions_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 保存窗体控件信息至选项信息对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            #region 时刻数序列
            if (this.txtHourTicks.Text != null && txtHourTicks.Text != string.Empty)
            {
                string[] hourst = this.txtHourTicks.Text.Split(',');
                List<string> hourstlist = new List<string>();
                foreach (string hour in hourst)
                {
                    if (hour != null && hour != string.Empty)
                    {
                        hourstlist.Add(hour);
                    }
                }
                int[] hoursticks = new int[hourstlist.Count];
                for (int i = 0; i < hourstlist.Count; i++)
                {
                    hoursticks.SetValue(Convert.ToInt32(hourstlist[i]), i);
                }
                _OptionsInstance.HourTicks = hoursticks;
            }
            else
            {
                _OptionsInstance.HourTicks = new TemperatureDocumentOptions().HourTicks;
            }
            #endregion

            _OptionsInstance.BackColor = Color.FromName(txtBackColor.Text);//背景色
            _OptionsInstance.DateFormatString = txtDateFormatString.Text;//日期格式化字符串
            _OptionsInstance.FontName = txtFontName.Text;//字体名称
            _OptionsInstance.NumOfDaysInOnePage = Convert.ToInt32(txtNumOfDaysInOnePage.Text);//每页显示的天数
            _OptionsInstance.SymbolSize = float.Parse(txtSymbolSize.Text);//数据点符号大小
            _OptionsInstance.YSplitNum = Convert.ToInt32(txtYSplitNum.Text);//Y轴分割区域数

            _OptionsInstance.HeaderLines = ((List<TitleLineInfo>)this.dgvHeaderLines.DataSource);
            _OptionsInstance.YAxisInfos = ((YAxisInfoList)this.dgvYAxisInfos.DataSource);
            _OptionsInstance.FooterLines = ((List<TitleLineInfo>)this.dgvFooterLines.DataSource);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvYAxisInfos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dgvYAxisInfos.Columns[e.ColumnIndex].HeaderText=="颜色")
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.AllowFullOpen = true;
                colorDialog.FullOpen = true; colorDialog.ShowHelp = true;
                colorDialog.ShowDialog();
                Color cl = colorDialog.Color;
                dgvYAxisInfos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cl.Name.ToString();
            }
            
        }
    }
}
