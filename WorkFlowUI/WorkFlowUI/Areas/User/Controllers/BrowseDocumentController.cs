using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "User,PCVUser,PCVUser2,ServiceAdmin,ServiceEngineer")]
    //[Authorize(Roles = "PCVUser")]
    public class BrowseDocumentController : Controller
    {

        private DocumentBs ObjBs;
        //  private CommonBs CmnBs;
        private DocumentWorkfFlowBs ObjWFBs;
        private string docLocation;
        private string Erpdoclocation;
        private fspDocumentBs ObjfspBs;
        private fspDocumentDetailsBs ObjfspdtlBs;

        private UserBs ObjUserBs;
        public BrowseDocumentController()
        {
            ObjBs = new DocumentBs();
            //  CmnBs = new CommonBs();
            ObjWFBs = new DocumentWorkfFlowBs();
            ObjfspBs = new fspDocumentBs();
            ObjfspdtlBs = new fspDocumentDetailsBs();
            ObjUserBs = new UserBs();
            docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
            Erpdoclocation = ConfigurationManager.AppSettings["ERPDocLocation"].ToString();
        }


        // GET: Common/BrowseDocument
        public ActionResult Index(string Status, string SortOrder, string Sortby, string Page, string Search, string Pagesize)
        {
            try
            {

                Status = (string.IsNullOrEmpty(Status) ? "N" : Status);
                Page = (string.IsNullOrEmpty(Page) ? "1" : Page);
                Pagesize = (string.IsNullOrEmpty(Pagesize) ? Convert.ToString(clsGeneral.pagingCountInt) : Pagesize);
                Search = (string.IsNullOrEmpty(Search) ? string.Empty : Search);
                SortOrder = (string.IsNullOrEmpty(SortOrder) ? "Desc" : SortOrder);
                Sortby = (string.IsNullOrEmpty(Sortby) ? "SubmitDate" : Sortby);


                ViewBag.Status = Status;
                ViewBag.SortOrder = SortOrder;
                ViewBag.Sortby = Sortby;
                ViewBag.User = User.Identity.Name;
                ViewBag.IsSuperUser = false;
                var userRole = ObjUserBs.GetRoleByID(User.Identity.Name);
                if (userRole != null && userRole.Count() > 0)
                {
                    foreach (BOL.tbl_UserRoles item in userRole)
                    {
                        if (item.Role == "Superuser")
                        {
                            ViewBag.IsSuperUser = true;
                            break;
                        }
                    }
                }
                ViewData["Search"] = clsGeneral.searchStringDecrypt(Search);
                ViewData["Pagesize"] = Pagesize;
                ViewData["Page"] = Page;
                var Documents = ObjBs.GetSubmittedDocuments(User.Identity.Name, Status, clsGeneral.checkandReplace(Search));
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

                    case "VendorCategory":
                        {
                            switch (SortOrder)
                            {
                                case "Asc":
                                    Documents = Documents.OrderBy(x => x.VendorCategory).ToList();
                                    break;
                                case "Desc":
                                    Documents = Documents.OrderByDescending(x => x.VendorCategory).ToList();
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


                    default:
                        Documents = Documents.OrderBy(x => x.SubmitDate).ToList();
                        //  Documents = Documents.OrderBy(x => x.DocType).ToList();
                        break;
                }

                //x.SubmitBy == User.Identity.Name || x.IssueBy == User.Identity.Name

                ViewBag.Totalpages = Math.Ceiling(Documents.Count() / Convert.ToDecimal(Pagesize));

                int page = int.Parse(Page == null ? "1" : Page);
                ViewBag.Page = page;

                Documents = Documents.Skip((page - 1) * Convert.ToInt32(Pagesize)).Take(Convert.ToInt32(Pagesize));

                return View(Documents);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseDocument", "Index", clsGeneral.errorMessage(ex));
                return View();
            }


            #region Old Code

            //List<string> userList = new List<string>();
            //userList.Add(User.Identity.Name);
            //var userRole = ObjUserBs.GetRoleByID(User.Identity.Name);

            //if (userRole != null && userRole.Role == "Superuser")
            //{
            //    //ViewBag.IsSuperUser = true;
            //    //var users = ObjUserBs.GetALL();

            //    //string[] deptcode = null;
            //    //foreach (var item in users)
            //    //{
            //    //    if (item.UserId == User.Identity.Name)
            //    //    {
            //    //        deptcode = Convert.ToString(item.DeptCode).Split(',');
            //    //        break;
            //    //    }
            //    //}

            //    //if (deptcode != null)
            //    //{
            //    //    foreach (var item in users)
            //    //    {
            //    //        if (Array.IndexOf(deptcode, item.DeptCode) >= 0)
            //    //        {
            //    //            userList.Add(item.UserId);
            //    //        }
            //    //    }
            //    //}

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
            //    if (!string.IsNullOrEmpty(userRole.Departments))
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



            ////x.SubmitBy == User.Identity.Name
            ////x.IssueBy == User.Identity.Name
            //if (Status == null)
            //{
            //    var Documents = ObjBs.GetALL().Where(x => x.Status == "N" && (Array.IndexOf(userList.ToArray(), x.SubmitBy) >= 0 || Array.IndexOf(userList.ToArray(), x.IssueBy) >= 0) && x.UpdateDate >= DateTime.Now.AddDays(-90) && x.DocNo.ToLower().Contains(Search.ToLower()));

            //    switch (Sortby)
            //    {
            //        case "DocType":
            //            switch (SortOrder)
            //            {
            //                case "Asc":
            //                    Documents = Documents.OrderBy(x => x.DocType).ToList();
            //                    break;
            //                case "Desc":
            //                    Documents = Documents.OrderByDescending(x => x.DocType).ToList();
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;

            //        case "DocNo":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.DocNo).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.DocNo).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;
            //        case "DocNetPrice":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.DocNetPrice).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.DocNetPrice).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;



            //        case "Currency":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.Currency).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.Currency).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "NetPrice":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.NetPrice).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.NetPrice).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "VendorCode":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.VendorCode).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.VendorCode).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "VendorName":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.VendorName).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.VendorName).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "VendorCategory":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.VendorCategory).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.VendorCategory).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;



            //        case "SubmitBy":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.SubmitBy).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.SubmitBy).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;


            //        case "SubmitDate":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.SubmitDate).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.SubmitDate).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "AttachDoc":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.AttachDoc).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.AttachDoc).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;
            //        case "AddAttachDoc1":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.AddAttachDoc1).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.AddAttachDoc1).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;
            //        case "AddAttachDoc2":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.AddAttachDoc2).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.AddAttachDoc2).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;
            //        case "AddAttachDoc3":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.AddAttachDoc3).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.AddAttachDoc3).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;


            //        default:
            //            Documents = Documents.OrderBy(x => x.SubmitDate).ToList();
            //            //  Documents = Documents.OrderBy(x => x.DocType).ToList();
            //            break;
            //    }

            //    //x.SubmitBy == User.Identity.Name || x.IssueBy == User.Identity.Name

            //    ViewBag.Totalpages = Math.Ceiling(ObjBs.GetALL().Where(x => x.Status == "N" && (Array.IndexOf(userList.ToArray(), x.SubmitBy) >= 0 || Array.IndexOf(userList.ToArray(), x.IssueBy) >= 0) && x.UpdateDate >= DateTime.Now.AddDays(-90) && x.DocNo.ToLower().Contains(Search.ToLower())).Count() / clsGeneral.pagingCountDecimal);

            //    int page = int.Parse(Page == null ? "1" : Page);
            //    ViewBag.Page = page;

            //    Documents = Documents.Skip((page - 1) * clsGeneral.pagingCountInt).Take(clsGeneral.pagingCountInt);

            //    return View(Documents);
            //}
            //else
            //{
            //    //x.SubmitBy == User.Identity.Name
            //    //x.IssueBy == User.Identity.Name
            //    var Documents = ObjBs.GetALL().Where(x => (Status == "A" ? (x.Status == "A" || x.Status == "I") : x.Status == Status) && (Array.IndexOf(userList.ToArray(), x.SubmitBy) >= 0 || Array.IndexOf(userList.ToArray(), x.IssueBy) >= 0)
            //                                        && (Status == "A" ? x.UpdateDate >= DateTime.Now.AddDays(-30) : x.UpdateDate >= DateTime.Now.AddDays(-90)) && x.DocNo.ToLower().Contains(Search.ToLower()));

            //    switch (Sortby)
            //    {
            //        case "DocType":
            //            switch (SortOrder)
            //            {
            //                case "Asc":
            //                    Documents = Documents.OrderBy(x => x.DocType).ToList();
            //                    break;
            //                case "Desc":
            //                    Documents = Documents.OrderByDescending(x => x.DocType).ToList();
            //                    break;
            //                default:
            //                    break;
            //            }
            //            break;

            //        case "DocNo":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.DocNo).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.DocNo).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "DocNetPrice":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.DocNetPrice).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.DocNetPrice).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "Currency":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.Currency).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.Currency).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "NetPrice":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.NetPrice).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.NetPrice).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "VendorCode":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.VendorCode).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.VendorCode).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "VendorName":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.VendorName).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.VendorName).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "VendorCategory":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.VendorCategory).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.VendorCategory).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;



            //        case "SubmitBy":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.SubmitBy).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.SubmitBy).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;


            //        case "SubmitDate":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.SubmitDate).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.SubmitDate).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;

            //        case "AttachDoc":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.AttachDoc).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.AttachDoc).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;
            //        case "AddAttachDoc1":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.AddAttachDoc1).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.AddAttachDoc1).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;
            //        case "AddAttachDoc2":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.AddAttachDoc2).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.AddAttachDoc2).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;
            //        case "AddAttachDoc3":
            //            {
            //                switch (SortOrder)
            //                {
            //                    case "Asc":
            //                        Documents = Documents.OrderBy(x => x.AddAttachDoc3).ToList();
            //                        break;
            //                    case "Desc":
            //                        Documents = Documents.OrderByDescending(x => x.AddAttachDoc3).ToList();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //            }
            //            break;


            //        default:
            //            Documents = Documents.OrderBy(x => x.SubmitDate).ToList();
            //            // Documents = Documents.OrderBy(x => x.DocType).ToList();
            //            break;
            //    }


            //    //x.SubmitBy == User.Identity.Name || x.IssueBy == User.Identity.Name

            //    ViewBag.Totalpages = Math.Ceiling(ObjBs.GetALL().Where(x => (Status == "A" ? (x.Status == "A" || x.Status == "I") : x.Status == Status) && (Array.IndexOf(userList.ToArray(), x.SubmitBy) >= 0 || Array.IndexOf(userList.ToArray(), x.IssueBy) >= 0)
            //                                                              && (Status == "A" ? x.UpdateDate >= DateTime.Now.AddDays(-30) : x.UpdateDate >= DateTime.Now.AddDays(-90)) && x.DocNo.ToLower().Contains(Search.ToLower())).Count() / clsGeneral.pagingCountDecimal);

            //    int page = int.Parse(Page == null ? "1" : Page);
            //    ViewBag.Page = page;
            //    Documents = Documents.Skip((page - 1) * clsGeneral.pagingCountInt).Take(clsGeneral.pagingCountInt);
            //    return View(Documents);
            //}

            #endregion
        }
        public ActionResult BulkSubmit(string Ids)
        {
            try
            {
                if (!ObjUserBs.isEmailIdExits(User.Identity.Name))
                {
                    TempData["Msg"] = "Unable to Submit : Email ID doesnot exists";
                    return RedirectToAction("Index");
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<int> lt = js.Deserialize<List<int>>(Ids);

                string docIdList = null;
                foreach (int docId in lt)
                {
                    docIdList = (string.IsNullOrEmpty(docIdList) ? Convert.ToString(docId) : docIdList + "," + docId);
                }

                rfqSPResult spResult = ObjBs.validateDocument(docIdList);
                if (!spResult.result)
                {
                    TempData["Msg"] = Convert.ToString(spResult.name);
                    return RedirectToAction("Index");
                }

                string statusStr = "";
                foreach (int docId in lt)
                {
                    var document = ObjBs.GetbyID(docId);
                    statusStr = statusStr + SubmitAndSendMail(document, User.Identity.Name);
                }
                TempData["Msg"] = (string.IsNullOrEmpty(statusStr) ? "All Documnets Submitted Successfully" : statusStr);
                //TempData["Msg"] = "Submitted Successfully";
                return RedirectToAction("Index");
                // return new EmptyResult();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseDocument", "BulkSubmit", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult MergeDoc(string Ids)
        {
            try
            {
                if (!ObjUserBs.isEmailIdExits(User.Identity.Name))
                {
                    TempData["Msg"] = "Unable to Submit : Email ID doesnot exists";
                    return RedirectToAction("Index");
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<int> lt = js.Deserialize<List<int>>(Ids);
                string docIDList = "";
                foreach (int docId in lt)
                {
                    docIDList += docId + ",";
                    //var document = ObjBs.GetbyID(docId);
                    //statusStr = statusStr + SubmitAndSendMail(document, User.Identity.Name);
                }

                rfqSPResult isGet = ObjBs.validatePR(docIDList);
                if (isGet.result)
                {
                    isGet = ObjBs.mergePR(docIDList, User.Identity.Name);
                    if (isGet.result)
                    {
                        TempData["Msg"] = "Merged successfully. Document No. is " + isGet.name + ". Summary document will be available after 2 minutes. Please refresh the screen after 2 minutes.";
                    }
                    else
                    {
                        TempData["Msg"] = "Processed with errors : " + isGet.name;
                    }
                }
                else
                {
                    TempData["Msg"] = "Unable to Process for Merging : " + isGet.name;
                }
                //TempData["Msg"] = "Submitted Successfully";
                return RedirectToAction("Index");
                // return new EmptyResult();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseDocument", "MergeDoc", clsGeneral.errorMessage(ex));
                return null;
            }


        }

        private string SubmitAndSendMail(tbl_Documents document, string submitBy)
        {
            try
            {
                string isRet = "";
                var docwf = ObjWFBs.GetDocuemtWorkFlow(document.DocID).ToList();
                if (docwf != null && docwf.Count() > 0)
                {
                    try
                    {
                        document.Status = "P";
                        document.ApprovalSubmitBy = document.LastApprovalSubmitBy = submitBy;
                        document.ApprovalSubmitDate = document.LastApprovalSubmitDate = DateTime.Now;
                        document.UpdateDate = DateTime.Now;
                        document.UpdateBy = submitBy;

                        ObjBs.Update(document);
                        //---------------------------------------------------------
                        var fspdocument = ObjfspBs.GetALL().Where(x => x.DocID == document.DocID).ToList();
                        if (fspdocument != null && fspdocument.Count() > 0)
                        {
                            var fspDoc = fspdocument.First();

                            fspDoc.Status = "P";
                            ObjfspBs.Update(fspDoc);
                        }
                        var fspdocumentdtl = ObjfspdtlBs.GetALL().Where(x => x.DocID == document.DocID).ToList();
                        if (fspdocumentdtl != null && fspdocumentdtl.Count() > 0)
                        {
                            foreach (var fspdocdtl in fspdocumentdtl)
                            {
                                fspdocdtl.Status = "P";
                                ObjfspdtlBs.Update(fspdocdtl);
                            }
                        }
                        //----------------------------------------------------          
                        var documentWf = ObjWFBs.GetALL().Where(x => x.DocID == document.DocID & x.Sequence == 1 & x.ApprovalLevel == "L1" & x.Status == "N").ToList();
                        var wf = documentWf.First();
                        wf.Status = "P";
                        wf.Submitdate = DateTime.Now;
                        ObjWFBs.Update(wf);
                        SendMailService.SendStatusToService(wf);
                        isRet = document.DocNo + " : Submitted Successfully\\n\\n"; ;
                    }
                    catch (Exception ex)
                    {
                        BLL.clsLog.insertLog(User.Identity.Name, "BrowseDocument", "SubmitAndSendMail", "Error : " + document.DocNo + ", " + clsGeneral.errorMessage(ex));
                        isRet = document.DocNo + " : Error : Submitted with errors\\n\\n";
                    }
                }
                else
                {
                    isRet = document.DocNo + " : Not Submitted : No workflow found\\n\\n";
                }
                return isRet;
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseDocument", "SubmitAndSendMail", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult RouteDocNo(int docId, string docNo, string type, string Status, int Page)
        {
            try
            {
                //ViewBag.PRid = id;
                Session["PRid"] = docId;
                if (string.Equals(type, "SB", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "SBDetails", new { docId = docId, docNo = docNo, workFlowId = 0, type = "BrowseDocument", Status = Status, Page = Page, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "PR", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index", "MiscPRCoa", new { docId = docId, docNo = docNo, workFlowId = 0, type = "BrowseDocument", Status = Status, Page = Page, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetSPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = 0, type = "BrowseDocument", Status = Status, IsPOIssued = 0, Page = Page, area = "Admin", AppLevel = 0 });
                }
                else if (string.Equals(type, "Stock PO", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("GetPo", "PoSpo", new { docId = docId, docNo = docNo, workFlowId = 0, type = "BrowseDocument", Status = Status, IsPOIssued = 0, Page = Page, area = "Admin", AppLevel = 0 });
                }
                else
                {
                    return new EmptyResult();
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseDocument", "RouteDocNo", clsGeneral.errorMessage(ex));
                return null;
            }
        }
        public ActionResult DeleteDocument(int id, string Status, string SortOrder, string Sortby, string Page, string Search)
        {
            try
            {
                var document = ObjBs.GetbyID(id);
                document.Status = "D";
                document.UpdateBy = User.Identity.Name;
                document.UpdateDate = DateTime.Now;
                ObjBs.Update(document);

                if (Convert.ToBoolean(document.IsSummaryDoc))
                {
                    var isRet = ObjBs.updateSummaryDoc(Convert.ToInt32(document.DocID), "D", User.Identity.Name);
                }
                else
                {
                    var fspdocument = ObjfspBs.GetALL().Where(x => x.DocID == document.DocID).ToList();
                    if(fspdocument !=null && fspdocument.Count>0)
                    {
                        var fspDoc = fspdocument.First();
                        fspDoc.Status = "P";
                        ObjfspBs.Update(fspDoc);
                    }
                   
                    var fspdocumentdtl = ObjfspdtlBs.GetALL().Where(x => x.DocID == document.DocID).ToList();
                    if(fspdocumentdtl!=null && fspdocumentdtl.Count>0)
                    {
                        foreach (var fspdocdtl in fspdocumentdtl)
                        {
                            fspdocdtl.Status = "P";
                            ObjfspdtlBs.Update(fspdocdtl);
                        }
                    }                    
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
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseDocument", "DeleteDocument", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult GetDocument(string docNo, string name, bool erpattach)
        {
            try
            {
                string filePath;

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

                byte[] filedata = System.IO.File.ReadAllBytes(filePath);

                string mimeType = MimeMapping.GetMimeMapping(filePath);

                return File(filedata, mimeType, name);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "BrowseDocument", "GetDocument", clsGeneral.errorMessage(ex));
                return null;
            }


        }

        //public ActionResult GetDocument(string docNo, string name, bool erpattach)
        //{
        //    string filePath;

        //    if (!erpattach)
        //    {
        //        filePath = Path.Combine(docLocation, docNo, name);
        //    }
        //    else
        //    {
        //        filePath = Path.Combine(Erpdoclocation, name);
        //    }
        //    //if (!System.IO.File.Exists(filePath))
        //    //{
        //    //    return new EmptyResult();
        //    //}
        //    NetworkCredential theNetworkCredential = new NetworkCredential(@"fsp\appnetsvc", "NetworkService1");
        //    CredentialCache theNetCache = new CredentialCache();
        //    theNetCache.Add(new Uri(Erpdoclocation), "Basic", theNetworkCredential);
        //    byte[] filedata = System.IO.File.ReadAllBytes(filePath);

        //    string mimeType = MimeMapping.GetMimeMapping(filePath);

        //    return File(filedata, mimeType, name);

        //}
    }
}