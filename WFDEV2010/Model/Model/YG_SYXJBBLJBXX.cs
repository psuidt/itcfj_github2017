//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class YG_SYXJBBLJBXX
    {
        public YG_SYXJBBLJBXX()
        {
            this.YG_SYXJBBLXX = new HashSet<YG_SYXJBBLXX>();
            this.YG_SYXJBYB = new HashSet<YG_SYXJBYB>();
        }
    
        public decimal XH { get; set; }
        public Nullable<decimal> PATID { get; set; }
        public Nullable<decimal> SYXH { get; set; }
        public Nullable<decimal> YEXH { get; set; }
        public Nullable<int> XTLB { get; set; }
        public string ZYHM { get; set; }
        public string ZDDM { get; set; }
        public string HZXM { get; set; }
        public Nullable<int> SFZY { get; set; }
        public string SEX { get; set; }
        public string SFZH { get; set; }
        public string JHRXM { get; set; }
        public string BIRTH { get; set; }
        public string AGE { get; set; }
        public string HZDWMC { get; set; }
        public string HZLXDH { get; set; }
        public Nullable<int> BLSYCODE { get; set; }
        public string BLSYNAME { get; set; }
        public string XZZSHENDM { get; set; }
        public string XZZSHENMC { get; set; }
        public string XZZSHIDM { get; set; }
        public string XZZSHIMC { get; set; }
        public string XZZXJSDM { get; set; }
        public string XZZXJSMC { get; set; }
        public string XZZXZDM { get; set; }
        public string XZZXZMC { get; set; }
        public string XZZCDM { get; set; }
        public string XZZCMC { get; set; }
        public string XZZMPHMC { get; set; }
        public Nullable<int> ZYDM { get; set; }
        public string ZYQTNR { get; set; }
        public string HZKSDM { get; set; }
        public string HZKSMC { get; set; }
        public string HZBQDM { get; set; }
        public string HZBQMC { get; set; }
        public string ZDMC { get; set; }
        public string JWBS { get; set; }
        public Nullable<int> SFSYKSS { get; set; }
        public Nullable<int> SFJS { get; set; }
        public Nullable<int> SFCJBB { get; set; }
        public string FBRQ { get; set; }
        public string JZRQ { get; set; }
        public string SWRQ { get; set; }
        public string ZZTZCODE { get; set; }
        public string ZZTZMC { get; set; }
        public Nullable<decimal> ZZTZFS { get; set; }
        public string ZZTZQTNR { get; set; }
        public string XHXTCODE { get; set; }
        public string XHXTMC { get; set; }
        public Nullable<int> XHXTOTTC { get; set; }
        public Nullable<int> XHXTFXTC { get; set; }
        public string XHXTQTNR { get; set; }
        public string XHXTXZCODE { get; set; }
        public string XHXTXZMCE { get; set; }
        public string HXXTCODE { get; set; }
        public string HXXTMC { get; set; }
        public string HXXTQTNR { get; set; }
        public string XXGXTCODE { get; set; }
        public string XXGXTMC { get; set; }
        public string XXGXTQTNR { get; set; }
        public string MNXTCODE { get; set; }
        public string MNXTMC { get; set; }
        public string MNXTQTNR { get; set; }
        public string SJXTCODE { get; set; }
        public string SJXTMC { get; set; }
        public string SJXTQTNR { get; set; }
        public string PFPZXTCODE { get; set; }
        public string PFPZXTMC { get; set; }
        public string PFPZXTQTNR { get; set; }
        public string FJURL { get; set; }
        public string YYMC { get; set; }
        public string SBYSDM { get; set; }
        public string SBYSNC { get; set; }
        public string SBKSDM { get; set; }
        public string SBKSMC { get; set; }
        public string SBBQDM { get; set; }
        public string SBBQMC { get; set; }
        public string SBRQ { get; set; }
        public string LRRQ { get; set; }
        public Nullable<int> SHBZ { get; set; }
        public string SHWTGYY { get; set; }
    
        public virtual YG_SYXJBBLJBXX YG_SYXJBBLJBXX1 { get; set; }
        public virtual YG_SYXJBBLJBXX YG_SYXJBBLJBXX2 { get; set; }
        public virtual ICollection<YG_SYXJBBLXX> YG_SYXJBBLXX { get; set; }
        public virtual ICollection<YG_SYXJBYB> YG_SYXJBYB { get; set; }
    }
}
