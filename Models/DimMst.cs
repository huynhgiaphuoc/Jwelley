//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Jewelly.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DimMst
    {
        public int DimMst_ID { get; set; }
        public decimal Dim_Crt { get; set; }
        public decimal Dim_Pcs { get; set; }
        public decimal Dim_Gm { get; set; }
        public decimal Dim_Size { get; set; }
        public decimal Dim_Rate { get; set; }
        public decimal Dim_Amt { get; set; }
        public Nullable<int> Style_Code { get; set; }
        public Nullable<int> DimQlty_ID { get; set; }
        public Nullable<int> DimSubType_ID { get; set; }
    
        public virtual DimQltyMst DimQltyMst { get; set; }
        public virtual ItemMst ItemMst { get; set; }
        public virtual DimQltySubMst DimQltySubMst { get; set; }
    }
}
