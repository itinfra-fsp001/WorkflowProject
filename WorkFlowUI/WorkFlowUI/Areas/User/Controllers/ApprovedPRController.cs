using BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "PCVUser")]
    public class ApprovedPRController : Controller
    {
        private DocumentBs ObjBs;

        private DocumentWorkfFlowBs ObjwfBs;
        private string docLocation;
        private string Erpdoclocation;

        public ApprovedPRController()
        {
            ObjBs = new DocumentBs();
            ObjwfBs = new DocumentWorkfFlowBs();
            docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
            Erpdoclocation = ConfigurationManager.AppSettings["ERPDocLocation"].ToString();

        }
        // GET: User/ApprovedPR
        public ActionResult Index(string Status, string SortOrder, string Sortby, string Page, string Search, string DocType, string VendorName)
        {

            try
            {

                //ViewBag.Doctype = (DocType == null ? "PR" : DocType);
                Status = (string.IsNullOrEmpty(Status) ? "A" : Status);
                SortOrder = (string.IsNullOrEmpty(SortOrder) ? "Desc" : SortOrder);
                Sortby = (string.IsNullOrEmpty(Sortby) ? "UpdateDate" : Sortby);
                Page = (string.IsNullOrEmpty(Page) ? "1" : Page);
                Search = (string.IsNullOrEmpty(Search) ? string.Empty : Search);
                DocType = (string.IsNullOrEmpty(DocType) ? string.Empty : DocType);
                VendorName = (string.IsNullOrEmpty(VendorName) ? string.Empty : VendorName);

                ViewBag.Status = Status;
                ViewBag.SortOrder = SortOrder;
                ViewBag.Sortby = Sortby;               
                ViewData["Search"] = clsGeneral.searchStringDecrypt(Search);                
                ViewData["VendorName"] = clsGeneral.searchStringDecrypt(VendorName);

               

                IEnumerable<BOL.tbl_Documents> Documents = ObjBs.GetALLPR(Status, clsGeneral.checkandReplace(Search), clsGeneral.checkandReplace(VendorName));

                //if (Status == null)
                //{
                //    Documents = ObjBs.GetALL().Where(x => x.Status == "A" && x.UpdateDate >= DateTime.Now.AddDays(-90) && x.DocType == "PR" && Convert.ToString(x.DocNo).ToLower().Contains(Search.ToLower()) && (string.IsNullOrEmpty(x.VendorName) ? x.VendorName != null : Convert.ToString(x.VendorName).ToLower().Contains(VendorName.ToLower())));
                //}
                //else if (Status == "P")
                //{
                //    Documents = ObjBs.GetALL().Where(x => (x.Status == "P" || x.Status == "H") && x.DocType != "SB" && x.UpdateDate >= DateTime.Now.AddDays(-90) && Convert.ToString(x.DocNo).ToLower().Contains(Search.ToLower()) && (string.IsNullOrEmpty(x.VendorName) ? true : Convert.ToString(x.VendorName).ToLower().Contains(VendorName.ToLower())));
                //}
                //else
                //{
                //    Documents = Status == "A" ? ObjBs.GetALL().Where(x => x.Status == Status && x.DocType == "PR" && x.UpdateDate >= DateTime.Now.AddDays(-90) && Convert.ToString(x.DocNo).ToLower().Contains(Search.ToLower()) && (string.IsNullOrEmpty(x.VendorName) ? true : Convert.ToString(x.VendorName).ToLower().Contains(VendorName.ToLower()))) :
                //                                ObjBs.GetALL().Where(x => x.Status == Status && x.DocType != "SB" && x.UpdateDate >= DateTime.Now.AddDays(-90) && Convert.ToString(x.DocNo).ToLower().Contains(Search.ToLower()) && (string.IsNullOrEmpty(x.VendorName) ? true : Convert.ToString(x.VendorName).ToLower().Contains(VendorName.ToLower())));
                //}


                switch (Sortby)
                {
                    case "DocType":
                        switch (SortOrder)
                        {
                            case "Asc":
                                Documents = Documents.OrderBy(x => x.DocType).ToList();
                                break;
                            case "Desc":
                                Documents = Documents.OrderByDescending(x => x.DocType).ToList();
                                break;
                            default:
                                break;
                        }
                        break;

                    case "DocNo":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.DocNo).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.DocNo).ToList();
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





                    case "SubmitBy":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.SubmitBy).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.SubmitBy).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;


                    case "SubmitDate":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.SubmitDate).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.SubmitDate).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "AttachDoc":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.AttachDoc).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.AttachDoc).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "AddAttachDoc1":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.AddAttachDoc1).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.AddAttachDoc1).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "AddAttachDoc2":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.AddAttachDoc2).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.AddAttachDoc2).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "AddAttachDoc3":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.AddAttachDoc3).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.AddAttachDoc3).ToList();
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;

                    case "UpdateDate":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.UpdateDate).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.UpdateDate).ToList();
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

                    default:
                        Documents = Documents.OrderByDescending(x => x.UpdateDate).ToList();
                        break;
                }
                ViewBag.Totalpages = Math.Ceiling(Documents.Count() / clsGeneral.pagingCountDecimal);
                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;
                Documents = Documents.Skip((page - 1) * clsGeneral.pagingCountInt).Take(clsGeneral.pagingCountInt);
                return View(Documents);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "ApprovedPR", "Index", clsGeneral.errorMessage(ex));
                return View();
            }
        }

        #region Old Code
        //            else
        //            {


        //                var Documents = Status == "A" ? ObjBs.GetALL().Where(x => x.Status == Status && x.DocType == "PR" && x.UpdateDate >= DateTime.Now.AddDays(-90) && x.DocNo.ToLower().Contains(Search.ToLower())) :
        //             ObjBs.GetALL().Where(x => x.Status == Status && x.DocType != "SB" && x.UpdateDate >= DateTime.Now.AddDays(-90) && x.DocNo.ToLower().Contains(Search.ToLower()));


        //                switch (Sortby)
        //                {
        //                    case "DocType":
        //                        switch (SortOrder)
        //                        {
        //                            case "Asc":
        //                                Documents = Documents.OrderBy(x => x.DocType).ToList();
        //                                break;
        //                            case "Desc":
        //                                Documents = Documents.OrderByDescending(x => x.DocType).ToList();
        //                                break;
        //                            default:
        //                                break;
        //                        }
        //                        break;

        //                    case "DocNo":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.DocNo).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.DocNo).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;

        //                    case "DocNetPrice":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.DocNetPrice).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.DocNetPrice).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;

        //                    case "Currency":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.Currency).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.Currency).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;

        //                    case "NetPrice":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.NetPrice).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.NetPrice).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;



        //                    case "SubmitBy":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.SubmitBy).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.SubmitBy).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;


        //                    case "SubmitDate":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.SubmitDate).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.SubmitDate).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;
        //                    case "AttachDoc":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.AttachDoc).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.AttachDoc).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;
        //                    case "AddAttachDoc1":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.AddAttachDoc1).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.AddAttachDoc1).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;
        //                    case "AddAttachDoc2":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.AddAttachDoc2).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.AddAttachDoc2).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;
        //                    case "AddAttachDoc3":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.AddAttachDoc3).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.AddAttachDoc3).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;

        //                    case "UpdateDate":
        //                        {
        //                            switch (SortOrder)
        //                            {
        //                                case "Asc":
        //                                    Documents = Documents.OrderBy(x => x.UpdateDate).ToList();
        //                                    break;
        //                                case "Desc":
        //                                    Documents = Documents.OrderByDescending(x => x.UpdateDate).ToList();
        //                                    break;
        //                                default:
        //                                    break;
        //                            }

        //                        }
        //                        break;



        //                    default:
        //                        Documents = Documents.OrderByDescending(x => x.UpdateDate).ToList();
        //                        break;
        //                }
        //                //ViewBag.Totalpages = Math.Ceiling(Documents.Count() / 10.0);

        //                ViewBag.Totalpages = Status == "A" ? Math.Ceiling(ObjBs.GetALL().Where(x => x.Status == Status && x.DocType == "PR" && x.UpdateDate >= DateTime.Now.AddDays(-90) && x.DocNo.ToLower().Contains(Search.ToLower())).Count() / 10.0) :
        //                     Math.Ceiling(ObjBs.GetALL().Where(x => x.Status == Status && x.DocType != "SB" && x.UpdateDate >= DateTime.Now.AddDays(-90) && x.DocNo.ToLower().Contains(Search.ToLower())).Count() / 10.0);

        //                int page = int.Parse(Page == null ? "1" : Page);
        //ViewBag.Page = page;

        //                Documents = Documents.Skip((page - 1) * 10).Take(10);

        //                return View(Documents);

        //            }
        //}
        #endregion

        public ActionResult RouteDocNo(long docId, string docNo, string type, string Status, int Page)
        {
            try
            {

                //ViewBag.PRid = id;
                Session["PRid"] = docNo;

                if (string.Equals(type, "PR", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "MiscPRCoa", new { docId = docId, docNo = docNo, workFlowId = 0, type = "ApprovedPR", Status = Status, Page = Page, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetSPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = 0, type = "ApprovedPR", Status = Status, IsPOIssued = 0, Page = Page, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "Stock PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = 0, type = "ApprovedPR", Status = Status, IsPOIssued = 0, Page = Page, area = "Admin", AppLevel = 0 });
                }

                else
                {
                    return new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "ApprovedPR", "RouteDocNo", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult GetDocument(string docNo, string name, bool erpattach)
        {
            try
            {
                string filePath;
                //var name = "91197705_20161006_0123.pdf";
                //  string docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
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
                    filePath = Path.Combine(Server.MapPath("~/Upload Documents/"), name);
                    if (!System.IO.File.Exists(filePath))
                    {
                        return new EmptyResult();
                    }
                }
                //var dbCommands = session.Advanced.DatabaseCommands;
                // var attachment = dbCommands.GetAttachment(id);
                byte[] filedata = System.IO.File.ReadAllBytes(filePath);
                //   Response.AppendHeader("Content-Disposition", "inline;filename=91197705_20161006_0123.pdf");
                //return File(filedata, "application/pdf");
                string mimeType = MimeMapping.GetMimeMapping(filePath);
                //if (mimeType == "application/pdf")
                //return File(filedata, "application/filetype");
                //else
                return File(filedata, mimeType, name);
                //  var stream = new MemoryStream(filedata);
                // return new FileStreamResult(stream, name);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "ApprovedPR", "GetDocument", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult CancelDocument(int id, string Status, string SortOrder, string Sortby, string Page, string Search)
        {
            try
            {
                var document = ObjBs.GetbyID(id);
                document.Status = "I";
                ObjBs.Update(document);

                var documentwf = ObjwfBs.GetDocuemtWorkFlow(id);
                foreach (var docwf in documentwf)

                {
                    docwf.Status = "I";
                    ObjwfBs.Update(docwf);
                }

                return RedirectToAction("Index", new
                {
                    Status = Status,
                    SortOrder = SortOrder,
                    Sortby = Sortby,
                    page = Page,
                    Search = Search
                });
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "ApprovedPR", "CancelDocument", clsGeneral.errorMessage(ex));
                return null;
            }
        }


    }
}