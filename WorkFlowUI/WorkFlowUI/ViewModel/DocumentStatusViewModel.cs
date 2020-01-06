using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkFlowUI.ViewModel
{
    public class DocumentStatusViewModel
    {
        public long workFlowId { get; set; }

        public List<DocStatus> DocStatus { get; set; }
        public string docNo { get; set; }
        public string txtComment { get; set; }

        public bool isVerifier { get; set; }
       // public tbl_DocumentWorkFlow workFlow { get; set; }

    }
}