using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WorkFlowUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,User,ServiceAdmin,ServiceEngineer")]
    public class AltApproveDocumentController : Controller
    {
        private DocumentBs ObjBs;
        private DocumentWorkfFlowBs ObjWFBs;
        private Document4AlternateApprovalBs ObjApproveBs;
        private string docLocation;
        private string Erpdoclocation;
        private string mdName;
        private string approverRoleToViewByMD;

        public AltApproveDocumentController()
        {
            ObjBs = new DocumentBs();
            ObjWFBs = new DocumentWorkfFlowBs();
            ObjApproveBs = new Document4AlternateApprovalBs();
            docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
            mdName = Convert.ToString(ConfigurationManager.AppSettings["MDName"]).ToLower();
            approverRoleToViewByMD = Convert.ToString(ConfigurationManager.AppSettings["ApproverRoleToViewByMD"]).ToLower();
        }


        // GET: Admin/AltApproveDocument
        [Authorize(Roles = "Admin")]
        public ActionResult Index(string Status, string SortOrder, string Sortby, string Page, string Search, string VendorName)
        {
            try
            {

                Status = (string.IsNullOrEmpty(Status) ? "P" : Status);
                SortOrder = (string.IsNullOrEmpty(SortOrder) ? "Desc" : SortOrder);
                // Sort by no need
                Page = (string.IsNullOrEmpty(Page) ? "1" : Page);
                Search = (string.IsNullOrEmpty(Search) ? string.Empty : Search);
                VendorName = (string.IsNullOrEmpty(VendorName) ? string.Empty : VendorName);


                ViewBag.showViewDocuments = false;
                ViewBag.Status = Status;
                ViewBag.SortOrder = SortOrder;
                ViewBag.Sortby = Sortby;                
                ViewData["Search"] = clsGeneral.searchStringDecrypt(Search);                
                ViewData["VendorName"] = clsGeneral.searchStringDecrypt(VendorName);

                string Approver = User.Identity.Name.ToLower();
                if (Approver == mdName)
                {
                    ViewBag.showViewDocuments = true;
                }

                //if (Status == null)
                //{
                var documentWf = ObjBs.getAlternateDocuments(Approver, Status, clsGeneral.checkandReplace(Search), approverRoleToViewByMD, clsGeneral.checkandReplace(VendorName));

                // var documentWf = ObjApproveBs.GetALL().Where(x => x.WorkFlowStatus == "P" && x.UpdateDate >= DateTime.Now.AddDays(-90)
                //&& x.DocNo.ToLower().Contains(Search.ToLower()) && (x.Alternate1.ToLower() == Approver | x.Alternate2.ToLower() == Approver));


                switch (Sortby)
                {
                    case "DocType":
                        switch (SortOrder)
                        {
                            case "Asc":
                                documentWf = documentWf.OrderBy(x => x.DocType).ToList();
                                break;
                            case "Desc":
                                documentWf = documentWf.OrderByDescending(x => x.DocType).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "DocNo":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.DocNo).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.DocNo).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "DocNetPrice":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.DocNetPrice).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.DocNetPrice).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;



                    case "Currency":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.Currency).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.Currency).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "NetPrice":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.NetPrice).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.NetPrice).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "Status":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.Status).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.Status).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "VendorCode":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.VendorCode).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.VendorCode).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "VendorName":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.VendorName).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.VendorName).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "ApprovalSubmitDate":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.ApprovalSubmitDate).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.ApprovalSubmitDate).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;


                    case "ApprovalSubmitBy":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.ApprovalSubmitBy).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.ApprovalSubmitBy).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    //case "WorkFlowStatus":
                    //    {
                    //        switch (SortOrder)
                    //        {
                    //            case "Asc":
                    //                documentWf = documentWf.OrderBy(x => x.WorkFlowStatus).ToList();
                    //                break;
                    //            case "Desc":
                    //                documentWf = documentWf.OrderByDescending(x => x.WorkFlowStatus).ToList();
                    //                break;
                    //            default:
                    //                break;
                    //        }

                    //    }
                    //    break;

                    case "Approver":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.Approver).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.Approver).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "AttachDoc":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.AttachDoc).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.AttachDoc).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "AddAttachDoc1":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.AddAttachDoc1).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.AddAttachDoc1).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "AddAttachDoc2":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.AddAttachDoc2).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.AddAttachDoc2).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "AddAttachDoc3":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.AddAttachDoc3).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.AddAttachDoc3).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "RFQRefNo":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    documentWf = documentWf.OrderBy(x => x.RFQRefNo).ToList();
                                    break;
                                case "Desc":
                                    documentWf = documentWf.OrderByDescending(x => x.RFQRefNo).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    #region MyRegion


                    //case "PRNumbers":
                    //    {
                    //        switch (SortOrder)
                    //        {
                    //            case "Asc":
                    //                documentWf = documentWf.OrderBy(x => x.PRNumbers).ToList();
                    //                break;
                    //            case "Desc":
                    //                documentWf = documentWf.OrderByDescending(x => x.PRNumbers).ToList();
                    //                break;
                    //            default:
                    //                break;
                    //        }

                    //    }
                    //    break;
                    //case "PRAmount":
                    //    {
                    //        switch (SortOrder)
                    //        {
                    //            case "Asc":
                    //                documentWf = documentWf.OrderBy(x => x.PRAmount).ToList();
                    //                break;
                    //            case "Desc":
                    //                documentWf = documentWf.OrderByDescending(x => x.PRAmount).ToList();
                    //                break;
                    //            default:
                    //                break;
                    //        }

                    //    }
                    //    break;

                    #endregion
                    default:
                        documentWf = documentWf.OrderBy(x => x.ApprovalSubmitDate).OrderBy(x => x.PriorityCode).OrderBy(x => x.Approver).ToList();
                        break;
                }

                ViewBag.Totalpages = Math.Ceiling(Convert.ToDecimal(documentWf.Count()) / clsGeneral.pagingCountDecimal);
                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;

                documentWf = documentWf.Skip((page - 1) * clsGeneral.pagingCountInt).Take(clsGeneral.pagingCountInt);
                //  documentWf = documentWf.OrderBy(x => x.DocType).ToList();
                return View(documentWf);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "AltApproverDocument", "Index", clsGeneral.errorMessage(ex));
                return View();
            }
        }
        #region MyRegion


        //else
        //{
        //    // var documentWf = ObjApproveBs.GetALL().Where(x => x.WorkFlowStatus == Status && x.UpdateDate >= DateTime.Now.AddDays(-90)
        //    //&& x.DocNo.ToLower().Contains(Search.ToLower()) && (x.Alternate1.ToLower() == Approver | x.Alternate2.ToLower() == Approver));

        //    // if (Status == "V")
        //    // {
        //    //     documentWf = ObjApproveBs.GetALL().Where(x => x.WorkFlowStatus != "N" && x.UpdateDate >= DateTime.Now.AddDays(-90)
        //    //&& x.DocNo.ToLower().Contains(Search.ToLower()) && (x.Alternate1.ToLower() == Approver | x.Alternate2.ToLower() == Approver));
        //    // }
        //    // else if (Status == "A")
        //    // {
        //    //     documentWf = ObjApproveBs.GetALL().Where(x => (x.WorkFlowStatus == "A" || x.WorkFlowStatus == "V") && x.UpdateDate >= DateTime.Now.AddDays(-90)
        //    //&& x.DocNo.ToLower().Contains(Search.ToLower()) && (x.Alternate1.ToLower() == Approver | x.Alternate2.ToLower() == Approver));
        //    // }

        //    var documentWf = ObjBs.getAlternateDocuments(Approver, Status, Search, approverRoleToViewByMD, VendorName);

        //    switch (Sortby)
        //    {
        //        case "DocType":
        //            switch (SortOrder)
        //            {
        //                case "Asc":
        //                    documentWf = documentWf.OrderBy(x => x.DocType).ToList();
        //                    break;
        //                case "Desc":
        //                    documentWf = documentWf.OrderByDescending(x => x.DocType).ToList();
        //                    break;
        //                default:
        //                    break;
        //            }
        //            break;

        //        case "DocNo":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.DocNo).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.DocNo).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;

        //        case "DocNetPrice":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.DocNetPrice).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.DocNetPrice).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;



        //        case "Currency":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.Currency).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.Currency).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;

        //        case "NetPrice":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.NetPrice).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.NetPrice).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;

        //        case "Status":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.Status).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.Status).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;

        //        case "VendorCode":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.VendorCode).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.VendorCode).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;

        //        case "VendorName":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.VendorName).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.VendorName).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;


        //        case "ApprovalSubmitDate":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.ApprovalSubmitDate).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.ApprovalSubmitDate).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;


        //        case "ApprovalSubmitBy":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.ApprovalSubmitBy).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.ApprovalSubmitBy).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;
        //        //case "WorkFlowStatus":
        //        //    {
        //        //        switch (SortOrder)
        //        //        {
        //        //            case "Asc":
        //        //                documentWf = documentWf.OrderBy(x => x.WorkFlowStatus).ToList();
        //        //                break;
        //        //            case "Desc":
        //        //                documentWf = documentWf.OrderByDescending(x => x.WorkFlowStatus).ToList();
        //        //                break;
        //        //            default:
        //        //                break;
        //        //        }

        //        //    }
        //        //    break;

        //        case "Approver":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.Approver).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.Approver).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;
        //        case "AttachDoc":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.AttachDoc).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.AttachDoc).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;
        //        case "AddAttachDoc1":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.AddAttachDoc1).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.AddAttachDoc1).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;
        //        case "AddAttachDoc2":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.AddAttachDoc2).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.AddAttachDoc2).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;

        //        case "AddAttachDoc3":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.AddAttachDoc3).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.AddAttachDoc3).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;
        //        case "RFQRefNo":
        //            {
        //                switch (SortOrder)
        //                {
        //                    case "Asc":
        //                        documentWf = documentWf.OrderBy(x => x.RFQRefNo).ToList();
        //                        break;
        //                    case "Desc":
        //                        documentWf = documentWf.OrderByDescending(x => x.RFQRefNo).ToList();
        //                        break;
        //                    default:
        //                        break;
        //                }

        //            }
        //            break;
        //        //case "PRNumbers":
        //        //    {
        //        //        switch (SortOrder)
        //        //        {
        //        //            case "Asc":
        //        //                documentWf = documentWf.OrderBy(x => x.PRNumbers).ToList();
        //        //                break;
        //        //            case "Desc":
        //        //                documentWf = documentWf.OrderByDescending(x => x.PRNumbers).ToList();
        //        //                break;
        //        //            default:
        //        //                break;
        //        //        }

        //        //    }
        //        //    break;
        //        //case "PRAmount":
        //        //    {
        //        //        switch (SortOrder)
        //        //        {
        //        //            case "Asc":
        //        //                documentWf = documentWf.OrderBy(x => x.PRAmount).ToList();
        //        //                break;
        //        //            case "Desc":
        //        //                documentWf = documentWf.OrderByDescending(x => x.PRAmount).ToList();
        //        //                break;
        //        //            default:
        //        //                break;
        //        //        }

        //        //    }
        //        //    break;


        //        default:
        //            documentWf = documentWf.OrderBy(x => x.ApprovalSubmitDate).OrderBy(x => x.PriorityCode).OrderBy(x => x.Approver).ToList();
        //            break;
        //    }


        //    ViewBag.Totalpages = Math.Ceiling(Convert.ToDecimal(documentWf.Count()) / clsGeneral.pagingCountDecimal);
        //    int page = int.Parse(Page == null ? "1" : Page);
        //    ViewBag.Page = page;
        //    documentWf = documentWf.Skip((page - 1) * clsGeneral.pagingCountInt).Take(clsGeneral.pagingCountInt);
        //    //  documentWf = documentWf.OrderBy(x => x.DocType).ToList();
        //    return View(documentWf);
        //    }

        //}
        #endregion
        public void Approve(long id)
        {
            try
            {
                string Approver = User.Identity.Name;
                var documentWf = ObjWFBs.GetbyID(id);
                documentWf.ApproveBy = User.Identity.Name;
                documentWf.ApproveDate = DateTime.Now;
                if (!string.IsNullOrEmpty(Convert.ToString(documentWf.IsVerifier)) && Convert.ToBoolean(documentWf.IsVerifier))
                {
                    documentWf.Status = "V";
                }
                else
                {
                    documentWf.Status = "A";
                }
                ObjWFBs.Update(documentWf);

                //If document is hold
                //var document = ObjBs.GetALL().Where(x => x.DocID == documentWf.DocID).ToList();
                var document = ObjBs.GetbyIDNew(Convert.ToInt32(documentWf.DocID)).ToList();
                if (document != null && document.Count > 0 && document[0].Status == "H")
                {
                    document[0].Status = "P";
                    document[0].UpdateDate = DateTime.Now;
                    document[0].UpdateBy = User.Identity.Name;
                    ObjBs.Update(document[0]);
                }

                CheckForNextWorkFlow(documentWf);
                TempData["Msg"] = "Approved Successfully";
                //   return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Approval Failed :" + clsGeneral.errorMessage(ex);
                //  return RedirectToAction("Index");
                BLL.clsLog.insertLog(User.Identity.Name, "AltApproveDocument", "Approve", clsGeneral.errorMessage(ex));
            }


        }

        private void CheckForNextWorkFlow(BOL.tbl_DocumentWorkFlow documentWf)
        {
            var docAnyWf1 = ObjWFBs.GetDocuemtWorkFlow(Convert.ToInt32(documentWf.DocID)).Where(p => p.Status == "P").ToList();
            if (docAnyWf1.Count() == 0)
            {
                var docAnyWf = ObjWFBs.GetDocuemtWorkFlow(Convert.ToInt32(documentWf.DocID)).Where(p => p.Status == "N").ToList();
                if (docAnyWf != null && docAnyWf.Count() > 0)
                {
                    var docNextWf = docAnyWf.OrderBy(p => p.ApprovalLevel).ThenBy(p => p.Sequence).First();
                    docNextWf.Status = "P";
                    // docNextWf.AlternateApprover = 0;
                    docNextWf.Submitdate = DateTime.Now;
                    ObjWFBs.Update(docNextWf);

                    //var document = ObjBs.GetALL().Where(x => x.DocID == documentWf.DocID).ToList();
                    var document = ObjBs.GetbyIDNew(Convert.ToInt32(documentWf.DocID)).ToList();
                    if (document != null && document.Count > 0)
                    {
                        document[0].LastApprovalSubmitBy = document[0].UpdateBy = User.Identity.Name;
                        document[0].LastApprovalSubmitDate = document[0].UpdateDate = DateTime.Now;
                        ObjBs.Update(document[0]);
                    }


                    SendMailService.SendStatusToService(documentWf, docNextWf);
                }
                else
                {
                    var isRet = ObjBs.updateSummaryDoc(Convert.ToInt32(documentWf.DocID), "A", User.Identity.Name);
                    SendMailService.SendStatusToService(documentWf);
                }
            }
        }

        public ActionResult Reject(long id)
        {
            try
            {
                string Approver = User.Identity.Name;
                var documentWf = ObjWFBs.GetbyID(id);
                documentWf.RejectBy = User.Identity.Name; ;
                documentWf.RejectDate = DateTime.Now;
                documentWf.Status = "R";

                ObjWFBs.Update(documentWf);
                var isRet = ObjBs.updateSummaryDoc(Convert.ToInt32(documentWf.DocID), "R", User.Identity.Name);
                SendMailService.SendStatusToService(documentWf);
                TempData["Msg"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Rejection Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
                BLL.clsLog.insertLog(User.Identity.Name, "AltApproveDocument", "Reject", clsGeneral.errorMessage(ex));
            }
        }

        public ActionResult BulkApprove(string Ids, string Type)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<long> lt = js.Deserialize<List<long>>(Ids);
                foreach (long wfId in lt)
                {
                    Approve(wfId);
                }
                return RedirectToAction("Index", Type);
                // return new EmptyResult();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "AltApproveDocument", "BulkApprove", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult BulkSubmitApprove(string Ids, string Type)
        {
            try
            {


                JavaScriptSerializer js = new JavaScriptSerializer();
                List<int> lt = js.Deserialize<List<int>>(Ids);
                foreach (long docId in lt)
                {
                    Approve(docId);
                }
                return RedirectToAction("Index", Type);
                // return new EmptyResult();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "AltApproveDocument", "BulkSubmitApprove", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult BulkReject(string Ids)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<long> lt = js.Deserialize<List<long>>(Ids);
                foreach (long wfId in lt)
                {
                    Reject(wfId);
                }
                return RedirectToAction("Index", "AltApproveDocument");
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "AltApproveDocument", "BulkReject", clsGeneral.errorMessage(ex));
                return null;
            }
            // return new EmptyResult();
        }

        public ActionResult RouteDocNo(long docId, string docNo, string type, long workFlowId, string Status, int Page, int AppLevel)
        {
            try
            {
                //ViewBag.PRid = id;
                Session["PRid"] = docNo;
                if (string.Equals(type, "SB", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "SBDetails", new { docId = docId, docNo = docNo, workFlowId = workFlowId, type = "AltApproveDocument", Status = Status, Page = Page, AppLevel = AppLevel });
                }
                else if (string.Equals(type, "PR", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "MiscPRCoa", new { docId = docId, docNo = docNo, workFlowId = workFlowId, type = "AltApproveDocument", Status = Status, Page = Page, AppLevel = AppLevel });
                }
                else if (string.Equals(type, "PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetSPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = workFlowId, type = "AltApproveDocument", Status = Status, IsPOIssued = 0, Page = Page, AppLevel = AppLevel });
                }
                else if (string.Equals(type, "Stock PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = workFlowId, type = "AltApproveDocument", Status = Status, IsPOIssued = 0, Page = Page, AppLevel = AppLevel });
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "AltApproveDocument", "RouteDocNo", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult GetDocument(string docNo, string name, bool erpattach)
        {
            try
            {

                string filePath;

                if (!erpattach)
                {
                    filePath = Path.Combine(docLocation, docNo, name);
                }
                else
                {
                    filePath = Path.Combine(Erpdoclocation, name);
                }
                if (!System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(Server.MapPath("~/Upload Documents/"), name);
                    if (!System.IO.File.Exists(filePath))
                    {
                        return new EmptyResult();
                    }
                }

                byte[] filedata = System.IO.File.ReadAllBytes(filePath);

                string mimeType = MimeMapping.GetMimeMapping(filePath);

                return File(filedata, mimeType, name);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "AltApproveDocument", "GetDocument", clsGeneral.errorMessage(ex));
                return null;
            }
        }
    }
}