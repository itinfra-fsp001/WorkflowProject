using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
  public class DocumentBudgetdb
    {
        private WorkFlowDBEntities db;

        public DocumentBudgetdb()
        {
            db = new WorkFlowDBEntities();

        }

        public IEnumerable<vw_tbl_DocumentBudget> GetALL()
        {
            //  return new List<vw_Documents4Approval>();
            return db.vw_tbl_DocumentBudget.AsNoTracking().ToList();
        }

        //public IEnumerable<vw_tbl_DocumentBudget> GetDocumentBudget(int DocID)
        //{
        //    return db.vw_tbl_DocumentBudget.ToList().Where(x => x.DocID == DocID);
        //}

        public IEnumerable<vw_tbl_DocumentBudget> GetDocumentBudget(int DocID)
        {
            return db.SP_GetDocumentBudgetByID(DocID, MergeOption.NoTracking).ToList();
        }
    }
}
