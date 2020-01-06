using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SupBudDeatilsBS
    {
        private SupBudDeatilsdb objdb;
        public SupBudDeatilsBS()
        {
            objdb = new SupBudDeatilsdb();
        }
        public IEnumerable<tbl_SupBudgetDetail> GetALL()
        {
            return objdb.GetALL();
        }
        public tbl_SupBudgetDetail GetByID(string DocID)
        {
            return objdb.GetByID(DocID);
        }

        public IEnumerable<tbl_SupBudgetDetail> GetByIDNew(string DocID)
        {
            return objdb.GetByIDNew(DocID);
        }

        public bool IsExistsRefId(string DocID)
        {
            return objdb.IsExistsRefId(DocID);
        }
        public void Insert(tbl_SupBudgetDetail Document)
        {
            objdb.Insert(Document);
        }
        public List<string> GetDtlObjectNos(string objectNo, string costType, string variationOrderNo)
        {
            List<string> objectNos = new List<string>();
            if (costType == "Project")
                objectNos = objdb.GetDtlObjectNos(objectNo, variationOrderNo).ToList();
            else
                objectNos.Add(objectNo);
            return objectNos;
        }
        public List<GlAccount> GetGlaAccounts(string ObjectNo, string CostType)
        {
            return objdb.GetGlaAccounts(ObjectNo, CostType);
        }

        public tbl_SupBudgetDetail GetSupDetailByGlCode(string glCode, string objectNumber, string costType)
        {
            tbl_SupBudgetDetail tbl = objdb.GetSupDetailByGlCode(glCode, objectNumber, costType);
            tbl.DtlObjectNo = objectNumber;
            tbl.GLAccount = glCode;
            return tbl;
        }

        public void DeleteByRefId(string id)
        {
            objdb.DeleteByRefId(id);
        }

        public List<GlAccount> GetDtAccounts(string objectNo)
        {
            return objdb.GetDtAccounts(objectNo);
        }

        public void DeleteSubDetail(string id, int seq)
        {
            objdb.DeleteSubDetail(id, seq);
        }

        public int GetMaxCount(string referenceNo)
        {
            return objdb.GetMaxCount(referenceNo);
        }

        public void SubmitReferenceNo(string id, string userId)
        {
            objdb.SubmitReferenceNo(id, userId);
        }

        public bool CanReqAmountAdded(string variationNumber, string referenceNo, string reqAmount, string GLAccount, ref decimal totalAmount, ref decimal elgAmount)
        {
            return objdb.CanReqAmountAdded(variationNumber, referenceNo, reqAmount, GLAccount, ref totalAmount, ref elgAmount);
        }
    }
}
