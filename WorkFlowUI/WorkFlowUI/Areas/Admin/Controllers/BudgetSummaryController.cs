using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.Areas.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]
    public class BudgetSummaryController : Controller
    {

        private BudgetSummaryBs ObjBs;


        public BudgetSummaryController()
        {
            ObjBs = new BudgetSummaryBs();
 


        }

        public ActionResult RouteDocNo(string id)
        {
            try
            {
                return RedirectToAction("Index", "MiscPRCoa", new { id = id });
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BudgetSummary", "RouteDocNo", clsGeneral.errorMessage(ex));
                return null;
            }
           

        }

        // GET: Common/BudgetSummary
        public ActionResult Index(string id)
        {
            try
            {
                ViewBag.BudgetSummary = ObjBs.GetALL(id).ToList();
                return View();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BudgetSummary", "Index", clsGeneral.errorMessage(ex));
                return View();
            }

        }


        //<td>
        //        @*@BudgetSummary.SupplementaryBudgetApproved*@
        //        @if(@BudgetSummary.SupplementaryBudgetApproved != null)
        //{
        //    var SupplementaryBudgetApproved = Convert.ToDecimal(@BudgetSummary.SupplementaryBudgetApproved).ToString("#,##0.00");
        //    @Html.DisplayFor(m => SupplementaryBudgetApproved)
        //        }
        //    </td>

        //    <td>
        //        @*@BudgetSummary.CommitPlusActual*@
        //        @if(@BudgetSummary.CommitPlusActual != null)
        //{
        //    var CommitPlusActual = Convert.ToDecimal(@BudgetSummary.CommitPlusActual).ToString("#,##0.00");
        //    @Html.DisplayFor(m => CommitPlusActual)
        //        }
        //    </td>

        //    <td>
        //        @*@BudgetSummary.BalanceBudgetAmount*@
        //        @if(@BudgetSummary.BalanceBudgetAmount != null)
        //{
        //    var BalanceBudgetAmount = Convert.ToDecimal(@BudgetSummary.BalanceBudgetAmount).ToString("#,##0.00");
        //    @Html.DisplayFor(m => BalanceBudgetAmount)
        //        }
        //    </td>
    }
}