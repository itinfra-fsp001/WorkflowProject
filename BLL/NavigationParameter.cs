using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class NavigationParameter
    {
        public long docid;

        public  string docNo { get; set; }
     public    long workFlowId { get; set; }
     public   string type { get; set; }
     public string Status { get; set; }
        public int Page { get; set; }
        public int IsPoIssued { get; set; }
        public string DocType { get; set; }
    }
}
