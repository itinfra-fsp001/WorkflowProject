using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
namespace BLL
{
    public class MergeDocBs
    {
        public MergeDocdb objdb;
        public MergeDocBs()
        {
            objdb = new MergeDocdb();
        }
        public IEnumerable<tbl_DocMergeDetails> GetMergeDocList(int docId)
        {
            return objdb.GetMergeDocList(docId).ToList();
        }
    }
}
