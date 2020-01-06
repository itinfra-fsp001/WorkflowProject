using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.ViewModel;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "ServiceEngineer")]
    public class DocumentStatusController : Controller
    {
        public DocStatusViewModal objVM;
        public DocumentBs objBs;

        public DocumentStatusController()
        {
            objVM = new DocStatusViewModal();
            objBs = new DocumentBs();
        }
        // GET: User/DocumentStatus
        public ActionResult Index(string searchText, string Page, string Pagesize)
        {          
            searchText = (string.IsNullOrEmpty(searchText) ? "" : searchText);
            Page = (string.IsNullOrEmpty(Page) ? "1" : Page);
            Pagesize = (string.IsNullOrEmpty(Pagesize) ? "50" : Pagesize);
            objVM.searchText = searchText;

            ViewData["SearchText"] = clsGeneral.searchStringDecrypt(searchText);
            ViewData["Pagesize"] = Pagesize;
            ViewData["Page"] = Page;
            ViewBag.Page = Page;

            if (!string.IsNullOrEmpty(searchText))
            {
                objVM.docList = objBs.ViewDocuments(User.Identity.Name, clsGeneral.checkandReplace(searchText)).ToList();
            }
            if(objVM.docList!=null && objVM.docList.Count>0)
            {
                ViewBag.Totalpages = Math.Ceiling(objVM.docList.Count() / Convert.ToDecimal(Pagesize));
                objVM.docList = objVM.docList.Skip((Convert.ToInt16(Page) - 1) * Convert.ToInt32(Pagesize)).Take(Convert.ToInt32(Pagesize)).ToList();
            }            
            return View(objVM);
        }

        public ActionResult RouteDocNo(int docId, string docNo, string type)
        {
            try
            {
                if (string.Equals(type, "SB", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "SBDetails", new { docId = docId, docNo = docNo, workFlowId = 0, type = "DocumentStatus", Status = "", Page = 0, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "PR", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "MiscPRCoa", new { docId = docId, docNo = docNo, workFlowId = 0, type = "DocumentStatus", Status = "", Page = 0, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetSPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = 0, type = "DocumentStatus", Status = "", IsPOIssued = 0, Page = 0, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "Stock PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = 0, type = "DocumentStatus", Status = "", IsPOIssued = 0, Page = 0, area = "Admin", AppLevel = 0 });
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "DocumentStatus", "RouteDocNo", clsGeneral.errorMessage(ex));
                return null;
            }
        }
    }
}