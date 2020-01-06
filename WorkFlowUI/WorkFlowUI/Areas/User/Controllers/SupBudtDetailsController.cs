using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.ViewModel;


namespace WorkFlowUI.Areas.User.Controllers
{
    public class SupBudtDetailsController : Controller
    {
        private SupBudDeatilsBS supDetailsBs;
        private SupplementaryBudgetBs supHeaderBs;
        private SupplimentaryDetailsViewModel suppViewModel;

        public SupBudtDetailsController()
        {
            supHeaderBs = new SupplementaryBudgetBs();
            supDetailsBs = new SupBudDeatilsBS();
            suppViewModel = new SupplimentaryDetailsViewModel();
        }
        // GET: User/SupBudtDetails
        public ActionResult Index(string id)
        {
            try
            {

                AssignDefaults();
                if (id != null)
                {
                    var header = supHeaderBs.GetByID(id);
                    if (header == null)
                    {
                        TempData["Msg"] = "Reference Number not available";
                        return View(suppViewModel);
                    }
                    suppViewModel.SupHeader = header;
                    suppViewModel.SupDetails = supDetailsBs.GetALL().Where(p => p.ReferenceNo == id.ToString() && p.UpdateBy == User.Identity.Name).ToList();
                    List<string> ltObjcts = supDetailsBs.GetDtlObjectNos(suppViewModel.SupHeader.ObjectNo,
                        suppViewModel.SupHeader.CostObject.Trim(), suppViewModel.SupHeader.VariationOrderNo);
                    ltObjcts.Sort();
                    var dtObjectNo = ltObjcts.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
                    if (dtObjectNo != null && dtObjectNo.Count > 0)
                    {
                        suppViewModel.DtlObjectNo = dtObjectNo;
                        List<GlAccount> lstDesig = supDetailsBs.GetGlaAccounts(suppViewModel.DtlObjectNo[0].Text, suppViewModel.SupHeader.CostObject);
                        if (lstDesig != null && lstDesig.Count > 0)
                        {
                            suppViewModel.GLAccounts = lstDesig.Select(x => new SelectListItem() { Value = x.GlCode, Text = x.GlCode }).ToList(); ;
                        }
                        else
                        {
                            if (suppViewModel.SupHeader.CostObject != "Inventory Stock")
                                TempData["Msg"] = "GL Accounts not available";
                        }
                    }
                    else
                    {
                        TempData["Msg"] = "ObjectNumber not available";

                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(header.CostCentreID)))
                    {
                        var selCostCentre = supHeaderBs.GetCostCentre().Where(p => p.CostCentreID == header.CostCentreID).ToList();
                        if (selCostCentre != null && selCostCentre.Count > 0)
                        {
                            suppViewModel.costCentre = selCostCentre[0].CostCentreDescription;
                        }
                    }

                    TempData["SuppViewDetailModel"] = suppViewModel;
                }
                return View(suppViewModel);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "Index", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        private void AssignDefaults()
        {
            suppViewModel.SupDetail = new tbl_SupBudgetDetail();
            suppViewModel.SupDetails = new List<tbl_SupBudgetDetail>();
            suppViewModel.SupHeader = new tbl_SupBudgetHeader();
            suppViewModel.DtlObjectNo = new List<SelectListItem>();
            suppViewModel.GLAccounts = new List<SelectListItem>();
        }

        public ActionResult GetGlaAccounts(string objectNo)
        {
            try
            {

                suppViewModel = TempData["SuppViewDetailModel"] as SupplimentaryDetailsViewModel;
                string costType = suppViewModel.SupHeader.CostObject.Trim();
                List<GlAccount> lstDesig = supDetailsBs.GetGlaAccounts(objectNo, costType);
                TempData["SuppViewDetailModel"] = suppViewModel;
                var jsonView = Json(lstDesig, JsonRequestBehavior.AllowGet);
                return jsonView;

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "GetGlaAccounts", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public string SaveRefChanges(string ApplicationFor, string ReasonFor, string refNo)
        {
            suppViewModel = TempData["SuppViewDetailModel"] as SupplimentaryDetailsViewModel;
            try
            {
                if (!string.IsNullOrEmpty(ApplicationFor) || !string.IsNullOrEmpty(ReasonFor))
                {
                    var supHeader = suppViewModel.SupHeader;
                    supHeader.ApplicationFor = ApplicationFor;
                    supHeader.ReasonFor = ReasonFor;
                    supHeaderBs.Update(supHeader);
                }


            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "SaveRefChanges", clsGeneral.errorMessage(ex));
                return clsGeneral.errorMessage(ex);
            }

            TempData["SuppViewDetailModel"] = suppViewModel;
            return "Success";
        }
        public string CreateSupDetails(string ReqAmount, string objectNumber, string glCode, string glDesc)
        {
            try
            {
                suppViewModel = TempData["SuppViewDetailModel"] as SupplimentaryDetailsViewModel;
                TempData["SuppViewDetailModel"] = suppViewModel;
                string errorMsg = string.Empty;
                int reqAmount;
                if (string.IsNullOrEmpty(ReqAmount))
                {
                    errorMsg += "<br/> Request budget amount cann't be empty.";
                }
                else if (!int.TryParse(ReqAmount, out reqAmount))
                {
                    errorMsg += "<br/> Request budget amount should be number.";
                }
                else if (Convert.ToInt64(ReqAmount) < 0)
                {
                    errorMsg += "<br/> Request budget amount should be greater than zero.";
                }

                if (string.Equals(objectNumber, "-- Select Object --", StringComparison.OrdinalIgnoreCase))
                {
                    errorMsg += "<br/> Please select detail object.";
                }

                else if (string.Equals(glCode, "-- Select GlCode --", StringComparison.OrdinalIgnoreCase))
                {
                    errorMsg += "<br/> Please select gl code.";
                }
                if (suppViewModel != null && suppViewModel.SupDetails != null && suppViewModel.SupDetails.Count() > 0)
                {
                    foreach (tbl_SupBudgetDetail item in suppViewModel.SupDetails)
                    {
                        if (item.DtlObjectNo == objectNumber && item.GLAccount == glCode)
                        {
                            errorMsg += "<br/> Dtl Object Number with same GL Account already added";
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    //   TempData["Msg"] = "Error Summary: " + errorMsg;
                    return "Error Summary: " + errorMsg;
                }
                tbl_SupBudgetDetail subDetail = suppViewModel.SupDetail;
                subDetail.DtlObjectNo = objectNumber;
                subDetail.GLAccount = glCode;
                subDetail.GLDescription = glDesc;
                subDetail.ReferenceNo = suppViewModel.SupHeader.ReferenceNo;
                subDetail.ReqSuppBudgetAmt = Convert.ToDecimal(ReqAmount);
                subDetail.UpdateBy = User.Identity.Name;
                var maxSeq = supDetailsBs.GetMaxCount(suppViewModel.SupHeader.ReferenceNo);

                subDetail.SeqNo = maxSeq;
                if (suppViewModel.SupHeader.CostObject == "Project")
                {
                    var variationNumber = suppViewModel.SupHeader.VariationOrderNo;
                    if (!string.IsNullOrEmpty(variationNumber))
                    {
                        decimal TotalAmount = 0;
                        decimal elgAmount = 0;
                        bool status = supDetailsBs.CanReqAmountAdded(variationNumber, subDetail.ReferenceNo,
                            ReqAmount, subDetail.GLAccount, ref TotalAmount, ref elgAmount);
                        if (!status)
                        {
                            TempData["SuppViewDetailModel"] = suppViewModel;
                            return string.Format("Requested Budget Amount can't exceded than {0}. Total Budget for selected GlCode '{2}' is: {1}", elgAmount, TotalAmount, subDetail.GLAccount);
                        }
                    }
                }
                supDetailsBs.Insert(subDetail);


                // string costType = suppViewModel.SupHeader.CostObject;
                //  List<GlAccount> lstDesig = supDetailsBs.GetGlaAccounts(objectNo, costType);
                TempData["SuppViewDetailModel"] = suppViewModel;
                return "Success";
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "CreateSupDetails", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult DeleteSubDetail(string id, int seq)
        {
            try
            {

                suppViewModel = TempData["SuppViewDetailModel"] as SupplimentaryDetailsViewModel;
                supDetailsBs.DeleteSubDetail(id, seq);
                TempData["SuppViewDetailModel"] = suppViewModel;
                return RedirectToAction("Index", new { id = suppViewModel.SupHeader.ReferenceNo });

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "DeleteSubDetail", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult CreateSupDetails1()
        {
            try
            {

                suppViewModel = TempData["SuppViewDetailModel"] as SupplimentaryDetailsViewModel;
                TempData["SuppViewDetailModel"] = suppViewModel;
                return RedirectToAction("Index", new { id = suppViewModel.SupHeader.ReferenceNo });

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "CreateSupDetails1", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult GetSupDetailByGlCode(string glCode, string objectNumber)
        {
            try
            {

                suppViewModel = TempData["SuppViewDetailModel"] as SupplimentaryDetailsViewModel;
                string costType = suppViewModel.SupHeader.CostObject;
                tbl_SupBudgetDetail subDetail = supDetailsBs.GetSupDetailByGlCode(glCode, objectNumber, costType);
                suppViewModel.SupDetail = subDetail;
                TempData["SuppViewDetailModel"] = suppViewModel;
                var jsonView = Json(subDetail, JsonRequestBehavior.AllowGet);
                return jsonView;

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "GetSupDetailByGlCode", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public int GetSubDetailCount(string RefNo)
        {
            int cnt = 0;
            try
            {
                suppViewModel = TempData["SuppViewDetailModel"] as SupplimentaryDetailsViewModel;
                TempData["SuppViewDetailModel"] = suppViewModel;
                var data = supDetailsBs.IsExistsRefId(RefNo);
                if (data)
                    cnt = 1;
                return cnt;
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "GetSubDetailCount", clsGeneral.errorMessage(ex));
            }
            return cnt;
        }

        public ActionResult SubmitReferenceNo()
        {
            try
            {

                suppViewModel = TempData["SuppViewDetailModel"] as SupplimentaryDetailsViewModel;
                supDetailsBs.SubmitReferenceNo(suppViewModel.SupHeader.ReferenceNo, User.Identity.Name);
                //// TempData["Msg"] = "Supp Budget Released Successfully";
                TempData["SuppViewDetailModel"] = suppViewModel;
                // return "Success";
                return RedirectToAction("Index", "SupplementaryBudget");

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "SubmitReferenceNo", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult SupDetailsSB(string id)
        {
            try
            {
                AssignDefaults();
                if (id != null)
                {
                    var header = supHeaderBs.GetByID(id);
                    if (header == null)
                    {
                        TempData["Msg"] = "Reference Number not available";
                        return View(suppViewModel);
                    }
                    suppViewModel.SupHeader = header;
                    suppViewModel.SupDetails = supDetailsBs.GetALL().Where(p => p.ReferenceNo == id.ToString() && p.UpdateBy == User.Identity.Name).ToList();
                    // TempData["SuppViewDetailModel"] = suppViewModel;
                }
                return View(suppViewModel);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupBudtDetails", "SupDetailsSB", clsGeneral.errorMessage(ex));
                return null;
            }
        }
    }
}