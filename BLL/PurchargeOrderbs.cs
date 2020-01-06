using BOL;
using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PurchargeOrderbs
    {
        private PurchaseOrderdb objdb;
        public PurchargeOrderbs()
        {
            objdb = new PurchaseOrderdb();

        }

        public IEnumerable<tbl_PurchaseOrder> GetALL()
        {
            return objdb.GetALL();
        }

        public IEnumerable<tbl_PurchaseOrder> GetALLPurchaseOrders(bool status, string docNo, string buyerName, string vendorName)
        {
            return objdb.GetALLPurchaseOrders(status, docNo, buyerName, vendorName);
        }

        public tbl_PurchaseOrder GetbyID(int Id)
        {
            return objdb.GetByID(Id);
        }

        public void Insert(tbl_PurchaseOrder Document)
        {
            objdb.Insert(Document);
        }

        public void Delete(int Id)
        {
            objdb.Delete(Id);
        }

        public void Update(tbl_PurchaseOrder Document)
        {
            objdb.Update(Document);
        }

        public IEnumerable<tbl_PurchaseOrder> GetALLForDepartment(string department)
        {
            return objdb.GetALLForDepartment(department);
        }
        public bool IsPrmailExists(string poNumber, int docId)
        {
            return objdb.IsPrmailExists(poNumber, docId);
        }

        public spResult isPREmailExistsNew(string poNumber, int docId)
        {
            return objdb.isPREmailExistsNew(poNumber, docId);
        }
    }
}
