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
    
    public partial class tbl_RFQAttachments
    {
        public long Id { get; set; }
        public Nullable<long> QuoteId { get; set; }
        public string AttachmentType { get; set; }
        public string FilePath { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public System.DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> RevisionNo { get; set; }
    
        public virtual tbl_RequestForQuotation tbl_RequestForQuotation { get; set; }
    }
}
