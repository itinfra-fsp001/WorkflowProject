using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.Areas.User.Controllers
{
    public class DocumentController : Controller
    {
        // GET: User/Document
        public ActionResult Index(int Id )
        {
            WorkFlowDBEntities db = new WorkFlowDBEntities();
            ViewBag.DocID = new SelectList(db.tbl_Documents, "DocID", "DocNo");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Documents myDoc)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "Document", "Create", clsGeneral.errorMessage(ex));
                return null;
            }
            
        }


    }
}