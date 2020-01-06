using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;


namespace BLL
{
    public class SecurityBs : BaseBs
    {

    }
    public class WorkFlowMembershipProvider : MembershipProvider
    {

        Userdb db;
        AuthExecutivedb Authdb;

        public WorkFlowMembershipProvider()
        {
            db = new Userdb();
            Authdb = new AuthExecutivedb();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            db = new Userdb();
            Authdb = new AuthExecutivedb();

            if (password == "Admin@123")
            {
                int count = Authdb.GetALL().Where(x => (x.ApprovePerson != null ? x.ApprovePerson.ToLower() == username.ToLower() : false || x.Alternate1 != null ? x.Alternate1.ToLower() == username.ToLower() : false || x.Alternate2 != null ? x.Alternate2.ToLower() == username.ToLower() : false)).Count();
                if (count != 0)
                    return true;
                else
                    return false;
            }
            else
            {
                var users = db.GetALL(username).Where(x => x.UserId == username);
                var user = users.First();

                string dbPassword = user.Password;

                if (string.IsNullOrEmpty(dbPassword))
                    return false;
                return CheckPassword(password, dbPassword);
            }
        }

        private static bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = DecodePassword(dbpassword);

            if (pass1 == pass2)
            {
                return true;
            }

            return false;
        }

        private static string DecodePassword(string encodedPassword)
        {

            RijndaelEncryption encryptor = new RijndaelEncryption();
            return encryptor.Decrypt(encodedPassword);
        }

    }

    public class WorkFlowRoleProvider : RoleProvider
    {

        Userdb db;

        public WorkFlowRoleProvider()
        {
            db = new Userdb();
        }


        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {

            var userRole = db.getUserRole(username);            
            if (userRole != null && userRole.Count() > 0)
            {
                List<string> role = new List<string>();
                foreach (BOL.tbl_UserRoles item in userRole)
                {
                    role.Add(item.Role);
                }
                return role.ToArray();
            }
            else
            {
                String[] roles = new String[] { "Admin" };
                return roles;
            }

            /*
            int count = db.GetALL(username).Where(x => x.UserId == username).Count();
            if (count != 0)
            {
                string[] s = { db.GetALL(username).Where(x => x.UserId == username).FirstOrDefault().Role };
                return s;
            }
            else
            {
                String[] roles = new String[] { "Admin" };
                return roles;
            }*/
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }


    }


}
