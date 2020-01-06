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
    public class EInvoicedb
    {
        private WorkFlowDBEntities db;

        public EInvoicedb()
        {
            db = new WorkFlowDBEntities();
        }

        public IEnumerable<vw_ERP_ServiceTaxInvoice> GetServiceTaxInvoiceList(string status, string customerName, string period, string invoiceType, string organization, string lastThreeMonthsList)
        {
            return db.SP_EInvoice_View_GetServiceTaxInvoice(status, customerName, period, invoiceType, organization,lastThreeMonthsList,MergeOption.NoTracking).ToList();
        }

        public IEnumerable<vw_ERP_ServiceTaxInvoice> GetAllInvoiceByStatus(string status, string lastThreeMonthsList)
        {
            //if (status == "New")
            //{
            //    return db.vw_ERP_ServiceTaxInvoice.Where(x => x.InvoiceStatus == status).ToList();
            //}
            //else if (status == "Processed")
            //{
            //    return db.vw_ERP_ServiceTaxInvoice.Where(x => x.InvoiceStatus == "Success" || x.InvoiceStatus == "Exception").ToList();
            //}            
            return db.SP_EInvoice_View_GetAllServiceTaxInvoiceByStatus(status,lastThreeMonthsList, MergeOption.NoTracking).ToList();
        }

        public tbl_SIRDocuments GetSIRDocList(string period, string billtoparty)
        {
            var sir = db.SP_EInvoice_View_GetSIRDocuments(billtoparty, period, MergeOption.NoTracking).ToList();
            if (sir != null && sir.Count > 0)
            {
                return sir[0];
            }
            return null;
        }
        public List<vw_ERP_FujitecActiveContrItem> GetActiveContracts(string billtoparty)
        {
            return db.SP_EInvoice_View_GetActiveContract(billtoparty, MergeOption.NoTracking).ToList();
        }

        public string GetBillToPartyName(string billToParty)
        {
            return db.vw_ERP_FujitecActiveContrItem.AsNoTracking().Where(x => x.BillToParty == billToParty).ToList()[0].BillToPartyName;
        }

        public string GetSoldToPartyName(string soldToParty)
        {
            return db.vw_ERP_FujitecActiveContrItem.AsNoTracking().Where(x => x.SoldToParty == soldToParty).ToList()[0].SoldToPartyName;
        }

        public spResult proceedAsException(string transId, string userId)
        {
            spResult isRet = new spResult();
            var opSPResult = new ObjectParameter("Result", typeof(bool));
            var opMessage = new ObjectParameter("Message", typeof(string));
            var spResult = db.SP_EInvoice_View_UpdateSIRDocumentStatus(transId, userId, opSPResult, opMessage);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.message = Convert.ToString(opMessage.Value);
            return isRet;
        }

        public List<vw_ERP_ServiceTaxInvoice> GetServiceTaxInvoiceByID(string logID)
        {
            return db.SP_EInvoice_View_GetServiceTaxInvoiceByID(logID, MergeOption.NoTracking).ToList();
        }

        public vw_ERP_tbl_Customeremail GetCustomerEmailDetails(string customerNo)
        {
            var email = db.SP_EInvoice_View_GetCustomerEmailDetails(customerNo, MergeOption.NoTracking).ToList();
            if (email != null && email.Count>0)
            {
                return email[0];
            }
            return null;
        }

        public rfqSPResult getEmailContent(string logID)
        {
            rfqSPResult isRet = new rfqSPResult();
            var opSubject = new ObjectParameter("Subject", typeof(string));
            var opBody = new ObjectParameter("Body", typeof(string));
            var opSite = new ObjectParameter("Site", typeof(string));
            var opAddressLine1 = new ObjectParameter("AddressLine1", typeof(string));
            var opBillingPlanDescription = new ObjectParameter("BillingPlanDescription", typeof(string));
            var spResult = db.SP_EInvoice_View_GetEmailContent(logID, opSubject, opBody, opSite, opAddressLine1, opBillingPlanDescription);
            isRet.name = Convert.ToString(opSubject.Value);
            isRet.email = Convert.ToString(opBody.Value);
            isRet.buyerName = Convert.ToString(opSite.Value);
            isRet.buyerEmail = Convert.ToString(opAddressLine1.Value);
            isRet.BuyerManagerEmail = Convert.ToString(opBillingPlanDescription.Value);
            return isRet;
        }

        public spResult issueInvoice(string invoiceList, string to, string cc, string subject, string body, string attachmentLocation, string issuedBy, string attachmentList, string mailSendBy)
        {
            spResult isRet = new spResult();
            var opSPResult = new ObjectParameter("Result", typeof(bool));
            var opMessage = new ObjectParameter("Message", typeof(string));
            var spResult = db.SP_EInvoice_View_SaveEmailDetails(invoiceList, to, cc, subject, body, attachmentLocation, issuedBy, attachmentList, opSPResult, opMessage, mailSendBy);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.message = Convert.ToString(opMessage.Value);
            return isRet;
        }

        public void markAsException(string invoiceList, string issuedBy)
        {
            using (var db = new WorkFlowDBEntities())
            {
                db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
                db.SP_EInvoice_Email_UpdateIssueEInvoiceStatus(0, invoiceList, issuedBy, "Exception");
                db.Configuration.EnsureTransactionsForFunctionsAndCommands = true;
            }
        }

        public List<tbl_SIRDocuments> getSIRList(string status, string customerName, string period, string SIRStatus, string site,string salesgroup, string lastThreeMonthsList)
        {
            //return db.SP_EInvoice_View_GetSIRList(status, customerName, period, SIRStatus, site).ToList();
            return db.SP_EInvoice_View_GetSIRListForDashboard(status, customerName, period, SIRStatus, site,salesgroup,lastThreeMonthsList, MergeOption.NoTracking).ToList();
        }

        public List<tbl_SIRDocuments> getALLSIRList(string status,string lastThreeMonthsList)
        {
            return db.SP_EInvoice_View_GetAllSIRList(status, lastThreeMonthsList, MergeOption.NoTracking).ToList();
        }

        public spResult getLastConsolidatedOn()
        {
            spResult isRet = new spResult();
            var opSPResult = new ObjectParameter("LastConsolidated", typeof(DateTime));
            var spResult = db.SP_EInvoice_View_GetLastSIRConsolidatedOn(opSPResult);
            isRet.result = true;
            if (opSPResult.Value != null)
            {
                isRet.message = Convert.ToDateTime(opSPResult.Value).ToString("dd/MM/yyyy hh:mm tt");
            }
            return isRet;
        }

        public tbl_SIRDocuments GetSIRDocumentByID(Int32 transId)
        {
            var sir = db.SP_EInvoice_View_GetSIRDocumentByID(transId, MergeOption.NoTracking).ToList();
            if (sir != null && sir.Count > 0)
            {
                return sir[0];
            }
            return null;
        }

        public bool isServiceAdminUser(string userId)
        {
            bool isRet = false;
            var opSPResult = new ObjectParameter("SPResult", typeof(bool));
            var spResult = db.SP_EInvoice_View_IsServiceAdminUser(userId, opSPResult);
            isRet = Convert.ToBoolean(opSPResult.Value);
            return isRet;
        }

        public List<tbl_SIRDocuments> GetSIRDocumentsForExport(string period)
        {
            return db.SP_EInvoice_View_ExportSIRReport(period, MergeOption.NoTracking).ToList();
        }
    }
}
