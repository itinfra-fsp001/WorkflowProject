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
    public class LeaveDetails_Hisdb
    {

        private WorkFlowDBEntities db;

        public LeaveDetails_Hisdb()
        {
            db = new WorkFlowDBEntities();

        }
        public IEnumerable<tbl_LeaveDetails_His> GetALL()
        {
            return db.tbl_LeaveDetails_His.AsNoTracking().ToList();
        }

        public tbl_LeaveDetails_His GetByID(string User)
        {
            //return db.tbl_LeaveDetails_His.Find(User);
            return db.SP_GetLeaveDetailsHistory(User,MergeOption.NoTracking).ToList()[0];
        }

        public void Insert(tbl_LeaveDetails_His LeaveDetails_His)
        {
            db.tbl_LeaveDetails_His.Add(LeaveDetails_His);
            Save();
        }

        public void Delete(string User)
        {
            //tbl_LeaveDetails_His LeaveDetails_His = db.tbl_LeaveDetails_His.Find(User);
            tbl_LeaveDetails_His LeaveDetails_His = GetByID(User);
            db.tbl_LeaveDetails_His.Remove(LeaveDetails_His);
            Save();
        }

        public void Update(tbl_LeaveDetails_His LeaveDetails_His)
        {
            db.Entry(LeaveDetails_His).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Save()
        {
            db.SaveChanges();
        }


    }
}
