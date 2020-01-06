using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class ERP_SubconPOdb
    {

        private ErpByNetR1100Entities db;

        public ERP_SubconPOdb()
        {
            db = new ErpByNetR1100Entities();

        }

        public IEnumerable<fsp_ReportSubconPO_CumulativeDetails_Result> GetALL(string PurchaseOrderNo)
        {
            return db.fsp_ReportSubconPO_CumulativeDetails(PurchaseOrderNo).ToList();
        }

    }
}
