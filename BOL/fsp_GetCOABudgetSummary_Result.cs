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
    
    public partial class fsp_GetCOABudgetSummary_Result
    {
        public Nullable<int> PurchaseRequisitionID { get; set; }
        public Nullable<int> ChartOfAccountSetDetailID { get; set; }
        public string ChartOfAccountSetDetailDescription { get; set; }
        public Nullable<int> COACostCentreID { get; set; }
        public string COACostCentreName { get; set; }
        public string COACostCentreCode { get; set; }
        public Nullable<double> COARequisitionAmount { get; set; }
        public double COAActualAmount { get; set; }
        public Nullable<double> SecondaryEntityBudgetApproved { get; set; }
        public int BudgetYear { get; set; }
        public Nullable<double> SupplementaryBudget1Approved { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public string ChartOfAccountSetDetailValueCode { get; set; }
        public Nullable<decimal> GrandTotalInLocalCurrency { get; set; }
        public double CommitPlusActual
        {
            get
            {

                return Math.Round(COAActualAmount + COARequisitionAmount.Value, 2);
            }
        }


        public double BalanceBudgetAmount
        {
            get
            {

                return Math.Round((SecondaryEntityBudgetApproved.Value + SupplementaryBudget1Approved.Value) - (COAActualAmount + COARequisitionAmount.Value), 2);
            }
        }
    }
}
