using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class ERP_COABudgetdb
    {
        private ErpByNetR1100Entities db;

        public ERP_COABudgetdb()
        {
            db = new ErpByNetR1100Entities();

        }

        public IEnumerable<fsp_GetCOABudgetSummary_Result> GetALL(string PurchaseRequisitionNo)
        {
            return db.fsp_GetCOABudgetSummary(PurchaseRequisitionNo).ToList();
        }

      
    }
}
