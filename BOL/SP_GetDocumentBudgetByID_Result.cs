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
    
    public partial class SP_GetDocumentBudgetByID_Result
    {
        public long DocID { get; set; }
        public int SequenceNo { get; set; }
        public string Object { get; set; }
        public string ObjectNo { get; set; }
        public string ObjectName { get; set; }
        public string AccountNo { get; set; }
        public Nullable<decimal> OrginalBudget { get; set; }
        public Nullable<decimal> CommitBudget { get; set; }
        public Nullable<decimal> ActualBudget { get; set; }
        public Nullable<decimal> SuppBudget { get; set; }
        public Nullable<decimal> BalBudget { get; set; }
        public Nullable<decimal> ThisExp { get; set; }
    }
}
