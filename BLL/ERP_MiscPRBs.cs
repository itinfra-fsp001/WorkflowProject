using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ERP_MiscPRBs
    {
        private ERP_MiscPRdb objdb;

        public ERP_MiscPRBs()
        {
            objdb = new ERP_MiscPRdb();

        }

        public IEnumerable<fsp_ReportMiscPurchaseRequisition_Result> GetALL(string PurchaseRequisitionNo)
        {
            return objdb.GetALL(PurchaseRequisitionNo);
        }

    }
}
