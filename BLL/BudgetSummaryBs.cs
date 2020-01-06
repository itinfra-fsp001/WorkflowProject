using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BudgetSummaryBs
    {
        private BudgetSummarydb objdb;

        public BudgetSummaryBs()
        {
            objdb = new BudgetSummarydb();

        }

        public IEnumerable<ERP_ProjectBudgetSummary_Result> GetALL(string ObjectNo)
        {
            return objdb.GetALL(ObjectNo);
        }
    }
}
