using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using policymicroservice.Models;
using policymicroservice.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace policymicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class policyController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        public policyController()
        {
            _log4net = log4net.LogManager.GetLogger(typeof(policyController));      
        }
        // GET: api/<memberController>
        [HttpGet]
        public IActionResult Get()
        {
            memberpolicyrepo ob = new memberpolicyrepo();
            return Ok(ob.fun());
        }
        [HttpPost]
        public List<List<int>> getchainofproviders(int policyid)//as per user requirement
        {
            _log4net.Info("Policy Controller getchainofproviders action method is called");
            //at first need to call policy repo to get list of all policies and then for a particular policy get list of hospitals
            List<List<int>> hosploca = new List<List<int>>();
            policyrepo ob1 = new policyrepo();
            List<policy> p = new List<policy>();
            p = ob1.giveall();
            List<int> ml = new List<int>();
            foreach (var item in p)
            {
                if(item.policyid==policyid)
                {
                    int x = item.hospitalid;
                    ml.Add(x);
                }
            }
            providerpolicyrepo res1 = new providerpolicyrepo();
            List<providerpolicy> pq = new List<providerpolicy>();
            pq = res1.giveall1();
            foreach(var item in ml)
            {
                foreach(var item1 in pq)
                {
                    if(item==item1.hospitalid)
                    {
                        List<int> op = new List<int>();
                        op.Add(item);//op.add(item1.hospitalid);
                        op.Add(item1.locationid);
                        hosploca.Add(op);
                    }
                }
            }
            return hosploca;
        }
        [HttpGet("{memberid}")]
        public int getpolid(int memberid)
        {
            memberpolicyrepo ob = new memberpolicyrepo();
            int policyid = ob.receivepolicyid(memberid);
            return policyid;
        }
        [HttpGet("{policyid}/{memberid}")]
        public List<int> GetEligibleBenefits(int policyid, int memberid)//run in browser1 2 100 200 300 400
        {
            _log4net.Info("Policy Controller GetEligibleBenefits action method is called");
            memberpolicyrepo o = new memberpolicyrepo();
            providerpolicyrepo res = new providerpolicyrepo();
            List<int> cob = new List<int>();
            List<int> f = new List<int>();
            cob = o.gethosloc(memberid); //hosp loc
            f = res.getbenefits(cob);
            return f;
        }
        [HttpGet("{policyid}/{memberid}/{benefitid}")]
        public int getEligibleClaimAmount(int policyid,int memberid,int benefitid)//as per user requirement
        {
            _log4net.Info("Policy Controller getEligibleClaimAmount action method is called");
            if (benefitid == 0)
            {
                policyrepo x = new policyrepo();
                int y = x.givepolicy(policyid);
                return 2*y;
            }
            else
            {
                List<int> r = new List<int>();
                r = GetEligibleBenefits(policyid, memberid);
                return r[benefitid-1];
            }
        }
        [HttpGet("{policyid}/{memberid}/{benefitid}/{bid}")]
        public int top(int policyid, int memberid, int benefitid,int bid)//as per user requirement
        {
            memberpolicyrepo ob = new memberpolicyrepo();
            int y = ob.gettopup(memberid);
            return y;
        }
    }
}
