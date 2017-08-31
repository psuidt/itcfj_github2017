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
    public partial class GridMasterDetail1 : DevExpress.XtraEditors.XtraForm
    {
        public GridMasterDetail1()
        {
            InitializeComponent();
        }

        private void GridMasterDetail1_Load(object sender, EventArgs e)
        {
            InitData();
            gridView1.SetMasterRowExpandedEx(0, 0, true);
            gridView1.SetMasterRowExpanded(1, true);
            gridView1.SetMasterRowExpanded(3, true);
        }

        void InitData()
        {
            //ConvertXMLFileToDataSet(
            //     string[] str = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Dev13.NewFolder1.Parents.xml");
        
            dataSet11.ReadXml(stream, XmlReadMode.IgnoreSchema);

            //DataSet ds = new DataSet();
            //      ds.ReadXml(@"E:\云端TFS\BuildProcessTemplates\WFDEV2010\Dev13\NewFolder1\Parents.xml");
            // gridControl1.DataSource = ds.Tables[0];
            //  gridView1.PopulateColumns();
        }
    }
}