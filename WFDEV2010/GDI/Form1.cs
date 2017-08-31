using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.timer1.Tick += timer1_Tick;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.9)
            {
                this.Opacity = this.Opacity - 0.01;//窗体以0.01的速度渐变
            }
            else if (this.Opacity < 0)
            {
                this.timer1.Enabled = false;//时间为false

            }
            else
            {
              //  Close();///渐变消失
            }
        }

        void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;//获取当前运行时间
            this.Opacity = 1;//获取当前窗体的透明度级别;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //投影文字
            Graphics g = this.CreateGraphics();
            //设置文本输出质量
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Font newFont = new Font("Times New Roman", 48);
            Matrix matrix = new Matrix();
            //投射
            matrix.Shear(-1.5f, 0.0f);
            //缩放
            matrix.Scale(1, 0.5f);
            //平移
            matrix.Translate(130, 88);
            //对绘图平面实施坐标变换、、
            g.Transform = matrix;
            SolidBrush grayBrush = new SolidBrush(Color.Red);
            SolidBrush colorBrush = new SolidBrush(Color.BlueViolet);
            string text = "博客园";
            //绘制阴影
            g.DrawString(text, newFont, grayBrush, new PointF(0, 30));
            g.ResetTransform();
            //绘制前景
            g.DrawString(text, newFont, colorBrush, new PointF(0, 30));
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Blue, 5);//设置笔的粗细为,颜色为蓝色
            Graphics g = this.CreateGraphics();

            //画虚线
            p.DashStyle = DashStyle.Dot;//定义虚线的样式为点
            g.DrawLine(p,90,10,800, 200);

            //自定义虚线
            p.DashPattern = new float[] { 2, 1 };//设置短划线和空白部分的数组
            g.DrawLine(p, 10, 20, 200, 20);

            //画箭头,只对不封闭曲线有用
            p.DashStyle = DashStyle.Solid;//恢复实线
            p.EndCap = LineCap.ArrowAnchor;//定义线尾的样式为箭头
            g.DrawLine(p, 10, 30, 200, 30);

            g.Dispose();
            p.Dispose();
        }
    }
}
