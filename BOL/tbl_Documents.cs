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
    
    public partial class tbl_Documents
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Documents()
        {
            this.tbl_DocumentWorkFlow = new HashSet<tbl_DocumentWorkFlow>();
            this.tbl_DocMergeHeader = new HashSet<tbl_DocMergeHeader>();
            this.tbl_DocMergeDetails = new HashSet<tbl_DocMergeDetails>();
        }
    
        public long DocID { get; set; }
        public string DocType { get; set; }
        public string DocNo { get; set; }
        public Nullable<decimal> NetPrice { get; set; }
        public string Currency { get; set; }
        public string SubmitBy { get; set; }
        public Nullable<System.DateTime> SubmitDate { get; set; }
        public Nullable<System.DateTime> ApprovalSubmitDate { get; set; }
        public string ApprovalSubmitBy { get; set; }
        public string Status { get; set; }
        public string AttachDoc { get; set; }
        public string AddAttachDoc1 { get; set; }
        public string AddAttachDoc2 { get; set; }
        public string AddAttachDoc3 { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string VendorCategory { get; set; }
        public string IssueBy { get; set; }
        public Nullable<decimal> DocNetPrice { get; set; }
        public string PRNumbers { get; set; }
        public Nullable<decimal> PRAmount { get; set; }
        public Nullable<short> PriorityCode { get; set; }
        public bool ERPAttachment { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string RFQRefNo { get; set; }
        public string LastApprovalSubmitBy { get; set; }
        public Nullable<System.DateTime> LastApprovalSubmitDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<bool> IsMerged { get; set; }
        public Nullable<bool> IsSummaryDoc { get; set; }
        public string DocNoList { get; set; }
        public Nullable<bool> IsMultipleVendor { get; set; }
        public string VendorNameList { get; set; }
        public string Remarks { get; set; }
        public string DeptCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DocumentWorkFlow> tbl_DocumentWorkFlow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DocMergeHeader> tbl_DocMergeHeader { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_DocMergeDetails> tbl_DocMergeDetails { get; set; }
    }
}
