using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.App_Start;
using WorkFlowUI.ViewModel;


namespace WorkFlowUI.Areas.Admin.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class SBDetailsController : Controller
    {
        private SupBudDeatilsBS supDetailsBs;
        private SupplementaryBudgetBs supHeaderBs;
        private SupplimentaryDetailsViewModel suppViewModel;
        private CommonBs cmBs;
        public SBDetailsController()
        {
            supHeaderBs = new SupplementaryBudgetBs();
            supDetailsBs = new SupBudDeatilsBS();
            suppViewModel = new SupplimentaryDetailsViewModel();
            cmBs = new CommonBs();
        }
        // GET: User/SupBudtDetails
       

        private void AssignDefaults()
        {
            suppViewModel.SupDetail = new tbl_SupBudgetDetail();
            suppViewModel.SupDetails = new List<tbl_SupBudgetDetail>();
            suppViewModel.SupHeader = new tbl_SupBudgetHeader();
            suppViewModel.DtlObjectNo = new List<SelectListItem>();
            suppViewModel.GLAccounts = new List<SelectListItem>();
        }
        
        public ActionResult Index(long docId,string docNo, long workFlowId,string type,string Status,int Page,int AppLevel)
        {
            try
            {

                AssignDefaults();
                if (docNo != null)
                {
                    var header = supHeaderBs.GetByID(docNo);
                    if (header == null)
                    {
                        TempData["Msg"] = "Reference Number not available";
                        suppViewModel.DocStatusVm = new DocumentStatusViewModel();
                        return View(suppViewModel);
                    }
                    suppViewModel.SupHeader = header;
                    suppViewModel.DocStatusVm = CommonCls.GetDocStatus(docId, docNo, workFlowId, AppLevel);

                    //suppViewModel.SupDetails = supDetailsBs.GetALL().Where(p => p.ReferenceNo == docNo);
                    suppViewModel.SupDetails = supDetailsBs.GetByIDNew(docNo);
                    //supDetailsBs.GetALL().Where(p => p.ReferenceNo == docNo.ToString());
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
                    else if (type == "DocumentStatus")
                    {
                        ViewBag.Controller = "DocumentStatus";
                    }
                    else
                    {
                        ViewBag.Controller = "AltApproveDocument";
                        ViewBag.PrevStatus = Status ?? "P";

                    }
                    ViewBag.Page = Page;
                    TempData["SuppViewDetailModel"] = suppViewModel;
                }
                return View(suppViewModel);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SBDetails", "Index", clsGeneral.errorMessage(ex));
                return View();
            }

        }

        public ActionResult Approve(int id,string comments, bool IsAlternate )
        {
            try
            {

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
                BLL.clsLog.insertLog(User.Identity.Name, "SBDetails", "Approve", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Approval Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
            }


        }

        public ActionResult Reject(int id, string comments,bool IsAlternate)
        {
            try
            {

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
                BLL.clsLog.insertLog(User.Identity.Name, "SBDetails", "Reject", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Rejection Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
            }
        }
    }
}