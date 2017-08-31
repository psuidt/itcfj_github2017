using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
namespace DevWinfrom
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private Model.MYCISDBEntities EnCISDB;
        public Form1()
        {
            InitializeComponent();
            EnCISDB = new Model.MYCISDBEntities();
            this.Load += (s, e) => { Bind();
                gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                gridView2.OptionsSelection.MultiSelect = true;
                gridView2.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
               // checkedListBoxControl1.LookAndFeel= true;
                checkedListBoxControl1.LookAndFeel.SkinName = "The Asphalt World";
               checkedListBoxControl1.LookAndFeel.UseDefaultLookAndFeel = false;
               btnEdit1.Width = 100;
               btnEdit1.Properties.Buttons[0].Kind = ButtonPredefines.OK;
               btnEdit1.Properties.Buttons.RemoveAt(0);
               radioGroup1.Properties.AllowHtmlDraw = DefaultBoolean.True;
               simpleButton4.AllowHtmlDraw = DefaultBoolean.True;

             //  simpleButton4.Text = "<b><color=255, 0, 0>dddd</color></b>";
               simpleButton4.Text = "<b> <font size=\"3\" color=\"red\">This is some text!</font></b>";

            };
            radioGroup1.SelectedIndex = 1;
            DataTable dtq = new DataTable();
            dtq.Columns.Add("状态ID");
            dtq.Columns.Add("状态名称");
            dtq.Rows.Add(new object[] { "99", "全部" });
            dtq.Rows.Add(new object[] { "0", "未审批" });
            dtq.Rows.Add(new object[] { "1", "审批通过" });
            dtq.Rows.Add(new object[] { "2", "审批未通过" });
            dtq.Rows.Add(new object[] { "9", "作废" });
            lookUpEditSpzt.Properties.DataSource = dtq;
            lookUpEditSpzt.Properties.DisplayMember = "状态名称";
            lookUpEditSpzt.Properties.ValueMember = "状态ID";
            //lookUpEditSpzt.Properties.Columns[0].Width = 10;

            //lookUpEditSpzt.Properties.Columns[1].Width = 10;

            ////控制选择项的总宽度

            //lookUpEditSpzt.Properties.PopupWidth = 20;


            lookUpEditSpzt.Properties.PopupWidth = lookUpEditSpzt.Properties.PopupFormMinSize.Width - 15;

            this.gridView1.RowCellStyle += gridView1_RowCellStyle;
  //          this.gridView1.CustomDrawColumnHeader += gridView1_CustomDrawColumnHeader;
    //        this.gridView1.Click += gridView1_Click;
            this.gridView1.ColumnPanelRowHeight = 50;
            this.gridView1.OptionsView.AllowHtmlDrawHeaders = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            //表头及行内容居中显示
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.Appearance.EvenRow.BackColor = Color.FromArgb(150, 237, 243, 254);
            gridView1.Appearance.OddRow.BackColor = Color.FromArgb(150, 199, 237, 204);

            gridView1.OptionsView.ShowViewCaption = false;
            gridView1.ViewCaption = "体检结果";
            gridColumn1.Caption = "   体重<br>(kg)";
            gridColumn1.Width = 40;
            gridColumn2.Caption = "   视力<br>(左)";
            gridColumn1.FieldName = "sTz";
            gridColumn2.FieldName = "sSl";
            gridColumn3.Caption = "录入日期";
            gridColumn3.FieldName = "dLrrq";
            gridColumn4.Caption = "";
            gridColumn4.FieldName = "bCheck";
            DataTable dt = new DataTable();
            dt.Columns.Add("bCheck", typeof(bool));
            dt.Columns.Add("sTz", typeof(decimal));
            dt.Columns.Add("sSl", typeof(decimal));
            dt.Columns.Add("dLrrq", typeof(DateTime));
            dt.Rows.Add(new object[] { false, 2.3, 44.4, "2013-11-11 01:11" });
            dt.Rows.Add(new object[] { false, 6.3, 66.5, "2014-01-12 11:25" });
            dt.Rows.Add(new object[] { true, 23, 444, "2014-12-11 01:11" });
            gridControl1.DataSource = dt;
            lookUpEdit1.Properties.DataSource = dt;
            gridView1.ShowFindPanel();
            lookUpEdit1.Properties.DisplayMember = "sTz";
            lookUpEdit1.Properties.ValueMember = "sSl";
            lookUpEdit1.Properties.NullText = "输入查看..";
            lookUpEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
            lookUpEdit1.Properties.SearchMode = SearchMode.AutoFilter;
            lookUpEdit1.Properties.Buttons.AddRange(new EditorButton[] 
            {   
                
                new EditorButton(
                    ButtonPredefines.Delete,
                    "删除", -1, true, true, false,DevExpress.XtraEditors.ImageLocation.MiddleCenter,
                    null, 
                    new KeyShortcut(Keys.Delete),
                    new SerializableAppearanceObject(),
                    "删除选中项", 
                    "Delete",
                    null,
                    true) 
            });
            lookUpEdit1.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == ButtonPredefines.Delete)
                {
                    LookUpEdit _curLue = s as LookUpEdit;
                    _curLue.EditValue = null;
                }
            };
            popupContainerEdit1.Properties.Buttons.AddRange(
                new EditorButton[] 
            {   
                new EditorButton(
                    ButtonPredefines.Glyph,
                    "添加", -1, true, true, false,DevExpress.XtraEditors.ImageLocation.MiddleCenter,
                    null, 
                    new KeyShortcut(Keys.Add),
                    new SerializableAppearanceObject(),
                    "添加关键字", 
                    "ADD",
                    null,
                    true) 
            }
                );
            popupContainerEdit1.ButtonClick += (s, e) =>
            {
                if (e.Button.Kind == ButtonPredefines.Glyph)
                {
                    MessageBox.Show("为popupContainerEdit1增加自定义按钮！");
                }
            };
            comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[] 
            {   
                new EditorButton(
                    ButtonPredefines.Delete,
                    "删除", -1, true, true, false,DevExpress.XtraEditors.ImageLocation.MiddleCenter,
                    null, 
                    new KeyShortcut(Keys.Delete),
                    new SerializableAppearanceObject(),
                    "删除选中项", 
                    "Delete",
                    null,
                    true) 
            });

        }

        private void Bind()
        {
            //memoEdit1.butto
            list = new List<SYS_KSDMK>();
            //list.AddRange(EnCISDB.SYS_KSDMK.Where(p => true).ToList());

           // list.Add(ks);
            gridControl2.DataSource = list;
            gridControl2.RefreshDataSource();
            gridView2.BestFitColumns();
        }
        private bool m_checkStatus = false;
        void gridView1_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (gridView1 != null)
            {
                gridView1.ClearSorting();//禁止排序

                gridView1.PostEditor();
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info;
                Point pt = gridView1.GridControl.PointToClient(Control.MousePosition);
                info = gridView1.CalcHitInfo(pt);
                if (info.InColumn && info.Column != null && info.Column.FieldName == "bCheck")
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        gridView1.SetRowCellValue(i, "bCheck", !m_checkStatus);
                    }
                    result = true;
                }
            }
            if (result)
            {
                m_checkStatus = !m_checkStatus;
            }
        }

        void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "bCheck")
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                RepositoryItemCheckEdit repositoryCheck = e.Column.ColumnEdit as RepositoryItemCheckEdit;
                if (repositoryCheck != null)
                {
                    Graphics g = e.Graphics;
                    Rectangle r = e.Bounds;

                    DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
                    DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
                    DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
                    info = repositoryCheck.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;

                    painter = repositoryCheck.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
                    info.EditValue = m_checkStatus;
                    info.Bounds = r;
                    info.CalcViewInfo(g);
                    args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                    painter.Draw(args);
                    args.Cache.Dispose();
                }
                e.Handled = true;
            }
        }

        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "sTz" && ((decimal)e.CellValue) > 6)
            {
                // e.Appearance.BackColor = Color.DeepSkyBlue;
                e.Appearance.BackColor = Color.Red;
                e.Appearance.BackColor2 = Color.LightCyan;
            }
            if (e.Column.FieldName == "dLrrq")
            {
                e.Column.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            }

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void radioGroup1_Paint(object sender, PaintEventArgs e)
        {

            RadioGroup rButton = (RadioGroup)sender;
          //  radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description = "<b><color=255, 0, 0>" + radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description + "</color></b>";
            Rectangle r = rButton.GetItemRectangle(radioGroup1.SelectedIndex);
            Graphics g = e.Graphics;
            Rectangle radioButtonrect = new Rectangle(r.X, r.Y + 1, 12, 12);
            g.SmoothingMode = SmoothingMode.AntiAlias;//抗锯齿处理 
            //圆饼背景 
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillEllipse(brush, radioButtonrect);
            }
            //     if (rButton.SelectedIndex==2)
            //  {
            radioButtonrect.Inflate(-2, -2);//矩形内缩2单位 
            g.FillEllipse(Brushes.Red, radioButtonrect);
            //g.DrawString("放大师傅", new Font("Arial", 8), new SolidBrush(Color.DarkGray), radioButtonrect);
            radioButtonrect.Inflate(2, 2);//还原 
            //  }
            //圆形边框 
            using (Pen pen = new Pen(Color.Red))
            {
                g.DrawEllipse(pen, radioButtonrect);
            }
        }

        private void radioGroup1_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {

            e.DisplayText = "得得得";
        }
        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            for (int i = 0; i < radioGroup1.Properties.Items.Count; i++)
            {
                radioGroup1.Properties.Items[i].Description = radioGroup1.Properties.Items[i].Description.Replace("<b><color=255, 0, 0>", "").Replace("</color></b>", "");
                if (i==radioGroup1.SelectedIndex)
                {
                    radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description = "<b><color=255, 0, 0>" + radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Description + "</color></b>";
                }

            }
         
      //radioGroup1.Properties.Items[0].Description = "<b><color=255, 0, 0>实习医生</color></b>";
            //  index = radioGroup1.SelectedIndex;
        }

        private void checkedListBoxControl1_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {


        }

        private void checkedListBoxControl1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle re = checkedListBoxControl1.GetItemRectangle(1);
            Rectangle radioButtonrect = new Rectangle(re.X, re.Y + 1, 12, 12);
            g.FillRectangle(Brushes.Maroon, radioButtonrect);

            Point p = new Point(0, 0);
            Point p1 = new Point(re.X, re.Width / 2);
            Pen pen = new Pen(Color.Red);
            //pen  .Color = Color.Red;
            //g.DrawLine()

            g.DrawLine(pen, p, p1);
        }

        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {


            //  MessageBox.Show(e.Index.ToString());
        }

        private void 截屏_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                System.Threading.Thread.Sleep(1000);
                //创建图象，保存将来截取的图象
                Bitmap image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics imgGraphics = Graphics.FromImage(image);
                //设置截屏区域 柯乐义
                imgGraphics.CopyFromScreen(0, 0, 0, 0, new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
                //保存
                SaveImage(image, i);
                Application.DoEvents();
            }
        }
        private void SaveImage(Image image, int i)
        {
            //    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            //{
            string fileName = @"D:\a" + i + ".jpg";
            //         string extension = Path.GetExtension(fileName);
            //    if (extension == ".jpg")
            //   {
            image.Save(fileName, ImageFormat.Jpeg);
            //   }
            //  else
            //  {
            //     image.Save(fileName, ImageFormat.Bmp);
            // }
        }

        private void popupContainerEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SYS_KSDMK ksModel = new SYS_KSDMK
            {
                ID = "0001",
                NAME = "测试科室测试科室测试科室测试科室"
            };
            list.Add(ksModel);
            gridView2.RefreshData();
            gridView2.BestFitColumns();
        }



        public List<SYS_KSDMK> list { get; set; }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DbQuery<SYS_KSDMK> query = EnCISDB.SYS_KSDMK;
            // System.Data.Entity.SqlServer.SqlFunctions.PatIndex()
            //  System.Data.Entity.Core.EntityKey.
            //System.Data.Entity.
            //   System.Data.Entity.DbFunctions.a
            //EnCISDB.Database.BeginTransaction();
            //   EnCISDB.Database
            //list.ForEach(s => EnCISDB.SYS_KSDMK.f(p => p.ID, s));
            // EnCISDB.Entry<SYS_KSDMK>().c

            //  EnCISDB.SaveChanges();
            //
            //      EnCISDB.SYS_KSDMK.AddOrUpdate(list);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            // ColumnView View = gridControl1.MainView as ColumnView;
           
  //          gridView2.GetSelectedRows();
            //按界面上显示出来的值查询
            //     gridView2.LocateByDisplayText();


          
            //按数据源中的原值查询
          //  gridView2.LocateByValue();
            gridView2.BeginUpdate(); 
            int rowHandle = 0;
            try
            {
                this.gridView2.FocusedRowHandle = this.gridView2.LocateByValue(0, this.gridView2.Columns["NAME"], "党");
                this.gridView2.FocusedColumn = this.gridView2.Columns["NAME"];
                gridView2.TopRowIndex = this.gridView2.FocusedRowHandle;
               // DevExpress.XtraGrid.Columns.GridColumn col = View.Columns["NAME"];
          //      rowHandle = View.LocateByValue(rowHandle, col, "党群部");
                //while (true)
                //{
                //    // locating the next row
                //    rowHandle = gridView2.LocateByValue(0, colNAME, "党群部");
                //    // exiting the loop if no row is found
                //    if (rowHandle == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                //        break;
                //    // perform specific operations on the row found here
                //    // ...
                //    rowHandle++;
                // //   Application.DoEvents();
                //}
            }
            finally { gridView2.EndUpdate(); }
          //  gridView2.FocusedRowHandle = rowHandle;
        }

        private void btnEdit1_MouseEnter(object sender, EventArgs e)
        {
            btnEdit1.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
        }

        private void btnEdit1_MouseLeave(object sender, EventArgs e)
        {
            btnEdit1.Properties.Buttons.RemoveAt(0);
        }
    }
}

