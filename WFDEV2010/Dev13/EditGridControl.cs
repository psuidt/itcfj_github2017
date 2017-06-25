using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Dev13
{
    public partial class EditGridControl : DevExpress.XtraEditors.XtraForm
    {
        public EditGridControl()
        {
            InitializeComponent();
            gridControl1.DataSource = ClassLibrary.Data.DataSource.GetData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < this.gridView1.DataRowCount; i++)
            {
                if (this.gridView1.GetDataRow(i).RowState == DataRowState.Modified)
                {
                    MessageBox.Show(this.gridView1.GetRowCellValue(i, this.gridView1.Columns[1]).ToString());
                }

            }
        }
    }
}