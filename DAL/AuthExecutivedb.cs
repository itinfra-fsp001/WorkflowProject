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
    public class AuthExecutivedb
    {

        private WorkFlowDBEntities db;

        public AuthExecutivedb()
        {
            db = new WorkFlowDBEntities();

        }

        public IEnumerable<tbl_AuthExecutives> GetALL()
        {
            return db.tbl_AuthExecutives.AsNoTracking().ToList();
        }

        public tbl_AuthExecutives GetByID(string Approver)
        {
            //return db.tbl_AuthExecutives.Find(Approver);
            return db.SP_GetAuthorizeExecutive(Approver,System.Data.Entity.Core.Objects.MergeOption.NoTracking).ToList()[0];
        }

        public void Insert(tbl_AuthExecutives AuthExecutive)
        {
            db.tbl_AuthExecutives.Add(AuthExecutive);
            Save();
        }

        public void Delete(string Approver)
        {
            //tbl_AuthExecutives authExecutive = db.tbl_AuthExecutives.Find(Approver);
            tbl_AuthExecutives authExecutive = GetByID(Approver);
            db.tbl_AuthExecutives.Remove(authExecutive);
            Save();
        }

        public void Update(tbl_AuthExecutives AuthExecutive)
        {
            db.Entry(AuthExecutive).State = EntityState.Modified;
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
