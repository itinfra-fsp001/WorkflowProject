using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOL;
using System.Web.Mvc;

namespace WorkFlowUI.ViewModel
{
    public class CustomerMasterViewModel
    {
        public CustomerMasterViewModel()
        {
            organizationList = new List<SelectListItem>();
        }
        public List<SelectListItem> organizationList;
        public List<vw_ERP_tbl_Customeremail> custList { get; set; }
        public vw_ERP_tbl_Customeremail newCust { get; set; }
        public string searchCustomerName { get; set; }
        public string delCustomerCodeList { get; set; }         
        public string searchOrganization { get; set; }       
    }
}