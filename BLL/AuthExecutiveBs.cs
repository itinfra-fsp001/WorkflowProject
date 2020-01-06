using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthExecutiveBs
    {
        private AuthExecutivedb objdb;

        public AuthExecutiveBs()
        {
            objdb = new AuthExecutivedb();

        }

        public IEnumerable<tbl_AuthExecutives> GetALL()
        {
            return objdb.GetALL();
        }

        public tbl_AuthExecutives GetbyID(string Approver)
        {
            return objdb.GetByID(Approver);
        }

        public void Insert(tbl_AuthExecutives AuthExecutive)
        {
            objdb.Insert(AuthExecutive);
        }

        public void Delete(string Approver)
        {
            objdb.Delete(Approver);
        }

        public void Update(tbl_AuthExecutives AuthExecutive)
        {
            objdb.Update(AuthExecutive);
        }

    }
}
