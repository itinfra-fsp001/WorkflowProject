//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_RequestForQuotation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_RequestForQuotation()
        {
            this.tbl_RFQAttachments = new HashSet<tbl_RFQAttachments>();
        }
    
        public long Id { get; set; }
        public string QuoteId { get; set; }
        public string PurchaseCategory { get; set; }
        public string PurchaseRemarks { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
        public string BuyerRemarks { get; set; }
        public string Status { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public string Type { get; set; }
        public string ProcessedBy { get; set; }
        public Nullable<int> RevisionNo { get; set; }
        public Nullable<int> Priority { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_RFQAttachments> tbl_RFQAttachments { get; set; }
    }
}
