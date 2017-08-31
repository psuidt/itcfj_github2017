using System;
using System.Collections.Generic;
using System.Text;
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

using System.Drawing;
using System.Drawing.Printing;

namespace DCSoft.TemperatureChart
{
    /// <summary>
    /// 体温单打印文档
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [System.Runtime.InteropServices.ComVisible(false)]
    public class TemperaturePrintDocument : PrintDocument 
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        /// <param name="document">文档对象</param>
        /// <param name="render">绘制器</param>
        public TemperaturePrintDocument(
            TemperatureDocument document,
            TemperatureDocumentRender render)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }
            if( render == null )
            {
                throw new ArgumentNullException("render");
            }
            _Document = document;
            _Render = render;
        }
       
        /// <summary>
        /// 文档对象
        /// </summary>
        private TemperatureDocument _Document = null;
        /// <summary>
        /// 文档视图绘制器
        /// </summary>
        private TemperatureDocumentRender _Render = null;

        /// <summary>
        /// 当前页码号
        /// </summary>
        private int _CurrentPageIndex = 0 ;

        private int _SpecifyPageIndex = -1;
        /// <summary>
        /// 打印指定的页码
        /// </summary>
        [System.ComponentModel.DefaultValue( -1 )]
        public int SpecifyPageIndex
        {
            get
            {
                return _SpecifyPageIndex; 
            }
            set
            {
                _SpecifyPageIndex = value; 
            }
        }

        /// <summary>
        /// 开始打印任务
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBeginPrint(PrintEventArgs e)
        {
            DateTime maxDate = TemperatureDocument.NullDate;
            DateTime minDate = TemperatureDocument.NullDate;
            _CurrentPageIndex = 0;
            _Document.UpdateState();
            _Document.UpdateNumOfPage(out maxDate, out minDate);
            base.OnBeginPrint(e);
        }

        /// <summary>
        /// 打印一页
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            base.OnPrintPage(e);
            // 设置当前页码号
            if (_SpecifyPageIndex >= 0)
            {
                _CurrentPageIndex = _SpecifyPageIndex;
            }
            _Document.PageIndex = _CurrentPageIndex;
            // 设置计量单位
            e.Graphics.PageUnit = GraphicsUnit.Document;
            // 设置文档位置
            _Document.Options.Left = e.PageSettings.Margins.Left * 3;
            _Document.Options.Top = e.PageSettings.Margins.Top * 3;
            _Document.Options.Width = e.PageSettings.Bounds.Width * 3 - _Document.Options.Left - e.PageSettings.Margins.Right * 3 ;
            _Document.Options.Height = e.PageSettings.Bounds.Height * 3 - _Document.Options.Top - e.PageSettings.Margins.Bottom * 3 ;
            // 绘制文档
            _Render.Draw(e.Graphics, _Document);
            _CurrentPageIndex++;
            if ( _SpecifyPageIndex >= 0 || _CurrentPageIndex >= _Document.NumOfPages)
            {
                // 若超过最大页则没有后续页，不再打印下一页
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
            }
        }
    }
}
