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
    
    public partial class SP_GetMergeDocDetails_Result
    {
        public long ID { get; set; }
        public string MergeDocNo { get; set; }
        public Nullable<long> DocId { get; set; }
        public string DocNo { get; set; }
        public string Status { get; set; }
        public Nullable<long> SumDocId { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
