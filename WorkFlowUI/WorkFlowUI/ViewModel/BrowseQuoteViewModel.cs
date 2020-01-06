using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOL;

namespace WorkFlowUI.ViewModel
{
    public class BrowseQuoteViewModel
    {
        public List<tbl_RequestForQuotation> rfqMain { get; set; }
        public List<tbl_RFQAttachments> rfqPurchaseAttachments { get; set; }
        public List<tbl_RFQAttachments> rfqBuyerAttachments { get; set; }
    }
}