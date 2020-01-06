using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.ViewModel
{
    public class LeaveViewModel
    {
        public tbl_LeaveDetails Leave { get; set; }
        public List<SelectListItem> Users { get; set; }
    }
}