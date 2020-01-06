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
    public class EInvoiceBs
    {
        private EInvoicedb objdb;

        public EInvoiceBs()
        {
            objdb = new EInvoicedb();
        }

        public IEnumerable<vw_ERP_ServiceTaxInvoice> GetServiceTaxInvoiceList(string status, string customerName, string period, string invoiceType, string organization, string lastThreeMonthsList)
        {
            return objdb.GetServiceTaxInvoiceList(status, customerName, period, invoiceType, organization, lastThreeMonthsList);
        }

        public IEnumerable<vw_ERP_ServiceTaxInvoice> GetAllInvoiceByStatus(string status, string lastThreeMonthsList)
        {
            return objdb.GetAllInvoiceByStatus(status, lastThreeMonthsList);
        }

        public tbl_SIRDocuments GetSIRDocList(string period, string billtoparty)
        {
            return objdb.GetSIRDocList(period, billtoparty);
        }
        public List<vw_ERP_FujitecActiveContrItem> GetActiveContracts(string billtoparty)
        {
            return objdb.GetActiveContracts(billtoparty);
        }
        public string GetBillToPartyName(string billToParty)
        {
            return objdb.GetBillToPartyName(billToParty);
        }

        public string GetSoldToPartyName(string soldToParty)
        {
            return objdb.GetSoldToPartyName(soldToParty);
        }

        public spResult proceedAsException(string transId, string userId)
        {
            return objdb.proceedAsException(transId, userId);
        }

        public List<vw_ERP_ServiceTaxInvoice> GetServiceTaxInvoiceByID(string logID)
        {
            return objdb.GetServiceTaxInvoiceByID(logID);
        }

        public vw_ERP_tbl_Customeremail GetCustomerEmailDetails(string customerNo)
        {
            return objdb.GetCustomerEmailDetails(customerNo);
        }

        public rfqSPResult getEmailContent(string logID)
        {
            return objdb.getEmailContent(logID);
        }

        public spResult issueInvoice(string invoiceList, string to, string cc, string subject, string body, string attachmentLocation, string issuedBy, string attachmentList, string mailSendBy)
        {
            return objdb.issueInvoice(invoiceList, to, cc, subject, body, attachmentLocation, issuedBy, attachmentList, mailSendBy);
        }

        public void markAsException(string invoiceList, string issuedBy)
        {
            objdb.markAsException(invoiceList, issuedBy);
        }

        public List<tbl_SIRDocuments> getSIRList(string status, string customerName, string period, string SIRStatus, string site, string salesgroup, string lastThreeMonthsList)
        {
            return objdb.getSIRList(status, customerName, period, SIRStatus, site, salesgroup, lastThreeMonthsList);
        }
        public spResult getLastConsolidatedOn()
        {
            return objdb.getLastConsolidatedOn();
        }
        public tbl_SIRDocuments GetSIRDocumentByID(Int32 transId)
        {
            return objdb.GetSIRDocumentByID(transId);
        }

        public List<tbl_SIRDocuments> getALLSIRList(string status, string lastThreeMonthsList)
        {
            return objdb.getALLSIRList(status, lastThreeMonthsList);
        }

        public bool isServiceAdminUser(string userId)
        {
            return objdb.isServiceAdminUser(userId);
        }

        public List<tbl_SIRDocuments> GetSIRDocumentsForExport(string period)
        {
            return objdb.GetSIRDocumentsForExport(period);
        }
        }
}
