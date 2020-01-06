using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
 public   class GlCodeDetail
    {
        public string GlCode { get; set; }
        public string GlDesc { get; set; }
        public decimal OriginalBudgtAmt { get; set; }
        public decimal SuppBudgetAmt { get; set; }
        public decimal ActualAmount  { get; set; }
       // public string GlDesc { get; set; }
    }
}
