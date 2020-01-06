using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class DocumentBudgetBs
    {
        private DocumentBudgetdb objdb;

        public DocumentBudgetBs()
        {
            objdb = new DocumentBudgetdb();

        }

        public IEnumerable<vw_tbl_DocumentBudget> GetALL()
        {
            return objdb.GetALL();
        }

        //public IEnumerable<vw_tbl_DocumentBudget> GetDocumentBudget(int DocID)
        //{
        //    return objdb.GetALL().Where(x => x.DocID == DocID);
        //}

        public IEnumerable<vw_tbl_DocumentBudget> GetDocumentBudget(int DocID)
        {
            return objdb.GetDocumentBudget(DocID);
        }
    }
}
