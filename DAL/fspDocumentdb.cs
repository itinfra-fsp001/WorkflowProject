using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class fspDocumentdb
    {
        private ErpByNetR1100Entities db;
        private WorkFlowDBEntities db1;
        public fspDocumentdb()
        {
            db = new ErpByNetR1100Entities();
            db1 = new WorkFlowDBEntities();
        }
        public IEnumerable<fsp_Documents> GetALL()
        {
            
            return db.fsp_Documents.AsNoTracking().ToList();
        }

        public fsp_Documents GetByID(int DocID)
        {
            //return db.fsp_Documents.Find(DocID);
            return db.fsp_Documents.AsNoTracking().Where(x => x.DocID == DocID).ToList()[0];
        }





        public void Update(fsp_Documents Document)
        {
            db.Entry(Document).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Document.UpdateDate = DateTime.Now;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }


        public void Save()
        {
            db.SaveChanges();
        }
    }
}
