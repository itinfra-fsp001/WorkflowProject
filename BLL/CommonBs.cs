using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace BLL
{
    public class CommonBs
    {
        private Commondb cmDb;
        private DocumentBs ObjBs;
        private DocumentWorkfFlowBs ObjWFBs;
        private fspDocumentBs ObjfspBs;
        private fspDocumentDetailsBs ObjfspdtlBs;
        private MergeDocBs objMergeDocBs;
        public CommonBs()
        {
            cmDb = new Commondb();
            ObjBs = new DocumentBs();
            ObjWFBs = new DocumentWorkfFlowBs();
            ObjfspBs = new fspDocumentBs();
            ObjfspdtlBs = new fspDocumentDetailsBs();
            objMergeDocBs = new MergeDocBs();
        }
        public List<DocStatus> GetDocStatusByDocId(long docId, long workFlowId, ref long wfId, int APPLevel)
        {
            return cmDb.GetDocStatusByDocId(docId, workFlowId, ref wfId, APPLevel);
        }

        public long GetDocIdByDocNo(string DocNo)
        {
            return cmDb.GetDocIdByDocNo(DocNo);
        }
        public bool Approve(int id, string userName, string comments)
        {
            bool status = false;

            string Approver = userName;

            var documentWf = ObjWFBs.GetbyID(id);




            documentWf.ApproveBy = userName;
            documentWf.ApproveDate = DateTime.Now;
            documentWf.Status = "A";
            documentWf.Remarks = comments;
            ObjWFBs.Update(documentWf);


            //var document = ObjBs.GetALL().Where(x => x.DocID == documentWf.DocID).ToList();
            var document = ObjBs.GetbyID(Convert.ToInt32(documentWf.DocID));
            if (document != null)
            {
                //If document is hold
                if (document.Status == "H")
                {
                    document.Status = "P";
                }
                document.UpdateDate = DateTime.Now;
                document.UpdateBy = userName;
                ObjBs.Update(document);

            }
            CheckForNextWorkFlow(documentWf, userName);
            status = true;

            return status;

        }

        public bool Verify(int id, string userName, string comments)
        {
            bool status = false;
            string Approver = userName;

            var documentWf = ObjWFBs.GetbyID(id);
            documentWf.ApproveBy = userName;
            documentWf.ApproveDate = DateTime.Now;
            documentWf.Status = "V";
            documentWf.Remarks = comments;
            ObjWFBs.Update(documentWf);

            //var document = ObjBs.GetALL().Where(x => x.DocID == documentWf.DocID).ToList();
            var document = ObjBs.GetbyID(Convert.ToInt32(documentWf.DocID));
            if (document != null)
            {
                //If document is hold
                if (document.Status == "H")
                {
                    document.Status = "P";
                }
                document.UpdateDate = DateTime.Now;
                document.UpdateBy = userName;
                ObjBs.Update(document);

            }


            CheckForNextWorkFlow(documentWf, userName);
            status = true;

            return status;

        }


        private void CheckForNextWorkFlow(BOL.tbl_DocumentWorkFlow documentWf, string userName)
        {
            var docAnyWf1 = ObjWFBs.GetDocuemtWorkFlow(Convert.ToInt32(documentWf.DocID)).Where(p => p.Status == "P");
            if (docAnyWf1.Count() == 0)
            {
                var docAnyWf = ObjWFBs.GetDocuemtWorkFlow(Convert.ToInt32(documentWf.DocID)).Where(p => p.Status == "N");
                if (docAnyWf != null && docAnyWf.Count() > 0)
                {
                    var docNextWf = docAnyWf.OrderBy(p => p.ApprovalLevel).ThenBy(p => p.Sequence).First();
                    docNextWf.Status = "P";
                    // docNextWf.AlternateApprover = 0;
                    docNextWf.Submitdate = DateTime.Now;
                    ObjWFBs.Update(docNextWf);
                    //No tracking required because entity loaded already, otherwise error will be thrown
                    var document = ObjBs.GetByIDWithoutTracking(Convert.ToInt32(documentWf.DocID));
                    if (document != null)
                    {
                        document.UpdateDate = document.LastApprovalSubmitDate = DateTime.Now;
                        document.UpdateBy = document.LastApprovalSubmitBy = userName;
                        ObjBs.Update(document);
                    }
                    SendMailService.SendStatusToService(documentWf, docNextWf);
                }
                else
                {
                    var isRet = ObjBs.updateSummaryDoc(Convert.ToInt32(documentWf.DocID), "A", userName);
                    SendMailService.SendStatusToService(documentWf);
                }
            }

        }

        public bool Hold(int id, string userName, string comments)
        {
            bool status = false;
            var documentWf = ObjWFBs.GetbyID(id);
            if (documentWf != null)
            {
                documentWf.Status = "H";
                documentWf.Remarks = comments;
                documentWf.ApproveBy = userName;
                documentWf.ApproveDate = DateTime.Now;
                ObjWFBs.Update(documentWf);
                var docs = ObjBs.GetbyID(Convert.ToInt32(documentWf.DocID));
                if (docs != null)
                {
                    docs.Status = "H";
                    docs.UpdateDate = DateTime.Now;
                    docs.UpdateBy = userName;
                    ObjBs.Update(docs);
                }
                SendMailService.SendStatusToService(documentWf);
                status = true;
            }
            return status;
        }

        public bool Reject(int id, string userName, string comments)
        {
            bool status = false;
            try
            {
                string Approver = userName;
                var documentWf = ObjWFBs.GetbyID(id);
                documentWf.RejectBy = userName;
                documentWf.RejectDate = DateTime.Now;
                documentWf.Status = "R";
                documentWf.Remarks = comments;
                ObjWFBs.Update(documentWf);

                var isRet = ObjBs.updateSummaryDoc(Convert.ToInt32(documentWf.DocID), "R", userName);
                SendMailService.SendStatusToService(documentWf);

                var document = ObjBs.GetbyIDNew(Convert.ToInt32(documentWf.DocID)).ToList();
                if (document != null && document.Count > 0 && document[0].IsSummaryDoc == true)
                {
                    var mergedoclist = objMergeDocBs.GetMergeDocList(Convert.ToInt32(documentWf.DocID)).ToList();
                    if (mergedoclist != null && mergedoclist.Count > 0)
                    {
                        foreach (var item in mergedoclist)
                        {
                            var fspdocument = ObjfspBs.GetALL().Where(x => x.DocID == item.DocId).ToList();
                            if (fspdocument != null && fspdocument.Count() > 0)
                            {
                                var fspDoc = fspdocument.First();
                                fspDoc.Status = "N";
                                fspDoc.IsModified = false;
                                ObjfspBs.Update(fspDoc);
                            }
                            var fspdocumentdtl = ObjfspdtlBs.GetALL().Where(x => x.DocID == item.DocId).ToList();
                            if (fspdocumentdtl != null && fspdocumentdtl.Count() > 0)
                            {
                                foreach (var fspdocdtl in fspdocumentdtl)
                                {
                                    fspdocdtl.Status = "N";
                                    ObjfspdtlBs.Update(fspdocdtl);
                                }
                            }
                        }
                    }
                }

                status = true;
            }
            catch (Exception e1)
            {
                // errMsg = e1.Message;
            }
            return status;
        }

        //public void SubmitAndSendMail(tbl_Documents document, string submitBy)
        //{
        //    document.Status = "P";
        //    document.ApprovalSubmitBy = submitBy;
        //    document.ApprovalSubmitDate = DateTime.Now;
        //    document.UpdateDate = DateTime.Now;
        //    ObjBs.Update(document);

        //    //tbl_DocumentWorkFlow documentWf = ObjWFBs.GetALL().Where(x => x.DocID == document.DocID & x.Sequence == 1 & x.ApprovalLevel == "L1" & x.Status == "N") as tbl_DocumentWorkFlow;

        //    var documentWf = ObjWFBs.GetALL().Where(x => x.DocID == document.DocID & x.Sequence == 1 & x.ApprovalLevel == "L1" & x.Status == "N");


        //    var wf = documentWf.First();

        //    wf.Status = "P";
        //   // wf.AlternateApprover = 0;
        //    wf.Submitdate = DateTime.Now;
        //    ObjWFBs.Update(wf);
        //  //  SendMailService.SendStatusToService(wf);
        //}



        public List<vw_ERP_tbl_Customeremail> getCustomerEmailList(string customerName,string organization)
        {
            return cmDb.getCustomerEmailList(customerName, organization);
        }

        public spResult checkCustomerCodeExists(string customerCode)
        {
            return cmDb.checkCustomerCodeExists(customerCode);
        }

        public void addCustomer(vw_ERP_tbl_Customeremail customer)
        {
            cmDb.addCustomer(customer);
        }

        public void deleteCustomer(string customerCodeList, string userId)
        {
            cmDb.deleteCustomer(customerCodeList, userId);
        }

        public void updateCustomer(List<vw_ERP_tbl_Customeremail> custList)
        {
            cmDb.updateCustomer(custList);
        }

        public List<vw_ERP_Organization> getOrganizationList()
        {
            return cmDb.getOrganizationList();
        }

        public List<string> getAllOrganizationList()
        {
            return cmDb.getAllOrganizationList();
        }
    }
}
