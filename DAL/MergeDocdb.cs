using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class MergeDocdb
    {
        private WorkFlowDBEntities db;
        public MergeDocdb()
        {
            db = new WorkFlowDBEntities();
        }
        public IEnumerable<tbl_DocMergeDetails> GetMergeDocList(int docId)
        {
            return db.SP_GetMergeDocDetails(docId, MergeOption.NoTracking).ToList();
        }
    }
}
