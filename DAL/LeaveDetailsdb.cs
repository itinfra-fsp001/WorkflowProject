using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class LeaveDetailsdb
    {

        private WorkFlowDBEntities db;

        public LeaveDetailsdb()
        {
            db = new WorkFlowDBEntities();

        }
        public IEnumerable<tbl_LeaveDetails> GetALL()
        {
            return db.tbl_LeaveDetails.AsNoTracking().ToList();
        }

        public tbl_LeaveDetails GetByID(string User)
        {
            //return db.tbl_LeaveDetails.Find(User);
            return db.SP_GetLeaveDetails(User,MergeOption.NoTracking).ToList()[0];
        }

        public void Insert(tbl_LeaveDetails LeaveDetails)
        {
            db.tbl_LeaveDetails.Add(LeaveDetails);
            Save();
        }

        public void Delete(long Id)
        {
            tbl_LeaveDetails LeaveDetails = db.tbl_LeaveDetails.Find(Id);
            //tbl_LeaveDetails LeaveDetails = GetByID(Id);
            db.tbl_LeaveDetails.Remove(LeaveDetails);
            Save();
        }

        public void Update(tbl_LeaveDetails LeaveDetails)
        {
            db.Entry(LeaveDetails).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public List<string> GetAllApprovers(string user)
        {
            List<string> lt = new List<string>();
            lt = db.SP_Get_AltApprovers(user).ToList();
            //lt.Add(user);
            if (lt.Count > 0)
            {
                string first = lt[0];
                lt.Remove(user.ToLower());
                lt.Add(user.ToLower());
                lt.Reverse();
            }
            return lt;
        }
    }
}
