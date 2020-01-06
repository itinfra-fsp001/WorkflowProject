using BLL;
using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class fspDocumentDetailsBs
    {

        private fspDocumentDetailsdb objdb;
        public fspDocumentDetailsBs()
        {
            objdb = new fspDocumentDetailsdb();

        }

        public IEnumerable<fsp_DocumentDetails> GetALL()
        {
            return objdb.GetALL();
        }

        public fsp_DocumentDetails GetbyID(int Id)
        {
            return objdb.GetByID(Id);
        }





        public void Update(fsp_DocumentDetails Document)
        {
            objdb.Update(Document);
        }
    }
}
