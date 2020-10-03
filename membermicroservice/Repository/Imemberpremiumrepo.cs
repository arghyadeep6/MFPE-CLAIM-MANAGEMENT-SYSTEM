using membermicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace membermicroservice.Repository
{
    public interface Imemberpremiumrepo
    {
      //  public  List<memberpremium> fun();
        public List<memberpremium> getViewBills(int mid, int pid);


    }
}
