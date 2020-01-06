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
    
    public partial class fsp_ReportSubconPO_CumulativeDetails_Result
    {
        public string PurchaseOrderNo { get; set; }
        public int SequenceNo { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string CostEntityName { get; set; }
        public string CostEntityKeyName { get; set; }
        public string ChartOfAccountSetDetailDescription { get; set; }
        public string ChartOfAccountSetDetailValueCode { get; set; }
        public Nullable<float> OrderQuantity { get; set; }
        public string UnitOfMeasureName { get; set; }
        public Nullable<float> Price { get; set; }
        public string CurrencyName { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<double> TotalAmountLocal { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
        public Nullable<System.DateTime> RequiredOn { get; set; }
        public string PurchaseRequisitionNo { get; set; }
        public Nullable<double> ExchangeRate { get; set; }
        public string AddedByUser { get; set; }
        public int PurchaseOrderDetailID_NonInv { get; set; }
        public int PurchaseOrder_NonInvID { get; set; }
        public Nullable<bool> IsApproved { get; set; }
        public bool IsInvoiced { get; set; }
        public Nullable<int> SourceEntityID { get; set; }
        public string SourceEntityKey { get; set; }
        public string SourceEntityKeyName { get; set; }
        public double ExtendedPrice { get; set; }
        public string ChartOfAccountSetDetailValue { get; set; }
        public Nullable<int> UnitOfMeasureID { get; set; }
        public string StatusEntityName { get; set; }
        public string CostCentre { get; set; }
        public string CostCentreDescription { get; set; }
        public System.DateTime PODate { get; set; }
        public Nullable<int> RootSourceEntityID { get; set; }
        public Nullable<int> RootSourceEntityKey { get; set; }
        public string RootSourceEntityDetailKey { get; set; }
        public string PODetailDescription { get; set; }
        public string StatusName { get; set; }
        public Nullable<int> VendorId { get; set; }
        public string OrganizationName { get; set; }
        public string BuyerCode { get; set; }
        public string BuyerName { get; set; }
    }
}
