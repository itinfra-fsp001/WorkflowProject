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
    public class fspDocumentDetailsdb
    {
        private ErpByNetR1100Entities db;

        public fspDocumentDetailsdb()
        {
            db = new ErpByNetR1100Entities();

        }
        public IEnumerable<fsp_DocumentDetails> GetALL()
        {
            return db.fsp_DocumentDetails.AsNoTracking().ToList();
        }

        public fsp_DocumentDetails GetByID(int DocID)
        {
            //return db.fsp_DocumentDetails.Find(DocID);
            return db.fsp_DocumentDetails.AsNoTracking().Where(x => x.DocID == DocID).ToList()[0];
        }





        public void Update(fsp_DocumentDetails Document)
        {
            db.Entry(Document).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }


        public void Save()
        {
            db.SaveChanges();
        }
    }
}
