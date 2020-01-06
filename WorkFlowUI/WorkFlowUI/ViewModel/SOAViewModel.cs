using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.ViewModel
{
    public class SOAViewModel
    {
        private List<SelectListItem> _organizationList;
        private List<SelectListItem> _parentOrganizationList;
        private List<SelectListItem> _customerTypeList;
        private List<SelectListItem> _periodList;
        public SOAViewModel()
        {
            _organizationList = new List<SelectListItem>();
            _parentOrganizationList = new List<SelectListItem>();
            _customerTypeList = new List<SelectListItem>();
            _periodList = new List<SelectListItem>();
        }

        public List<SelectListItem> organizationList { get { return _organizationList; } set { _organizationList = value; } }
        public List<SelectListItem> parentOrganizationList { get { return _parentOrganizationList; } set { _parentOrganizationList = value; } }
        public List<SelectListItem> customerTypeList { get { return _customerTypeList; } set { _customerTypeList = value; } }
        public List<SelectListItem> periodList { get { return _periodList; } set { _periodList = value; } }

        public List<vw_ERP_ServiceSOA> soaList { get; set; }
        public string organization { get; set; }
        public string parentOrganization { get; set; }
        public string customerType { get; set; }

        public string period { get; set; }

        public string customerName { get; set; }
        public string driveLocation { get; set; }
        public string soaSelectedList { get; set; }

    }
}