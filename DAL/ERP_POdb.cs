using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class ERP_POdb
    {
        private ErpByNetR1100Entities db;

        public ERP_POdb()
        {
            db = new ErpByNetR1100Entities();

        }

        public IEnumerable<fsp_ReportPurchaseOrder_sg_Result> GetALL(string PurchaseOrderNo)
        {
            return db.fsp_ReportPurchaseOrder_sg(PurchaseOrderNo).ToList();
        }
    }
}
