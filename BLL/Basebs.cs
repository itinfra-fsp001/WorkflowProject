using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {
        public DocumentBs DocumentBs { get; set; }
        public DocumentWorkfFlowBs DocumentWorkfFlowBs { get; set; }
        public Document4ApprovalBs Document4ApprovalBs { get; set; }
        public UserBs UserBs { get; set; }

        public BaseBs()
        {
            DocumentBs = new DocumentBs();
            DocumentWorkfFlowBs = new DocumentWorkfFlowBs();
            Document4ApprovalBs = new Document4ApprovalBs();
            UserBs = new UserBs();
        }



    }
}
