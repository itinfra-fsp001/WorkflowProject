using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WorkFlowUI
{
    public static class clsGeneral
    {
        public static decimal pagingCountDecimal = 50;
        public static int pagingCountInt = 50;

        public static string checkandReplace(string checkStr)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(checkStr)))
            {
                checkStr = checkStr.Replace("andandand", "&");
                checkStr = checkStr.Replace("'", "''");
            }
            return checkStr;
        }

        public static string checkandReplace(string checkStr, string type)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(checkStr)))
            {
                checkStr = checkStr.Replace("andandand", "&");
            }
            return checkStr;
        }

        public static string searchStringEncrypt(string checkStr)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(checkStr)))
            {
                checkStr = checkStr.Replace("&", "andandand");
            }
            return checkStr;
        }

        public static string searchStringDecrypt(string checkStr)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(checkStr)))
            {
                checkStr = checkStr.Replace("andandand", "&");
            }
            return checkStr;
        }

        public static string errorMessage(Exception ex)
        {
            string str = "";
            if (!string.IsNullOrEmpty(ex.Message))
            {
                str = str + "Message : " + ex.Message;
            }
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
            {
                str = str + "::: Inner Exception Message : " + ex.InnerException.Message;
            }
            return str;
        }

        public static string getLastThreeMonthsPeriod(string status)
        {
            List<string> isRet = new List<string>();
            if (status == "P")
                isRet.Add(ToShortMonthName(DateTime.Now) + "_" + DateTime.Now.Year);
            isRet.Add(ToShortMonthName(DateTime.Now.AddMonths(-1)) + "_" + DateTime.Now.AddMonths(-1).Year);
            isRet.Add(ToShortMonthName(DateTime.Now.AddMonths(-2)) + "_" + DateTime.Now.AddMonths(-2).Year);
            isRet.Add(ToShortMonthName(DateTime.Now.AddMonths(-3)) + "_" + DateTime.Now.AddMonths(-3).Year);
            return string.Join(",", isRet.ToArray());
        }

        static string ToShortMonthName(DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
}