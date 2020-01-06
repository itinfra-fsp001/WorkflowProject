using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class Document4Approvaldb
    {

        private WorkFlowDBEntities db;

        public Document4Approvaldb()
        {
            db = new WorkFlowDBEntities();

        }

        //public IEnumerable<vw_Documents4Approval> GetALL()
        //{
        //  //  return new List<vw_Documents4Approval>();
        //    return db.vw_Documents4Approval.ToList();
        //}

        //public IEnumerable<vw_Documents4Approval> GetDocuemtWorkFlow(int DocID)
        //{
        //    return db.vw_Documents4Approval.ToList().Where(x => x.DocID == DocID);
        //}

        //public vw_Documents4Approval GetByID(int WorkFlowID)
        //{
        //    return db.vw_Documents4Approval.Find(WorkFlowID);
        //}


    }
}
