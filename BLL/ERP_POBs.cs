using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ERP_POBs
    {
        private ERP_POdb objdb;

        public ERP_POBs()
        {
            objdb = new ERP_POdb();

        }

        public IEnumerable<fsp_ReportPurchaseOrder_sg_Result> GetALL(string PurchaseOrderNo)
        {
            return objdb.GetALL(PurchaseOrderNo);
        }
    }
}
