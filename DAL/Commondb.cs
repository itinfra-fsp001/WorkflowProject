using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace DAL
{
    public class Commondb
    {
        private WorkFlowDBEntities db;
        private RequestForQuotedb rfqdb;
        public Commondb()
        {
            db = new WorkFlowDBEntities();
            rfqdb = new RequestForQuotedb();

        }
        public List<DocStatus> GetDocStatusByDocId(long docId, long workFlowId, ref long wfId, int AppLevel)
        {
            List<DocStatus> lt = new List<DocStatus>();

            var docInfo = db.SP_GetDocumentByID(docId, System.Data.Entity.Core.Objects.MergeOption.NoTracking).ToList();
            //if (docInfo == null)
            //if(docInfo.Count()==0)
            //{throw  new Exception("Document information not available."); }
            if (docInfo.Count() != 0)
            {
                var docInfo1 = docInfo.First();
                if (AppLevel != 2)
                {
                    lt.Add(new DocStatus()
                    {
                        UserId = docInfo1.IssueBy,
                        Status = "Issued",
                        UserName = GetName(docInfo1.IssueBy),
                        // Date = ' ',
                        Remarks = string.Empty
                    });
                    lt.Add(new DocStatus()
                    {
                        UserId = docInfo1.SubmitBy,
                        Status = GetDocStatus(docInfo1.Status),
                        UserName = GetName(docInfo1.SubmitBy),
                        Date = docInfo1.ApprovalSubmitDate,
                        Remarks = docInfo1.Remarks
                    });
                }
                //var workFlw = db.tbl_DocumentWorkFlow.Where(p => p.DocID == docInfo1.DocID).OrderBy(p => p.ApprovalLevel).OrderBy(p => p.WorkFlowID); .OrderBy(p => p.ApprovalLevel);

                //var workFlw = db.tbl_DocumentWorkFlow.Where(p => p.DocID == docInfo1.DocID).OrderBy(p => p.ApprovalLevel).ThenBy(p => p.Sequence);
                var workFlw = db.SP_GetDocWorkflowForDocStatus(docId, System.Data.Entity.Core.Objects.MergeOption.NoTracking).ToList();
                foreach (tbl_DocumentWorkFlow wf in workFlw)
                {
                    lt.Add(GetDocWorkflowStatus(wf));
                }

                //lt.AddRange(workFlw.Select(p =>  GetDocWorkflowStatus(p)
                //).ToList()); 
                //var isPending = db.tbl_DocumentWorkFlow.Where(p => p.WorkFlowID == workFlowId && (p.Status == "P" || p.Status == "H"));

                var isPending = db.SP_GetDocPendingWorkflow(workFlowId, MergeOption.NoTracking);
                if (isPending != null && isPending.Count() > 0)
                    wfId = workFlowId;
                return lt;
            }
            return lt;
        }


        public long GetDocIdByDocNo(string DocNo)
        {
            long docid = 0;
            long[] docids = db.tbl_Documents.AsNoTracking().Where(p => p.DocNo == DocNo && p.Status == "A").OrderByDescending(p => p.UpdateDate).Select(p => p.DocID).ToArray();
            if (docids.Count() != 0)
            {
                docid = docids.First();
            }
            return docid;
        }


        private string GetDocStatus(string status)
        {
            string statusVal = string.Empty;
            switch (status)
            {
                case "I":
                    statusVal = "Checked";
                    break;
                case "A":
                    statusVal = "Checked";
                    break;
                case "R":
                    statusVal = "Checked";
                    break;
                case "P":
                    statusVal = "Checked";
                    break;
                case "H":
                    statusVal = "Checked";
                    break;
                case "N":
                    statusVal = "Submission Pending";
                    break;
                default:
                    break;
            }
            return statusVal;
        }

        private DocStatus GetDocWorkflowStatus(tbl_DocumentWorkFlow p)
        {
            DocStatus dc = new DocStatus();
            switch (p.Status)
            {
                case "I":
                    dc.Status = "Approved";
                    dc.UserName = p.ApproveBy;
                    dc.Date = Convert.ToDateTime(p.ApproveDate);
                    dc.Remarks = p.Remarks;
                    break;
                case "A":
                    dc.Status = "Approved";
                    dc.UserName = p.ApproveBy;
                    dc.Date = Convert.ToDateTime(p.ApproveDate);
                    dc.Remarks = p.Remarks;
                    break;
                case "R":
                    dc.Status = "Rejected";
                    dc.UserName = p.RejectBy;
                    dc.Date = Convert.ToDateTime(p.RejectDate);
                    dc.Remarks = p.Remarks;
                    break;
                case "H":
                    dc.Status = "Hold";
                    dc.UserName = p.ApproveBy;
                    dc.Date = Convert.ToDateTime(p.ApproveDate);
                    dc.Remarks = p.Remarks;
                    break;
                case "P":
                    if (p.IsVerifier == true)
                    {
                        dc.Status = "Pending For Verification";
                    }
                    else
                    {
                        dc.Status = "Pending For Approval";
                    }

                    break;
                case "V":
                    dc.Status = "Verified";
                    dc.UserName = p.ApproveBy;
                    dc.Date = Convert.ToDateTime(p.ApproveDate);
                    dc.Remarks = p.Remarks;
                    break;
                case "N":
                    break;
                default:
                    break;
            }
            dc.UserId = p.Approver.StartsWith("MC") ? "MC" : p.Approver;
            return dc;
        }



        private string GetName(string subUserId)
        {
            //var user = db.vw_ERP_UserDetails.Where(p => p.UserId == subUserId).First();
            var user = db.SP_GetERPUserName(subUserId, System.Data.Entity.Core.Objects.MergeOption.NoTracking).ToList();
            if (user != null && user.Count > 0)
            {
                return user[0].FirstName + " " + user[0].LastName;
            }
            return null;
        }

        public void insertLog(string userName, string controller, string method, string message)
        {
            db.SP_InsertLog(userName, controller, method, message);
        }

        public List<vw_ERP_tbl_Customeremail> getCustomerEmailList(string customerName, string organization)
        {
            return db.SP_GetCustomerMaster(customerName, organization, System.Data.Entity.Core.Objects.MergeOption.NoTracking).ToList();
        }

        public spResult checkCustomerCodeExists(string customerCode)
        {
            //var outputParameter = new ObjectParameter("Result", typeof(bool));
            //db.SP_CheckCustomerCodeExists(customerCode, outputParameter);
            //return Convert.ToBoolean(outputParameter.Value);


            spResult isRet = new spResult();
            var opSPResult = new ObjectParameter("Result", typeof(bool));
            var opMessage = new ObjectParameter("Message", typeof(string));
            var spResult = db.SP_CheckCustomerCodeExists(customerCode, opSPResult, opMessage);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.message = Convert.ToString(opMessage.Value);
            return isRet;


        }

        //public void addCustomer(vw_ERP_tbl_Customeremail customer)
        //{
        //    db.vw_ERP_tbl_Customeremail.Add(customer);
        //    db.SaveChanges();
        //}

        public void deleteCustomer(string customerCodeList, string userId)
        {
            //var refRange = db.vw_ERP_tbl_Customeremail.Where(p => p.CustomerCode == customerCode).ToList();
            //db.vw_ERP_tbl_Customeremail.RemoveRange(refRange);
            //db.SaveChanges();
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            db.SP_DeleteCustomerEmail(customerCodeList, userId);
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = true;
        }

        public void updateCustomer(List<vw_ERP_tbl_Customeremail> custList)
        {
            //using (DbContextTransaction transaction = db.Database.BeginTransaction())
            //{
            //    try
            //    {
            //db.Configuration.ValidateOnSaveEnabled = false;
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            var temp_cust_List = db.temp_tbl_Customeremail.ToList();
            if (temp_cust_List != null && temp_cust_List.Count > 0)
            {
                db.temp_tbl_Customeremail.RemoveRange(temp_cust_List);
                db.SaveChanges();
            }
            foreach (vw_ERP_tbl_Customeremail customer in custList)
            {
                //db.Entry(customer).State = EntityState.Modified;
                temp_tbl_Customeremail temp_Cus = new temp_tbl_Customeremail()
                {
                    CustomerCode = customer.CustomerCode,
                    CustomerName = customer.CustomerName,
                    OrganizationName = customer.OrganizationName,
                    email_address = customer.email_address,
                    CCemail_Address = customer.CCemail_Address,
                    SOAemail_address = customer.SOAemail_address,
                    SOACCemail_Address = customer.SOACCemail_Address,
                    Exclude_EInvoice = customer.Exclude_EInvoice,
                    Exclude_SOA = customer.Exclude_SOA,
                    Updateuser = customer.Updateuser,
                    Remarks = customer.Remarks
                };
                db.temp_tbl_Customeremail.Add(temp_Cus);
            }
            db.SaveChanges();
            db.SP_UpdateCustomerEmail();
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = true;
            //db.Configuration.ValidateOnSaveEnabled = true;

            //        transaction.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        transaction.Rollback();
            //        Console.WriteLine("Error occurred.");
            //    }
            //}
        }


        public void addCustomer(vw_ERP_tbl_Customeremail customer)
        {
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            var temp_cust_List = db.temp_tbl_Customeremail.ToList();
            if (temp_cust_List != null && temp_cust_List.Count > 0)
            {
                db.temp_tbl_Customeremail.RemoveRange(temp_cust_List);
                db.SaveChanges();
            }
            temp_tbl_Customeremail temp_Cus = new temp_tbl_Customeremail()
            {
                CustomerCode = customer.CustomerCode,
                CustomerName = customer.CustomerName,
                OrganizationName = customer.OrganizationName,
                email_address = customer.email_address,
                CCemail_Address = customer.CCemail_Address,
                SOAemail_address = customer.SOAemail_address,
                SOACCemail_Address = customer.SOACCemail_Address,
                Exclude_EInvoice = customer.Exclude_EInvoice,
                Exclude_SOA = customer.Exclude_SOA,
                Updateuser = customer.Updateuser,
                Remarks = customer.Remarks
            };
            db.temp_tbl_Customeremail.Add(temp_Cus);
            db.SaveChanges();

            db.SP_AddCustomer();
            db.Configuration.EnsureTransactionsForFunctionsAndCommands = true;
        }

        public List<vw_ERP_Organization> getOrganizationList()
        {
            return db.vw_ERP_Organization.AsNoTracking().ToList();
        }

        public List<string> getAllOrganizationList()
        {
            var orgList = db.SP_GetCustomerOrganization(MergeOption.NoTracking).ToList();
            return orgList.Select(x => x.OrganizationName).Distinct().ToList();
            //return db.vw_ERP_tbl_Customeremail.AsNoTracking().ToList().Select(x => x.OrganizationName).Distinct().ToList();
        }
    }
}
