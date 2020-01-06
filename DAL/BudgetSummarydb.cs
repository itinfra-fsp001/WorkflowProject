using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class BudgetSummarydb
    {

        private WorkFlowDBEntities db;

        public BudgetSummarydb()
        {
            db = new WorkFlowDBEntities();

        }
        public IEnumerable<ERP_ProjectBudgetSummary_Result> GetALL(string ObjectNo)
        {
            return db.ERP_ProjectBudgetSummary(ObjectNo).ToList();
        }
    }
}
