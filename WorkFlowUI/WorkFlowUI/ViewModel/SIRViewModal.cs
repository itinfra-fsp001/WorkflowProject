using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOL;
using System.IO;
using System.Web.Mvc;

namespace WorkFlowUI.ViewModel
{
    public class SIRViewModal
    {
        private List<SelectListItem> _periodList;
        private List<SelectListItem> _statusList;
        private List<SelectListItem> _salesGroupList;
        public SIRViewModal()
        {
            _periodList = new List<SelectListItem>();
            _statusList = new List<SelectListItem>();
            _salesGroupList = new List<SelectListItem>();
        }

        public List<SelectListItem> periodList { get { return _periodList; } set { _periodList = value; } }
        public List<SelectListItem> statusList { get { return _statusList; } set { _statusList = value; } }

        public List<SelectListItem> salesGroupList { get { return _salesGroupList; } set { _salesGroupList = value; } }

        public tbl_SIRDocuments sirDoc { get; set; }

        public List<vw_ERP_FujitecActiveContrItem> activeContract { get; set; }

        public string customerNo { get; set; }
        public string customerName { get; set; }

        public string site { get; set; }
        public string sirStatus { get; set; }

        public string soldCustomerName { get; set; }

        public string period { get; set; }
        public string salesgroup { get; set; }

        public List<string> jobSheet { get; set; }

        public string driveLocation { get; set; }

        public List<tbl_SIRDocuments> sirList { get; set; }

        public string lastConsolidationOn { get; set; }

        public string sirSelectedList { get; set; }

        public bool isServiceAdmin { get; set; }
    }
}