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
    public class DocumentWorkFlowdb
    {
        private WorkFlowDBEntities db;

        public DocumentWorkFlowdb()
        {
            db = new WorkFlowDBEntities();

        }

        public IEnumerable<tbl_DocumentWorkFlow> GetALL()
        {
            return db.tbl_DocumentWorkFlow.AsNoTracking().ToList();
        }


        public IEnumerable<tbl_DocumentWorkFlow> GetDocuemtWorkFlow(long DocID)
        {
            //return db.tbl_DocumentWorkFlow.ToList().Where(x => x.DocID == DocID);
            return db.SP_GetDocumentWorkflowByDocID(DocID,MergeOption.NoTracking).ToList();
        }


        public tbl_DocumentWorkFlow GetByID(long WorkFlowID)
        {
            //return db.tbl_DocumentWorkFlow.Find(WorkFlowID);
            return db.SP_GetDocumentWorkflowByWorkflowID(WorkFlowID,MergeOption.NoTracking).ToList()[0];
        }

        public void Insert(tbl_DocumentWorkFlow Document)
        {
            db.tbl_DocumentWorkFlow.Add(Document);
            Save();
        }

        public void Delete(int WorkFlowID)
        {
            //tbl_DocumentWorkFlow Document = db.tbl_DocumentWorkFlow.Find(WorkFlowID);
            tbl_DocumentWorkFlow Document = GetByID(WorkFlowID);
            db.tbl_DocumentWorkFlow.Remove(Document);
            Save();
        }

        public void Update(tbl_DocumentWorkFlow Document)
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
