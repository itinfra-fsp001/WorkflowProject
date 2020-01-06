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
    public class LeaveDetailsBs
    {
        private LeaveDetailsdb objdb;
        public LeaveDetailsBs()
        {
            objdb = new LeaveDetailsdb();

        }

        public IEnumerable<tbl_LeaveDetails> GetALL()
        {
            return objdb.GetALL();
        }

        public tbl_LeaveDetails GetbyID(string User)
        {
            return objdb.GetByID(User);
        }

        public void Insert(tbl_LeaveDetails LeaveDetails)
        {
            objdb.Insert(LeaveDetails);
        }

        public void Delete(long id)
        {
            objdb.Delete(id);
        }

        public void Update(tbl_LeaveDetails LeaveDetails)
        {
            objdb.Update(LeaveDetails);
        }
        public List<string> GetAllApprovers(string user)
        {
            return objdb.GetAllApprovers(user);
        }
    }
}
