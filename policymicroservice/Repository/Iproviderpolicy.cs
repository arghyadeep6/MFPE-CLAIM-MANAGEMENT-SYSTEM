using policymicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policymicroservice.Repository
{
    public interface Iproviderpolicy
    {
        public List<int> getbenefits(List<int> a);

        public List<providerpolicy> giveall1();
    }
}
