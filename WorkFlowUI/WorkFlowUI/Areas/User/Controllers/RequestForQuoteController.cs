using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.ViewModel;
using BLL;
using System.IO;

namespace WorkFlowUI.Areas.User.Controllers
{
    public class RequestForQuoteController : Controller
    {
        public RFQViewModel viewModal;
        public RequestForQuotebs combs;
        public UserBs userbs;
        public RequestForQuoteController()
        {
            combs = new RequestForQuotebs();
            viewModal = new ViewModel.RFQViewModel();
            userbs = new UserBs();
        }
        // GET: User/RequestForQuote
        public ActionResult Index(string status, string quoteId)
        {
            try
            {


                viewModal.purchaseCategoryMain.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });

                foreach (var item in combs.GetPurchaseCategory().ToList())
                {
                    viewModal.purchaseCategoryMain.Add(new SelectListItem { Text = item.Category, Value = item.Category });
                }
                ViewBag.purchaseCategoryList = viewModal.purchaseCategoryMain;

                if (status == "N")
                {
                    status = "New";
                }
                else if (status == "P")
                {
                    status = "Pending";
                }
                else if (status == "F")
                {
                    status = "Finalised";
                }
                else if (status == "C")
                {
                    status = "Canceled";
                }
                else if (status == "R")
                {
                    status = "Rejected";
                }
                else if (status == "A")
                {
                    status = "Assigned";
                }
                else if (status == "I")
                {
                    status = "Insert";
                }
                else if (status == "H")
                {
                    status = "Hold";
                }
                ViewBag.Status = status;
                ViewBag.QuoteNo = quoteId;
                ViewBag.UserId = User.Identity.Name;
                var userRole = userbs.GetRoleByID(User.Identity.Name);                
                ViewBag.IsPCVUser = false;
                ViewBag.IsPCVUser2 = false;
                if (userRole != null && userRole.Count() > 0)
                {
                    foreach (BOL.tbl_UserRoles item in userRole)
                    {
                        if (item.Role == "PCVUser")
                        {
                            ViewBag.IsPCVUser = true;
                        }
                        else if (item.Role == "PCVUser2")
                        {
                            ViewBag.IsPCVUser2 = true;
                        }
                    }
                }
                //ViewBag.IsPCVUser = combs.isPCVUser(ViewBag.UserId);
                //ViewBag.IsPCVUser2 = combs.isPCVUser2(ViewBag.UserId);
                ViewBag.IsQuoteSuperuser = combs.isQuoteSuperUser(ViewBag.UserId, quoteId);
                ViewBag.IsEmailIDExists = userbs.isEmailIdExits(User.Identity.Name);

                if (status == "New" || status == "Assigned" || status == "Hold")
                {
                    viewModal.rfqMain = combs.getQuotes(ViewBag.UserId, status, quoteId, "A");
                    viewModal.rfqPurchaseAttachments = combs.getQuoteAttachments(ViewBag.UserId, status, quoteId, "Requestor");
                    viewModal.rfqBuyerAttachments = combs.getQuoteAttachments(ViewBag.UserId, status, quoteId, "Buyer");
                }
                else if (status == "Pending" || status == "Finalised" || status == "Canceled" || status == "Rejected")
                {
                    ViewBag.UserId = null;
                    viewModal.rfqMain = combs.getQuotes(ViewBag.UserId, status, quoteId, "A");
                    viewModal.rfqPurchaseAttachments = combs.getQuoteAttachments(ViewBag.UserId, "", quoteId, "Requestor");
                    viewModal.rfqBuyerAttachments = combs.getQuoteAttachments(ViewBag.UserId, "", quoteId, "Buyer");
                    ViewBag.UserId = User.Identity.Name;
                }
                ViewBag.IsQuoteOwner = false;

