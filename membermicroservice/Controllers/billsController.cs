using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using membermicroservice.Models;
using membermicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace membermicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class billsController : ControllerBase
    {
        Imemberpremiumrepo ob;
        readonly log4net.ILog _log4net;
        public billsController(Imemberpremiumrepo _ob)
        {
            ob = _ob;
            _log4net = log4net.LogManager.GetLogger(typeof(billsController));
        }


        // GET: api/<billsController>

        [HttpGet("{mid}/{pid}")]
        public IActionResult Get1(int mid, int pid)
        {
            _log4net.Info("Bills Controller Get View Bills Action Method is called");
            try
            {
                List<memberpremium> ab = ob.getViewBills(mid, pid);
                if (ab.Count() == 0)
                    return BadRequest(ab);
                return Ok(ab);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        }
}
