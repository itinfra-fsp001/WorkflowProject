using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class vw_DocumentsValidation
    {
        [Required]
        public string AttachDoc { get; set; }
    }

    [MetadataType(typeof(vw_DocumentsValidation))]
    public partial class vw_Documents
    {

    }
}