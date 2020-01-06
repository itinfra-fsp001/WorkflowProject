using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DAL
{
    public class SOAdb
    {
        private WorkFlowDBEntities db;

        public SOAdb()
        {
            db = new WorkFlowDBEntities();
        }

        public List<vw_ERP_ServiceSOA> GetSOAList(string status, string customerName, string organization, string customerType, string parentOrganization,string period)
        {
            return db.SP_SOA_View_GetSOAListForFDashboard(customerName, organization, customerType, parentOrganization, status,period,MergeOption.NoTracking).ToList();
        }

        public List<vw_ERP_ServiceSOA> getALLSOAList(string status)
        {
            return db.SP_SOA_View_GetALLSOAList(status, MergeOption.NoTracking).ToList();
        }

        public vw_ERP_ServiceSOA GetSOAByID(Int32 logId)
        {
            var soa = db.SP_SOA_View_GetSOAByID(logId, MergeOption.NoTracking).ToList();
            if (soa != null && soa.Count > 0)
            {
                return soa[0];
            }
            return null;
        }

        public void markAsException(string IdList, string UserId)
        {

            using (var db = new WorkFlowDBEntities())
            {
                db.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
                db.SP_SOA_View_UpdateAsException(IdList, UserId);
                db.Configuration.EnsureTransactionsForFunctionsAndCommands = true;
            }
        }

        public void sendSOA(string IdList, string UserId, List<vw_ERP_ServiceSOA> soaList)
        {
            string[] idArr = IdList.Split(',');
            using (var db1 = new WorkFlowDBEntities())
            {
                //db.Configuration.AutoDetectChangesEnabled = false;
                //db.Configuration.AutoDetectChangesEnabled = true;
                //db.Configuration.ValidateOnSaveEnabled = false;
                //db.Configuration.ValidateOnSaveEnabled = true;
                //db.SP_SOA_View_UpdateAsException(IdList, UserId);
                db1.Configuration.EnsureTransactionsForFunctionsAndCommands = false;                
                foreach (vw_ERP_ServiceSOA soaItem in soaList)
                {
                    if (idArr.Contains(Convert.ToString(soaItem.LogID)))
                    {
                        db1.SP_SOA_View_UpdateSOAStatusToJobQueue(soaItem.LogID, soaItem.email_address, soaItem.CCemail_address, UserId);
                        //var dbItem = db1.vw_ERP_ServiceSOA.AsNoTracking().Where(x => x.LogID == soaItem.LogID).ToList();
                        //if(dbItem!=null && dbItem.Count()>0)
                        //{
                        //    dbItem[0].email_address = soaItem.email_address;
                        //    dbItem[0].CCemail_address = soaItem.CCemail_address;
                        //    dbItem[0].SOAStatus = "JOB QUEUE";
                        //    dbItem[0].UpdateBy = UserId;
                        //    dbItem[0].UpdateDate = DateTime.Now;
                        //    db1.vw_ERP_ServiceSOA.AddOrUpdate(dbItem[0]);                            
                        //}
                    }
                }
                //db1.SaveChanges();                
                db1.Configuration.EnsureTransactionsForFunctionsAndCommands = true;                
            }
        }


    }
}
