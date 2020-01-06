using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class Document4AltrApprovaldb
    {
        private WorkFlowDBEntities db;

        public Document4AltrApprovaldb()
        {
            db = new WorkFlowDBEntities();

        }

        //public IEnumerable<vw_Documents4AlternateApproval> GetALL()
        //{
        //    //  return new List<vw_Documents4Approval>();
        //    return db.vw_Documents4AlternateApproval.ToList();
        //}

        //public IEnumerable<vw_Documents4AlternateApproval> GetDocuemtWorkFlow(int DocID)
        //{
        //    return db.vw_Documents4AlternateApproval.ToList().Where(x => x.DocID == DocID);
        //}

        //public vw_Documents4AlternateApproval GetByID(int WorkFlowID)
        //{
        //    return db.vw_Documents4AlternateApproval.Find(WorkFlowID);
        //}
    }
}
