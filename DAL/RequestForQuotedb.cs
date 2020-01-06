using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class RequestForQuotedb
    {

        private WorkFlowDBEntities db;

        public RequestForQuotedb()
        {
            db = new WorkFlowDBEntities();
        }

        public IEnumerable<tbl_PurchaseCategory> GetPurchaseCategory()
        {
            return db.tbl_PurchaseCategory.AsNoTracking().ToList();
        }

        public rfqSPResult createQuote(string userId, string purchaseCategory, string purchaseRemarks, string status, string attachmentList, string quoteNo, string delAttachmentList, DateTime requiredDate, string quoteType, int priority)
        {
            rfqSPResult isRet = new rfqSPResult();

            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var opBuyerName = new ObjectParameter("BuyerName", typeof(string));
            var opBuyerEmail = new ObjectParameter("BuyerEmail", typeof(string));
            var opRetQuoteNo = new ObjectParameter("RetQuoteNo", typeof(string));
            var opIsResubmitted = new ObjectParameter("IsResubmitted", typeof(bool));
            var spResult = db.SP_CreateQuote(userId, purchaseCategory, purchaseRemarks, status, attachmentList, quoteNo, delAttachmentList, opSPResult, opBuyerName, opBuyerEmail, opRetQuoteNo, requiredDate, quoteType, priority, opIsResubmitted);

            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.name = Convert.ToString(opBuyerName.Value);
            isRet.email = Convert.ToString(opBuyerEmail.Value);
            isRet.quoteNo = Convert.ToString(opRetQuoteNo.Value);
            isRet.isResubmitted = Convert.ToBoolean(opIsResubmitted.Value);
            return isRet;
        }

        public IEnumerable<tbl_RequestForQuotation> getQuotes(string userId, string status, string searchString, string filterType)
        {
            return db.SP_GetQuote(userId, status, searchString, filterType, MergeOption.NoTracking).ToList();
        }
        public IEnumerable<tbl_RFQAttachments> getQuoteAttachments(string userId, string status, string quoteId, string category)
        {
            return db.SP_GetQuoteAttachments(userId, status, quoteId, category, MergeOption.NoTracking).ToList();
        }

        public string cancelQuote(string quoteList, string userId, string mode, string remarks, string attachmentList, string deleteAttachmentList)
        {
            var outputParameter = new ObjectParameter("SPResult", typeof(string));
            db.SP_CancelQuote(quoteList, userId, mode, outputParameter, remarks, attachmentList, deleteAttachmentList);
            return Convert.ToString(outputParameter.Value);
        }

        public rfqSPResult finaliseQuote(string buyerRemarks, string userId, string attachmentList, string quoteNo, string deleteAttachmentList, string status)
        {
            rfqSPResult isRet = new rfqSPResult();

            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var opBuyerName = new ObjectParameter("SubmitterName", typeof(string));
            var opBuyerEmail = new ObjectParameter("SubmitterEmail", typeof(string));
            //var opRetQuoteNo = new ObjectParameter("RetQuoteNo", typeof(string));

            var spResult = db.SP_FinaliseQuote(quoteNo, buyerRemarks, attachmentList, userId, opBuyerEmail, opBuyerName, opSPResult, deleteAttachmentList, status);

            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.name = Convert.ToString(opBuyerName.Value);
            isRet.email = Convert.ToString(opBuyerEmail.Value);

            return isRet;
        }


        public rfqSPResult reviseQuote(string userId, string quoteNo)
        {
            rfqSPResult isRet = new rfqSPResult();
            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var opRevisionNo = new ObjectParameter("RevisionNo", typeof(int));
            var spResult = db.SP_ReviseQuote(quoteNo, userId, opSPResult, opRevisionNo);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.name = Convert.ToString(opRevisionNo.Value);
            return isRet;
        }

        public rfqSPResult updateQuoteByBuyer(string buyerRemarks, string userId, string attachmentList, string quoteNo, string deleteAttachmentList)
        {
            rfqSPResult isRet = new rfqSPResult();
            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var spResult = db.SP_UpdateQuoteByBuyer(quoteNo, buyerRemarks, attachmentList, userId, deleteAttachmentList, opSPResult);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            return isRet;
        }

        public bool isPCVUser(string userId)
        {
            bool isRet = false;
            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var spResult = db.SP_IsPCVUser(userId, opSPResult);
            isRet = Convert.ToBoolean(opSPResult.Value);
            return isRet;
        }

        public bool isPCVUser2(string userId)
        {
            bool isRet = false;

            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var spResult = db.SP_IsPCVUser2(userId, opSPResult);
            isRet = Convert.ToBoolean(opSPResult.Value);
            return isRet;
        }

        public rfqSPResult getQuoteEmailIds(string quoteNo)
        {
            rfqSPResult isRet = new rfqSPResult();

            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var opSubmitterName = new ObjectParameter("SubmitterName", typeof(string));
            var opSubmitterEmai = new ObjectParameter("SubmitterEmail", typeof(string));
            var opBuyerName = new ObjectParameter("BuyerName", typeof(string));
            var opBuyerEmail = new ObjectParameter("BuyerEmail", typeof(string));
            var opUpdatedBy = new ObjectParameter("UpdatedBy", typeof(string));
            var opUpdaterEmail = new ObjectParameter("UpdaterEmail", typeof(string));
            var opSubmitterManagerEmail = new ObjectParameter("SubmitterManagerEmail", typeof(string));
            var opBuyerManagerEmail = new ObjectParameter("BuyerManagerEmail", typeof(string));
            var opPriority = new ObjectParameter("Priority", typeof(string));

            var spResult = db.SP_GetQuoteEmailIds(quoteNo, opSPResult, opSubmitterName, opSubmitterEmai, opBuyerName, opBuyerEmail, opUpdatedBy, opUpdaterEmail, opSubmitterManagerEmail, opBuyerManagerEmail, opPriority);

            isRet.result = Convert.ToBoolean(opSPResult.Value);

            isRet.submitterName = Convert.ToString(opSubmitterName.Value);
            isRet.submitterEmail = Convert.ToString(opSubmitterEmai.Value);

            isRet.buyerName = Convert.ToString(opBuyerName.Value);
            isRet.buyerEmail = Convert.ToString(opBuyerEmail.Value);

            isRet.UpdaterName = Convert.ToString(opUpdatedBy.Value);
            isRet.UpdaterEmail = Convert.ToString(opUpdaterEmail.Value);

            isRet.SubmitterManagerEmail = Convert.ToString(opSubmitterManagerEmail.Value);
            isRet.BuyerManagerEmail = Convert.ToString(opBuyerManagerEmail.Value);

            isRet.priority = Convert.ToString(opPriority.Value);
            return isRet;
        }

        public bool isQuoteSuperUser(string userId, string quoteId)
        {
            bool isRet = false;

            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var spResult = db.SP_IsQuoteSuperuser(quoteId, userId, opSPResult);
            isRet = Convert.ToBoolean(opSPResult.Value);
            return isRet;
        }

        public bool isCurrentApproverIsVerifier(string workflowId)
        {
            bool isRet = false;
            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var spResult = db.SP_IsCurrentApproverIsVerifier(workflowId, opSPResult);
            if (!string.IsNullOrEmpty(Convert.ToString(opSPResult.Value)))
                isRet = Convert.ToBoolean(opSPResult.Value);
            return isRet;
        }

        public List<SP_TestCustomNew_Result1> SP_TestCustom()
        {
            return db.SP_TestCustomNew().ToList();
        }

        public List<tbl_RequestForQuotation> getAllRFQ()
        {
            return db.tbl_RequestForQuotation.AsNoTracking().ToList();
        }

        public spResult checkRFQStatus(string rfqNo)
        {
            spResult isRet = new spResult();
            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var opMessage = new ObjectParameter("Message", typeof(string));
            var spResult = db.SP_CheckRFQStatus(rfqNo, opSPResult, opMessage);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.message = Convert.ToString(opMessage.Value);
            return isRet;
        }
        public List<tbl_RFQAttachments> getRFQAttachmentsForDoc(string attachmentList)
        {
            return db.SP_GetRFQAttachmetsForSubmitDoc(attachmentList, MergeOption.NoTracking).ToList();
        }

        public rfqSPResult getRFQAttachmentCount(string rfqNo)
        {
            rfqSPResult isRet = new rfqSPResult();
            var opRequestorCount = new ObjectParameter("RequestorCount", typeof(int));
            var opBuyerCount = new ObjectParameter("BuyerCount", typeof(int));
            var spResult = db.SP_GetQuoteAttachmentCount(rfqNo, opRequestorCount, opBuyerCount);
            isRet.submitterEmail = Convert.ToString(opRequestorCount.Value);
            isRet.buyerEmail = Convert.ToString(opBuyerCount.Value);
            return isRet;
        }

    }
}
