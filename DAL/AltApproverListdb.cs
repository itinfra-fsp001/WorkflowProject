using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
   public  class AltApproverListdb
    {
        private WorkFlowDBEntities db;

        public AltApproverListdb()
        {
            db = new WorkFlowDBEntities();

        }
        public List<string>  GetALL(string User)
        {
            return db.SP_Get_AltApprovers(User).ToList();
        }


    }
}
