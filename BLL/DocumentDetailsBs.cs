using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class DocumentDetailsBs
    {

        private DocumentDetailsdb objdb;

        public DocumentDetailsBs()
        {
            objdb = new DocumentDetailsdb();

        }

        public IEnumerable<vw_tbl_DocumentDetails> GetALL()
        {
            return objdb.GetALL();
        }

        //public IEnumerable<vw_tbl_DocumentDetails> GetDocuemtDetails(int DocID)
        //{
        //    return objdb.GetALL().Where(x => x.DocID == DocID);
        //}

        public IEnumerable<vw_tbl_DocumentDetails> GetDocuemtDetails(int DocID)
        {
            //return objdb.GetALL().Where(x => x.DocID == DocID);
            return objdb.GetDocumentDetailsByID(DocID);
        }

    }
}
