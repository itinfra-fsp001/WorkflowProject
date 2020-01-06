using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {
        private Userdb objdb;

        public UserBs()
        {
            objdb = new Userdb();

        }

        public IEnumerable<vw_ERP_UserDetails> GetALL1()
        {
            return objdb.GetALL(null);
        }

        public vw_ERP_UserDetails GetbyID(string UserID)
        {
            return objdb.GetByID(UserID);
        }

        public void Insert(vw_ERP_UserDetails User)
        {
            objdb.Insert(User);
        }

        public void Delete(string UserID)
        {
            objdb.Delete(UserID);
        }

        public void Update(vw_ERP_UserDetails User)
        {
            objdb.Update(User);
        }

        public IEnumerable<tbl_UserRoles> GetRoleByID(string UserID)
        {
            return objdb.getUserRole(UserID);
        }

        public bool isEmailIdExits(string userId)
        {
            return objdb.isEmailIdExits(userId);
        }

        public tbl_User getUserByUserID(string userId)
        {
            return objdb.getUserByUserID(userId);
        }


        
    }
}
