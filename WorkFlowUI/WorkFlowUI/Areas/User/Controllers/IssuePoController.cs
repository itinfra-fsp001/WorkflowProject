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
    //[Authorize(Roles = "PVCUser")]
    public class IssuePoController : Controller
    {
        private PurchargeOrderbs ObjBs;
        private SendMailService ObjSendMail;
        public IssuePoController()
        {
            ObjBs = new PurchargeOrderbs();
            ObjSendMail = new SendMailService();
        }
        // GET: User/IssuePo
        public ActionResult Index(int id)
        {
            try
            {
                var purchaseOrders = ObjBs.GetbyID(id);
                spResult emailCheck = ObjBs.isPREmailExistsNew(purchaseOrders.PurchaseOrderNo, id);
                ViewBag.isPREmailExists = false;
                ViewBag.isPRMessage = string.Empty;
                if (emailCheck.result)
                {
                    ViewBag.isPREmailExists = true;
                    ViewBag.isPRMessage = emailCheck.message;
                }
                else
                {
                    ViewBag.isPRMessage = emailCheck.message;
                }
                //ViewBag.Subject = string.Format("{0} & {1}", purchaseOrders.VendorName, purchaseOrders.PurchaseOrderNo);
                ViewBag.Subject = string.Format("Purchase Order By Fujitec Singapore:{0} issued to {1}", purchaseOrders.PurchaseOrderNo, purchaseOrders.VendorName);
                ViewBag.Body = SendMailService.GetMailBody();
                ViewBag.VendorEmail = purchaseOrders.Vendoremail ?? string.Empty;
                TempData["Purchase"] = purchaseOrders;
                return View(purchaseOrders);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "IssuePO", "Index", clsGeneral.errorMessage(ex));
                return View();
            }            
        }
        [HttpPost]
        public ActionResult SendMail(string txtBody, HttpPostedFileBase AttachFile, string txtVendorEmail
            , HttpPostedFileBase AttachFile1, HttpPostedFileBase AttachFile2, HttpPostedFileBase AttachFile3,string txtSubject)
        {
            tbl_PurchaseOrder purchaseOrders = TempData["Purchase"] as tbl_PurchaseOrder;
            try
            {
                spResult emailCheck = ObjBs.isPREmailExistsNew(purchaseOrders.PurchaseOrderNo, Convert.ToInt32(purchaseOrders.DocID));
                ViewBag.isPREmailExists = false;
                ViewBag.isPRMessage = string.Empty;
                if (emailCheck.result)
                {
                    ViewBag.isPREmailExists = false;
                }
                else
                {
                    ViewBag.isPRMessage = emailCheck.message;
                    ViewBag.Subject = string.Format("Purchase Order By Fujitec Singapore:{0} issued to {1}", purchaseOrders.PurchaseOrderNo, purchaseOrders.VendorName);
                    ViewBag.Body = SendMailService.GetMailBody();
                    ViewBag.VendorEmail = purchaseOrders.Vendoremail ?? string.Empty;
                    TempData["Purchase"] = purchaseOrders;
                    return View("Index", purchaseOrders);
                }

                //ViewBag.Subject = string.Format("Purchase Order By Fujitec Singapore:{0} issued to {1}", purchaseOrders.PurchaseOrderNo, purchaseOrders.VendorName);
                ViewBag.Subject = txtSubject;
                ViewBag.Body = txtBody;
                ViewBag.VendorEmail = txtVendorEmail;

                string docLocation = ConfigurationManager.AppSettings["DocLocation"].ToString();
                string path = Path.Combine(docLocation, purchaseOrders.PurchaseOrderNo);
                if (AttachFile == null
                    && AttachFile1 == null
                    && AttachFile2 == null
                    && AttachFile3 == null)
                {
                    TempData["Msg"] = "Atleast one document should be attached.";
                    return View("Index", purchaseOrders);
                }
                CreateAndCleanDirectory(path);

                purchaseOrders.Attachment = PostAttachMent(AttachFile, purchaseOrders, path);
                purchaseOrders.Attachment1 = PostAttachMent(AttachFile1, purchaseOrders, path);
                purchaseOrders.Attachment2 = PostAttachMent(AttachFile2, purchaseOrders, path);
                purchaseOrders.Attachment3 = PostAttachMent(AttachFile3, purchaseOrders, path);

                if (string.IsNullOrEmpty(txtVendorEmail)) //|| !IsValidEmail(txtVendorEmail))
                {
                    TempData["Msg"] = "Please enter valid email";
                    return View("Index", purchaseOrders);
                }
                else
                {
                    if (purchaseOrders.Vendoremail != txtVendorEmail)
                    {
                        purchaseOrders.Vendoremail = txtVendorEmail;

                    }
                    ObjBs.Update(purchaseOrders);
                }

                bool status = SendMailService.SentPOMail(purchaseOrders, txtBody,txtSubject);
                //need to assing to tempvarilbe
                bool check = ObjBs.IsPrmailExists(purchaseOrders.PurchaseOrderNo, Convert.ToInt32(purchaseOrders.DocID));
                if (!check)
                    TempData["alert"] = "not available";
                TempData["Msg"] = "PO Sending in Progress..";
                return View("Index", purchaseOrders);


            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "IssuePO", "SendMail", clsGeneral.errorMessage(ex));
                TempData["Msg"] = "PO Issued Failed :" + clsGeneral.errorMessage(ex);
                return View("Index", purchaseOrders);
            }
            finally
            {
                TempData["Purchase"] = purchaseOrders;
            }
        }

        private void CreateAndCleanDirectory(string path)
        {
            try
            {

                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);

                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(path);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "IssuePO", "CreateAndCleanDirectory", clsGeneral.errorMessage(ex));
                if (!Directory.Exists(path))
                {
                    throw new Exception("Files directory not created: ", ex);
                }
            }
        }

        private string PostAttachMent(HttpPostedFileBase attachment, tbl_PurchaseOrder purchaseOrders, string path)
        {
            try
            {

            
            if (attachment != null)
            {
                if (!IsValidContentLength(attachment.ContentLength))
                {
                    throw new Exception("AttachFile - file is too big");
                    //  return View("Index", purchaseOrders);
                    //return RedirectToAction("Index" , document);
                }
                else
                {
                    if (attachment.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(attachment.FileName);
                        //  document.AttachDoc = fileName;

                        path = Path.Combine(path, fileName);
                        attachment.SaveAs(path);

                        purchaseOrders.Attachment = fileName;
                        return fileName;
                    }

                }
            }
            return null;
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "IssuePO", "PostAttachMent", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        private bool IsValidContentType(string ContentType)
        {
            //return ContentType.Equals("application/pdf");
            return true;

        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsValidContentLength(int ContentLength)
        {
            try
            {
                return ((ContentLength / 1024) / 1024) < 3; //less than 1 MB
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "IssuePO", "IsValidContentLength", clsGeneral.errorMessage(ex));
                return false;
            }
            

        }
    }
}