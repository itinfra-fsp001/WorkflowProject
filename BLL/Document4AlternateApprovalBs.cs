using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Document4AlternateApprovalBs
    {

        private Document4AltrApprovaldb objdb;

        public Document4AlternateApprovalBs()
        {
            objdb = new Document4AltrApprovaldb();

        }

        //public IEnumerable<vw_Documents4AlternateApproval> GetALL()
        //{
        //    return objdb.GetALL();
        //}

        //public IEnumerable<vw_Documents4AlternateApproval> GetDocuemtWorkFlow(int DocID)
        //{
        //    return objdb.GetALL().Where(x => x.DocID == DocID);
        //}


        //public vw_Documents4AlternateApproval GetbyID(int Id)
        //{
        //    return objdb.GetByID(Id);
        //}
    }
}
