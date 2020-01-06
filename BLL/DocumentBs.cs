using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.MailService;
namespace BLL
{
    public class DocumentBs
    {
        private Documentdb objdb;
        public DocumentBs()
        {
            objdb = new Documentdb();

        }

        public IEnumerable<tbl_Documents> GetALL()
        {
            return objdb.GetALL();
        }

        public IEnumerable<tbl_Documents> GetALLPR(string status, string docno, string vendorname)
        {
            return objdb.GetALLPR(status, docno, vendorname);
        }

        public IEnumerable<tbl_Documents> GetSubmittedDocuments(string userId, string status, string docNo)
        {
            return objdb.GetSubmittedDocuments(userId, status, docNo);
        }
        public tbl_Documents GetbyID(int Id)
        {
            return objdb.GetByID(Id);
        }

        public tbl_Documents GetByIDWithoutTracking(int DocID)
        {
            return objdb.GetByIDWithoutTracking(DocID);
        }

        public IEnumerable<tbl_Documents> GetbyIDNew(int Id)
        {
            return objdb.GetByIDNew(Id);
        }
        public void Insert(tbl_Documents Document)
        {
            objdb.Insert(Document);
        }
        public IEnumerable<tbl_Documents> GetChildDocuments(int DocID)
        {
            return objdb.GetChildDocuments(DocID);
        }
        public void Delete(int Id)
        {
            objdb.Delete(Id);
        }

        public void Update(tbl_Documents Document)
        {
            objdb.Update(Document);
        }
        //public void UpdateWithDetach(tbl_Documents Document)
        //{
        //    objdb.UpdateWithDetach(Document);
        //}

        public IEnumerable<vw_Documents4Approval> getDocuments(string userId, string status, string docNo, string mdRole, string vendorName)
        {
            return objdb.getDocuments(userId, status, docNo, mdRole, vendorName);
        }


        public IEnumerable<vw_Documents4AlternateApproval> getAlternateDocuments(string userId, string status, string docNo, string mdRole, string vendorName)
        {
            return objdb.geAlternatetDocuments(userId, status, docNo, mdRole, vendorName);
        }

        public rfqSPResult validatePR(string docIDList)
        {
            return objdb.validatePR(docIDList);
        }

        public rfqSPResult mergePR(string docIDList, string userId)
        {
            return objdb.mergePR(docIDList, userId);
        }

        public rfqSPResult updateSummaryDoc(int docId, string status, string userId)
        {
            return objdb.updateSummaryDoc(docId, status, userId);
        }

        public rfqSPResult validateDocument(string docIdList)
        {
            return objdb.validateDocument(docIdList);
        }

        public IEnumerable<tbl_Documents> ViewDocuments(string userId, string searchText)
        {
            return objdb.ViewDocuments(userId,searchText);
        }
    }
}
