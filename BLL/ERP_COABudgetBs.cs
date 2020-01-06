using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ERP_COABudgetBs
    {
        private ERP_COABudgetdb objdb;

        public ERP_COABudgetBs()
        {
            objdb = new ERP_COABudgetdb();

        }

        public IEnumerable<fsp_GetCOABudgetSummary_Result> GetALL(string PurchaseRequisitionNo)
        {
            return objdb.GetALL(PurchaseRequisitionNo);
        }
    }
}
