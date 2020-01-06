using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
  public  class SupplementaryBudgetdb
    {
        private WorkFlowDBEntities db;
        public SupplementaryBudgetdb()
        {
            db = new WorkFlowDBEntities();
        }
        public IEnumerable<tbl_SupBudgetHeader> GetALL()
        {
            return db.tbl_SupBudgetHeader.AsNoTracking().ToList();
        }

        public IEnumerable<tbl_SupBudgetHeader> GetSBHeader(string userId)
        {
            return db.SP_GetALLSBHeader(userId, MergeOption.NoTracking).ToList();
        }

        public tbl_SupBudgetHeader GetByID(string refNumber)
        {
            return db.SP_GetSBHeader(refNumber, MergeOption.NoTracking).ToList()[0];
        }
        public void Update(tbl_SupBudgetHeader suppHeader)
        {
            db.Entry(suppHeader).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void Insert(tbl_SupBudgetHeader suppHeader)
        {
            try
            {
                db.tbl_SupBudgetHeader.Add(suppHeader);
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        //Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetDisvisionNumber(string user)
        {
            return db.vw_ERP_UserDetails.Where(p => p.UserId == user).First().DivisionCode;
        }

        public void DeleteByRefId(string id)
        {
            //var refs = db.tbl_SupBudgetHeader.Where(p => p.ReferenceNo == id);
            var refs = db.SP_GetSBHeader(id); //,MergeOption.NoTracking
            db.tbl_SupBudgetHeader.RemoveRange(refs);
            db.SaveChanges();
        }

        public IEnumerable<vw_ERP_CostCentre> GetCostCentre()
        {
            return db.SP_GetCostCentre(MergeOption.NoTracking).ToList();
        }
    }
}
