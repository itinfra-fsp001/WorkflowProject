using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.ViewModel;


namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "ServiceAdmin")]
    public class EInvoiceController : Controller
    {
        // GET: User/EInvoice

        private EInvoiceBs objBs;
        public EInvoiceViewModal viewModal;
        public EInvoiceController()
        {
            objBs = new EInvoiceBs();
            viewModal = new EInvoiceViewModal();
        }
        public ActionResult Index(string status, string invoicetype, string organization, string period, string customername, string sortOrder, string sortBy, string page, string pageSize)
        {
            viewModal.invoiceType.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });
            viewModal.organization.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });
            viewModal.period.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });

            status = (string.IsNullOrEmpty(status) ? "N" : status);
            page = (string.IsNullOrEmpty(page) ? "1" : page);
            pageSize = (string.IsNullOrEmpty(pageSize) ? "50" : pageSize);

            ViewData["Status"] = status;
            ViewData["InvoiceType"] = invoicetype;
            ViewData["Organization"] = organization;
            ViewData["Period"] = period;
            ViewData["CustomerName"] = clsGeneral.searchStringDecrypt(customername);
            ViewData["Pagesize"] = pageSize;
            ViewData["Page"] = page;
            ViewData["SortOrder"] = sortOrder;
            ViewData["SortBy"] = sortBy;
            ViewData["Status"] = status;

            viewModal.customerName = clsGeneral.searchStringDecrypt(customername);
            viewModal.organizationName = organization;
            viewModal.periodName = period;
            viewModal.invoiceTypeName = invoicetype;
            //TempData["QryStr"] = "123";

            if (status == "N" || status == "P")
            {


                var taxInvoice = objBs.GetServiceTaxInvoiceList(status, clsGeneral.checkandReplace(customername), period, invoicetype, organization, clsGeneral.getLastThreeMonthsPeriod(status));

                string orgStatus = "New";
                orgStatus = (status == "P" ? "Processed" : orgStatus);

                var taxInvoiceAll = objBs.GetAllInvoiceByStatus(orgStatus, clsGeneral.getLastThreeMonthsPeriod(status));
                foreach (string item in taxInvoiceAll.Select(x => x.InvoiceType).Distinct())
                {
                    viewModal.invoiceType.Add(new SelectListItem { Text = item, Value = item });
                }
                foreach (string item in taxInvoiceAll.Select(x => x.Organization).Distinct())
                {
                    viewModal.organization.Add(new SelectListItem { Text = item, Value = item });
                }
                foreach (string item in taxInvoiceAll.Select(x => x.Period).Distinct())
                {
                    viewModal.period.Add(new SelectListItem { Text = item, Value = item });
                }

                var invoiceList = taxInvoice.ToList();

                switch (sortBy)
                {
                    case "InvoiceNo":
                        switch (sortOrder)
                        {
                            case "Asc":
                                invoiceList = invoiceList.OrderBy(x => x.InvoiceNo).ToList();
                                break;
                            case "Desc":
                                invoiceList = invoiceList.OrderByDescending(x => x.InvoiceNo).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "InvoiceType":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.InvoiceType).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.InvoiceType).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "Organization":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.Organization).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.Organization).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;



                    case "Period":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.Period).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.Period).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "InvoiceDate":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.InvoiceDate).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.InvoiceDate).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "CustomerName":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.CustomerName).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.CustomerName).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "InvoiceAmount":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.InvoiceAmount).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.InvoiceAmount).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "InvoiceStatus":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.InvoiceStatus).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.InvoiceStatus).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;



                    case "DocGenStatus":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.DocGenStatus).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.DocGenStatus).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;


                    case "InvoiceGenStatus":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.InvoiceGenStatus).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.InvoiceGenStatus).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "IsInvoiceIssued":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.IsInvoiceIssued).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.IsInvoiceIssued).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "InvoiceIssuedBy":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.InvoiceIssuedBy).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.InvoiceIssuedBy).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "InvoiceIssuedDate":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.InvoiceIssuedDate).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.InvoiceIssuedDate).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "UpdatedBy":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.UpdateBy).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.UpdateBy).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "UpdatedDate":
                        {
                            switch (sortOrder)
                            {
                                case "Asc":
                                    invoiceList = invoiceList.OrderBy(x => x.UpdateDate).ToList();
                                    break;
                                case "Desc":
                                    invoiceList = invoiceList.OrderByDescending(x => x.UpdateDate).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    default:
                        invoiceList = invoiceList.OrderBy(x => x.CustomerName).ToList();
                        break;
                }

                ViewData["Totalpages"] = Math.Ceiling(invoiceList.Count() / Convert.ToDecimal(pageSize));
                int pageNo = int.Parse(page == null ? "1" : page);
                ViewData["Page"] = pageNo;
                invoiceList = invoiceList.Skip((pageNo - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize)).ToList();
                viewModal.invoiceList = invoiceList;
            }
            return View(viewModal);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult GoToSendInvoice(EInvoiceViewModal eIVM, string Command)
        {
            try
            {
                if (Command == "Issue")
                {
                    string[] invList = eIVM.invoiceSelectedList.Split(',');
                    Array.Sort(invList);

                    TempData["QryStr"] = string.Join(",", invList);
                    return RedirectToAction("Index", new { Controller = "SendEInvoice", status = "N", logId = "" });
                }
                else if (Command == "Exception")
                {
                    objBs.markAsException(eIVM.invoiceSelectedList, User.Identity.Name);
                    TempData["Msg"] = "Selected invoice(s) marked as exception successfully";
                    return RedirectToAction("Index", new { status = "S", logId = "" });
                }

                return null;
            }
            catch (Exception ex)
            {
                TempData["Msg"] = Convert.ToString(ex.Message);
                return RedirectToAction("Index", new { status = "E", logId = "" });
            }

        }
    }
}