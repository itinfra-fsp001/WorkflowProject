using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class fspDocumentBs
    {
        private fspDocumentdb objdb;
        public fspDocumentBs()
        {
            objdb = new fspDocumentdb();

        }

        public IEnumerable<fsp_Documents> GetALL()
        {
            return objdb.GetALL();
        }

        public fsp_Documents GetbyID(int Id)
        {
            return objdb.GetByID(Id);
        }





        public void Update(fsp_Documents Document)
        {
            objdb.Update(Document);
        }
    }
}
