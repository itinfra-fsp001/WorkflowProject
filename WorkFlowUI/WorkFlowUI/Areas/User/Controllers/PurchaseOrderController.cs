using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "PCVUser")]
    public class PurchaseOrderController : Controller
    {
        private PurchargeOrderbs ObjBs;
        private DocumentBs ObjdocBs;
        private DocumentWorkfFlowBs ObjwfBs;

        public PurchaseOrderController()
        {
            ObjBs = new PurchargeOrderbs();
            ObjdocBs = new DocumentBs();
            ObjwfBs = new DocumentWorkfFlowBs();
        }
        // GET: User/PurchaseOrder
        public ActionResult Index(int IsPOIssued, string SortOrder, string Sortby, string Page, string Search, string BuyerName, string VendorName)
        {
            try
            {
                IsPOIssued = (string.IsNullOrEmpty(Convert.ToString(IsPOIssued)) ? 0 : IsPOIssued);
                SortOrder = (string.IsNullOrEmpty(SortOrder) ? "Desc" : SortOrder);
                Sortby = (string.IsNullOrEmpty(Sortby) ? "POType" : Sortby);
                Page = (string.IsNullOrEmpty(Page) ? "1" : Page);
                Search = (string.IsNullOrEmpty(Search) ? string.Empty : Search);
                BuyerName = (string.IsNullOrEmpty(BuyerName) ? string.Empty : BuyerName);
                VendorName = (string.IsNullOrEmpty(VendorName) ? string.Empty : VendorName);



                ViewBag.IsPOIssued = IsPOIssued;
                ViewBag.SortOrder = SortOrder;
                ViewBag.Sortby = Sortby;
                //      string department=ConfigurationManager.AppSettings["DeparmentName"].ToString();
                //var Documents = IsPOIssued==1 ? ObjBs.GetALLForDepartment(department).Where(x => x.POStatus == "A"
                //    && x.IsPOIssued == true):ObjBs.GetALLForDepartment(department).Where(x => x.POStatus == "A"
                //    &&x.IsPOIssued!=true);
                
                ViewData["Search"] = clsGeneral.searchStringDecrypt(Search);                
                ViewData["BuyerName"] = clsGeneral.searchStringDecrypt(BuyerName);                
                ViewData["VendorName"] = clsGeneral.searchStringDecrypt(VendorName);

                var Documents = ObjBs.GetALLPurchaseOrders((IsPOIssued == 1 ? true : false), clsGeneral.checkandReplace(Search), clsGeneral.checkandReplace(BuyerName), clsGeneral.checkandReplace(VendorName));

                //var Documents = IsPOIssued == 1 ? ObjBs.GetALL().Where(x => x.POStatus == "A" && x.IsPOIssued == true && x.POIssuedDate >= DateTime.Now.AddDays(-30) && x.PurchaseOrderNo.ToLower().Contains(Search.ToLower()) && (string.IsNullOrEmpty(x.VendorName) ? true : Convert.ToString(x.VendorName).ToLower().Contains(VendorName.ToLower())) && (string.IsNullOrEmpty(x.BuyerName) ? true : Convert.ToString(x.BuyerName).ToLower().Contains(BuyerName.ToLower())))
                //                                : ObjBs.GetALL().Where(x => x.POStatus == "A" && x.IsPOIssued != true && x.PurchaseOrderNo.ToLower().Contains(Search.ToLower()) && (string.IsNullOrEmpty(x.VendorName) ? true : Convert.ToString(x.VendorName).ToLower().Contains(VendorName.ToLower())) && (string.IsNullOrEmpty(x.BuyerName) ? true : Convert.ToString(x.BuyerName).ToLower().Contains(BuyerName.ToLower())));

                switch (Sortby)
                {
                    case "POType":
                        switch (SortOrder)
                        {
                            case "Asc":
                                Documents = Documents.OrderBy(x => x.POType).ToList();
                                break;
                            case "Desc":
                                Documents = Documents.OrderByDescending(x => x.POType).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "PurchaseOrderNo":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.PurchaseOrderNo).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.PurchaseOrderNo).ToList();
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
                                    Documents = Documents.OrderBy(x => x.DocNetPrice).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.DocNetPrice).ToList();
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
                                    Documents = Documents.OrderBy(x => x.Currency).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.Currency).ToList();
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
                                    Documents = Documents.OrderBy(x => x.NetPrice).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.NetPrice).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    //case "POStatus":
                    //    {
                    //        switch (SortOrder)
                    //        {
                    //            case "Asc":
                    //                Documents = Documents.OrderBy(x => x.POStatus).ToList();
                    //                break;
                    //            case "Desc":
                    //                Documents = Documents.OrderByDescending(x => x.POStatus).ToList();
                    //                break;
                    //            default:
                    //                break;
                    //        }

                    //    }
                    //    break;


                    case "Organization":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.Organization).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.Organization).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;


                    case "Warehouse":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.Warehouse).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.Warehouse).ToList();
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
                                    Documents = Documents.OrderBy(x => x.VendorCode).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.VendorCode).ToList();
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
                                    Documents = Documents.OrderBy(x => x.VendorName).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.VendorName).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "Vendoremail":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.Vendoremail).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.Vendoremail).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "BuyerCode":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.BuyerCode).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.BuyerCode).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "BuyerName":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.BuyerName).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.BuyerName).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;



                    default:
                        Documents = Documents.OrderBy(x => x.POType).ToList();
                        break;
                }
                ViewBag.Totalpages = Math.Ceiling(Documents.Count() / clsGeneral.pagingCountDecimal);


                //ViewBag.Totalpages = IsPOIssued == 1 ? 
                //    Math.Ceiling(ObjBs.GetALL().Where(x => x.POStatus == "A" & x.IsPOIssued==true & x.BuyerName == User.Identity.Name && x.PurchaseOrderNo.ToLower().Contains(Search.ToLower())).Count() / 10.0):
                //    Math.Ceiling(ObjBs.GetALL().Where(x => x.POStatus == "A" & x.IsPOIssued != true & x.BuyerName == User.Identity.Name && x.PurchaseOrderNo.ToLower().Contains(Search.ToLower())).Count() / 10.0);


                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;

                Documents = Documents.Skip((page - 1) * clsGeneral.pagingCountInt).Take(clsGeneral.pagingCountInt);

                return View(Documents);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PurchaseOrder", "Index", clsGeneral.errorMessage(ex));
                return View();
            }
        }

        public ActionResult IssueWithOutMail(int id, int IsPOIssued, string SortOrder, string Sortby, string Page)
        {
            try
            {
                var purchaseOrders = ObjBs.GetbyID(id);
                purchaseOrders.IsPOIssued = true;
                purchaseOrders.POIssuedBy = User.Identity.Name;
                purchaseOrders.POIssuedDate = DateTime.Now;
                ObjBs.Update(purchaseOrders);
                bool check = ObjBs.IsPrmailExists(purchaseOrders.PurchaseOrderNo, Convert.ToInt32(purchaseOrders.DocID));
                if (!check)
                    TempData["alert"] = "not available";
                SendMailService.SentPOMail(purchaseOrders, string.Empty, string.Format("Purchase Order By Fujitec Singapore:{0} issued to {1}", purchaseOrders.PurchaseOrderNo, purchaseOrders.VendorName), true);
                TempData["Msg"] = "PO Issued Successfully.";
                return RedirectToAction("Index", new { IsPOIssued = IsPOIssued, SortOrder = SortOrder, Sortby = Sortby, Page = Page });
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PurchaseOrder", "IssueWithOutMail", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult RouteDocNo(long docId, string docNo, string type, int IsPoIssued, int Page)
        {
            try
            {
                //ViewBag.PRid = id;
                Session["PRid"] = docNo;

                if (string.Equals(type, "PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetSPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = 0, type = "PurchaseOrder", IsPoIssued = IsPoIssued, Page = Page, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "Stock PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = 0, type = "PurchaseOrder", IsPoIssued = IsPoIssued, Page = Page, area = "Admin", AppLevel = 0 });
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PurchaseOrder", "RouteDocNo", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult CancelDocument(int id, int IsPOIssued, string SortOrder, string Sortby, string Page, string Search)
        {
            try
            {
                var document = ObjdocBs.GetbyID(id);
                document.Status = "I";
                ObjdocBs.Update(document);

                var documentwf = ObjwfBs.GetDocuemtWorkFlow(id);
                foreach (var docwf in documentwf)

                {
                    docwf.Status = "I";
                    ObjwfBs.Update(docwf);
                }
                ObjBs.Delete(id);

                return RedirectToAction("Index", new
                {
                    IsPOIssued = IsPOIssued,
                    SortOrder = SortOrder,
                    Sortby = Sortby,
                    page = Page,
                    Search = Search
                });
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PurchaseOrder", "CancelDocument", clsGeneral.errorMessage(ex));
                return null;
            }
        }
    }
}