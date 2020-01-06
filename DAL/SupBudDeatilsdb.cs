using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace DAL
{
    public class SupBudDeatilsdb
    {
        private WorkFlowDBEntities db;
        private Userdb userDb;
        public SupBudDeatilsdb()
        {
            db = new WorkFlowDBEntities();
            userDb = new Userdb();
        }
        public IEnumerable<tbl_SupBudgetDetail> GetALL()
        {
            return db.tbl_SupBudgetDetail.AsNoTracking().ToList();
        }

        //public tbl_SupBudgetDetail GetByID(string refNumber)
        //{
        //    return db.tbl_SupBudgetDetail.Find(refNumber.ToString());
        //}

        public tbl_SupBudgetDetail GetByID(string refNumber)
        {
            return db.SP_GetSBDetails(refNumber, MergeOption.NoTracking).ToList()[0];
        }

        public IEnumerable<tbl_SupBudgetDetail> GetByIDNew(string refNumber)
        {
            return db.SP_GetSBDetails(refNumber, MergeOption.NoTracking).ToList();
        }

        public void Insert(tbl_SupBudgetDetail supDetails)
        {
            db.tbl_SupBudgetDetail.Add(supDetails);
            db.SaveChanges();
            string RefNo = supDetails.ReferenceNo;
            var tblsubdetails = db.tbl_SupBudgetDetail.AsNoTracking().Where(p => p.ReferenceNo == RefNo);
            var Netprice = tblsubdetails.Sum(p => p.ReqSuppBudgetAmt);
            var header = db.tbl_SupBudgetHeader.AsNoTracking().Where(p => p.ReferenceNo == RefNo).First();
            header.NetPrice = Netprice;
            //db.SaveChanges();
            db.Entry(header).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool IsExistsRefId(string refNumber)
        {
            bool isExists = false;
            //var cnt = db.tbl_SupBudgetDetail.Where(p => p.ReferenceNo == refNumber.ToString());
            var cnt = db.SP_GetSBDetails(refNumber, MergeOption.NoTracking).ToList();
            if (cnt != null && cnt.Count() > 0) isExists = true;
            return isExists;
            //    throw new NotImplementedException();
        }

        public IEnumerable<string> GetDtlObjectNos(string objectNo, string variationOrderNo)
        {
            List<string> ltObjects = new List<string>();
            if (string.IsNullOrEmpty(variationOrderNo))
                ltObjects = db.vw_ERP_ProjectBudget.AsNoTracking().Where(p => p.ObjectNo == objectNo).Select(x => x.DtlObjectNo).ToList();
            else
                ltObjects = db.vw_ERP_ProjectBudget.AsNoTracking().Where(p => p.ObjectNo == objectNo && p.IsChangeOrderGroup == false).Select(x => x.DtlObjectNo).ToList();
            return ltObjects.Distinct();
        }

        public List<GlAccount> GetGlaAccounts(string objectNo, string costType)
        {
            List<GlAccount> lt = new List<GlAccount>();
            List<GlAccount> ltFinal = new List<GlAccount>();
            try
            {
                switch (costType.Trim())
                {
                    case "Project":
                        lt = db.vw_ERP_ProjectBudget.AsNoTracking().Where(p => p.DtlObjectNo == objectNo).OrderBy(p => p.GLCode).Select(p => new GlAccount() { GlCode = p.GLCode, GlDesc = p.GLDesc }).Distinct().ToList();
                        break;
                    case "Cost center":
                        lt = db.vw_ERP_CostCentreBudget.AsNoTracking().Where(p => p.ObjectNo == objectNo).OrderBy(p => p.GLCode).Select(p => new GlAccount() { GlCode = p.GLCode, GlDesc = p.GLDesc }).Distinct().ToList();
                        break;

                    case "Sales Group":
                        lt = db.vw_ERP_SalesGroupBudget.AsNoTracking().Where(p => p.ObjectNo == objectNo).OrderBy(p => p.GLCode).Select(p => new GlAccount() { GlCode = p.GLCode, GlDesc = p.GLDesc }).Distinct().ToList();
                        break;
                    case "ETTicket":
                        lt = db.vw_ERP_CostCentreBudget.AsNoTracking().Where(p => p.ObjectNo == objectNo).OrderBy(p => p.GLCode).Select(p => new GlAccount() { GlCode = p.GLCode, GlDesc = p.GLDesc }).Distinct().ToList();
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

            }
            foreach (GlAccount ga in lt)
            {
                if (!ltFinal.Exists(p => p.GlCode == ga.GlCode))
                {
                    ltFinal.Add(ga);
                }
            }
            // lt.Sort();
            return ltFinal;
        }

        public bool CanReqAmountAdded(string variationNumber, string referenceNo, string reqAmount, string Glaccount, ref decimal totalAmount, ref decimal elgAmount)
        {
            bool status = false;
            var erp = db.vw_ERP_ProjectBudget.AsNoTracking().Where(p => p.DtlObjectNo == variationNumber && p.GLCode == Glaccount).First();
            if (erp != null)
            {
                totalAmount = Convert.ToDecimal(erp.ApprovedBudgetAmount + erp.SupplementaryBudget1Approved +
                    erp.SupplementaryBudget2Approved - (erp.CommitedAmount + erp.ActualAmount));
                var subDetailReqTotal = db.tbl_SupBudgetDetail.AsNoTracking().Where(p => p.ReferenceNo == referenceNo && p.GLAccount == Glaccount).Sum(p => p.ReqSuppBudgetAmt);
                subDetailReqTotal = subDetailReqTotal ?? 0;
                if (totalAmount < subDetailReqTotal + Convert.ToDecimal(reqAmount))
                {
                    elgAmount = Convert.ToDecimal(totalAmount - subDetailReqTotal);
                }
                else
                {
                    status = true;
                }
            }
            return status;
        }

        public void SubmitReferenceNo(string id,string userId)
        {
            var user = userDb.getUserByUserID(userId);
            string userDept = "";
            if(user!=null)
            {
                userDept = Convert.ToString(user.DeptCode);
            }
            //var supDetails = db.tbl_SupBudgetDetail.Where(p => p.ReferenceNo == id);
            var supDetails = db.SP_GetSBDetails(id, MergeOption.NoTracking).ToList();
            var netPrice = supDetails.Sum(p => p.ReqSuppBudgetAmt);
            var header = db.tbl_SupBudgetHeader.AsNoTracking().Where(p => p.ReferenceNo == id).First();
            header.NetPrice = netPrice;
            header.Status = "S";
            db.Entry(header).State = EntityState.Modified;
            db.SaveChanges();


            

            var tbldocuments = db.tbl_Documents.AsNoTracking();
            Int64 Docid = tbldocuments.AsNoTracking().Count(p => p.DocType == "SB") == 0 ? 1000001 : tbldocuments.AsNoTracking().Where(p => p.DocType == "SB").Max(p => p.DocID) + 1;
            tbl_Documents doc = new tbl_Documents()
            {
                DocID = Docid,
                DocNo = id,
                DocType = "SB",
                Currency = "SGD",
                NetPrice = netPrice,
                Status = "",
                SubmitBy = header.SubmitBy,
                SubmitDate = DateTime.Now,
                DocNetPrice = netPrice,
                ERPAttachment = false,
                UpdateDate = DateTime.Now,
                DeptCode = userDept

            };
            db.tbl_Documents.Add(doc);
            db.SaveChanges();
        }

        public int GetMaxCount(string referenceNo)
        {
            //var supDetails = db.tbl_SupBudgetDetail.Where(p => p.ReferenceNo == referenceNo);
            var supDetails = db.SP_GetSBDetails(referenceNo, MergeOption.NoTracking).ToList();
            return supDetails.Count() == 0 ? 1 : supDetails.Max(p => p.SeqNo) + 1;
        }

        public void DeleteSubDetail(string id, int seq)
        {
            //.AsNoTracking()
            var refRange = db.tbl_SupBudgetDetail.Where(p => p.ReferenceNo == id & p.SeqNo == seq).ToList();
            db.tbl_SupBudgetDetail.RemoveRange(refRange);
            db.SaveChanges();
            string RefNo = id;
            //var tblsubdetails = db.tbl_SupBudgetDetail.Where(p => p.ReferenceNo == RefNo);
            var tblsubdetails = db.SP_GetSBDetails(RefNo, MergeOption.NoTracking).ToList();
            var Netprice = tblsubdetails.Sum(p => p.ReqSuppBudgetAmt);
            var header = db.tbl_SupBudgetHeader.AsNoTracking().Where(p => p.ReferenceNo == RefNo).First();
            header.NetPrice = Netprice;
            db.Entry(header).State = EntityState.Modified;
            db.SaveChanges();

        }

        public List<GlAccount> GetDtAccounts(string objectNumber)
        {
            List<GlAccount> lt = new List<GlAccount>();
            var data = db.vw_ERP_ProjectBudget.AsNoTracking().Where(p => p.ObjectNo == objectNumber && p.IsChangeOrderGroup == true).Select(p => p.DtlObjectNo).Distinct().ToList();
            data.Sort();
            lt = data.Select(p => new GlAccount() { GlCode = p, GlDesc = p }).ToList();
            return lt;
        }

        public void DeleteByRefId(string id)
        {
            //var refRange = db.tbl_SupBudgetDetail.Where(p => p.ReferenceNo == id);
            var refRange = db.SP_GetSBDetails(id).ToList();  //, MergeOption.NoTracking
            db.tbl_SupBudgetDetail.RemoveRange(refRange);
            db.SaveChanges();
        }

        public tbl_SupBudgetDetail GetSupDetailByGlCode(string glCode, string DtlObjectNo, string costType)
        {
            tbl_SupBudgetDetail tblSupDetail = new tbl_SupBudgetDetail();
            try
            {
                switch (costType)
                {
                    case "Project":
                        var proj = db.vw_ERP_ProjectBudget.AsNoTracking().Where(p => p.DtlObjectNo == DtlObjectNo && p.GLCode == glCode).First();
                        tblSupDetail = GetSubDetails(proj.ApprovedBudgetAmount, proj.CommitedAmount, proj.ActualAmount
            , proj.SupplementaryBudget1Approved, proj.SupplementaryBudget2Approved);
                        break;
                    case "Cost center":
                        //tblSupDetail = db.vw_ERP_CostCentreBudget.ToList().Where(p => p.ObjectNo == objectNumber).Select(p => new GlAccount() { GlCode = p.GLCode, GlDesc = p.GLDesc }).Distinct().ToList();
                        var cost = db.vw_ERP_CostCentreBudget.AsNoTracking().Where(p => p.ObjectNo == DtlObjectNo && p.GLCode == glCode).First();
                        tblSupDetail = GetSubDetails(cost.ApprovedBudgetAmount, cost.CommitedAmount, cost.ActualAmount
                      , cost.SupplementaryBudget1Approved, cost.SupplementaryBudget2Approved);
                        break;

                    case "Sales Group":
                        // tblSupDetail = db.vw_ERP_SalesGroupBudget.ToList().Where(p => p.ObjectNo == objectNumber).Select(p => new GlAccount() { GlCode = p.GLCode, GlDesc = p.GLDesc }).Distinct().ToList();
                        var sales = db.vw_ERP_SalesGroupBudget.AsNoTracking().Where(p => p.ObjectNo == DtlObjectNo && p.GLCode == glCode).First();
                        tblSupDetail = GetSubDetails(sales.ApprovedBudgetAmount, sales.CommitedAmount, sales.ActualAmount
                      , sales.SupplementaryBudget1Approved, sales.SupplementaryBudget2Approved);
                        break;
                    case "ETTicket":
                        var ett = db.vw_ERP_CostCentreBudget.AsNoTracking().Where(p => p.ObjectNo == DtlObjectNo && p.GLCode == glCode).First();
                        tblSupDetail = GetSubDetails(ett.ApprovedBudgetAmount, ett.CommitedAmount, ett.ActualAmount
                      , ett.SupplementaryBudget1Approved, ett.SupplementaryBudget2Approved);
                        break;
                    case "Inventory Stock":
                        var invstock = db.vw_ERP_WarehouseBudget.AsNoTracking().Where(p => p.ObjectNo == DtlObjectNo).First();
                        tblSupDetail = GetSubDetails(Convert.ToDouble(invstock.ApprovedBudgetAmount), Convert.ToDouble(invstock.CommitedAmount), Convert.ToDouble(invstock.ActualAmount)
                      , Convert.ToDouble(invstock.SupplementaryBudget1Approved), Convert.ToDouble(invstock.SupplementaryBudget2Approved));
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {

            }
            return tblSupDetail;
        }

        private static tbl_SupBudgetDetail GetSubDetails(double? ApprovedBudgetAmount, double? CommitedAmount, double? ActualAmount
            , double? SupplementaryBudget1Approved, double? SupplementaryBudget2Approved)
        {
            return new tbl_SupBudgetDetail
            {
                OriginalBudgtAmt = Math.Round(Convert.ToDecimal(ApprovedBudgetAmount), 2),
                ActualAmount = Math.Round(Convert.ToDecimal(CommitedAmount + ActualAmount), 2),
                SuppBudgetAmt = Math.Round(Convert.ToDecimal(SupplementaryBudget1Approved + SupplementaryBudget2Approved), 2),
                TotalBalanceBudget = Math.Round(Convert.ToDecimal(ApprovedBudgetAmount + SupplementaryBudget1Approved + SupplementaryBudget2Approved - (CommitedAmount + ActualAmount)), 2)
            };
        }
    }
}
