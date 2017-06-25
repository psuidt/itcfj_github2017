using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dev13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gridView1.Click += gridView1_Click;
            repositoryItemCheckEdit1.QueryCheckStateByValue += repositoryItemCheckEdit1_QueryCheckStateByValue;

        }

        void repositoryItemCheckEdit1_QueryCheckStateByValue(object sender, DevExpress.XtraEditors.Controls.QueryCheckStateByValueEventArgs e)
        {
            if (e.CheckState == CheckState.Checked)
            {
                e.CheckState = CheckState.Unchecked;
            }
            else
            {
                e.CheckState = CheckState.Checked;
            }
            if (e.CheckState == CheckState.Indeterminate)
            {
                e.CheckState = CheckState.Checked;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = ClassLibrary.Data.DataSource.GetData();
            gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "数据", gridColumn7, "组计:{0}");

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "sex")
            {
                switch (e.Value.ToString().Trim())
                {
                    case "0":
                        e.DisplayText = "男";
                        break;
                    case "1":
                        e.DisplayText = "女";
                        break;
                    default:
                        e.DisplayText = "";
                        break;
                }

            }
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            //if (gdVwKjyw.FocusedRowHandle < 0)
            //    return;
            //decimal xh = Convert.ToDecimal(gdVwKjyw.GetFocusedRowCellValue("XH").ToString());
            ////CurCfdpgzb = ListCfdpgzb.Find(p => p.XH == xh);
            //tmpModel = ListKJYW.Find(p => p.XH == xh);
            //if (tmpModel.ISXZBZ)
            //    tmpModel.ISXZBZ = false;
            //else
            //    tmpModel.ISXZBZ = true;

            //gdCtrlkjyw.RefreshDataSource();
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.Column.FieldName == "sex")
            //{
            //    Pen p1 = new Pen(Color.Blue, 3);
            //    e.DisplayText = "";
            //    e.Graphics.DrawLines(p1, new Point[]{new Point(e.Bounds.Left,e.Bounds.Top+e.Bounds.Height/3),
            //      new Point(e.Bounds.Left+e.Bounds.Width/2,e.Bounds.Top+e.Bounds.Height/2),
            //    new Point(e.Bounds.Left+e.Bounds.Width/2,e.Bounds.Bottom)
            //}  );

            //}
        }


        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();

            }
        }
    }
}
