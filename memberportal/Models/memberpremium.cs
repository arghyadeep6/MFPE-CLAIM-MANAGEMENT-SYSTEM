using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace memberportal.Models
{
    public class memberpremium
    {
        [Display(Name = "MEMBER ID")]
        public int memberid { get; set; }
        [Display(Name = "POLICY ID")]
        public int policyid { get; set; }
        [Display(Name = "TOPUP")]
        public int topup { get; set; } //topup is essential to check first validation
        [Display(Name = "PREMIUM AMOUNT")]
        public int premium { get; set; }
        [Display(Name = "PAYMENT DATE")]
        public string paiddate { get; set; }
    }
}
