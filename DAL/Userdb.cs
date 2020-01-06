using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;

namespace DAL
{
    public class Userdb
    {

        private WorkFlowDBEntities db;

        public Userdb()
        {
            db = new WorkFlowDBEntities();            
        }

       
        public IEnumerable<vw_ERP_UserDetails> GetALL(string userId)
        {            
            return db.SP_GetAllERPUsers(userId,MergeOption.NoTracking).ToList();
            //return db.vw_ERP_UserDetails.ToList();
        }

        public vw_ERP_UserDetails GetByID(string UserID)
        {
            return db.SP_GetUserByID(UserID, MergeOption.NoTracking).ToList()[0];
        }

        public void Insert(vw_ERP_UserDetails User)
        {
            db.vw_ERP_UserDetails.Add(User);
            Save();
        }

        public void Delete(string UserID)
        {
            //vw_ERP_UserDetails user = db.vw_ERP_UserDetails.Find(UserID);
            vw_ERP_UserDetails user = db.SP_GetUserByID(UserID,MergeOption.NoTracking).ToList()[0];
            db.vw_ERP_UserDetails.Remove(user);
            Save();
        }

        public void Update(vw_ERP_UserDetails User)
        {
            db.Entry(User).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IEnumerable<tbl_UserRoles> getUserRole(string UserId)
        {
            try
            {
                
                var userRole = db.SP_GetUserRoleByID(UserId, MergeOption.NoTracking);
                //var userRole = db.tbl_UserRoles.Where(x => x.UserId == UserId).AsNoTracking();
                return userRole.ToList();
                /*if (userRole != null && userRole.Count() > 0)
                {
                    return userRole.ToList()[0];
                } */               
            }
            catch (Exception)
            {
                                
            }
            return null;


            //return db.tbl_UserRoles.Find(UserId);
        }

        public bool isEmailIdExits(string userId)
        {
            bool isRet = false;
            //var users = db.vw_ERP_UserDetails.ToList().Where(x => x.UserId.Equals(userId));
            var users = db.SP_GetUserByID(userId,MergeOption.NoTracking).ToList();
            var user = ((users != null && users.Count() > 0) ? users.First() : null);
            if (user != null && !string.IsNullOrEmpty(user.Email))
                isRet = true;
            return isRet;
        }

        public tbl_User getUserByUserID(string userId)
        {
            var user = db.SP_GetUserByUserID(userId, MergeOption.NoTracking).ToList();
            if(user!=null && user.Count>0)
            {
                return user[0];
            }
            return null;

        }
    }
}
