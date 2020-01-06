using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.MailService;

namespace BLL
{
    public class LeaveDetails_HisBs
    {
        private LeaveDetails_Hisdb objdb;
        public LeaveDetails_HisBs()
        {
            objdb = new LeaveDetails_Hisdb();

        }

        public IEnumerable<tbl_LeaveDetails_His> GetALL()
        {
            return objdb.GetALL();
        }

        public tbl_LeaveDetails_His GetbyID(string User)
        {
            return objdb.GetByID(User);
        }

        public void Insert(tbl_LeaveDetails_His LeaveDetails_His)
        {
            objdb.Insert(LeaveDetails_His);
        }

        public void Delete(string User)
        {
            objdb.Delete(User);
        }

        public void Update(tbl_LeaveDetails_His LeaveDetails_His)
        {
            objdb.Update(LeaveDetails_His);
        }

    }
}
