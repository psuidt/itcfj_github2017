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
using System.Drawing ;
using System.Drawing.Drawing2D ;

namespace DCSoft.TemperatureChart
{
    /// <summary>
    /// 体温单绘制对象
    /// </summary>
    /// <remarks>编制 袁永福</remarks>
    [System.Runtime.InteropServices.ComVisible(false)]
    public class TemperatureDocumentRender
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public TemperatureDocumentRender()
        {

        }


        /// <summary>
        /// 绘制体温单
        /// </summary>
        /// <param name="g">画布对象</param>
        public void Draw(Graphics g, TemperatureDocument document)
        {
            if (document == null)
            {
                return;
            }
            TemperatureDocumentOptions options = document.Options;
            foreach (TitleLineInfo line in options.HeaderLines)
            {
                line.RuntimeStartDate = line.StartDate;
                if (line.ValueType == TitleLineValueType.DayIndex)
                {
                    if (line.RuntimeStartDate == TemperatureDocument.NullDate)
                    {
                        if (string.IsNullOrEmpty(line.StartDateKeyword) == false)
                        {
                            foreach (Measure m in document.Measures)
                            {
                                if (m.Memo != null
                                    && m.Memo.IndexOf(line.StartDateKeyword) >= 0)
                                {
                                    line.RuntimeStartDate = m.ValueDate;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (line.ValueType == TitleLineValueType.InDayIndex)
                {
                    if (document.Measures.Count > 0)
                    {
                        line.RuntimeStartDate = document.Measures[0].ValueDate;
                    }
                }
            }

            Font labelFont = null;
            if (string.IsNullOrEmpty(options.FontName))
            {
                labelFont = new Font(
                    System.Windows.Forms.Control.DefaultFont.Name,
                    options.FontSize);
            }
            else
            {
                labelFont = new Font(
                    options.FontName,
                    options.FontSize);
            }

            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;
            centerFormat.FormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
                    | System.Drawing.StringFormatFlags.MeasureTrailingSpaces
                    | StringFormatFlags.NoClip | StringFormatFlags.NoWrap ;
            if (options.BackColor.A != 0)
            {
                // 绘制背景
                using (SolidBrush b = new SolidBrush(options.BackColor))
                {
                    g.FillRectangle(
                        b,
                        options.Left,
                        options.Top,
                        options.Width,
                        options.Height);
                }
            }

            // 计算Y坐标轴文本占据的宽度
            float totalYAxisWidth = 0;
            foreach (YAxisInfo info in options.YAxisInfos)
            {
                string title = info.Title;
                if (string.IsNullOrEmpty(title))
                {
                    title = "HHHH";
                }
                SizeF size = g.MeasureString(title, labelFont);
                info.ViewLeft = totalYAxisWidth;
                info.ViewWidth = size.Width * 1.1f;
                totalYAxisWidth += info.ViewWidth;
            }

            // 根据标题行文本的宽度设置左边缘区域宽度
            List<string> titleTexts = new List<string>();
            foreach (TitleLineInfo info in options.HeaderLines)
            {
                titleTexts.Add(info.Text);
            }
            foreach (TitleLineInfo info in options.FooterLines)
            {
                titleTexts.Add(info.Text);
            }
            foreach (string text in titleTexts)
            {
                if (string.IsNullOrEmpty(text))
                {
                    continue;
                }
                SizeF size = g.MeasureString(text, labelFont);
                totalYAxisWidth = Math.Max(totalYAxisWidth, size.Width);
            }//foreach

            // 有数据的时间区间的最大值
            DateTime maxDate = TemperatureDocument.NullDate;
            // 有数据的时间区间的最小值
            DateTime minDate = TemperatureDocument.NullDate;
            document.UpdateNumOfPage(out maxDate, out minDate);
             
            // 当前区域的开始时间
            DateTime startDate = minDate.AddDays(
                document.PageIndex * options.NumOfDaysInOnePage);

            // 计算标题行高度
            float titleLineHeight = labelFont.GetHeight(g) * 1.5f;
            // 标题行总高度
            float totalHeaderLineHeight = titleLineHeight * options.HeaderLines.Count;

            // 标题栏高度
            float titleHeight = 0;

            if (string.IsNullOrEmpty( document.Title) == false)
            {
                titleHeight = titleLineHeight * 3;
                // 绘制大标题
                using (Font titleFont = new Font(
                    labelFont.Name,
                    labelFont.Size * 3,
                    labelFont.Style))
                {
                    RectangleF titleTextBounds = new RectangleF(
                        options.Left,
                        options.Top,
                        options.Width,
                        titleHeight);
                    g.DrawString(
                        document.Title,
                        titleFont,
                        Brushes.Black,
                        titleTextBounds,
                        centerFormat);
                }
            }
            List<string> infoTitle = new List<string>();
            infoTitle.Add("姓名:" + document.PatientName);
            infoTitle.Add("年龄:" + document.PatientAge);
            infoTitle.Add("病区:" + document.Section);
            infoTitle.Add("床位:" + document.BedID);
            infoTitle.Add("住院号:" + document.InpatientID);
                // 绘制病人基本信息
            float infoWidth = options.Width / infoTitle.Count;
            using (StringFormat infoFormat = new StringFormat())
            {
                infoFormat.Alignment = StringAlignment.Near;
                infoFormat.LineAlignment = StringAlignment.Center;
                for (int iCount = 0; iCount < infoTitle.Count; iCount++)
                {
                    string text = infoTitle[iCount];
                    if (string.IsNullOrEmpty(text) == false)
                    {
                        RectangleF infoTextBounds = new RectangleF(
                            options.Left + infoWidth * iCount,
                            options.Top + titleHeight,
                            infoWidth,
                            titleLineHeight);
                        g.DrawString(
                            text,
                            labelFont,
                            Brushes.Black,
                            infoTextBounds,
                            infoFormat);
                    }//if
                }//for
            }//using
            titleHeight += titleLineHeight;
            

            // 页尾行总高度
            float totalFooterLineHeight = titleLineHeight * options.FooterLines.Count;

            // 数据区域网格边界矩形
            RectangleF dataGridBounds = new RectangleF(
                options.Left + totalYAxisWidth,
                options.Top + titleHeight + titleLineHeight * options.HeaderLines.Count,
                options.Width - totalYAxisWidth,
                options.Height - totalHeaderLineHeight - totalFooterLineHeight - titleHeight);

            // 绘制标题行网格竖线
            float dayStep = dataGridBounds.Width / options.NumOfDaysInOnePage;

            // 绘制数据标题行
            for (int lineIndex = 0; lineIndex < options.HeaderLines.Count; lineIndex++)
            {
                TitleLineInfo line = options.HeaderLines[lineIndex];
                line.Top = options.Top + titleHeight + titleLineHeight * lineIndex;
                // 绘制横线
                g.DrawLine(
                    Pens.Black,
                    options.Left,
                    line.Top + titleLineHeight,
                    options.Left + options.Width,
                    line.Top + titleLineHeight);

                // 标题边界
                RectangleF titleRect = new RectangleF(
                    options.Left,
                    line.Top,
                    totalYAxisWidth,
                    titleLineHeight);
                if (string.IsNullOrEmpty(line.Text) == false)
                {
                    // 绘制标题文本
                    g.DrawString(
                        line.Text,
                        labelFont,
                        Brushes.Black,
                        titleRect,
                        centerFormat);
                }
                if (line.ValueType == TitleLineValueType.SerialDate)
                {
                    // 绘制日期系列
                    for (int dayIndex = 0; dayIndex < options.NumOfDaysInOnePage; dayIndex++)
                    {
                        DateTime dtm = startDate.AddDays(dayIndex);
                        if (dtm > maxDate)
                        {
                            // 超出最大日期，不显示
                            break;
                        }
                        string text = null;
                        if (dayIndex == 0 || dtm.Day == 1)
                        {
                            // 如果是本序列的第一栏或是本月的第一天则显示完整的日期
                            text = dtm.ToString(options.DateFormatString);
                        }
                        else
                        {
                            // 否则只显示日数
                            text = dtm.Day.ToString();
                        }
                        g.DrawString(
                            text,
                            labelFont,
                            Brushes.Black,
                            new RectangleF(
                                dataGridBounds.Left + dayStep * dayIndex,
                                line.Top,
                                dayStep,
                                titleLineHeight),
                            centerFormat);
                    }//for
                }
                else if (line.ValueType == TitleLineValueType.DayIndex
                    || line.ValueType == TitleLineValueType.InDayIndex )
                {
                    // 绘制第几天数
                    if (line.RuntimeStartDate != TemperatureDocument.NullDate )
                    {
                        for (int dayIndex = 0; dayIndex < options.NumOfDaysInOnePage; dayIndex++)
                        {
                            // 计算当前日期
                            DateTime dtm = startDate.AddDays(dayIndex);
                            if (dtm > maxDate)
                            {
                                // 超出最大日期，不显示
                                break;
                            }
                            // 获得时间差
                            TimeSpan span = dtm - line.RuntimeStartDate ;
                            if (span.Days >= 0)
                            {
                                string text = Convert.ToString(span.Days + 1);
                                g.DrawString(
                                    text,
                                    labelFont,
                                    Brushes.Black,
                                    new RectangleF(
                                        dataGridBounds.Left + dayStep * dayIndex,
                                        line.Top,
                                        dayStep,
                                        titleLineHeight),
                                    centerFormat);
                            }
                        }//for
                    }//if
                }//else if
                else if (line.ValueType == TitleLineValueType.HourTick)
                {
                    // 绘制小时刻数
                    float topFix = (titleLineHeight - labelFont.GetHeight(g)) / 2;
                    for (int dayIndex = 0; dayIndex < options.NumOfDaysInOnePage; dayIndex++)
                    {
                        for (int tickCount = 0; tickCount < options.HourTicks.Length; tickCount++)
                        {
                            int hour = options.HourTicks[tickCount];
                            Brush b = hour > 12 ? Brushes.Red : Brushes.Black;
                            if (hour > 12)
                            {
                                hour = hour - 12;
                            }
                            float tickStep = dayStep / options.HourTicks.Length;
                            // 计算边界
                            RectangleF tickRect = new RectangleF(
                                dataGridBounds.Left + dayStep * dayIndex + tickStep * tickCount,
                                line.Top,
                                tickStep,
                                titleLineHeight);
                            // 绘制时刻数
                            g.DrawString(
                                hour.ToString(),
                                labelFont,
                                b,
                                tickRect.X ,
                                tickRect.Y + topFix );
                            // 绘制边框
                            g.DrawRectangle(
                                Pens.Black,
                                tickRect.Left,
                                tickRect.Top,
                                tickRect.Width,
                                tickRect.Height);
                        }//for
                    }//for
                }//else
            }//for

            // 绘制Y坐标轴内容
            for (int iCount = 0; iCount < options.YAxisInfos.Count; iCount++)
            {
                YAxisInfo info = options.YAxisInfos[iCount];
                for (int numTick = 0; numTick < options.YSplitNum; numTick++)
                {
                    // 绘制Y轴刻度文本
                    RectangleF infoRect = new RectangleF(
                       options.Left + info.ViewLeft,
                       dataGridBounds.Top + dataGridBounds.Height * numTick / options.YSplitNum,
                       info.ViewWidth,
                       titleLineHeight);
                    float numValue = info.MaxValue -
                        (info.MaxValue - info.MinValue) * numTick / options.YSplitNum;
                    string text = numValue.ToString();
                    if (numTick == 0)
                    {
                        // 第一行为标题
                        text = info.Title;
                    }
                    else if (numTick == options.YSplitNum - 1)
                    {
                        // 最后一行的位置要向上移动一行
                        infoRect.Offset(0, -titleLineHeight);
                    }
                    else
                    {
                        // 中间的要向上移动半行
                        infoRect.Offset(0, -titleLineHeight / 2);
                    }
                    if (string.IsNullOrEmpty(text) == false)
                    {
                        // 绘制文本
                        g.DrawString(
                            text,
                            labelFont,
                            Brushes.Black,
                            infoRect,
                            centerFormat);
                    }
                }//for
                // 绘制Y轴竖线
                g.DrawLine(
                    Pens.Black,
                    options.Left + info.ViewLeft + info.ViewWidth,
                    dataGridBounds.Top,
                    options.Left + info.ViewLeft + info.ViewWidth,
                    dataGridBounds.Bottom);
            }//for
            // 绘制Y坐标轴区域大边框
            g.DrawLine(
                Pens.Black,
                options.Left,
                dataGridBounds.Bottom ,
                dataGridBounds.Left ,
                dataGridBounds.Bottom);
            // 绘制数据区域大网格线
            DrawGrid(
                g,
                dataGridBounds,
                options.NumOfDaysInOnePage * options.HourTicks.Length,
                options.YSplitNum * 5,
                Pens.Black);

            // 清空状态
            foreach (YAxisInfo info in options.YAxisInfos)
            {
                info.LastPoint = new PointF(float.NaN, float.NaN);
            }

            // 绘制数据点和线
            foreach (Measure record in document.Measures)
            {
                int dayIndex = (record.ValueDate - startDate).Days;
                if (dayIndex < 0)
                {
                    // 过早的记录不显示
                    continue;
                }
                if (dayIndex >= options.NumOfDaysInOnePage)
                {
                    // 超出本页最后日期，后续记录不显示
                    break;
                }
                // 获得时刻点
                int hourTickIndex = 0;
                for (int hour = 0; hour < options.HourTicks.Length; hour++)
                {
                    if (record.ValueTime < options.HourTicks[hour])
                    {
                        hourTickIndex = hour-1;
                        break;
                    }
                }
                if (hourTickIndex < 0)
                {
                    hourTickIndex = 0;
                }
                // 计算当前数据点X坐标
                float pointX = dataGridBounds.Left +
                    (dayIndex * options.HourTicks.Length + hourTickIndex + 0.5f)
                    * (dayStep / (float)options.HourTicks.Length);

                if (string.IsNullOrEmpty(record.Memo) == false)
                {
                    // 绘制竖的提示文字
                    SizeF cs = g.MeasureString(
                        "##",
                        labelFont,
                        10000,
                        StringFormat.GenericTypographic);
                    float fh = labelFont.GetHeight(g);
                    float cTop = dataGridBounds.Top + 3;
                    foreach (char c in record.Memo)
                    {
                        string txt = c.ToString();
                        if (c == '-')
                        {
                            txt = "|";
                        }
                        g.DrawString(
                            txt,
                            labelFont,
                            Brushes.Red,
                            pointX - cs.Width / 2,
                            cTop);
                        cTop = cTop + fh;
                    }//foreach
                }

                foreach (YAxisInfo info in options.YAxisInfos)
                {
                    float Value = info.GetValue(record);
                    if( TemperatureDocument.IsNullValue(Value))
                    {
                        info.LastPoint = new PointF(float.NaN, float.NaN);
                    }
                    else
                    {
                        float pointY = 1.0f - (Value - info.MinValue) / (info.MaxValue - info.MinValue);
                        pointY = dataGridBounds.Top + dataGridBounds.Height * pointY;
                        PointF point = new PointF(pointX, pointY);
                        if (float.IsNaN(info.LastPoint.X) == false)
                        {
                            // 若上一个数据点存在则绘制连线
                            using (Pen pen = new Pen(info.SymbolColor))
                            {
                                g.DrawLine(pen, info.LastPoint, point);
                            }
                        }
                        // 绘制数据点符号
                        DrawSymbol(g, point.X, point.Y, info , options );
                        info.LastPoint = point;
                    }
                }//foreach YAxisInfo
            }//foreach Measure

            if (options.FooterLines.Count > 0)
            {
                // 绘制页脚内容
                float topCount = dataGridBounds.Bottom;
                foreach (TitleLineInfo info in options.FooterLines)
                {
                    info.Top = topCount;
                    // 绘制标题
                    RectangleF titleBounds = new RectangleF(
                        options.Left,
                        info.Top,
                        totalYAxisWidth,
                        titleLineHeight);
                    if (string.IsNullOrEmpty(info.Text) == false)
                    {
                        g.DrawString(
                            info.Text,
                            labelFont,
                            Brushes.Black,
                            titleBounds,
                            centerFormat);
                    }
                    // 绘制内容
                    for (int dayIndex = 0; dayIndex < options.NumOfDaysInOnePage; dayIndex++)
                    {
                        DateTime dtm = startDate.AddDays(dayIndex);
                        dtm = dtm.Date;
                        foreach (FooterMeasure cm in document.FooterMeasures)
                        {
                            if (cm.ValueDate.Date == dtm)
                            {
                                string text = info.GetText(cm);
                                if (string.IsNullOrEmpty(text) == false)
                                {
                                    // 计算文本内容位置
                                    RectangleF textBounds = new RectangleF(
                                        dataGridBounds.Left + dayIndex * dataGridBounds.Width / document.Options.NumOfDaysInOnePage,
                                        info.Top,
                                        dataGridBounds.Width / options.NumOfDaysInOnePage,
                                        titleLineHeight);
                                    // 绘制文本内容
                                    g.DrawString(
                                        text,
                                        labelFont,
                                        Brushes.Black,
                                        textBounds,
                                        centerFormat);
                                }//if
                                break;
                            }//if
                        }//foreach
                    }//for

                    // 绘制横线
                    g.DrawLine(
                        Pens.Black,
                        options.Left,
                        info.Top + titleLineHeight,
                        options.Left + options.Width,
                        info.Top + titleLineHeight);
                    topCount = topCount + titleLineHeight;
                }
            }
            // 绘制大竖线
            for (int lineIndex = 0; lineIndex <= options.NumOfDaysInOnePage; lineIndex++)
            {
                g.DrawLine(
                    lineIndex == 0 || lineIndex == options.NumOfDaysInOnePage ? Pens.Black : Pens.Red,
                    dataGridBounds.Left + dayStep * lineIndex,
                    options.Top + titleHeight,
                    dataGridBounds.Left + dayStep * lineIndex,
                    options.Top + options.Height);
            }//for

            // 绘制大边框
            using (Pen p = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(
                    p, 
                    options.Left,
                    options.Top + titleHeight , 
                    options.Width, 
                    options.Height - titleHeight );
            }

            labelFont.Dispose();
            centerFormat.Dispose();
        }



        /// <summary>
        /// 绘制网格线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="xNum"></param>
        /// <param name="yNum"></param>
        /// <param name="p"></param>
        private void DrawGrid(Graphics g, RectangleF rect, int xNum, int yNum, Pen p)
        {
            for (int x = 0; x < xNum; x++)
            {
                g.DrawLine(
                    p,
                    rect.Left + rect.Width * x / xNum,
                    rect.Top,
                    rect.Left + rect.Width * x / xNum,
                    rect.Bottom);
            }
            for (int y = 0; y <= yNum; y++)
            {
                g.DrawLine(
                    p,
                    rect.Left,
                    rect.Top + rect.Height * y / yNum,
                    rect.Right,
                    rect.Top + rect.Height * y / yNum);
            }
        }

        /// <summary>
        /// 绘制数据点符号
        /// </summary>
        /// <param name="g">画布对象</param>
        /// <param name="x">X坐标</param>
        /// <param name="y">Y坐标</param>
        /// <param name="info">坐标轴信息</param>
        private void DrawSymbol(Graphics g, float x, float y, YAxisInfo info , TemperatureDocumentOptions opt )
        {
            float ssize = opt.SymbolSize;
            if (g.PageUnit == GraphicsUnit.Document)
            {
                ssize = ssize * 300f / 96f;
            }
            RectangleF rect = new RectangleF(
                x - ssize / 2,
                y - ssize / 2,
                ssize,
                ssize);
            switch (info.SymbolStyle)
            {
                case PointSymbolStyle.SolidCicle:
                    using (SolidBrush b = new SolidBrush(info.SymbolColor))
                    {
                        g.FillEllipse(
                            b,
                            rect);
                    }
                    break;
                case PointSymbolStyle.HollowCicle:
                    using (Pen p = new Pen(info.SymbolColor , 2 ))
                    {
                        g.DrawEllipse(
                             p,
                             rect);
                    }
                    break;
                case PointSymbolStyle.Cross:
                    using (Pen p = new Pen(info.SymbolColor, 2 ))
                    {
                        g.DrawLine(p, rect.Left, rect.Top, rect.Right, rect.Bottom);
                        g.DrawLine(p, rect.Left, rect.Bottom, rect.Right, rect.Top);
                    }
                    break;
            }
        }
    }
}
