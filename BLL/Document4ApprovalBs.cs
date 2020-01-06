using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Document4ApprovalBs
    { 
            
        private Document4Approvaldb objdb;

        public Document4ApprovalBs()
        {
            objdb = new Document4Approvaldb();
        }

        //public IEnumerable<vw_Documents4Approval> GetALL()
        //{
        //    return objdb.GetALL();
        //}

        //public IEnumerable<vw_Documents4Approval> GetDocuemtWorkFlow(int DocID)
        //{
        //    return objdb.GetALL().Where(x => x.DocID == DocID);
        //}


        //public vw_Documents4Approval GetbyID(int Id)
        //{
        //    return objdb.GetByID(Id);
        //}
    }


}
