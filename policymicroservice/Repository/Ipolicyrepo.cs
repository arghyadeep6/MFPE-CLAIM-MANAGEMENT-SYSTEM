using policymicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace policymicroservice.Repository
{
    public interface Ipolicyrepo
    {
        public int givepolicy(int policyid);

        public List<policy> giveall();
    }
}
