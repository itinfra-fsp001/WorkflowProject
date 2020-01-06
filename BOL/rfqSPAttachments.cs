using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class rfqSPAttachments
    {
        public bool result { get; set; }
        public string message { get; set; }

        public IEnumerable<rfqCustomAttachments> attachmentList;
    }
}
