using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmailTemplate
    {

        public void sendQuoteEmail(string to, string cc, string submitter, string buyer, string quoteNo, string type, string revisionNo, string priority, bool isResubmitted)
        {
            StringBuilder str = new StringBuilder();
            string subject = "";
            string isUrgent = (Convert.ToString(priority) == "1" ? "[Urgent] " : "");
            if (type == "Submit")
            {
                str.AppendLine("Hi,<br/>");
            }
            else if (type == "Cancel Quote" || type == "Reject RFQ" || type == "Delete Quote" || type == "Finalise")
            {
                str.AppendLine("Hi,<br/>");
            }
            if (type == "Submit")
            {
                str.AppendLine("New RFQ is submitted by <b>" + submitter + "</b> on <b>" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "</b>. RFQ No. is <b> " + quoteNo + " </b>. Revision No. is <b>" + revisionNo + "</b>.<br/>");
                if (isResubmitted)
                    subject = isUrgent + "[Resubmit] RFQ No. " + quoteNo + " Revision " + revisionNo + " sent by " + submitter;
                else
                    subject = isUrgent + "[Submit] RFQ No." + quoteNo + " Revision " + revisionNo + " sent by " + submitter;
            }
            else if (type == "Reject RFQ")
            {
                str.AppendLine("RFQ No. <b>" + quoteNo + "</b> is <b> rejected </b> by <b> " + buyer + " </b> on <b> " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "</b>. Revision No. is <b>" + revisionNo + "</b>.<br/>");
                subject = isUrgent + "[Reject] RFQ  No. " + quoteNo + " Revision " + revisionNo + " sent by " + buyer;
            }
            else if (type == "Delete RFQ")
            {
                str.AppendLine("RFQ No. <b>" + quoteNo + "</b> is <b> deleted </b> by <b> " + buyer + " </b> on <b> " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "</b>. Revision No. is <b>" + revisionNo + "</b>.<br/>");
                subject = isUrgent + "[Delete] RFQ No. " + quoteNo + " Revision " + revisionNo + " sent by " + buyer;
            }
            else if (type == "Finalise")
            {
                str.AppendLine("RFQ No. <b>" + quoteNo + "</b> is <b> finalised </b> by <b> " + buyer + " </b> on <b> " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "</b>. Revision No. is <b>" + revisionNo + "</b>.<br/>");
                subject = isUrgent + "[Finalise] RFQ No. " + quoteNo + " Revision " + revisionNo + " sent by " + buyer;
            }
            else if (type == "Hold")
            {
                str.AppendLine("RFQ No. <b>" + quoteNo + "</b> is <b> hold </b> by <b> " + buyer + " </b> on <b> " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "</b>. Revision No. is <b>" + revisionNo + "</b>.<br/>");
                subject = isUrgent + "[Hold] RFQ  No. " + quoteNo + " Revision " + revisionNo + " sent by " + buyer;
            }
            str.AppendLine(string.Format("Please login to {0}", Convert.ToString(ConfigurationManager.AppSettings["AppUrl"])));
            str.AppendLine("It is system generated email, Please don't reply.");
            str.AppendLine(string.Format("<font  color=\"blue\">Note:Strictly recommended to use Google Chrome Browser to open the link</font>"));
            List<string> toAdd = new List<string>();
            foreach (var item in to.Split(','))
            {
                if (!string.IsNullOrEmpty(item))
                    toAdd.Add(item);
            }
            List<string> ccAdd = new List<string>();
            if (!string.IsNullOrEmpty(cc))
            {
                foreach (var item in cc.Split(','))
                {
                    if (!string.IsNullOrEmpty(item))
                        ccAdd.Add(item);
                }
            }
            MailService.MailServiceClient client = new MailService.MailServiceClient();
            MailService.MailResult isGet = client.sendEmail(toAdd.ToArray(), ccAdd.ToArray(), subject, Convert.ToString(str), null);
        }
    }
}
