using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ERP_SubconPOBs
    {
        private ERP_SubconPOdb objdb;

        public ERP_SubconPOBs()
        {
            objdb = new ERP_SubconPOdb();

        }

        public IEnumerable<fsp_ReportSubconPO_CumulativeDetails_Result> GetALL(string PurchaseOrderNo)
        {
            return objdb.GetALL(PurchaseOrderNo);
        }
    }
}