                if (viewModal.rfqMain != null && viewModal.rfqMain.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(viewModal.rfqMain[0].CreatedBy)) && (Convert.ToString(viewModal.rfqMain[0].CreatedBy).Split(':').Length > 1))
                    {
                        if (Convert.ToString(viewModal.rfqMain[0].CreatedBy).Split(':')[1] == User.Identity.Name)
                        {
                            ViewBag.IsQuoteOwner = true;
                        }
                    }
                }

                DateTime today = DateTime.Now;
                if (today.DayOfWeek == DayOfWeek.Saturday)
                {
                    today = today.AddDays(2);
                }
                else if (today.DayOfWeek == DayOfWeek.Sunday)
                {
                    today = today.AddDays(1);
                }
                int incCount = 0;
                while (incCount < 4)
                {
                    today = today.AddDays(1);
                    if (!(today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday))
                    {
                        incCount++;
                    }
                }

                viewModal.requiredMinDate = today.ToString("dd/MM/yyyy");
                return View(viewModal);

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "Index", clsGeneral.errorMessage(ex));
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult CreateRFQ(RFQViewModel rfq, string Command)
        //{



        //    if (ModelState.IsValid)
        //    {
        //        rfq.status = Command;
        //        rfq.userId = User.Identity.Name.ToLower();
        //        var fileName = "";
        //        foreach (string files in Request.Files)
        //        {
        //            HttpPostedFileBase file = Request.Files[files];
        //            //Save file here
        //            if (file != null && file.ContentLength > 0)
        //            {

        //                fileName = (string.IsNullOrEmpty(fileName) ? Path.GetFileName(file.FileName) : fileName + "," + Path.GetFileName(file.FileName));
        //            }
        //        }

        //        var isGet = combs.createQuote(rfq.userId, rfq.purchaseCategoryNew, rfq.purchaseRemarks, rfq.status, fileName,"","");

        //        int fileCount = 1;
        //        foreach (string files in Request.Files)
        //        {
        //            HttpPostedFileBase file = Request.Files[files];
        //            if (file != null && file.ContentLength > 0)
        //            {
        //                fileName = Path.GetFileName(file.FileName);
        //                var path = Path.Combine(Server.MapPath("~/Upload Documents/"), isGet[0].QuoteId + "_P" + fileCount + "_" + fileName);
        //                file.SaveAs(path);
        //            }
        //        }


        //    }
        //    return RedirectToAction("Index");
        //}


        public ActionResult CreateRFQNew(RFQViewModel rfq, IEnumerable<HttpPostedFileBase> files, string Command)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    if (Command == "Draft" || Command == "Submit")
                    {
                        if (!userbs.isEmailIdExits(User.Identity.Name))
                        {
                            //TempData["Status"] = "Success";
                            //TempData["Msg"] = "Unable to Save / Submit : Email ID doesn't exists";
                            return RedirectToAction("Index", new { status = "I", quoteId = "" });
                        }
                    }
                    BOL.rfqSPResult isGet = null;
                    BOL.rfqSPResult isGetEmail = null;
                    string attachPrefix = null;

                    int fileCount = 0;
                    if (!string.IsNullOrEmpty(rfq.quoteNo))
                    {
                        BOL.rfqSPResult isget = combs.getRFQAttachmentCount(rfq.quoteNo);
                        if (isget != null)
                        {
                            if (Command == "Draft" || Command == "Submit" || Command == "Delete RFQ")
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(isget.submitterEmail)))
                                {
                                    fileCount = Convert.ToInt32(Convert.ToString(isget.submitterEmail));
                                }
                            }
                            else if (Command == "Save" || Command == "Finalise" || Command == "Hold" || Command == "Reject RFQ")
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(isget.buyerEmail)))
                                {
                                    fileCount = Convert.ToInt32(Convert.ToString(isget.buyerEmail));
                                }
                            }
                        }
                        //if (!string.IsNullOrEmpty(rfq.deleteAttachmentFileList))
                        //{
                        //    fileCount = fileCount - Convert.ToInt32(rfq.deleteAttachmentFileList.Split(',').Length);
                        //}
                    }
                    if (Command == "Draft" || Command == "Submit" || Command == "Delete RFQ")
                    {
                        attachPrefix = "R";
                    }
                    else if (Command == "Save" || Command == "Finalise" || Command == "Hold" || Command == "Reject RFQ")
                    {
                        attachPrefix = "B";
                    }
                    var fileName = "";
                    if (files != null)
                    {
                        string tempFileName;
                        int tempfilecount = fileCount;
                        foreach (var file in files)
                        {
                            if (file != null && file.ContentLength > 0)
                            {
                                tempfilecount++;
                                //tempFileName = attachPrefix + Convert.ToString(tempfilecount) + "_" + Path.GetFileName(file.FileName).Replace(",", "commacomma");
                                tempFileName = Convert.ToString(tempfilecount) + "_" + Path.GetFileName(file.FileName).Replace(",", "commacomma");
                                fileName = (string.IsNullOrEmpty(fileName) ? tempFileName : fileName + "," + tempFileName);
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(fileName))
                        fileName = fileName + ",";


                    if (Command == "Reject RFQ" || Command == "Delete RFQ")
                    {
                        string remarks = null;
                        if (Command == "Reject RFQ")
                        {
                            remarks = rfq.buyerRemarks;
                            //attachPrefix = "B";
                        }
                        else if (Command == "Delete RFQ")
                        {
                            remarks = rfq.purchaseRemarks;
                            //attachPrefix = "R";
                        }
                        processAttachment(rfq.deleteAttachmentFileList, files, rfq.quoteNo, attachPrefix, fileCount);

                        var spResult = combs.cancelQuote(rfq.quoteId + ",", User.Identity.Name, Command, remarks, fileName, rfq.deleteAttachmentIdList);
                        if (spResult == "Success")
                        {
                            if (rfq.status != "New")
                            {
                                isGetEmail = combs.getQuoteEmailIds(rfq.quoteNo);
                                EmailTemplate clsEmail = new EmailTemplate();
                                if (isGetEmail.buyerEmail != isGetEmail.UpdaterEmail)
                                {
                                    // send email to actual buyer also
                                    clsEmail.sendQuoteEmail(isGetEmail.submitterEmail, isGetEmail.buyerEmail, null, isGetEmail.UpdaterName, rfq.quoteNo, Command, getRevisionNoForQuote(rfq.quoteNo), isGetEmail.priority, false);
                                }
                                else
                                {
                                    clsEmail.sendQuoteEmail(isGetEmail.submitterEmail, null, null, isGetEmail.buyerName, rfq.quoteNo, Command, getRevisionNoForQuote(rfq.quoteNo), isGetEmail.priority, false);
                                }
                            }
                            TempData["SubmitType"] = Command;
                            if (Command == "Reject RFQ")
                            {
                                TempData["Status"] = "Reject";
                                TempData["Msg"] = "RFQ Rejeted Successfully";
                            }
                            else if (Command == "Delete RFQ")
                            {
                                TempData["Status"] = "Delete";
                                TempData["Msg"] = "RFQ Deleted Successfully";
                            }
                            return RedirectToAction("Index", new { status = "I", quoteId = "" });
                        }
                    }
                    rfq.userId = User.Identity.Name.ToLower();
                    bool isResubmitted = false;
                    if (Command == "Draft" || Command == "Submit")
                    {
                        //attachPrefix = "R";
                        isGet = combs.createQuote(rfq.userId, rfq.purchaseCategoryNew, rfq.purchaseRemarks, Command, fileName, rfq.quoteNo, rfq.deleteAttachmentIdList, DateTime.ParseExact(rfq.requiredDate, "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo), rfq.quoteType, rfq.priority);
                        isResubmitted = isGet.isResubmitted;
                    }
                    else if (Command == "Finalise" || Command == "Hold")
                    {
                        //attachPrefix = "B";
                        isGet = combs.finaliseQuote(rfq.buyerRemarks, rfq.userId, fileName, rfq.quoteNo, rfq.deleteAttachmentIdList, Command);
                        isGet.quoteNo = rfq.quoteNo;
                    }
                    else if (Command == "Save")
                    {
                        //attachPrefix = "B";
                        isGet = combs.updateQuoteByBuyer(rfq.buyerRemarks, rfq.userId, fileName, rfq.quoteNo, rfq.deleteAttachmentIdList);
                        isGet.quoteNo = rfq.quoteNo;
                    }


                    // call processAttachment here
                    processAttachment(rfq.deleteAttachmentFileList, files, isGet.quoteNo, attachPrefix, fileCount);

                    // send email
                    if (Command == "Submit" || Command == "Finalise" || Command == "Hold")
                    {
                        isGetEmail = combs.getQuoteEmailIds(isGet.quoteNo);
                        EmailTemplate clsEmail = new EmailTemplate();
                        if (Command == "Submit")
                        {
                            clsEmail.sendQuoteEmail(isGetEmail.buyerEmail, isGetEmail.BuyerManagerEmail + "," + isGetEmail.SubmitterManagerEmail, isGetEmail.submitterName, null, isGet.quoteNo, Command, getRevisionNoForQuote(isGet.quoteNo), isGetEmail.priority, isResubmitted);
                        }
                        else if (Command == "Finalise" || Command == "Hold")
                        {
                            if (isGetEmail.buyerEmail != isGetEmail.UpdaterEmail)
                            {
                                // send email to actual buyer also
                                clsEmail.sendQuoteEmail(isGetEmail.submitterEmail, isGetEmail.buyerEmail + "," + isGetEmail.SubmitterManagerEmail, null, isGetEmail.UpdaterName, isGet.quoteNo, Command, getRevisionNoForQuote(isGet.quoteNo), isGetEmail.priority, false);
                            }
                            else
                            {
                                clsEmail.sendQuoteEmail(isGetEmail.submitterEmail, isGetEmail.SubmitterManagerEmail, null, isGetEmail.buyerName, isGet.quoteNo, Command, getRevisionNoForQuote(isGet.quoteNo), isGetEmail.priority, false);
                            }
                        }
                    }
                    TempData["SubmitType"] = Command;
                    if (isGet.result)
                    {
                        TempData["Status"] = "Success";
                        if (Command == "Draft")
                            TempData["Msg"] = "RFQ is saved successfully.Reference No. is " + isGet.quoteNo;
                        else if (Command == "Submit")
                            TempData["Msg"] = "RFQ is submitted successfully.Reference No. is " + isGet.quoteNo;
                        else if (Command == "Finalise")
                            TempData["Msg"] = "RFQ No. " + isGet.quoteNo + " is finalised successfully.";
                        else if (Command == "Save")
                            TempData["Msg"] = "RFQ No. " + isGet.quoteNo + " is updated successfully.";
                        else if (Command == "Hold")
                            TempData["Msg"] = "RFQ No. " + isGet.quoteNo + " is hold successfully.";
                    }
                    else
                    {
                        TempData["Status"] = "Failed";
                        TempData["Msg"] = "Failure while saving this data";
                    }
                }
                return RedirectToAction("Index", new { status = "I", quoteId = "" });
                //return View();
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "CreateRFQNew : " + Command, clsGeneral.errorMessage(ex));
                return null;
            }
        }


        public void processAttachment(string deleteAttachmentFileList, IEnumerable<HttpPostedFileBase> files, string quoteNo, string attachPrefix, int fileCount)
        {
            try
            {

                string fileName;
                if (deleteAttachmentFileList != null)
                {
                    foreach (var deleteFile in deleteAttachmentFileList.Split(','))
                    {
                        if (deleteFile != null)
                        {
                            //System.IO.File.Delete(Path.Combine(Server.MapPath("~/Upload Documents/"), deleteFile));
                        }
                    }
                }
                //int fileCount = 1;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            fileCount++;
                            fileName = Path.GetFileName(file.FileName);
                            //var path = Path.Combine(Server.MapPath("~/Upload Documents/"), quoteNo + "_" + attachPrefix + Convert.ToString(fileCount)+ "_" + fileName);
                            var path = Path.Combine(Server.MapPath("~/Upload Documents/"), quoteNo + "_" + Convert.ToString(fileCount) + "_" + fileName);
                            file.SaveAs(path);
                            //fileCount = fileCount + 1;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "processAttachment", clsGeneral.errorMessage(ex));
            }
        }

        public ActionResult GetAttachment(string docName)
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
        public ActionResult GetRFQTemplate()
        {
            try
            {

                string filePath;

                filePath = Path.Combine(Server.MapPath("~/Content/Templates/RFQ Details.xlsx"));

                if (!System.IO.File.Exists(filePath))
                {
                    return new EmptyResult();
                }

                byte[] filedata = System.IO.File.ReadAllBytes(filePath);

                string mimeType = MimeMapping.GetMimeMapping(filePath);

                return File(filedata, mimeType, "RFQ Details.xlsx");

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "GetRFQTemplate", clsGeneral.errorMessage(ex));
                return null;
            }

        }
        public ActionResult ReviseQuote(string quoteNo)
        {
            try
            {

                string userId = User.Identity.Name;

                BOL.rfqSPResult isGet = combs.reviseQuote(userId, quoteNo);
                TempData["SubmitType"] = "Revise RFQ";
                if (isGet.result)
                {
                    TempData["Status"] = "Success";
                    TempData["QuoteNo"] = quoteNo;
                    TempData["Msg"] = "RFQ is revised successfully.Revision No. is " + isGet.name;
                }
                else
                {
                    TempData["Status"] = "Failed";
                    TempData["Msg"] = "Failure while processing this request";
                }
                return RedirectToAction("Index", new { status = "I", quoteId = "" });

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "ReviseQuote", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        public string getRevisionNoForQuote(string quoteNo)
        {
            try
            {

                string isRet = null;
                var tblRFQ = combs.getAllRFQ().Where(x => x.QuoteId == quoteNo).ToList();
                if (tblRFQ != null && tblRFQ.Count > 0)
                {
                    isRet = Convert.ToString(tblRFQ[0].RevisionNo);
                }
                return isRet;

            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "RequestForQuote", "getRevisionNoForQuote", clsGeneral.errorMessage(ex));
                return null;
            }
        }
    }
}