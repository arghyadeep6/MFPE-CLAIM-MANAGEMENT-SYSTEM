using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memberportal.Models
{
    public class claimsubmitcontext:DbContext
    {
        public claimsubmitcontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<claimsubmit> claimsubmits { get; set; }

  
    }
}
