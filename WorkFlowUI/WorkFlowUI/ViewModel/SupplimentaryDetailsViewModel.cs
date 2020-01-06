using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.ViewModel
{
    public class SupplimentaryDetailsViewModel
    {
        public SupplimentaryDetailsViewModel()
        {
            // Your code here 
        }
        private List<SelectListItem> _dtlObjectNo;

        public List<SelectListItem> DtlObjectNo
        {
            get { return _dtlObjectNo; }
            set { _dtlObjectNo = value; }
        }
        private List<SelectListItem> _gLAccount;

        public List<SelectListItem>  GLAccounts
        {
            get { return _gLAccount; }
            set { _gLAccount = value; }
        }
        private tbl_SupBudgetDetail _supDetail;

        public IEnumerable<tbl_SupBudgetDetail> SupDetails { get; set; }
        public tbl_SupBudgetDetail SupDetail
        {
            get { return _supDetail; }
            set { _supDetail = value; }
        }
        public tbl_SupBudgetHeader SupHeader { get; set; }
        public DocumentStatusViewModel DocStatusVm { get; set; }

        public string costCentre { get; set; }

    }
}