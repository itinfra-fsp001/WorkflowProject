using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using workWorkFlowUI.ViewModel;

namespace WorkFlowUI.Areas.User.Controllers
{
    public class SupplementaryBudgetController : Controller
    {
        private SupplementaryBudgetBs supHeadBs;
        private SupplimentaryHeaderViewModel suppViewModel;
        private CostObjectBS costBs;
        private SupBudDeatilsBS supDetailsBs;
        private UserBs ObjUserBs;
        private SupplementaryBudgetViewModal suppBudget;
        static readonly object _lockRefNumber = new object();
        public SupplementaryBudgetController()
        {
            supHeadBs = new SupplementaryBudgetBs();
            suppViewModel = new SupplimentaryHeaderViewModel();
            costBs = new CostObjectBS();
            supDetailsBs = new SupBudDeatilsBS();
            ObjUserBs = new UserBs();
            suppBudget = new SupplementaryBudgetViewModal();
        }
        // GET: User/SupplementaryBudget
        public ActionResult Index(string SortOrder, string Sortby, string Page)
        {
            try
            {

                SortOrder = (string.IsNullOrEmpty(SortOrder) ? "ReferenceNo" : SortOrder);
                Sortby = (string.IsNullOrEmpty(Sortby) ? "Desc" : Sortby);
                Page = (string.IsNullOrEmpty(Page) ? "1" : Page);

                ViewBag.SortOrder = SortOrder;
                ViewBag.Sortby = Sortby;

                List<string> userList = new List<string>();
                userList.Add(User.Identity.Name);
                //var userRole = ObjUserBs.GetRoleByID(User.Identity.Name);

                #region Commented Code

                //if (userRole != null && userRole.Role == "Superuser")
                //{
                //    ViewBag.IsSuperUser = true;
                //    var users = ObjUserBs.GetALL();

                //    List<string> deptcode = new List<string>();
                //    foreach (var item in users)
                //    {
                //        if (item.UserId == User.Identity.Name)
                //        {
                //            //deptcode.Add(Convert.ToString(item.DeptCode));
                //            break;
                //        }
                //    }
                //    if(!string.IsNullOrEmpty(userRole.Departments))
                //    {
                //        foreach (var item in userRole.Departments.Split(','))
                //        {
                //            deptcode.Add(item);
                //        }
                //    }

                //    if (deptcode != null)
                //    {
                //        foreach (var item in users)
                //        {
                //            if (Array.IndexOf(deptcode.ToArray(), item.DeptCode) >= 0)
                //            {
                //                userList.Add(item.UserId);
                //            }
                //        }
                //    }
                //}

                //x.UpdateBy == User.Identity.Name

                //var supHeaders = supHeadBs.GetALL().Where(x => x.Status == "N" && x.UpdateDate >= DateTime.Now.AddDays(-90) && Array.IndexOf(userList.ToArray(), x.UpdateBy) >= 0);
                #endregion

                var supHeaders = supHeadBs.GetSBHeader(User.Identity.Name);
                switch (Sortby)
                {
                    case "ReferenceNo":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.ReferenceNo).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.ReferenceNo).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "CostObject":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.CostObject).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.CostObject).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "CostCentre":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.CostCentreID).ToList();                                
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.CostCentreID).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "ObjectNo":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.ObjectNo).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.ObjectNo).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "ObjectName":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.ObjectName).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.ObjectName).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "FromDivision":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.FromDivision).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.FromDivision).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "NetPrice":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.NetPrice).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.NetPrice).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Currency":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.Currency).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.Currency).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "VariationOrderNo":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.VariationOrderNo).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.VariationOrderNo).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "UpdateBy":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.UpdateBy).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.UpdateBy).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "UpdateDate":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.UpdateDate).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.UpdateDate).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Status":
                        switch (SortOrder)
                        {
                            case "Asc":
                                supHeaders = supHeaders.OrderBy(x => x.Status).ToList();
                                break;
                            case "Desc":
                                supHeaders = supHeaders.OrderByDescending(x => x.Status).ToList();
                                break;
                            default:
                                break;
                        }
                        break;





                    default:
                        supHeaders = supHeaders.OrderBy(x => x.ReferenceNo).ToList();
                        break;
                }


                //x.UpdateBy == User.Identity.Name
                ViewBag.Totalpages = Math.Ceiling(supHeaders.Count() / clsGeneral.pagingCountDecimal);

                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;

                supHeaders = supHeaders.Skip((page - 1) * clsGeneral.pagingCountInt).Take(clsGeneral.pagingCountInt);

                suppBudget.supHeader = supHeaders;
                suppBudget.costCentre = supHeadBs.GetCostCentre().ToList();
                return View(suppBudget);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupplementaryBudget", "Index", clsGeneral.errorMessage(ex));
                return View();
            }
        }

        public ActionResult AddNewSup(string refNumber)
        {
            try
            {

                string refNum = refNumber ?? "0";
                if (refNum != "0")
                {
                    var supHeaders = supHeadBs.GetByID(refNum);
                    suppViewModel.SupHeader = supHeaders;
                    suppViewModel.SupDetails = (IEnumerable<tbl_SupBudgetDetail>)new List<tbl_SupBudgetDetail>();
                }
                else
                {
                    suppViewModel.SupHeader = new tbl_SupBudgetHeader();
                    suppViewModel.SupDetails = (IEnumerable<tbl_SupBudgetDetail>)new List<tbl_SupBudgetDetail>();
                    suppViewModel.ObjectName = "";
                }
                var costs = costBs.GetALL();
                //  var dtObjects = supHeadBs.GetALL();
                //  SelectList objlistofcountrytobind = new SelectList(costs, "ObjectNo", "ObjectName", 0);
                suppViewModel.CostObjects = costs.Select(p => new SelectListItem
                {
                    Text = p.ObjectName,
                    Value = p.ObjectName
                }).ToList();

                var costCentre = supHeadBs.GetCostCentre();
                suppViewModel.CostCentre= costCentre.Select(p => new SelectListItem
                {
                    Text = p.CostCentreDescription,
                    Value = Convert.ToString(p.CostCentreID)
                }).ToList();

                suppViewModel.ObjectNumbers = new List<SelectListItem>();
                suppViewModel.VariationNumbers = new List<SelectListItem>();
                suppViewModel.SelectedCostObject = "";
                suppViewModel.SelectedCostCentre = "";
                TempData["SuppViewModel"] = suppViewModel;
                return View("AddNewSup", suppViewModel);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupplementaryBudget", "AddNewSup", clsGeneral.errorMessage(ex));
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddSupplementaryHeader(SupplimentaryHeaderViewModel supView)
        {
            try
            {

                tbl_SupBudgetHeader SupHeader = supView.SupHeader;
                suppViewModel = TempData["SuppViewModel"] as SupplimentaryHeaderViewModel;
                string error = string.Empty;

                if (!ModelState.IsValid)
                {
                    //  suppViewModel.SupHeader.ObjectName
                    TempData["SuppViewModel"] = suppViewModel;
                    return View("AddNewSup", suppViewModel);
                }
                string refNumber = GetReferenceNumber(supView.SelectedCostObject.Trim(), ref error);
                if (string.IsNullOrEmpty(refNumber))
                {
                    TempData["SuppViewModel"] = suppViewModel;
                    TempData["Msg"] = error;
                    return View("AddNewSup", suppViewModel);
                }
                if (!string.IsNullOrEmpty(SupHeader.ReferenceNo))
                {
                    var prevSupHeader = supHeadBs.GetByID(SupHeader.ReferenceNo);
                    if (prevSupHeader != null)
                    {
                        TempData["SuppViewModel"] = suppViewModel;
                        TempData["Msg"] = "Refernece no already available. Please enter another reference no";
                        return View("AddNewSup", suppViewModel);
                    }
                }
                string objectName = suppViewModel.ObjectName;
                suppViewModel = supView;

                tbl_SupBudgetHeader supHeader = new tbl_SupBudgetHeader()
                {
                    ReferenceNo = refNumber,
                    CostObject = suppViewModel.SelectedCostObject.Trim(),
                    ObjectNo = suppViewModel.SelectedObjectNo,
                    ObjectName = objectName,
                    ApplicationFor = SupHeader.ApplicationFor,
                    ReasonFor = SupHeader.ReasonFor,
                    VariationOrderNo = suppViewModel.SelectedVarNo,
                    FromDivision = supHeadBs.GetDisvisionNumber(User.Identity.Name),
                    Currency = "SGD",
                    NetPrice = 0,
                    Status = "N",
                    SubmitBy = User.Identity.Name,
                    SubmitDate = DateTime.Now,
                    UpdateBy = User.Identity.Name,
                    UpdateDate = DateTime.Now,
                    CostCentreID = Convert.ToInt32(suppViewModel.SelectedCostCentre)
                };

                supHeadBs.Insert(supHeader);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupplementaryBudget", "AddSupplementaryHeader", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        private string GetReferenceNumber(string type, ref string error)
        {
            try
            {

                string refNumber = string.Empty;
                try
                {
                    lock (_lockRefNumber)
                    {
                        var sups = supHeadBs.GetALL();
                        if (sups != null && sups.Count() > 0)
                        {
                            var last = sups.OrderBy(p => p.UpdateDate).Last();
                            var prevRefNumber = last.ReferenceNo.Split('-').Last();
                            var lastNumb = Convert.ToInt64(prevRefNumber) + 1;
                            refNumber = string.Format("SB-{0}-{1}", type[0], lastNumb.ToString("D7"));
                        }
                        else
                        {
                            refNumber = string.Format("SB-{0}-{1}", type[0], 1.ToString("D7"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = string.Format("Unable to create ref number.{0}", clsGeneral.errorMessage(ex));
                }
                return refNumber;

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupplementaryBudget", "GetReferenceNumber", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult GetObjects(string objType)
        {
            try
            {

                suppViewModel = TempData["SuppViewModel"] as SupplimentaryHeaderViewModel;
                var objeNumbers = costBs.GetObjectNumbers(objType);
                suppViewModel.ObjectNumbers = objeNumbers.Select(x => new SelectListItem() { Value = x, Text = x }).ToList();
                // suppViewModel.SelectedCostObject = objType;
                suppViewModel.SupHeader.CostObject = objType;
                TempData["SuppViewModel"] = suppViewModel;
                var jsonView = Json(suppViewModel.ObjectNumbers, JsonRequestBehavior.AllowGet);
                return jsonView;

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupplementaryBudget", "GetObjects", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public string GetObjectName(string objNumber, string objType)
        {
            try
            {

                suppViewModel = TempData["SuppViewModel"] as SupplimentaryHeaderViewModel;
                // suppViewModel.SelectedObjectNo = objNumber;
                suppViewModel.SupHeader.ObjectNo = objNumber;
                var objName = costBs.GetObjectNameByObjectNumber(objNumber, objType);
                suppViewModel.SupHeader.ObjectName = objName;
                suppViewModel.ObjectName = objName;
                //   suppViewModel.ObjectName = objName;
                TempData["SuppViewModel"] = suppViewModel;
                // var jsonView = Json(lstDesig, JsonRequestBehavior.AllowGet);
                return objName;

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupplementaryBudget", "GetObjectName", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult DeleteSubDetails(string RefNo)
        {
            try
            {

                supDetailsBs.DeleteByRefId(RefNo);
                supHeadBs.DeleteByRefId(RefNo);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupplementaryBudget", "DeleteSubDetails", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult GetDtAccounts(string objectNo)
        {
            try
            {

                suppViewModel = TempData["SuppViewModel"] as SupplimentaryHeaderViewModel;
                string costType = suppViewModel.SupHeader.CostObject;
                List<GlAccount> lstDesig = supDetailsBs.GetDtAccounts(objectNo);
                TempData["SuppViewModel"] = suppViewModel;
                var jsonView = Json(lstDesig, JsonRequestBehavior.AllowGet);
                return jsonView;

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "SupplementaryBudget", "GetDtAccounts", clsGeneral.errorMessage(ex));
                return null;
            }
        }

    }
}