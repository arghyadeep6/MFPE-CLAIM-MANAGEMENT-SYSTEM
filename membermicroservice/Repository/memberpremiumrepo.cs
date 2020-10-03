using membermicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace membermicroservice.Repository
{
    public class memberpremiumrepo : Imemberpremiumrepo
    {
        public List<memberpremium> m = new List<memberpremium>()
        {
         new memberpremium()
         {
             memberid=1,
             policyid=1,
             topup=1000,
             premium=2000,
             paiddate=new DateTime(2020,09,28).ToString("dd/MM/yyyy")
         },
         new memberpremium()
         {
             memberid=1,
             policyid=1,
             topup=1000,
             premium=2000,
             paiddate=new DateTime(2020,09,28).ToString("dd/MM/yyyy")
         },
         new memberpremium()
         {
             memberid=2,
             policyid=1,
             topup=1000,
             premium=2000,
             paiddate=new DateTime(2020,09,28).ToString("dd/MM/yyyy")
         },
         new memberpremium()
         {
             memberid=4,
             policyid=1,
             topup=1500,
             premium=2000,
             paiddate=new DateTime(2020,09,28).ToString("dd/MM/yyyy")
         },
          new memberpremium()
         {
             memberid=4,
             policyid=1,
             topup=4000,
             premium=5000,
             paiddate=new DateTime(2020,09,28).ToString("dd/MM/yyyy")
         }
};
    
            public  List<memberpremium> getViewBills(int mid, int pid)
            {
            List<memberpremium> memberp = new List<memberpremium>();
           foreach(var item in m)
            {
                if(item.memberid == mid && item.policyid==pid)
                {
                    memberp.Add(item);
                }
            }
            return memberp;
        }
    }
}
