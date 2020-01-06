using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class CostObjectBS
    {
      private CostObjectdb costDb;
      public CostObjectBS()
      {
          costDb = new CostObjectdb();
      }
      public IEnumerable<tbl_CostObject> GetALL()
      {
          return costDb.GetALL();
      }
       public  List<string> GetObjectNumbers(string objectType)
        {
            return costDb.GetObjectNumbers(objectType);
        }

        public string GetObjectNameByObjectNumber(string objNameobjNumber,string objeType)
        {
            return costDb.GetObjectNameByObjectNumber(objNameobjNumber, objeType);
        }
    }
}
