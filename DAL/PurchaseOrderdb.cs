using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class PurchaseOrderdb
    {
        private WorkFlowDBEntities db;

        public PurchaseOrderdb()
        {
            db = new WorkFlowDBEntities();

        }
        public IEnumerable<tbl_PurchaseOrder> GetALL()
        {
            return db.tbl_PurchaseOrder.AsNoTracking().ToList();
        }

        public IEnumerable<tbl_PurchaseOrder> GetALLPurchaseOrders(bool status,string docNo,string buyerName,string vendorName)
        {
            return db.SP_GetAllPurchaseOrders(status, docNo, buyerName, vendorName,MergeOption.NoTracking).ToList();
        }


        public tbl_PurchaseOrder GetByID(int DocID)
        {
            //return db.tbl_PurchaseOrder.Find(DocID);
            return db.SP_GetPurchaseOrder(DocID,MergeOption.NoTracking).ToList()[0];
        }

        public tbl_PurchaseOrder GetByIDForDelete(int DocID)
        {
            //return db.tbl_PurchaseOrder.Find(DocID);
            return db.SP_GetPurchaseOrder(DocID).ToList()[0]; //MergeOption.NoTracking
        }

        public void Insert(tbl_PurchaseOrder Document)
        {
            db.tbl_PurchaseOrder.Add(Document);
            Save();
        }

        public void Delete(int DocID)
        {
            //tbl_PurchaseOrder document = db.tbl_PurchaseOrder.Find(DocID);
            tbl_PurchaseOrder document = GetByIDForDelete(DocID);
            db.Configuration.ValidateOnSaveEnabled = false;
            //db.tbl_PurchaseOrder.Remove(document);
            db.Entry(document).State = EntityState.Deleted;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Update(tbl_PurchaseOrder Document)
        {
            db.Entry(Document).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public IEnumerable<tbl_PurchaseOrder> GetALLForDepartment(string department)
        {
            var purchaseOrder = from a in db.tbl_PurchaseOrder
                                join c in db.vw_ERP_UserDetails on a.BuyerName equals c.UserId
                                where c.DepartmentName == department
                                select a;
            return purchaseOrder;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public bool IsPrmailExists(string poNumber, int docId)
        {
            bool isPrmailExists = true;
            List<string> prs = db.SP_Get_PrEmails(poNumber, docId).ToList();
            if (prs == null || prs.Count == 0)
                isPrmailExists = false;
            return isPrmailExists;

        }

        public spResult isPREmailExistsNew(string poNumber, int docId)
        {
            spResult isRet = new spResult();
            var opSPResult = new ObjectParameter("Status", typeof(bool));
            var opMessage = new ObjectParameter("Message", typeof(string));
            var spResult = db.SP_Get_POEmailAllDetails(poNumber, docId, opSPResult, opMessage);
            isRet.result = Convert.ToBoolean(opSPResult.Value);
            isRet.message = Convert.ToString(opMessage.Value);            
            return isRet;
        }        
    }
}

