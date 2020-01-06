using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using WorkFlowUI.ViewModel;
using System.Web.Script.Serialization;
using System.Data.Entity.Core.Objects;

namespace WorkFlowUI.Areas.User.Controllers
{
    public class BrowseQuoteController : Controller
    {
        public BrowseQuoteViewModel viewModel;
        public RequestForQuotebs combs;
        private UserBs ObjUserBs;
        public BrowseQuoteController()
        {
            viewModel = new BrowseQuoteViewModel();
            combs = new RequestForQuotebs();
            ObjUserBs = new UserBs();
        }
        // GET: User/BrowseQuote
        public ActionResult Index(string Status, string SortOrder, string Sortby, string Page, string Search, string FilterType)
        {
            try
            {

                Status = (string.IsNullOrEmpty(Status) ? "N" : Status);
                SortOrder = (string.IsNullOrEmpty(SortOrder) ? "Desc" : SortOrder);
                // Sort By no need, it should goes to default                
                Page = (string.IsNullOrEmpty(Page) ? "1" : Page);
                Search = (string.IsNullOrEmpty(Search) ? string.Empty : Search);
                FilterType = (string.IsNullOrEmpty(FilterType) ? "S" : FilterType);

                ViewBag.Status = Status;
                ViewBag.SortOrder = SortOrder;
                ViewBag.Sortby = Sortby;
                ViewBag.User = User.Identity.Name;
                
                //ViewBag.IsSuperUser = false;
                var userRole = ObjUserBs.GetRoleByID(User.Identity.Name);
                ViewBag.IsSuperUser = false;
                ViewBag.IsPCVUser = false;
                ViewBag.IsPCVUser2 = false;
                if (userRole != null && userRole.Count() > 0)
                {
                    foreach (BOL.tbl_UserRoles item in userRole)
                    {
                        if (item.Role == "Superuser")
                        {
                            ViewBag.IsSuperUser = true;                            
                        }
                        else if (item.Role == "PCVUser")
                        {
                            ViewBag.IsPCVUser = true;
                        }
                        else if (item.Role == "PCVUser2")
                        {
                            ViewBag.IsPCVUser2 = true;
                        }
                    }
                }
                
                ViewData["Search"] = clsGeneral.searchStringDecrypt(Search);

                //if(Status=="N" || Status=="P")

                ViewData["FilterType"] = FilterType;

                var tabStatus = "";
                if (Status == "N")
                {
                    tabStatus = "New";
                }
                else if (Status == "P")
                {
                    tabStatus = "Pending";
                }
                else if (Status == "F")
                {
                    tabStatus = "Finalised";
                }
                else if (Status == "C")
                {
                    tabStatus = "Canceled";
                }
                else if (Status == "R")
                {
                    tabStatus = "Rejected";
                }
                else if (Status == "A")
                {
                    tabStatus = "Assigned";
                }
                else if (Status == "H")
                {
                    tabStatus = "Hold";
                }
                viewModel.rfqMain = combs.getQuotes(ViewBag.User, tabStatus, clsGeneral.checkandReplace(Convert.ToString(ViewData["Search"])), Convert.ToString(ViewData["FilterType"]));
                viewModel.rfqPurchaseAttachments = combs.getQuoteAttachments(ViewBag.User, tabStatus, clsGeneral.checkandReplace(Convert.ToString(ViewData["Search"])), "Requestor");
                viewModel.rfqBuyerAttachments = combs.getQuoteAttachments(ViewBag.User, tabStatus, clsGeneral.checkandReplace(Convert.ToString(ViewData["Search"])), "Buyer");

                switch (Sortby)
                {
                    case "QuoteNo":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.QuoteId).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.QuoteId).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "QuoteType":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.Type).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.Type).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Revision":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.RevisionNo).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.RevisionNo).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "PurchaseCategory":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.PurchaseCategory).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.PurchaseCategory).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "BuyerCode":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.BuyerCode).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.BuyerCode).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "BuyerName":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.BuyerName).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.BuyerName).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "CreatedBy":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.CreatedBy).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.CreatedBy).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "ProcessedBy":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.ProcessedBy).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.ProcessedBy).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "CreatedOn":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.Created).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.Created).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "UpdatedBy":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.ModifiedBy).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.ModifiedBy).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "UpdatedOn":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.Modified).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.Modified).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "RequiredDate":
                        switch (SortOrder)
                        {
                            case "Asc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => x.RequiredDate).ToList();
                                break;
                            case "Desc":
                                viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.RequiredDate).ToList();
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        //viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.Modified).ToList();
                        if (Status == "P" || Status == "H" || Status == "A")
                        {
                            var overduequote = viewModel.rfqMain.Where(x => x.RequiredDate < DateTime.Now.Date).OrderBy(x => x.RequiredDate).ToList();
                            var priorityquote = viewModel.rfqMain.Where(x => x.RequiredDate >= DateTime.Now.Date).OrderByDescending(x => x.Priority).ThenBy(x => x.Modified).ToList();
                            viewModel.rfqMain = overduequote;
                            viewModel.rfqMain.AddRange(priorityquote);

                            //viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.Priority).ToList();
                            //viewModel.rfqMain = viewModel.rfqMain.OrderBy(x => (x.RequiredDate < DateTime.Now ? x.RequiredDate : null)).ToList();
                        }
                        else
                            viewModel.rfqMain = viewModel.rfqMain.OrderByDescending(x => x.Modified).ToList();
                        break;
                }
                ViewBag.Totalpages = Math.Ceiling((viewModel.rfqMain).Count() / clsGeneral.pagingCountDecimal);

                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;

                viewModel.rfqMain = viewModel.rfqMain.Skip((page - 1) * clsGeneral.pagingCountInt).Take(clsGeneral.pagingCountInt).ToList();

                return View(viewModel);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseQuote", "Index", clsGeneral.errorMessage(ex));
                return View();
            }
        }
        public ActionResult DeleteQuote(string Ids)
        {
            try
            {
                processRequest(Ids, "Delete RFQ");
                return RedirectToAction("Index");
                // return new EmptyResult();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseQuote", "DeleteQuote", clsGeneral.errorMessage(ex));
                return null;
            }

        }
        public ActionResult CancelQuote(string Ids)
        {
            try
            {
                processRequest(Ids, "Cancel RFQ");
                return RedirectToAction("Index");
                // return new EmptyResult();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseQuote", "CancelQuote", clsGeneral.errorMessage(ex));
                return null;
            }

        }
        public void processRequest(string Ids, string mode)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<int> lt = js.Deserialize<List<int>>(Ids);
                var quoteList = "";
                foreach (int docId in lt)
                {
                    if (string.IsNullOrEmpty(quoteList))
                        quoteList = Convert.ToString(docId) + ",";
                    else
                        quoteList = quoteList + "," + Convert.ToString(docId) + ",";
                }
                var spResult = combs.cancelQuote(quoteList, User.Identity.Name, mode, "", "", "");

                if (spResult == "Success")
                {
                    if (mode == "Cancel RFQ")
                    {
                        TempData["Msg"] = "RFQ Cancelled Successfully";
                    }
                    else if (mode == "Delete RFQ")
                    {
                        TempData["Msg"] = "RFQ Deleted Successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseQuote", "processRequest", clsGeneral.errorMessage(ex));
                //return null;
            }
        }
    }
}