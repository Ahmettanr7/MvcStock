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
    
    public partial class TBLCUSTOMERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLCUSTOMERS()
        {
            this.TBLSALES = new HashSet<TBLSALES>();
        }
    
        public int CUSTOMERID { get; set; }
        public string CUSTOMERFİRSTNAME { get; set; }
        public string CUSTOMERLASTNAME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLSALES> TBLSALES { get; set; }
    }
}
