using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;

namespace WFDEV2010
{
    public partial class GridControl合并表头 : DevExpress.XtraEditors.XtraForm
    {
        public GridControl合并表头()
        {
            InitializeComponent();
            
            //首先拖到窗体上一个GridControl，在表格上点击“Click here to change view”链接，在弹出菜单中选择“convert to”-->“AdvBandedGridView”。
            
            InitGrid();

            DataTable dtq = new DataTable();
            dtq.Columns.Add("状态ID");
            dtq.Columns.Add("状态名称");
            dtq.Rows.Add(new object[] { "99", "全部" });
            dtq.Rows.Add(new object[] { "0", "未审批" });
            dtq.Rows.Add(new object[] { "1", "审批通过" });
            dtq.Rows.Add(new object[] { "2", "审批未通过" });
            dtq.Rows.Add(new object[] { "9", "作废" });
            lookUpEdit1.Properties.DataSource = dtq;
            lookUpEdit1.Properties.DisplayMember = "状态名称";
            lookUpEdit1.Properties.ValueMember = "状态ID";

        }

        ///初始化表格
        private void InitGrid()
        {

            // advBandedGridView1是表格上的默认视图，注意这里声明的是：BandedGridView
            BandedGridView view = advBandedGridView1 as BandedGridView;
            
            view.BeginUpdate(); //开始视图的编辑，防止触发其他事件
            view.BeginDataUpdate(); //开始数据的编辑

            view.Bands.Clear();

            //修改附加选项
            view.OptionsView.ShowColumnHeaders = false;                         //因为有Band列了，所以把ColumnHeader隐藏
            view.OptionsView.ShowGroupPanel = false;                            //如果没必要分组，就把它去掉
            view.OptionsView.EnableAppearanceEvenRow = false;                   //是否启用偶数行外观
            view.OptionsView.EnableAppearanceOddRow = true;                     //是否启用奇数行外观
            view.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;   //是否显示过滤面板
            view.OptionsCustomization.AllowColumnMoving = false;                //是否允许移动列
            view.OptionsCustomization.AllowColumnResizing = false;              //是否允许调整列宽
            view.OptionsCustomization.AllowGroup = false;                       //是否允许分组
            view.OptionsCustomization.AllowFilter = false;                      //是否允许过滤
            view.OptionsCustomization.AllowSort = true;                         //是否允许排序
            view.OptionsSelection.EnableAppearanceFocusedCell = true;           //???
            view.OptionsBehavior.Editable = true;                               //是否允许用户编辑单元格

            //添加列标题
            GridBand bandID = view.Bands.AddBand("ID");
            bandID.Visible = false; //隐藏ID列
            GridBand bandName = view.Bands.AddBand("姓名");
            GridBand bandSex = view.Bands.AddBand("性别");
            GridBand bandBirth = view.Bands.AddBand("出生日期");
            GridBand bandScore = view.Bands.AddBand("分数");
            GridBand bandMath = bandScore.Children.AddBand("数学");
            GridBand bandChinese = bandScore.Children.AddBand("语文");
            GridBand bandEnglish = bandScore.Children.AddBand("英语");
            GridBand bandSubTotal = bandScore.Children.AddBand("小计");
            GridBand bandRemark = view.Bands.AddBand("备注");

            //列标题对齐方式
            bandName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandSex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandBirth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandScore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandMath.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandChinese.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandEnglish.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandSubTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            bandRemark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            //模拟几个数据
            List<Record> listDataSource = new List<Record>();
            listDataSource.Add(new Record(1, "张三","男",Convert.ToDateTime("1989-5-6") ,115.5f,101,96,""));
            listDataSource.Add(new Record(2, "李四", "女", Convert.ToDateTime("1987-12-23"), 92, 85, 87, ""));
            listDataSource.Add(new Record(3, "王五", "女", Convert.ToDateTime("1990-2-11"), 88, 69, 41.5f, ""));
            listDataSource.Add(new Record(4, "赵六", "男", Convert.ToDateTime("1988-9-1"), 119, 108, 110, "备注行"));
            //绑定数据源并显示
            gridControl1.DataSource = listDataSource;
            gridControl1.MainView.PopulateColumns();

            //[小计]这一列因为没绑定数据源，所以需要手动添加
            //(有点复杂，慢慢看吧)
            string[] fieldNames = new string[] { "SubTotal" };
            GridColumn column;   //声明单列
            column = view.Columns.AddField(fieldNames[0]);  //添加一个数据字段
            column.VisibleIndex = view.Columns.Count -1;  //设置该列在编辑视图时的显示位置(倒数第二列)  
            column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            column.OptionsColumn.AllowEdit = false;     //此列不可编辑
            column.Visible = true;
            view.Columns.Add(column);   //视图中添加一列

            //绑定事件，当[分数]改变时[小计]也跟着变
            //(好像只有在绑定事件里才能改变该单元格数值，直接修改无效)
            view.CustomUnboundColumnData += new
                DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(advBandedGridView1_CustomUnboundColumnData);

            //[性别]列绑定ComboBox
            RepositoryItemComboBox riCombo = new RepositoryItemComboBox();
            riCombo.Items.AddRange(new string[] {"男", "女"});
            gridControl1.RepositoryItems.Add(riCombo);
            view.Columns["Sex"].ColumnEdit = riCombo;

            //[出生年月]列绑定Date
            RepositoryItemDateEdit riDate = new RepositoryItemDateEdit();
            gridControl1.RepositoryItems.Add(riDate);
            view.Columns["Birth"].ColumnEdit = riDate;

            //[分数]列绑定SpinEdit
            RepositoryItemSpinEdit riSpin = new RepositoryItemSpinEdit();
            gridControl1.RepositoryItems.Add(riSpin);
            view.Columns["Math"].ColumnEdit = riSpin;
            view.Columns["Chinese"].ColumnEdit = riSpin;
            view.Columns["English"].ColumnEdit = riSpin;

            //[备注]列绑定MemoExEdit
            RepositoryItemMemoExEdit riMemoEx = new RepositoryItemMemoExEdit();
            gridControl1.RepositoryItems.Add(riMemoEx);
            view.Columns["Remark"].ColumnEdit = riMemoEx;


            //小计列添加汇总
            view.OptionsView.ShowFooter = true;     //显示表格页脚
            view.Columns["SubTotal"].SummaryItem.FieldName = "SubTotal";
            view.Columns["SubTotal"].SummaryItem.DisplayFormat = "{0:f2}";
            view.Columns["SubTotal"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;

            //将标题列和数据列对应
            view.Columns["ID"].OwnerBand = bandID;
            view.Columns["Name"].OwnerBand = bandName;
            view.Columns["Sex"].OwnerBand = bandSex;
            view.Columns["Birth"].OwnerBand = bandBirth;
            view.Columns["Math"].OwnerBand = bandMath;
            view.Columns["Chinese"].OwnerBand = bandChinese;
            view.Columns["English"].OwnerBand = bandEnglish;
            view.Columns["SubTotal"].OwnerBand = bandSubTotal;
            view.Columns["Remark"].OwnerBand = bandRemark;

            view.EndDataUpdate();//结束数据的编辑
            view.EndUpdate();   //结束视图的编辑


        }



        // 计算小计
        private float calcSubTotal(float math, float chinese, float english)
        {
            return math + chinese + english;
        }


        private void advBandedGridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            ColumnView colView = sender as ColumnView;
            if (e.Column.FieldName == "SubTotal" && e.IsGetData) e.Value = calcSubTotal(
                     Convert.ToSingle(colView.GetRowCellValue(e.ListSourceRowIndex, colView.Columns["Math"])),
                     Convert.ToSingle(colView.GetRowCellValue(e.ListSourceRowIndex, colView.Columns["Chinese"])),
                     Convert.ToSingle(colView.GetRowCellValue(e.ListSourceRowIndex, colView.Columns["English"])));
        }



        #region 运行时绑定到实现Ilist接口的数据源

        public class Record
        {
            int id;
            DateTime birth;
            string name, sex, remark;
            float math, chinese, english;
            public Record(int id, string name, string sex, DateTime birth, float math, float chinese, float english, string remark)
            {
                this.id = id;
                this.name = name;
                this.sex = sex;
                this.birth = birth;
                this.math = math;
                this.chinese = chinese;
                this.english = english;
                this.remark = remark;
            }
            public int ID { get { return id; } }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Sex
            {
                get { return sex; }
                set { sex = value; }
            }
            public DateTime Birth
            {
                get { return birth; }
                set { birth = value; }
            }
            public float Math
            {
                get { return math; }
                set { math = value; }
            }
            public float Chinese
            {
                get { return chinese; }
                set { chinese = value; }
            }
            public float English
            {
                get { return english; }
                set { english = value; }
            }
            public string Remark
            {
                get { return remark; }
                set { remark = value; }
            }


        }

        #endregion


    }
}
