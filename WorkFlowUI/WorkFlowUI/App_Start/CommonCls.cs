using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorkFlowUI.ViewModel;

namespace WorkFlowUI.App_Start
{
    public class CommonCls
    {

        public static DocumentStatusViewModel GetDocStatus(long docId, string docNo, long workFlowId, int AppLevel)
        {
            DocumentStatusViewModel ds = new DocumentStatusViewModel();
            List<DocStatus> lt = new List<DocStatus>();
            long wfId = 0;
           CommonBs cmBs = new CommonBs();
            RequestForQuotebs commBs = new RequestForQuotebs();
            if (docId == 0)
            {
                docId = cmBs.GetDocIdByDocNo(docNo);
            }
            lt = cmBs.GetDocStatusByDocId(docId, workFlowId, ref wfId,AppLevel);
            //if (AppLevel == 2)
            //{
            //    if (lt.Count >= 2)
            //    {
            //         lt1= lt.Skip(2);
            //        ds.DocStatus = lt1;
            //    }
            //}
            ds.isVerifier = commBs.isCurrentApproverIsVerifier(Convert.ToString(workFlowId));
            ds.DocStatus = lt;
            ds.workFlowId = wfId;
            if (lt.Exists(p => p.Status == "Rejected"))
                ds.txtComment = lt.Find(p => p.Status == "Rejected").Remarks;
            ds.docNo = docNo;
            return ds;
        }
    }
}