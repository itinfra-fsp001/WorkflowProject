using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "User,PCVUser,PCVUser2,ServiceAdmin,ServiceEngineer")]
    public class UploadFileController : Controller
    {
        // GET: User/UploadFile

        private DocumentBs ObjBs;
        private DocumentWorkfFlowBs ObjWFBs;
        private string docLocation;

        public UploadFileController()
        {
            ObjBs = new DocumentBs();
            ObjWFBs = new DocumentWorkfFlowBs();
            docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();

        }

        public ActionResult Index(int Id, string status)
        {

            try
            {
                ViewBag.IsWorkflowFound = false;
                var document = ObjBs.GetbyID(Id);
                if (document != null)
                {
                    var docwf = ObjWFBs.GetDocuemtWorkFlow(document.DocID).ToList();
                    if (docwf != null && docwf.Count() > 0)
                    {
                        ViewBag.IsWorkflowFound = true;
                    }
                }
                TempData["Document"] = document;
                ViewBag.Status = status;
                return View(document);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "UploadFile", "Index", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        private bool IsValidContentType(string ContentType)
        {
            //return ContentType.Equals("application/pdf");

            return true;

        }

        private bool IsValidContentLength(int ContentLength)
        {
            try
            {
                return ((ContentLength / 1024) / 1024) < 3; //less than 3 MB
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "UploadFile", "IsValidContentLength", clsGeneral.errorMessage(ex));
                return false;
            }


        }



        [HttpPost]
        public ActionResult Process(HttpPostedFileBase AttachFile, HttpPostedFileBase Attach1, HttpPostedFileBase Attach2, HttpPostedFileBase Attach3, string Command)
        {
            var document = TempData["Document"] as tbl_Documents;

            try
            {
                ViewBag.IsWorkflowFound = true;
                if (document == null)
                {
                    TempData["Msg"] = "Pleased select new document and submit.";
                    return View("Index", new tbl_Documents());
                }
                document = ObjBs.GetbyID(Convert.ToInt32(document.DocID));
                string docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
                string path = Path.Combine(docLocation, document.DocNo);

                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);

                }
                if(Command == "Submit")
                {
                    rfqSPResult spResult = ObjBs.validateDocument(Convert.ToString(document.DocID));
                    if (!spResult.result)
                    {
                        TempData["Msg"] = Convert.ToString(spResult.name);
                        return View("Index", new tbl_Documents());
                    }
                }
                if (AttachFile != null)

                {
                    if (!IsValidContentType(AttachFile.ContentType))
                    {
                        TempData["Msg"] = "AttachFile: Only pdf files are allowed :";
                        return View("Index", document);
                        //return RedirectToAction("Index" , document);
                    }

                    else if (!IsValidContentLength(AttachFile.ContentLength))
                    {
                        TempData["Msg"] = "AttachFile - file is too big";
                        return View("Index", document);
                        //return RedirectToAction("Index" , document);
                    }

                    else
                    {
                        if (AttachFile.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(AttachFile.FileName);
                            document.AttachDoc = fileName;
                            string filePath = Path.Combine(path, fileName);
                            AttachFile.SaveAs(filePath);

                        }

                    }
                }

                if (Attach1 != null)

                {
                    if (!IsValidContentType(Attach1.ContentType))
                    {
                        TempData["Msg"] = "Attach1 - Only pdf files are allowed";
                        return View("Index", document);
                        //return RedirectToAction("Index", document);
                    }

                    else if (!IsValidContentLength(Attach1.ContentLength))
                    {
                        TempData["Msg"] = "Attach1 - file is too big";
                        return View("Index", document);
                        //return RedirectToAction("Index" , document);
                    }

                    else
                    {
                        if (Attach1.ContentLength > 0)
                        {

                            var fileName = Path.GetFileName(Attach1.FileName);
                            document.AddAttachDoc1 = fileName;
                            string filePath = Path.Combine(path, fileName);
                            Attach1.SaveAs(filePath);

                        }

                    }
                }

                if (Attach2 != null)

                {
                    if (!IsValidContentType(Attach2.ContentType))
                    {
                        TempData["Msg"] = "Attach2 - Only pdf files are allowed";
                        return View("Index", document);
                        //return RedirectToAction("Index", document);
                    }

                    else if (!IsValidContentLength(Attach2.ContentLength))
                    {
                        TempData["Msg"] = "Attach2 -  file is too big";
                        return View("Index", document);
                        //return RedirectToAction("Index", document);
                    }

                    else
                    {
                        if (Attach2.ContentLength > 0)
                        {

                            var fileName = Path.GetFileName(Attach2.FileName);
                            document.AddAttachDoc2 = fileName;
                            string filePath = Path.Combine(path, fileName);
                            Attach2.SaveAs(filePath);

                        }

                    }
                }

                if (Attach3 != null)

                {
                    if (!IsValidContentType(Attach3.ContentType))
                    {
                        TempData["Msg"] = "Attach3 - Only pdf files are allowed";
                        return View("Index", document);
                        //return RedirectToAction("Index" , document);
                    }

                    else if (!IsValidContentLength(Attach3.ContentLength))
                    {
                        TempData["Msg"] = "Attach3 -  file is too big";
                        return View("Index", document);
                        //return RedirectToAction("Index", document);
                    }

                    else
                    {
                        if (Attach3.ContentLength > 0)
                        {

                            var fileName = Path.GetFileName(Attach3.FileName);
                            document.AddAttachDoc3 = fileName;
                            string filePath = Path.Combine(path, fileName);
                            Attach3.SaveAs(filePath);

                        }

                    }
                }
                //if (ModelState.IsValid)
                //{
                // SubmitAndSendMail(document);

                //    TempData["Msg"] = "Submitted Successfully";
                //    //   return RedirectToAction("INdex", "BrowseDocument", new { area = "User" });
                //    return View("Index", new tbl_Documents());



                //}
                //else
                //{
                //    return View("Index", document);
                //}

                if (!string.IsNullOrEmpty(Convert.ToString(Request.Form["VendorName"])))
                {
                    RequestForQuotebs rfq = new RequestForQuotebs();
                    var attachmentList = rfq.getRFQAttachmentsForDoc(Convert.ToString(Request.Form["VendorName"]));
                    foreach (var item in attachmentList)
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(document.AttachDoc)))
                        {
                            document.AttachDoc = item.FilePath;
                        }
                        else if (string.IsNullOrEmpty(Convert.ToString(document.AddAttachDoc1)))
                        {
                            document.AddAttachDoc1 = item.FilePath;
                        }
                        else if (string.IsNullOrEmpty(Convert.ToString(document.AddAttachDoc2)))
                        {
                            document.AddAttachDoc2 = item.FilePath;
                        }
                        else if (string.IsNullOrEmpty(Convert.ToString(document.AddAttachDoc3)))
                        {
                            document.AddAttachDoc3 = item.FilePath;
                        }
                        ObjBs.Update(document);
                    }
                }

                document.PriorityCode = Convert.ToInt16(Request.Form["PriorityCode"]);
                document.RFQRefNo = Convert.ToString(Request.Form["RFQRefNo"]);
                document.Remarks = Convert.ToString(Request.Form["Remarks"]);
                document.UpdateBy = User.Identity.Name;
                document.UpdateDate = DateTime.Now;

                if (Command == "Submit")
                {
                    document.Status = "P";
                    document.ApprovalSubmitBy = document.LastApprovalSubmitBy = User.Identity.Name;
                    document.ApprovalSubmitDate = document.LastApprovalSubmitDate = DateTime.Now;
                }
                ObjBs.Update(document);
                if (Command == "Submit")
                {
                    SendMailService.SendStatusToService(document, "U");
                }

                return RedirectToAction("INdex", "BrowseDocument", new { area = "User" });
            }

            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "UploadFile", "Process", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "Save Failed :" + clsGeneral.errorMessage(ex);
                return View("Index", document);
                //return RedirectToAction("Index", document);
            }


        }

        private void SubmitAndSendMail(tbl_Documents document)
        {
            try
            {

                document.Status = "P";
                document.ApprovalSubmitBy = User.Identity.Name;
                document.ApprovalSubmitDate = DateTime.Now;
                document.UpdateDate = DateTime.Now;
                ObjBs.Update(document);

                //tbl_DocumentWorkFlow documentWf = ObjWFBs.GetALL().Where(x => x.DocID == document.DocID & x.Sequence == 1 & x.ApprovalLevel == "L1" & x.Status == "N") as tbl_DocumentWorkFlow;

                var documentWf = ObjWFBs.GetALL().Where(x => x.DocID == document.DocID & x.Sequence == 1 & x.ApprovalLevel == "L1" & x.Status == "N").ToList();


                var wf = documentWf.First();

                wf.Status = "P";
                // wf.AlternateApprover = 0;
                wf.Submitdate = DateTime.Now;
                ObjWFBs.Update(wf);
                SendMailService.SendStatusToService(wf);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "UploadFile", "SubmitAndSendMail", clsGeneral.errorMessage(ex));
                //return null;
            }
        }
        [HttpPost]
        public EmptyResult ClearFile(int DocNo, string Type)
        {
            try
            {

                var document = ObjBs.GetbyID(DocNo);
                DeleteFile(document, Type);
                if (Type == "Attach0")
                    document.AttachDoc = null;
                else if (Type == "Attach1")
                    document.AddAttachDoc1 = null;
                else if (Type == "Attach2")
                    document.AddAttachDoc2 = null;
                else if (Type == "Attach3")
                    document.AddAttachDoc3 = null;
                ObjBs.Update(document);

                TempData["Document"] = document;
                return new EmptyResult();

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "UploadFile", "ClearFile", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        private void DeleteFile(tbl_Documents document, string Type)
        {
            try
            {
                string fileName = string.Empty;
                if (Type == "Attach0")
                    fileName = document.AttachDoc;
                else if (Type == "Attach1")
                    fileName = document.AddAttachDoc1;
                else if (Type == "Attach2")
                    fileName = document.AddAttachDoc2;
                else if (Type == "Attach3")
                    fileName = document.AddAttachDoc3;
                string filePath = Path.Combine(docLocation, document.DocNo, fileName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "UploadFile", "DeleteFile", clsGeneral.errorMessage(ex));
            }

        }

        public ActionResult GetDocument(string docNo, string name)
        {
            try
            {
                //var name = "91197705_20161006_0123.pdf";
                //  string docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
                string filePath = Path.Combine(docLocation, docNo, name);
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
                BLL.clsLog.insertLog(User.Identity.Name, "UploadFile", "GetDocument", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public ActionResult GetRFQAttachment(string docName)
        {
            try
            {


                string filePath;

                filePath = Path.Combine(Server.MapPath("~/Upload Documents/"), docName);

                if (!System.IO.File.Exists(filePath))
                {
                    return new EmptyResult();
                }

                byte[] filedata = System.IO.File.ReadAllBytes(filePath);

                string mimeType = MimeMapping.GetMimeMapping(filePath);

                return File(filedata, mimeType, docName);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "GetAttachment", clsGeneral.errorMessage(ex));
                return null;
            }

        }

        //[HttpGet]
        public ActionResult getAttachmentList(string rfqno)
        {
            rfqSPAttachments isRet1 = new rfqSPAttachments();
            try
            {
                RequestForQuotebs objBs = new RequestForQuotebs();
                spResult isGet = objBs.checkRFQStatus(rfqno);
                if (isGet.result)
                {
                    isRet1.result = true;
                    isRet1.attachmentList = objBs.getQuoteAttachmentsNew(null, null, rfqno, "All");
                }
                else
                {
                    isRet1.result = false;
                    isRet1.message = isGet.message;
                }
                var jsonView = Json(isRet1, JsonRequestBehavior.AllowGet);
                return jsonView;
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "UploadFile", "getAttachmentList", clsGeneral.errorMessage(ex));
                return null;
            }

        }
    }
}