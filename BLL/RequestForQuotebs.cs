using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;
using System.Data.Entity.Core.Objects;

namespace BLL
{
    public class RequestForQuotebs
    {
        private RequestForQuotedb db;
        public RequestForQuotebs()
        {
            db = new RequestForQuotedb();
        }

        public IEnumerable<tbl_PurchaseCategory> GetPurchaseCategory()
        {
            return db.GetPurchaseCategory();
        }

        public rfqSPResult createQuote(string userId, string purchaseCategory, string purchaseRemarks, string status, string attachmentList, string quoteNo, string delAttachmentList, DateTime requiredDate, string quoteType, int priority)
        {
            return db.createQuote(userId, purchaseCategory, purchaseRemarks, status, attachmentList, quoteNo, delAttachmentList, requiredDate, quoteType, priority);
        }

        public IEnumerable<tbl_RequestForQuotation> getQuotes(string userId, string status, string searchString, string filterType)
        {
            return db.getQuotes(userId, status, searchString, filterType).ToList();
        }

        public List<tbl_RFQAttachments> getQuoteAttachments(string userId, string status, string quoteId, string category)
        {
            return db.getQuoteAttachments(userId, status, quoteId, category).ToList();
        }
        public List<rfqCustomAttachments> getQuoteAttachmentsNew(string userId, string status, string quoteId, string category)
        {
            IEnumerable<tbl_RFQAttachments> isget = db.getQuoteAttachments(userId, status, quoteId, category).ToList();
            List<rfqCustomAttachments> isRet = new List<rfqCustomAttachments>();
            rfqCustomAttachments isCur;
            foreach (tbl_RFQAttachments item in isget)
            {
                isCur = new rfqCustomAttachments();
                isCur.id = Convert.ToInt32(item.Id);
                isCur.category = item.AttachmentType;
                isCur.filepath = item.FilePath;
                isRet.Add(isCur);
            }
            return isRet;
        }
        public string cancelQuote(string quoteList, string userId, string mode, string remarks, string attachmentList, string deleteAttachmentList)
        {
            return db.cancelQuote(quoteList, userId, mode, remarks, attachmentList, deleteAttachmentList);
        }
        public rfqSPResult finaliseQuote(string buyerRemarks, string userId, string attachmentList, string quoteNo, string deleteAttachmentList, string status)
        {
            return db.finaliseQuote(buyerRemarks, userId, attachmentList, quoteNo, deleteAttachmentList, status);
        }
        public bool isPCVUser(string userId)
        {
            return db.isPCVUser(userId);
        }

        public bool isPCVUser2(string userId)
        {
            return db.isPCVUser2(userId);
        }
        public rfqSPResult getQuoteEmailIds(string quoteNo)
        {
            return db.getQuoteEmailIds(quoteNo);
        }

        public bool isQuoteSuperUser(string userId, string quoteId)
        {
            return db.isQuoteSuperUser(userId, quoteId);
        }

        public bool isCurrentApproverIsVerifier(string workflowId)
        {
            return db.isCurrentApproverIsVerifier(workflowId);
        }

        public rfqSPResult updateQuoteByBuyer(string buyerRemarks, string userId, string attachmentList, string quoteNo, string deleteAttachmentList)
        {
            return db.updateQuoteByBuyer(buyerRemarks, userId, attachmentList, quoteNo, deleteAttachmentList);
        }

        public rfqSPResult reviseQuote(string userId, string quoteNo)
        {
            return db.reviseQuote(userId, quoteNo);
        }

        public void get_TestCustomResult()
        {
            List<SP_TestCustomNew_Result1> isget = db.SP_TestCustom();
            //isget[0].

        }

        public List<tbl_RequestForQuotation> getAllRFQ()
        {
            return db.getAllRFQ();
        }

        public spResult checkRFQStatus(string rfqno)
        {
            return db.checkRFQStatus(rfqno);
        }

        public List<tbl_RFQAttachments> getRFQAttachmentsForDoc(string attachmentList)
        {
            return db.getRFQAttachmentsForDoc(attachmentList);
        }

        public rfqSPResult getRFQAttachmentCount(string rfqNo)
        {
            return db.getRFQAttachmentCount(rfqNo);
        }
    }
}
