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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO ;
using System.Xml.Serialization;

namespace DCSoft.TemperatureChart
{
    /// <summary>
    /// 体温单控件
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [System.ComponentModel.ToolboxItem( true )]
    [System.Runtime.InteropServices.ComVisible(false)]
    public partial class TemperatureControl : UserControl
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public TemperatureControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode == false)
            {
                this.UpdateState();
                this.UpdateViewSize();
            }
        }

        private TemperatureDocumentOptions _DocumentOptions = null;
        /// <summary>
        /// 文档选项
        /// </summary>
        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public TemperatureDocumentOptions DocumentOptions
        {
            get
            {
                if (_DocumentOptions == null)
                {
                    _DocumentOptions = new TemperatureDocumentOptions();
                    _DocumentOptions.InitDefaultSettings();
                }
                return _DocumentOptions; 

            }
            set 
            {
                _DocumentOptions = value; 
            }
        }

        private TemperatureDocument _Document = null;
        /// <summary>
        /// 文档对象
        /// </summary>
        [Browsable( false )]
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public TemperatureDocument Document
        {
            get
            {
                if (_Document == null)
                {
                    _Document = new TemperatureDocument();
                    _Document.Options = this.DocumentOptions;
                }
                return _Document; 
            }
            set
            {
                _Document = value;
                if (_Document != null)
                {
                    _Document.Options = this.DocumentOptions;
                }
                if (this.IsHandleCreated)
                {
                    UpdateViewSize();
                }
            }
        }

        private TemperatureDocumentRender _DocumentRender = new TemperatureDocumentRender();
        /// <summary>
        /// 文档内容绘制器
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TemperatureDocumentRender DocumentRender
        {
            get
            {
                return _DocumentRender; 
            }
            set
            {
                _DocumentRender = value; 
            }
        }

        private PageSettings _PageSettings = new PageSettings();
        /// <summary>
        /// 页面设置
        /// </summary>
        [Browsable( false )]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PageSettings PageSettings
        {
            get
            {
                return _PageSettings; 
            }
            set
            {
                _PageSettings = value;
                if (this.DesignMode == false)
                {
                    UpdateViewSize();
                }
            }
        }

        private Color _PageBackColor = Color.White;
        /// <summary>
        /// 页面背景色
        /// </summary>
        [DefaultValue( typeof( Color ) , "White")]
        [Category("Appearance")]
        public Color PageBackColor
        {
            get
            {
                return _PageBackColor; 
            }
            set
            {
                _PageBackColor = value; 
            }
        }

        /// <summary>
        /// 更新文档视图
        /// </summary>
        public void RefreshView()
        {
            UpdateState();
            UpdateViewSize();
            pnlView.Invalidate();
        }

        /// <summary>
        /// 更新控件状态
        /// </summary>
        public void UpdateState()
        {
            if (this.Document != null)
            {
                this.Document.UpdateState();
                DateTime max = TemperatureDocument.NullDate;
                DateTime min = TemperatureDocument.NullDate;
                this.Document.UpdateNumOfPage( out max , out min );
                cboPageIndex.Items.Clear();
                for (int iCount = 0; iCount < this.Document.NumOfPages; iCount ++ )
                {
                    cboPageIndex.Items.Add( iCount + 1 );
                }
                if (cboPageIndex.Items.Count > 0)
                {
                    cboPageIndex.SelectedIndex = 0;
                }
            }
        }

        private Rectangle _PageBounds = Rectangle.Empty;
        private Rectangle _DocumentBounds = Rectangle.Empty;
        private void UpdateViewSize()
        {
            if (this.IsHandleCreated
                && this.Document != null
                && this.DesignMode == false )
            {
                using (Graphics g = pnlView.CreateGraphics())
                {
                    // 计算页面框架视图边界
                    _PageBounds = new Rectangle(
                        10,
                        10,
                        (int)(g.DpiX * this.PageSettings.Bounds.Width / 100f),
                        (int)(g.DpiY * this.PageSettings.Bounds.Height / 100f));
                    if (_PageBounds.Width + 20 < this.ClientSize.Width)
                    {
                        _PageBounds.X = 10 + (this.ClientSize.Width - _PageBounds.Width) / 2;
                    }
                    // 计算文档视图边界
                    _DocumentBounds.X = _PageBounds.X + (int)(this.PageSettings.Margins.Left * g.DpiX / 100f);
                    _DocumentBounds.Y = _PageBounds.Y + (int)(this.PageSettings.Margins.Top * g.DpiY / 100f);
                    _DocumentBounds.Width = _PageBounds.Right - (int)(this.PageSettings.Margins.Right * g.DpiX / 100f) - _DocumentBounds.Left;
                    _DocumentBounds.Height = _PageBounds.Bottom - (int)(this.PageSettings.Margins.Bottom * g.DpiY / 100f) - _DocumentBounds.Top;

                    Size viewSize = new Size(
                        _PageBounds.Left + 10 ,
                        _PageBounds.Bottom + 10 );
                    
                    if (pnlView.AutoScrollMinSize != viewSize)
                    {
                        pnlView.AutoScrollMinSize = viewSize;
                    }
                }
            }
        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode == false)
            {
                pnlView.Invalidate();
                UpdateViewSize();
            }
        }

        private void pnlView_Paint(object sender, PaintEventArgs e)
        {
            if (this.Document == null)
            {
                return;
            }
            // 绘制页面边框
            Rectangle pb = _PageBounds;
            pb.Offset(this.pnlView.AutoScrollPosition.X, this.pnlView.AutoScrollPosition.Y);
            Rectangle pb2 = Rectangle.Intersect(pb, e.ClipRectangle);
            if (pb2.IsEmpty)
            {
                return;
            }
            using (SolidBrush b = new SolidBrush(this.PageBackColor))
            {
                e.Graphics.FillRectangle(b, pb2);
            }
            e.Graphics.DrawRectangle(Pens.Black, pb);
            // 绘制文档
            Rectangle db = _DocumentBounds;
            db.Offset(this.pnlView.AutoScrollPosition.X, this.pnlView.AutoScrollPosition.Y);
            if (e.ClipRectangle.IntersectsWith(db))
            {
                TemperatureDocumentOptions options = this.DocumentOptions;
                options.FontName = this.Font.Name;
                options.FontSize = this.Font.Size;
                this.Document.UpdateState();
                this.Document.PageIndex = cboPageIndex.SelectedIndex;
                options.Left = db.Left;
                options.Top = db.Top;
                options.Width = db.Width;
                options.Height = db.Height;
                this.DocumentRender.Draw(e.Graphics, this.Document);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void cboPageIndex_Click(object sender, EventArgs e)
        {

        }

        private void cboPageIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlView.Invalidate();
        }

        private void btnPrintCurrentPage_Click(object sender, EventArgs e)
        {
            PrintDocument(true);
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            PrintDocument(false);
        }

        private void PrintDocument( bool currentPage )
        {
            using (PrintDialog dlg = new PrintDialog())
            {
                dlg.AllowCurrentPage = false;
                dlg.AllowSelection = false;
                dlg.AllowSomePages = false;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    using (TemperaturePrintDocument pd = new TemperaturePrintDocument( 
                        this.Document , 
                        this.DocumentRender  ))
                    {
                        if (currentPage)
                        {
                            // 指定当前页
                            pd.SpecifyPageIndex = cboPageIndex.SelectedIndex;
                        }
                        pd.PrinterSettings = dlg.PrinterSettings;
                        pd.DefaultPageSettings = this.PageSettings;
                        pd.Print();
                    }
                }
            }
        }

        /// <summary>
        /// 从文件流中加载文档
        /// </summary>
        /// <param name="stream">文件流对象</param>
        public void LoadDocument(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            TemperatureDocument doc = new TemperatureDocument();
            if( doc.Load(stream) )
            {
                this.Document = doc;
                if (this.IsHandleCreated)
                {
                    this.UpdateState();
                    this.pnlView.Invalidate();
                }
            }
        }

        public void SaveDocument(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (this.Document != null)
            {
                this.Document.Save(stream);
            }
        }
    }
}
