using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
   public class CostObjectdb
    {
       private WorkFlowDBEntities db;
       public CostObjectdb()
       {
           db = new WorkFlowDBEntities();
       }
       public IEnumerable<tbl_CostObject> GetALL()
       {
           return db.tbl_CostObject.AsNoTracking().ToList();
       }

        public List<string> GetObjectNumbers(string objectType)
        {
            List<string> lt=new List<string>();
            List<string> ltFinal = new List<string>();
            try
            {
                switch (objectType)
                {
                    case "Project":
                        //lt = db.vw_ERP_ProjectBudget.Select(p => p.ObjectNo).Distinct().ToList();
                        lt = db.SP_GetProjectBudget("List",null).ToList();
                        break;
                    case "Cost center":
                        //lt = db.vw_ERP_CostCentreBudget.Select(p => p.ObjectNo).Distinct().ToList();
                        lt = db.SP_GetCostCentreBudget("List",null).ToList();
                        break;

                    case "Sales Group":
                        //lt = db.vw_ERP_SalesGroupBudget.Select(p => p.ObjectNo).Distinct().ToList();
                        lt = db.SP_GetSalesGroupBudget("List",null).ToList();
                        break;
                    case "ETTicket":
                        //lt = db.vw_ERP_CostCentreBudget.Select(p => p.ObjectNo).Distinct().ToList();
                        lt = db.SP_GetCostCentreBudget("List",null).ToList();
                        break;
                    case "Inventory Stock":
                        //lt = db.vw_ERP_CostCentreBudget.Select(p => p.ObjectNo).Distinct().ToList();
                        lt = db.SP_GetWarehouseBudget("List", null).ToList();
                        break;
                    default:
                        break;
                }
                lt.Sort();
            }
            catch (Exception)
            {
            }
            return lt ;
        }

        public string GetObjectNameByObjectNumber(string objNumber,string objectType)
        {
            string objectName = string.Empty;
            switch (objectType.Trim())
            {
                case "Project":
                    //objectName = db.vw_ERP_ProjectBudget.First(p=>p.ObjectNo==objNumber).ObjectName;
                    objectName = db.SP_GetProjectBudget("Desc", objNumber).ToList()[0];
                    break;
                case "Cost center":
                    //objectName = db.vw_ERP_CostCentreBudget.First(p => p.ObjectNo == objNumber).ObjectDesc; ;
                    objectName = db.SP_GetCostCentreBudget("Desc", objNumber).ToList()[0];
                    break;
                case "Sales Group":
                    //objectName = db.vw_ERP_SalesGroupBudget.First(p => p.ObjectNo == objNumber).ObjectName; ;
                    objectName = db.SP_GetSalesGroupBudget("Desc", objNumber).ToList()[0];
                    break;
                case "ETTicket":
                    //objectName = db.vw_ERP_CostCentreBudget.First(p => p.ObjectNo == objNumber).ObjectDesc; 
                    objectName = db.SP_GetCostCentreBudget("Desc", objNumber).ToList()[0];
                    break;
                case "Inventory Stock":
                    //lt = db.vw_ERP_CostCentreBudget.Select(p => p.ObjectNo).Distinct().ToList();
                    objectName = db.SP_GetWarehouseBudget("Desc", objNumber).ToList()[0];
                    break;
                default:
                    break;
            }
            return objectName;
        }
    }
}
