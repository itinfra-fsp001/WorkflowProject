using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOL;
using System.Web.Mvc;

namespace WorkFlowUI.ViewModel
{
    public class SendEInvoiceModel
    {
        public string logId { get; set; }
        [AllowHtml]
        public string to { get; set; }
        [AllowHtml]
        public string cc { get; set; }
        public string subject { get; set; }
        [AllowHtml]
        public string body { get; set; }        
        public string attachmentFolderLocation { get; set; }
        public List<vw_ERP_ServiceTaxInvoice> invoice { get; set; }

        public string mailSendBy { get; set; }

        public string maxAttachmentLimitInBytes { get; set; }

        public string invoiceFileSize { get; set; }

    }
}