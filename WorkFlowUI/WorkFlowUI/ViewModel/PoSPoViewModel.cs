using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFlowUI.ViewModel
{
    public class PoSPoViewModel
    {
        //public List<fsp_ReportPurchaseOrder_sg_Result> PO { get; set; }
        public List<tbl_Documents> Documents { get; set; }
        public List<vw_tbl_DocumentDetails> PO { get; set; }
        public List<vw_tbl_DocumentBudget> PObdgt { get; set; }
        
        public DocumentStatusViewModel DocStatusVm { get; set; }
    }
}