using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFlowUI.ViewModel
{
    public class DocStatusViewModal
    {
        public string searchText { get; set; }

        public List<tbl_Documents> docList { get; set; }
    }
}