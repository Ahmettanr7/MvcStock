//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStock.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLSALES
    {
        public int SALEID { get; set; }
        public Nullable<int> PRODUCTID { get; set; }
        public Nullable<int> CUSTOMERID { get; set; }
        public Nullable<int> AMOUNT { get; set; }
        public Nullable<decimal> PRİCE { get; set; }
    
        public virtual TBLCUSTOMERS TBLCUSTOMERS { get; set; }
        public virtual TBLPRODUCTS TBLPRODUCTS { get; set; }
    }
}