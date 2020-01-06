using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WorkFlowUI.App_Start;
using WorkFlowUI.ViewModel;

namespace WorkFlowUI.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    // [AllowAnonymous]
    public class MiscPRCoaController : Controller
    {
        private CommonBs cmBs;
        //private ERP_MiscPRBs miscPr;
        //private ERP_COABudgetBs coaBs;
        private MiscPrCoaViewModel prCoaViewModel;
        //-----
        private DocumentDetailsBs docdtl;
        private DocumentBudgetBs docbudget;
        private DocumentBs doc;
        private string docLocation;
        private string Erpdoclocation;
        public static string controllerName = "MiscPRCoa";

        public dynamic PageNo { get; private set; }

        public MiscPRCoaController()
        {
            //miscPr = new ERP_MiscPRBs();
            //coaBs = new ERP_COABudgetBs();
            cmBs = new CommonBs();
            prCoaViewModel = new MiscPrCoaViewModel();
            //--------------------
            docdtl = new DocumentDetailsBs();
            docbudget = new DocumentBudgetBs();
            doc = new DocumentBs();
            docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
            Erpdoclocation = ConfigurationManager.AppSettings["ERPDocLocation"].ToString();


        }
        // GET: Admin/MiscPR

        public ActionResult RouteDocNo(string id)
        {
            try
            {
                return RedirectToAction("Index", "BudgetSummary", new { id = id });
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "MiscPRCoa", "RouteDocNo", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult Index(long docId, string docNo, long workFlowId, string type, string Status, int Page, int AppLevel)
        {
            try
            {

                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t Index \t Enter");
                prCoaViewModel.MiscPRBudet = docdtl.GetDocuemtDetails(Convert.ToInt32(docId)).ToList();
                prCoaViewModel.CoaBudget = docbudget.GetDocumentBudget(Convert.ToInt32(docId)).ToList();
                prCoaViewModel.DocStatusVm = CommonCls.GetDocStatus(docId, docNo, workFlowId, AppLevel);
                //prCoaViewModel.Documents = doc.GetALL().Where(x => x.DocID== (Convert.ToInt32(docId))).ToList();
                prCoaViewModel.Documents = doc.GetbyIDNew(Convert.ToInt32(docId)).ToList();

                ViewBag.isSummaryPR = false;
                if (prCoaViewModel.Documents.Count > 0 && prCoaViewModel.Documents[0] != null)
                {
                    if (Convert.ToBoolean(prCoaViewModel.Documents[0].IsSummaryDoc))
                    {
                        ViewBag.isSummaryPR = true;
                        prCoaViewModel.ChildDocuments = doc.GetChildDocuments(Convert.ToInt32(prCoaViewModel.Documents[0].DocID)).ToList();
                    }
                }


                if (type == "BrowseDocument")
                {
                    ViewBag.Controller = "BrowseDocument";
                    ViewBag.PrevStatus = Status ?? "N";

                }
                else if (type == "ApproveDocument")
                {
                    ViewBag.Controller = "ApproveDocument";
                    ViewBag.PrevStatus = Status ?? "P";

                }
                else if (type == "AltApproveDocument")
                {
                    ViewBag.Controller = "AltApproveDocument";
                    ViewBag.PrevStatus = Status ?? "P";

                }
                else if (type == "ApprovedPR")
                {
                    ViewBag.Controller = "ApprovedPR";
                    ViewBag.PrevStatus = Status ?? "A";
                }
                else if (type == "PO")
                {
                    ViewBag.Controller = "PO";
                }
                else if (type == "SPO")
                {
                    ViewBag.Controller = "SPO";
                }
                else if (type == "DocumentStatus")
                {
                    ViewBag.Controller = "DocumentStatus";
                }
                ViewBag.Page = Page;
                ViewBag.DocNo = docNo == null ? "" : docNo.ToUpper();
                ViewBag.DocId = docId;
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t Index \t Exit");
                return View(prCoaViewModel);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "MiscPRCoa", "Index", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult Approve(int id, string comments, bool IsAlternate)
        {
            try
            {
                comments = clsGeneral.checkandReplace(comments);
                cmBs.Approve(id, User.Identity.Name, comments);
                TempData["Msg"] = "Approved Successfully";

                if (IsAlternate == false)
                {
                    return RedirectToAction("Index", "ApproveDocument");
                }
                else
                {
                    return RedirectToAction("Index", "AltApproveDocument");
                }



            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "MiscPRCoa", "Approve", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Approval Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
            }


        }
        public ActionResult Reject(int id, string comments, bool IsAlternate)
        {
            try
            {
                comments = clsGeneral.checkandReplace(comments);
                cmBs.Reject(id, User.Identity.Name, comments);
                TempData["Msg"] = "Rejected Successfully";
                if (IsAlternate == false)
                {
                    return RedirectToAction("Index", "ApproveDocument");
                }
                else
                {
                    return RedirectToAction("Index", "AltApproveDocument");
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "MiscPRCoa", "Reject", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Rejection Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
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
                    return new EmptyResult();
                }

                byte[] filedata = System.IO.File.ReadAllBytes(filePath);

                string mimeType = MimeMapping.GetMimeMapping(filePath);

                return File(filedata, mimeType, name);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "MiscPRCoa", "GetDocument", clsGeneral.errorMessage(ex));
                return null;
            }           
        }
    }
}