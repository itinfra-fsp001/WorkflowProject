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
    
    public partial class SP_GetDocumentWorkflowByWorkflowID_Result
    {
        public long WorkFlowID { get; set; }
        public Nullable<long> DocID { get; set; }
        public string ApprovalLevel { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string Status { get; set; }
        public Nullable<int> AlternateApprover { get; set; }
        public Nullable<System.DateTime> Submitdate { get; set; }
        public string Approver { get; set; }
        public string ReportTo { get; set; }
        public string ApproveBy { get; set; }
        public Nullable<System.DateTime> ApproveDate { get; set; }
        public string RejectBy { get; set; }
        public Nullable<System.DateTime> RejectDate { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<bool> IsVerifier { get; set; }
    }
}
