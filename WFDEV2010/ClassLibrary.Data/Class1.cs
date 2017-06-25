using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public static class DataSource
    {

        public static DataTable GetData()
        {
            DataTable dt = new DataTable("个人简历");
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("sex", typeof(int));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("aihao", typeof(string));
            dt.Columns.Add("photo", typeof(string));
            //格式增加    
            dt.Columns.Add("数据", typeof(decimal));
            dt.Columns.Add("时间", typeof(DateTime));
            dt.Columns.Add("自定义", typeof(string));
            dt.Rows.Add(new object[] { 1, "张三", 1,"东大街6号","看书","",-52.874,"2011-8-5 17:52:55","###" });   
            dt.Rows.Add(new object[] { 2, "王五", 0,"西大街2号","上网,游戏","", -37.257,"2011-8-5 17:52:55" });  
            dt.Rows.Add(new object[] { 3, "李四", 1,"南大街3号","上网,逛街","", -54.254,"2011-8-9 17:52:55" });   
            dt.Rows.Add(new object[] { 4, "钱八", 0,"北大街5号","上网,逛街,看书,游戏","",-35.127,"2011-8-9 17:52:55" });  
            dt.Rows.Add(new object[] { 1,"赵九", 1,"中大街1号","看书,逛街,游戏","",-29.548,"2011-8-9 20:52:55" });  
            return dt;
        }
    }
}
