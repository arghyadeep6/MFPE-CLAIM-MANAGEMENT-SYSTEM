using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace memberportal.Models
{
    public class claimsubmit
    {
        [Key]
        public int submitid { get; set; }
        public int claimid { get; set; }
        public string claimstatus { get; set; }
    }
}
