using membermicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace membermicroservice.Repository
{
    public interface Imemberclaimrepo
    {
        public string submitClaim(memberclaim obj);
        public memberclaim viewClaimStatus(int id, memberclaim obj);

        public List<memberclaim> getmyclaim(int id);
    }
}
