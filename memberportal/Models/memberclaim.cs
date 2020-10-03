using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace memberportal.Models
{
    public class memberclaim
    {
        //the corresponding controller and mvc must have the same controller name and model class
        //the hospital id dropdown is made using memberpolicyrepo as it has hospitalid
        //[Display(Name = "Product Name")]
        //public string ProductName { get; set; }
       
        [Display(Name = "MEMBER ID")]
        public int memberid { get; set; }

        [Key]
        [Display(Name = "CLAIM ID")]
        public int claimid { get; set; }

        [Required]
        [Range(0,100000)]
        [Display(Name = "BILLED AMOUNT")]
        public int billedamount { get; set; }

        [Required]
        [Range(0,100000)]
        [Display(Name = "CLAIMED AMOUNT")]
        public int claimedamount { get; set; }

        [Required]
        [Display(Name = "BENEFIT ID")]
        public int benefitid { get; set; }


        [Display(Name = "CLAIM STATUS")]
        public string claimstatus { get; set; }
    }
}
