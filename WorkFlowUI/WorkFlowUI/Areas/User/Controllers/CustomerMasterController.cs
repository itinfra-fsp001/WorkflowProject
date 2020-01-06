using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.ViewModel;
using BLL;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;
using System.Data;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace WorkFlowUI.Areas.User.Controllers
{
    [Authorize(Roles = "ServiceAdmin")]
    public class CustomerMasterController : Controller
    {
        // GET: User/CustomerMaster
        public CustomerMasterViewModel viewmodel;
        public CommonBs objBs;
        public CustomerMasterController()
        {
            viewmodel = new CustomerMasterViewModel();
            objBs = new CommonBs();
        }
        public ActionResult Index(string customerName, string organization, string pageSize, string page, string status)
        {
            status = (string.IsNullOrEmpty(status) ? "V" : status);
            ViewData["Status"] = status;
            if (status == "V")
            {

                viewmodel.organizationList.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });
                foreach (string item in objBs.getAllOrganizationList())
                {
                    viewmodel.organizationList.Add(new SelectListItem { Text = item, Value = item });
                }


                page = (string.IsNullOrEmpty(page) ? "1" : page);
                pageSize = (string.IsNullOrEmpty(pageSize) ? "50" : pageSize);

                ViewData["Mode"] = "Edit";
                ViewData["Pagesize"] = pageSize;
                ViewData["CustomerName"] = clsGeneral.searchStringDecrypt(customerName);
                ViewData["Organization"] = organization;
                ViewData["Page"] = page;
                viewmodel.searchCustomerName = clsGeneral.searchStringDecrypt(customerName);
                viewmodel.searchOrganization = organization;
                //if (!string.IsNullOrEmpty(customerName))
                //{
                //    customerName = Convert.ToString(customerName).Replace("'", "''");
                //}
                var customerList = objBs.getCustomerEmailList(clsGeneral.checkandReplace(customerName), organization);
                ViewData["Totalpages"] = Math.Ceiling(customerList.ToList().Count() / Convert.ToDecimal(pageSize));

                int pageNo = int.Parse(page == null ? "1" : page);
                ViewData["Page"] = pageNo;

                customerList = customerList.Skip((pageNo - 1) * Convert.ToInt32(pageSize)).Take(Convert.ToInt32(pageSize)).ToList();
                viewmodel.custList = customerList;
            }
            else if (status == "A")
            {
                viewmodel.organizationList.Add(new SelectListItem { Text = "-- Select --", Value = "-- Select --" });
                var orgList = objBs.getOrganizationList();
                foreach (BOL.vw_ERP_Organization item in orgList)
                {
                    viewmodel.organizationList.Add(new SelectListItem { Text = item.OrganizationName, Value = item.OrganizationName });
                }

                viewmodel.newCust = new BOL.vw_ERP_tbl_Customeremail { OrganizationName = "FSP" };
                ViewData["Mode"] = "Add";
            }
            return View(viewmodel);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateCustomer(CustomerMasterViewModel soaVM, string Command, List<BOL.vw_ERP_tbl_Customeremail> custList)
        {
            try
            {
                if (Command == "Update")
                {
                    if (custList != null)
                    {
                        foreach (BOL.vw_ERP_tbl_Customeremail item in custList)
                        {
                            item.Updateuser = User.Identity.Name;
                        }
                        objBs.updateCustomer(custList);
                        TempData["Msg"] = "Customer email details updated successfully";
                    }
                }
                else if (Command == "Delete")
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    List<int> lt = js.Deserialize<List<int>>(soaVM.delCustomerCodeList);
                    var idList = "";
                    foreach (int docId in lt)
                    {
                        idList = (string.IsNullOrEmpty(idList)) ? Convert.ToString(docId) : idList + "," + Convert.ToString(docId);
                    }
                    objBs.deleteCustomer(idList, User.Identity.Name);
                    TempData["Msg"] = "Selected customer(s) deleted successfully";
                }
                return RedirectToAction("Index", new { status = "S", logId = "" });
            }
            catch (Exception ex)
            {
                TempData["Msg"] = Convert.ToString(ex.Message);
                return RedirectToAction("Index", new { status = "E", logId = "" });
            }

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public string checkCustomerCodeExists(string customercode)
        {
            var isget = objBs.checkCustomerCodeExists(customercode);
            if (isget.result)
                return "1," + isget.message;
            else
                return "0";

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddCustomer(BOL.vw_ERP_tbl_Customeremail newCust)
        {
            try
            {
                newCust.Updateuser = User.Identity.Name;
                objBs.addCustomer(newCust);
                TempData["Msg"] = "Customer email details added successfully";
                return RedirectToAction("Index", new { status = "S", logId = "" });
            }
            catch (Exception ex)
            {
                TempData["Msg"] = Convert.ToString(ex.Message);
                return RedirectToAction("Index", new { status = "E", logId = "" });
            }

        }

        public ActionResult ExportToExcel()
        {
            //var gv = new GridView();
            //gv.DataSource = ToDataTable<BOL.vw_ERP_tbl_Customeremail>(objBs.getCustomerEmailList(clsGeneral.checkandReplace("")));
            //gv.DataBind();

            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=CustomerEmailMaster_"+DateTime.Now.ToString("ddMMyyyyhhmmsstt")+".xls");
            //Response.ContentType = "application/ms-excel";

            //Response.Charset = "";
            //StringWriter objStringWriter = new StringWriter();
            //HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            //gv.RenderControl(objHtmlTextWriter);

            //Response.Output.Write(objStringWriter.ToString());
            //Response.Flush();
            //Response.End();


            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerName", typeof(string));
            dt.Columns.Add("OrganizationName", typeof(string));
            dt.Columns.Add("CustomerCode", typeof(string));
            dt.Columns.Add("EInvoiceTo", typeof(string));
            dt.Columns.Add("EInvoiceCC", typeof(string));
            dt.Columns.Add("SOATo", typeof(string));
            dt.Columns.Add("SOACC", typeof(string));
            dt.Columns.Add("Remarks", typeof(string));
            dt.Columns.Add("ExcludeEInvoice", typeof(string));
            dt.Columns.Add("ExcludeSOA", typeof(string));
            dt.Columns.Add("UpdateUser", typeof(string));



            var sirList = objBs.getCustomerEmailList(clsGeneral.checkandReplace(""), "");
            if (sirList != null && sirList.Count > 0)
            {
                foreach (BOL.vw_ERP_tbl_Customeremail item in sirList)
                {


                    dt.Rows.Add(
                        item.CustomerName,
                        item.OrganizationName,
                        item.CustomerCode,
                        item.email_address,
                        item.CCemail_Address,
                        item.SOAemail_address,
                        item.SOACCemail_Address,
                        item.Remarks,
                        item.Exclude_EInvoice,
                        item.Exclude_SOA,
                        item.Updateuser
                        );
                }
            }
            var grid = new GridView();
            grid.DataSource = dt;
            grid.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=CustomerEmailMaster_" + DateTime.Now.ToString("ddMMyyyyhhmmsstt") + ".xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();



            return View("Index");
        }






        //Generic method to convert List to DataTable
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

    }

}