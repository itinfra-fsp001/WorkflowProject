using BLL.MailService;
using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DocumentWorkfFlowBs
    {
        private DocumentWorkFlowdb objdb;
        private MailServiceClient _mailClient;
        public DocumentWorkfFlowBs()
        {
            objdb = new DocumentWorkFlowdb();

        }

        public IEnumerable<tbl_DocumentWorkFlow> GetALL()
        {
            return objdb.GetALL();
        }

        public IEnumerable<tbl_DocumentWorkFlow> GetDocuemtWorkFlow(long DocID)
        {
            //return objdb.GetALL().Where(x => x.DocID == DocID); 
            return objdb.GetDocuemtWorkFlow(DocID);
        }


        public tbl_DocumentWorkFlow GetbyID(long Id)
        {
            return objdb.GetByID(Id);
        }

        public void Insert(tbl_DocumentWorkFlow Document)
        {
            objdb.Insert(Document);
        }

        public void Delete(int Id)
        {
            objdb.Delete(Id);
        }

        public void Update(tbl_DocumentWorkFlow Document)
        {
            objdb.Update(Document);
        }
       
    }
}
