//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAn_CNPM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailForm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DetailForm()
        {
            this.DiseaseStatisticLists = new HashSet<DiseaseStatisticList>();
        }
    
        public int IdDetailForm { get; set; }
        public int Quantity { get; set; }
        public int IdForm { get; set; }
        public int IdPriceList { get; set; }
        public Nullable<bool> IsPay { get; set; }
    
        public virtual Form Form { get; set; }
        public virtual PriceList PriceList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiseaseStatisticList> DiseaseStatisticLists { get; set; }
    }
}
