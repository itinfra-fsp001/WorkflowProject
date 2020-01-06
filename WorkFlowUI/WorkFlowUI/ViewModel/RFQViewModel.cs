using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOL;
using System.Web.Mvc;
using System.ComponentModel;

namespace WorkFlowUI.ViewModel
{
    public class RFQViewModel
    {
        private List<SelectListItem> purchaseCategory;
        public RFQViewModel()
        {
            purchaseCategory = new List<SelectListItem>();
        }
        public string requiredDate { get; set; }        
        public string requiredMinDate { get; set; }
        public string quoteId { get; set; }
        public string quoteNo { get; set; }
        public string userId { get; set; }
        public string purchaseRemarks { get; set; }
        public string purchaseCategoryNew { get; set; }
        public string status { get; set; }
        public string attachmentList { get; set; }
        public List<SelectListItem> purchaseCategoryMain { get { return purchaseCategory; } set { purchaseCategory = value; } }
        public List<tbl_RequestForQuotation> rfqMain { get; set; }
        public List<tbl_RFQAttachments> rfqPurchaseAttachments { get; set; }
        public List<tbl_RFQAttachments> rfqBuyerAttachments { get; set; }
        public string deleteAttachmentIdList { get; set; }
        public string deleteAttachmentFileList { get; set; }
        public string buyerRemarks { get; set; }
        public string quoteType { get; set; }
        public string processedBy { get; set; }
        public int revisionNo { get; set; }
        public int priority { get; set; }
    }    
}