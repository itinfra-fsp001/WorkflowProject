using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.ViewModel
{

    public class EInvoiceViewModal
    {
        private List<SelectListItem> _invoiceType;
        private List<SelectListItem> _organization;
        private List<SelectListItem> _period;
        public EInvoiceViewModal()
        {
            _invoiceType = new List<SelectListItem>();
            _organization = new List<SelectListItem>();
            _period = new List<SelectListItem>();
        }
        public List<SelectListItem> invoiceType { get { return _invoiceType; } set { _invoiceType = value; } }
        public List<SelectListItem> organization { get { return _organization; } set { _organization = value; } }
        public List<SelectListItem> period { get { return _period; } set { _period = value; } }

        public List<vw_ERP_ServiceTaxInvoice> invoiceList { get; set; }

        public string customerName { get; set; }

        public string organizationName { get; set; }

        public string periodName { get; set; }
        public string invoiceTypeName { get; set; }

        public string invoiceSelectedList { get; set; }
    }
}