using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SupplementaryBudgetBs
    {
        private SupplementaryBudgetdb objdb;
        public SupplementaryBudgetBs()
        {
            objdb = new SupplementaryBudgetdb();
        }
        public IEnumerable<tbl_SupBudgetHeader> GetALL()
        {
            return objdb.GetALL();
        }

        public IEnumerable<tbl_SupBudgetHeader> GetSBHeader(string userId)
        {
            return objdb.GetSBHeader(userId);
        }

        public tbl_SupBudgetHeader GetByID(string DocID)
        {
            return objdb.GetByID(DocID);
        }
        public void Insert(tbl_SupBudgetHeader Document)
        {
            objdb.Insert(Document);
        }
        public string GetDisvisionNumber(string user)
        {
            return objdb.GetDisvisionNumber(user);
        }
        public void Update(tbl_SupBudgetHeader Document)
        {
            objdb.Update(Document);
        }
        public void DeleteByRefId(string id)
        {
            objdb.DeleteByRefId(id);
        }
        public IEnumerable<vw_ERP_CostCentre> GetCostCentre()
        {
            return objdb.GetCostCentre().ToList();
        }
    }
}
