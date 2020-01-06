using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public static class clsLog
    {
        private static Commondb cmDb=new Commondb();        
        public static void insertLog(string userName, string controller, string method, string message)
        {
            cmDb.insertLog(userName, controller, method, message);
        }
    }
}
