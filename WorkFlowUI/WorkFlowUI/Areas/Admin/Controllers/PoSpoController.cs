using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using WorkFlowUI.ViewModel;
using WorkFlowUI.App_Start;
using BOL;
using System.Configuration;
using System.IO;

namespace WorkFlowUI.Areas.Admin.Controllers
{
    public class PoSpoController : Controller
    {
        private ERP_POBs poBs;
        private ERP_SubconPOBs spoBs;
        private PoSPoViewModel poSpoVm;
        private CommonBs cmBs;
        private DocumentDetailsBs docdtl;
        private DocumentBudgetBs docbudget;
        private DocumentBs doc;
        private string docLocation;
        private string Erpdoclocation;
        public static string controllerName = "PoSpo";
        public PoSpoController()
        {
            poBs = new ERP_POBs();
            spoBs = new ERP_SubconPOBs();
            poSpoVm = new PoSPoViewModel();
            cmBs = new CommonBs();
            docdtl = new DocumentDetailsBs();
            docbudget = new DocumentBudgetBs();
            doc = new DocumentBs();
            docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
            Erpdoclocation = ConfigurationManager.AppSettings["ERPDocLocation"].ToString();
        }
        // GET: Admin/PoSpo
        public ActionResult GetPo(long docId,string docNo, long workFlowId,string type,string Status,int Page,int AppLevel,int IsPoIssued,bool? prevView)
        {
            try
            {
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t GetPo \t Enter");
                bool prevView1 = prevView ?? false;
                if (prevView1 && Session["GetPo"] != null)
                {
                    NavigationParameter nv = Session["GetPo"] as NavigationParameter;
                    if (nv != null)
                    {
                        docNo = nv.docNo
                    ;
                        docId = nv.docid;
                        workFlowId = nv.workFlowId
                        ;
                        IsPoIssued = nv.IsPoIssued
                        ;
                        Page = nv.Page
                        ;
                        Status = nv.Status
                        ;

                        type = nv.type;
                    }
                }
                poSpoVm.DocStatusVm = CommonCls.GetDocStatus(docId, docNo, workFlowId, AppLevel);
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t GetPo-GetDocStatus \t Exit");

                //var poList = poBs.GetALL(docNo).ToList();
                var poList = docdtl.GetDocuemtDetails(Convert.ToInt32(docId)).ToList();
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t GetPo-GetDocuemtDetails \t Exit");

                poSpoVm.PO = poList;
                var bdgtpoList = docbudget.GetDocumentBudget(Convert.ToInt32(docId)).ToList();
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t GetPo-GetDocumentBudget \t Exit");

                poSpoVm.PObdgt = bdgtpoList;
                // poSpoVm.PO = new List<fsp_ReportPurchaseOrder_sg_Result>(); //poList;
                //poSpoVm.Documents = doc.GetALL().Where(x => x.DocID == (Convert.ToInt32(docId))).ToList();
                poSpoVm.Documents = doc.GetbyIDNew(Convert.ToInt32(docId)).ToList();
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t GetPo-GetDocument \t Exit");

                if (type == "BrowseDocument")
                {
                    ViewBag.Controller = "BrowseDocument";
                    ViewBag.PrevStatus = Status ?? "N";
                }
                else if (type == "ApproveDocument")
                {
                    ViewBag.Controller = "ApproveDocument";
                    ViewBag.PrevStatus = Status ?? "P";
                }
                else if (type == "AltApproveDocument")
                {
                    ViewBag.Controller = "AltApproveDocument";
                    ViewBag.PrevStatus = Status ?? "P";
                }
                else if (type == "PurchaseOrder")
                {
                    ViewBag.Controller = "PurchaseOrder";
                    ViewBag.IsPoIssued = IsPoIssued;

                }
                else if (type == "ApprovedPR")
                {
                    ViewBag.Controller = "ApprovedPR";
                    ViewBag.PrevStatus = Status ?? "P";
                }
                else if (type == "DocumentStatus")
                {
                    ViewBag.Controller = "DocumentStatus";
                }
                ViewBag.Page = Page;
                NavigationParameter navParameter = new NavigationParameter()
                {
                    docNo = docNo
                    ,
                    docid = docId,
                    workFlowId = workFlowId
                    ,
                    IsPoIssued = IsPoIssued
                    ,
                    Page = Page
                    ,
                    Status = Status
                    ,

                    type = type
                };
                Session["GetPo"] = navParameter;
                ViewBag.DocId = docId;
                //poSpoVm.PO = new List<BOL.fsp_ReportPurchaseOrder_sg_Result>();
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t GetPo \t Exit");
                return View(poSpoVm);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PoSpo", "GetPo", clsGeneral.errorMessage(ex));
                return View();
            }            
        }
        public ActionResult GetSPo(long docId,string docNo, long workFlowId,string type, string Status,int Page,int AppLevel,int IsPoIssued,bool? prevView)
        {
            try
            {
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t GetSPo \t Enter");
                bool prevView1 = prevView ?? false;
                if (prevView1 && Session["GetSPo"] != null)
                {
                    NavigationParameter nv = Session["GetSPo"] as NavigationParameter;
                    if (nv != null)
                    {
                        docNo = nv.docNo
                    ;
                        docId = nv.docid;
                        workFlowId = nv.workFlowId
                        ;
                        IsPoIssued = nv.IsPoIssued
                        ;
                        Page = nv.Page
                        ;
                        Status = nv.Status
                        ;
                        type = nv.type;
                    }
                }
                poSpoVm.DocStatusVm = CommonCls.GetDocStatus(docId, docNo, workFlowId, AppLevel);
                if (type == "BrowseDocument")
                {
                    ViewBag.Controller = "BrowseDocument";
                    ViewBag.PrevStatus = Status ?? "N";
                }
                else if (type == "ApproveDocument")
                {
                    ViewBag.Controller = "ApproveDocument";
                    ViewBag.PrevStatus = Status ?? "P";
                }
                else if (type == "AltApproveDocument")
                {
                    ViewBag.Controller = "AltApproveDocument";
                    ViewBag.PrevStatus = Status ?? "P";
                }
                else if (type == "PurchaseOrder")
                {
                    ViewBag.Controller = "PurchaseOrder";
                    ViewBag.IsPoIssued = IsPoIssued;

                }
                else if (type == "ApprovedPR")
                {
                    ViewBag.Controller = "ApprovedPR";
                    ViewBag.PrevStatus = Status ?? "P";
                }
                else if (type == "DocumentStatus")
                {
                    ViewBag.Controller = "DocumentStatus";
                }
                ViewBag.Page = Page;
                NavigationParameter navParameter = new NavigationParameter()
                {
                    docNo = docNo
                ,
                    docid = docId,
                    workFlowId = workFlowId
                ,
                    IsPoIssued = IsPoIssued
                ,
                    Page = Page
                ,
                    Status = Status
                ,
                    type = type
                };
                Session["GetSPo"] = navParameter;
                var spoList = docdtl.GetDocuemtDetails(Convert.ToInt32(docId)).ToList();
                poSpoVm.PO = spoList;
                var bdgtpoList = docbudget.GetDocumentBudget(Convert.ToInt32(docId)).ToList();
                poSpoVm.PObdgt = bdgtpoList;

                //poSpoVm.Documents = doc.GetALL().Where(x => x.DocID == (Convert.ToInt32(docId))).ToList();
                poSpoVm.Documents = doc.GetbyIDNew(Convert.ToInt32(docId)).ToList();

                // poSpoVm.SPO = new List<BOL.fsp_ReportSubconPO_CumulativeDetails_Result>();
                // {
                //      new fsp_ReportSubconPO_CumulativeDetails_Result()
                //    {PurchaseRequisitionNo=docNo,SequenceNo=1,ItemName="Prassu",CostEntityKeyName="prassu",ChartOfAccountSetDetailValueCode="hello",
                //    ChartOfAccountSetDetailDescription="dsasasd",OrderQuantity=1,UnitOfMeasureName="dadsas",
                //   CurrencyName="SGD",VendorName="dfsds",Price=1234,TotalPrice=1123},
                //      new fsp_ReportSubconPO_CumulativeDetails_Result()
                //    {PurchaseRequisitionNo=docNo,SequenceNo=1,ItemName="Prassu",CostEntityKeyName="prassu",ChartOfAccountSetDetailValueCode="hello",
                //    ChartOfAccountSetDetailDescription="dsasasd",OrderQuantity=1,UnitOfMeasureName="dadsas",
                //   CurrencyName="SGD",VendorName="dfsds",Price=1234,TotalPrice=1123}
                // };
                ViewBag.DocId = docId;
                //clsLog.insert(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss tt") + " \t " + User.Identity.Name + " \t " + controllerName + " \t GetSPo \t Exit");
                return View(poSpoVm);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PoSpo", "GetSPo", clsGeneral.errorMessage(ex));
                return View();
            }            
        }
        public ActionResult Approve(int id, string comments,bool IsAlternate)
        {
            try
            {
                comments = clsGeneral.checkandReplace(comments,"Save");
                cmBs.Approve(id, User.Identity.Name,comments);
                TempData["Msg"] = "Approved Successfully";
                if (IsAlternate == false)
                {
                    return RedirectToAction("Index", "ApproveDocument");
                }
                else
                {
                    return RedirectToAction("Index", "AltApproveDocument");
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PoSpo", "Approve", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Approval Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
            }


        }
        public ActionResult Verify(int id, string comments, bool IsAlternate)
        {
            try
            {
                comments = clsGeneral.checkandReplace(comments, "Save");
                cmBs.Verify(id, User.Identity.Name, comments);
                TempData["Msg"] = "Verified Successfully";
                if (IsAlternate == false)
                {
                    return RedirectToAction("Index", "ApproveDocument");
                }
                else
                {
                    return RedirectToAction("Index", "AltApproveDocument");
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PoSpo", "Verify", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Verified Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
            }


        }
        public ActionResult Reject(int id, string comments,bool IsAlternate)
        {
            try
            {
                comments = clsGeneral.checkandReplace(comments, "Save");
                cmBs.Reject(id, User.Identity.Name, comments);
                TempData["Msg"] = "Rejected Successfully";
                if (IsAlternate == false)
                {
                    return RedirectToAction("Index", "ApproveDocument");
                }
                else
                {
                    return RedirectToAction("Index", "AltApproveDocument");
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PoSpo", "Reject", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Rejection Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
            }
        }
        public ActionResult Hold(int id, string comments, bool IsAlternate)
        {
            try
            {
                comments = clsGeneral.checkandReplace(comments, "Save");
                cmBs.Hold(id, User.Identity.Name, comments);
                TempData["Msg"] = "Hold Successfully";
                if (IsAlternate == false)
                {
                    return RedirectToAction("Index", "ApproveDocument");
                }
                else
                {
                    return RedirectToAction("Index", "AltApproveDocument");
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PoSpo", "Hold", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Hold Failed :" + clsGeneral.errorMessage(ex);
                return RedirectToAction("Index");
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
                    return new EmptyResult();
                }

                byte[] filedata = System.IO.File.ReadAllBytes(filePath);

                string mimeType = MimeMapping.GetMimeMapping(filePath);

                return File(filedata, mimeType, name);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "PoSpo", "GetDocument", clsGeneral.errorMessage(ex));
                return null;
            }
            

        }       
    }
}
    
