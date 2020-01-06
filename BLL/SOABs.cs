using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;

namespace BLL
{
    public class SOABs
    {
        public SOAdb db;
        public SOABs()
        {
            db = new SOAdb();
        }
        public List<vw_ERP_ServiceSOA> GetSOAList(string status, string customerName, string organization, string customerType, string parentOrganization,string period)
        {
            return db.GetSOAList(status, customerName, organization, customerType, parentOrganization,period).ToList();
        }
        public List<vw_ERP_ServiceSOA> getALLSOAList(string status)
        {
            return db.getALLSOAList(status).ToList();
        }
        public vw_ERP_ServiceSOA GetSOAByID(Int32 logId)
        {
            return db.GetSOAByID(logId);
        }

        public void markAsException(string IdList, string UserId)
        {
            db.markAsException(IdList, UserId);
        }

        public void sendSOA(string IdList, string UserId, List<vw_ERP_ServiceSOA> soaList)
        {
            db.sendSOA(IdList, UserId, soaList);
        }
    }
}
