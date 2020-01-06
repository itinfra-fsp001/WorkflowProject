using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOL;
namespace WorkFlowUI.ViewModel
{
    public class MiscPrCoaViewModel
    {
        //public List<fsp_ReportMiscPurchaseRequisition_Result> MiscPRBudet { get; set; }
        public List<tbl_Documents> Documents { get; set; }
        public List<vw_tbl_DocumentDetails> MiscPRBudet { get; set; }
        //public List<fsp_GetCOABudgetSummary_Result> CoaBudget { get; set; }
        public List<vw_tbl_DocumentBudget> CoaBudget { get; set; }
        public DocumentStatusViewModel DocStatusVm { get; set; }
        public List<tbl_Documents> ChildDocuments { get; set; }
    }
}