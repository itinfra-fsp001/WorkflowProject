using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class rfqSPResult
    {
        public bool result { get; set; }

        public string quoteNo { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public string submitterName { get; set; }
        public string submitterEmail { get; set; }

        public string buyerName { get; set; }
        public string buyerEmail { get; set; }

        public string UpdaterName { get; set; }
        public string UpdaterEmail { get; set; }

        public string SubmitterManagerEmail { get; set; }
        public string BuyerManagerEmail { get; set; }

        public string priority { get; set; }

        public bool isResubmitted { get; set; }
    }
}
