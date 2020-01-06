using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkFlowUI.ViewModel;

namespace WorkFlowUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LeaveDetailsController : Controller
    {
        // GET: Admin/LeaveDetails
        private LeaveDetailsBs ObjBs;
        private LeaveDetails_HisBs ObjHisBs;



        public LeaveDetailsController()
        {
            ObjBs = new LeaveDetailsBs();
            ObjHisBs = new LeaveDetails_HisBs();


        }

        public ActionResult Index()
        {            
            try
            {
                var users = GetUserInfo();
                var leaveModel = new LeaveViewModel()
                {
                    Leave = new tbl_LeaveDetails(),
                    Users = users
                };
                //  var LeaveDetails = ObjBs.GetbyID(Id);
                TempData["Users"] = users;
                return View(leaveModel);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "LeaveDetails", "Index", clsGeneral.errorMessage(ex));
                return View();
            }
        }

        private List<SelectListItem> GetUserInfo()
        {
            
            try
            {
                var users = ObjBs.GetAllApprovers(User.Identity.Name);
                List<SelectListItem> lt = new List<SelectListItem>();
                foreach (string user in users)
                {
                    lt.Add(new SelectListItem
                    {
                        Text = user,
                        Value = user
                    });
                }
                return lt;
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "LeaveDetails", "GetUserInfo", clsGeneral.errorMessage(ex));
                return null;
            }
        }

        [HttpPost]
        public ActionResult SaveLeaveDetails(LeaveViewModel vm)
        {
            try
            {
                tbl_LeaveDetails LeaveDetails = vm.Leave;
                string errorMsg = string.Empty;
                if (TempData["Users"] == null)
                {
                    TempData["Users"] = GetUserInfo();
                }
                vm.Users = TempData["Users"] as List<SelectListItem>;
                bool validateFailed = ValidateLeave(LeaveDetails, ref errorMsg);
                if (!validateFailed)
                {
                    @TempData["Msg"] = errorMsg;
                    return View("Index", vm);
                }
                var LDetails = ObjBs.GetALL().Where(p => p.User.ToLower() == LeaveDetails.User.ToLower() && p.Enddate < DateTime.Now.Date).ToList();

                if (LDetails.Count() != 0)
                {
                    foreach (tbl_LeaveDetails item in LDetails)
                    {
                        var LeaveDetailsHis = new tbl_LeaveDetails_His();
                        LeaveDetailsHis.User = LeaveDetails.User.ToLower();
                        LeaveDetailsHis.StartDate = item.StartDate;
                        LeaveDetailsHis.Enddate = item.Enddate;
                        LeaveDetailsHis.Remarks = item.Remarks;
                        LeaveDetailsHis.UpdateDate = item.UpdateDate;
                        LeaveDetailsHis.UpdateBy = item.UpdateBy;
                        ObjHisBs.Insert(LeaveDetailsHis);
                        ObjBs.Delete(item.Id); // Remove from Leave details
                    }
                }

                #region Old Code
                //List<tbl_LeaveDetails> ltLeveDetails = new List<tbl_LeaveDetails>();
                //List<tbl_LeaveDetails_His> ltLeveDetailsHis = new List<tbl_LeaveDetails_His>();
                //if (LDetails.Count() != 0)
                //{
                //    var ldetail = LDetails.Last();
                //    //foreach (var ldetail in LDetails)
                //    // {
                //    var LeaveDetailsHis = new tbl_LeaveDetails_His();

                //    LeaveDetailsHis.User = LeaveDetails.User.ToLower();
                //    LeaveDetailsHis.StartDate = ldetail.StartDate;
                //    LeaveDetailsHis.Enddate = ldetail.Enddate;
                //    LeaveDetailsHis.Remarks = ldetail.Remarks;
                //    LeaveDetailsHis.UpdateDate = ldetail.UpdateDate;
                //    LeaveDetailsHis.UpdateBy = ldetail.UpdateBy;
                //    ObjHisBs.Insert(LeaveDetailsHis);
                //    // }
                //    //ObjBs.Delete(ldetail.Id);
                //}
                #endregion

                LeaveDetails.User = LeaveDetails.User.ToLower();
                LeaveDetails.StartDate = LeaveDetails.StartDate;
                LeaveDetails.Enddate = LeaveDetails.Enddate;
                LeaveDetails.UpdateDate = DateTime.Now;
                LeaveDetails.UpdateBy = User.Identity.Name;
                ObjBs.Insert(LeaveDetails);
                @TempData["Msg"] = "Saved Successfully.";
                vm.Users = GetUserInfo();
                return View("Index", vm);
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "LeaveDetails", "SaveLeaveDetails", clsGeneral.errorMessage(ex));
                return null;
            }            
        }

        private bool ValidateLeave(tbl_LeaveDetails leaveDetails, ref string errorMsg)
        {
            bool validation = false;
            try
            {
                var startDate = leaveDetails.StartDate;
                var endDate = leaveDetails.Enddate;
                if (startDate == null || endDate == null)
                {
                    errorMsg = "Start and End Dates are mandatory.";
                }
                else if (endDate < startDate)
                {
                    errorMsg = "Start date should be lesser than End date.";
                }
                else if (endDate < DateTime.Now.AddDays(-1) || startDate < DateTime.Now.AddDays(-1))
                {
                    errorMsg = "Old dates can not be selected.";
                }
                else if (ObjBs.GetALL().Where(p => p.User.ToLower() == leaveDetails.User.ToLower() && ((leaveDetails.StartDate >= p.StartDate && leaveDetails.StartDate <= p.Enddate) || (leaveDetails.Enddate >= p.StartDate && leaveDetails.Enddate <= p.Enddate) || (leaveDetails.StartDate >= p.StartDate && leaveDetails.Enddate <= p.Enddate))).ToList().Count() > 0)
                {
                    errorMsg = "Out of office configured already for these date(s).";
                }
                else
                {
                    validation = true;
                }
            }
            catch (Exception ex)
            {
                BLL.clsLog.insertLog(User.Identity.Name, "LeaveDetails", "ValidateLeave", clsGeneral.errorMessage(ex));

            }
            return validation;
        }
    }
}