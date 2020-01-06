using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class DocumentDetailsdb
    {
        private WorkFlowDBEntities db;

        public DocumentDetailsdb()
        {
            db = new WorkFlowDBEntities();

        }

        public IEnumerable<vw_tbl_DocumentDetails> GetALL()
        {
            //  return new List<vw_Documents4Approval>();
            return db.vw_tbl_DocumentDetails.AsNoTracking().ToList();
        }

        public IEnumerable<vw_tbl_DocumentDetails> GetDocuemtDetails(int DocID)
        {
            return db.vw_tbl_DocumentDetails.AsNoTracking().ToList().Where(x => x.DocID == DocID);
        }

        public IEnumerable<vw_tbl_DocumentDetails> GetDocumentDetailsByID(int docId)
        {
            //  return new List<vw_Documents4Approval>();
            return db.SP_GetDocumentDetailsByID(docId, MergeOption.NoTracking).ToList();
        }

    }
}
