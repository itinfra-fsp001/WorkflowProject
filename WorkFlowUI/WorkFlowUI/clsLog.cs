using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace WorkFlowUI
{
    public class clsLog
    {
        static string logFile = ConfigurationManager.AppSettings["LogPath"] + "\\" + DateTime.Now.ToString("ddMMyyyy") + "_log.txt";
        public static void insert(string message)
        {
            //if (Directory.Exists(ConfigurationManager.AppSettings["LogPath"]))
            //{
            //    if (!File.Exists(logFile))
            //    {
            //        File.Create(logFile).Close();
            //    }
            //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFile, true))
            //    {
            //        file.WriteLine(Convert.ToString(message));
            //    }
            //}
        }
    }
}