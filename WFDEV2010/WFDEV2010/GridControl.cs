using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using EFDATA;

namespace WFDEV2010
{
    public partial class GridControl : Form
    {
        public GridControl()
        {
            InitializeComponent();
        }

        private void GridControl_Load(object sender, EventArgs e)
        {
            DataBind();

        }
        private void DataBind()
        {
            HIP_Standard_BaseFrameworkEntities ef = new HIP_Standard_BaseFrameworkEntities();
            Func<dic_Hospital, bool> fun = P => P.sOrganizationType == "5";

            gridControl1.DataSource = ef.dic_Hospital.Where(fun).ToList();
            Func<dic_Dict, bool> thypefun = P => P.sTableCode == "sOrganizationType";
            repositoryItemLookUpEdit1.DataSource = ef.dic_Dict.Where(thypefun).ToList();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataBind();
        }



        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                //gridView1.AddNewRow();
                //if (EditRecord())
                //    gridView1.UpdateCurrentRow();
                //else gridView1.CancelUpdateCurrentRow();
                e.Handled = true;
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = gridView1.GetDataRow(e.RowHandle);
            row["sOrganizationName"] = 1;
            row["sCertificateNo"] = 5550;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            gridView1.OptionsView.AllowCellMerge =true;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

    }
}
