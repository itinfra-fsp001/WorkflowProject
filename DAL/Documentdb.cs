using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Documentdb
    {

        private WorkFlowDBEntities db;

        public Documentdb()
        {
            db = new WorkFlowDBEntities();

        }
        public IEnumerable<tbl_Documents> GetALL()
        {
            return db.tbl_Documents.AsNoTracking().ToList();
        }

        public IEnumerable<tbl_Documents> GetSubmittedDocuments(string userId, string status, string docNo)
        {
            return db.SP_GetSubmittedDocuments(userId, status, docNo, MergeOption.NoTracking).ToList();
        }
        public IEnumerable<tbl_Documents> GetALLPR(string status, string docno, string vendorname)
        {
            return db.SP_GetApprovedPR(status, docno, vendorname, MergeOption.NoTracking).ToList();
        }

        public tbl_Documents GetByIDWithoutTracking(int DocID)
        {
            return db.SP_GetDocumentByID(DocID).ToList()[0];
        }

        public tbl_Documents GetByID(int DocID)
        {
            return db.SP_GetDocumentByID(DocID, MergeOption.NoTracking).ToList()[0];
        }

        public IEnumerable<tbl_Documents> GetByIDNew(int DocID)
        {
            return db.SP_GetDocumentByID(DocID, MergeOption.NoTracking).ToList();
        }

        public IEnumerable<tbl_Documents> GetChildDocuments(int DocID)
        {
            return db.SP_GetChildPR(DocID, MergeOption.NoTracking).ToList();
        }

        public void Insert(tbl_Documents Document)
        {
            db.tbl_Documents.Add(Document);
            Save();
        }

        public void Delete(int DocID)
        {
            //tbl_Documents document = db.tbl_Documents.Find(DocID);
            tbl_Documents document = GetByID(DocID);
            db.tbl_Documents.Remove(document);
            Save();
        }

        public void Update(tbl_Documents Document)
        {           
            db.Configuration.ValidateOnSaveEnabled = false;
            db.Entry(Document).State = EntityState.Modified;
            Document.UpdateDate = DateTime.Now;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public IEnumerable<vw_Documents4Approval> getDocuments(string userId, string status, string docNo, string mdRole, string vendorName)
        {
            return db.SP_GetDocuments(userId, status, docNo, mdRole, vendorName, MergeOption.NoTracking).ToList();
        }

        public IEnumerable<vw_Documents4AlternateApproval> geAlternatetDocuments(string userId, string status, string docNo, string mdRole, string vendorName)
        {
            return db.SP_GetAlternateDocuments(userId, status, docNo, mdRole, vendorName, MergeOption.NoTracking).ToList();
        }

        //public void UpdateWithDetach(tbl_Documents Document)
        //{
        //    db.Entry(Document).State = EntityState.Detached;
        //    db.Entry(Document).State = EntityState.Modified;
        //    db.Configuration.ValidateOnSaveEnabled = false;
        //    Save();
        //    db.Configuration.ValidateOnSaveEnabled = true;
        //}

        public void Save()
        {
            db.SaveChanges();
        }

        public rfqSPResult updateSummaryDoc(int docId,string status, string userId)
        {
            rfqSPResult isRet = new rfqSPResult();
            var opSPResult = new ObjectParameter("Result", typeof(bool));
            var spres = db.SP_UpdateSummaryDoc(docId, status, userId, opSPResult);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            return isRet;
        }

        public rfqSPResult validatePR(string docIDList)
        {
            rfqSPResult isRet = new rfqSPResult();
            var opSPResult = new ObjectParameter("Result", typeof(bool));
            var opSPMessage = new ObjectParameter("Message", typeof(string));
            var spResponse = db.SP_ValidateMergePR(docIDList, opSPResult, opSPMessage);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.name = Convert.ToString(opSPMessage.Value);
            return isRet;
        }

        public rfqSPResult mergePR(string docIDList, string userId)
        {
            rfqSPResult isRet = new rfqSPResult();
            var opSPResult = new ObjectParameter("Result", typeof(bool));
            var opSPMessage = new ObjectParameter("Message", typeof(string));
            var spResponse = db.SP_MergePR(docIDList, opSPResult, opSPMessage, userId);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.name = Convert.ToString(opSPMessage.Value);
            return isRet;
        }
        public rfqSPResult validateDocument(string docIdList)
        {
            rfqSPResult isRet = new rfqSPResult();
            var opSPResult = new ObjectParameter("Result", typeof(bool));
            var opSPMessage = new ObjectParameter("Message", typeof(string));
            var spResponse = db.SP_ValidateDocument(docIdList, opSPResult, opSPMessage);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.name = Convert.ToString(opSPMessage.Value);
            return isRet;
        }

        public IEnumerable<tbl_Documents> ViewDocuments(string userId, string searchText)
        {
            return db.SP_ViewDocuments(userId, searchText, MergeOption.NoTracking).ToList();
        }
    }
}
