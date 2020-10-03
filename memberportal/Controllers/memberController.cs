using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using memberportal.Models;
using memberportal.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;//
//integrating membermicroservice with memberportal
namespace memberportal.Controllers
{
   
    public class memberController : Controller
    {
       // Uri baseaddress = new Uri("https://localhost:44371/api");//member micro
       // Uri baseaddress1 = new Uri("https://localhost:44311/api");
        HttpClient client;
        HttpClient client1;
        Uri baseaddress;
        Uri baseaddress1;
        IConfiguration oby;
        private readonly claimsubmitcontext _con;
        public memberController(claimsubmitcontext con,IConfiguration oby)
        {
            this.oby = oby;
            _con = con;
            client = new HttpClient();
            client1 = new HttpClient();          
            baseaddress = new Uri(oby["LINKS:MEMBER"]);
            baseaddress1= new Uri(oby["LINKS:AUTH"]);
            client.BaseAddress = baseaddress;
            client1.BaseAddress = baseaddress1;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Auth(Authenticate obj)
        {
            string f = obj.id;//to store the id of the user
            simple.m = f;
            string s = simple.m;//s stores the id of the user
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client1.PostAsync(client1.BaseAddress + "/Token",content).Result;
            if (response.IsSuccessStatusCode)
            {
                string token = response.Content.ReadAsStringAsync().Result;
                HttpContext.Response.Cookies.Append("token", token);
                return RedirectToAction("Index");
            }
            return View("Login");
        }
       
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Request.Cookies["token"]))
            {
                TempData["Unauthenticated"] = "Please Log In";
                return View("Login");
            }
            int x = Convert.ToInt32(simple.m);
            

            memberdetailsrepo h = new memberdetailsrepo();

            List<memberdetails> b = new List<memberdetails>();

            b = h.supplymemberdetails();

            foreach(var item in b)
            {
                if(item.memberid==x)
                {
                    ViewBag.Message =item.membername;
                }
            }

            //ViewBag.message = "Dude its very simple";

            // int x = Convert.ToInt32(simple.m);
            int f = 0;

            List<memberclaim> ls = new List<memberclaim>();

            string token = HttpContext.Request.Cookies["token"];

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/member/"+x).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<memberclaim>>(data);
                foreach (var item in ls)
                {
                    foreach (var item1 in _con.claimsubmits)
                    {
                        if (item.claimid == item1.claimid)//this check will happen only once
                        {
                            item1.claimstatus = item.claimstatus;
                            f = 1;
                        }
                    }
                    if (f == 0)
                    {
                        claimsubmit obk = new claimsubmit();
                        obk.claimid = item.claimid;
                        obk.claimstatus = item.claimstatus;
                        _con.claimsubmits.Add(obk);
                    }
                    f = 0;
                }
               _con.SaveChanges(); // The changes are made in the database atlast      
            } 
            return View(ls);   
        }
        public IActionResult Viewbills()
        {
            if (string.IsNullOrEmpty(HttpContext.Request.Cookies["token"]))
            {
                TempData["Unauthenticated"] = "Please Log In";
                return View("Login");
            }
            int x = Convert.ToInt32(simple.m);

            memberdetailsrepo h = new memberdetailsrepo();

            List<memberdetails> b = new List<memberdetails>();

            b = h.supplymemberdetails();
            int u = 0;//new

            foreach (var item in b)
            {
                if (item.memberid == x)
                {
                    ViewBag.Message = item.membername;
                    u = item.polid;//new
                }
            }
            List<memberpremium> ls = new List<memberpremium>();

            string token = HttpContext.Request.Cookies["token"];

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/bills/" + x + "/" + u).Result;//new

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<memberpremium>>(data);
            }

            return View(ls);
        }
        //[HttpGet("{id}")]
        //public List<memberpremium> Get(int id)
        //{
        public IActionResult Submit_Claim()
        {
            if (string.IsNullOrEmpty(HttpContext.Request.Cookies["token"]))
            {
                TempData["Unauthenticated"] = "Please Log In";
                return View("Login");
            }
            return View();
        }
        //remove claim id from Submit_Claim.cshtml
        [HttpPost]
        public IActionResult Submit_Claim(memberclaim obj)//no change here as the claims of all members are submitted into 1 list
        {
            if (string.IsNullOrEmpty(HttpContext.Request.Cookies["token"]))
            {
                TempData["Unauthenticated"] = "Please Log In";
                return View("Login");
            }
            int x = Convert.ToInt32(simple.m);
            obj.memberid = x;
            string token = HttpContext.Request.Cookies["token"];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/member", content).Result;
            if (response.IsSuccessStatusCode)
            {
                //claimsubmit obk = new claimsubmit();
                //obk.claimid = obj.claimid;
                //obk.claimstatus = obj.claimstatus;
                //_con.claimsubmits.Add(obk);
                //_con.SaveChanges();
                //return View("Index");
               return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int id)//id:claimid
        {
            if (string.IsNullOrEmpty(HttpContext.Request.Cookies["token"]))
            {
                TempData["Unauthenticated"] = "Please Log In";
                return View("Login");
            }

            ViewBag.Message = id.ToString();

            int x = Convert.ToInt32(simple.m);

            memberpolicyrepo er = new memberpolicyrepo();

            int y = er.receivepolicyid(x);

            ViewBag.Message1 = y.ToString();

            memberclaim obj = new memberclaim();

            string token = HttpContext.Request.Cookies["token"];

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<memberclaim> ls = new List<memberclaim>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/member/" + x).Result;//actually it calls getall of my claims

            
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<memberclaim>>(data);
            }

            //note that claimid is unique

            foreach(var item in ls)
            {
                if(item.claimid==id)
                {
                    obj = item;
                }
            }
            return View(obj);
        }


        [HttpPost]
        
        public IActionResult Edit(memberclaim obj)
        {
            if (string.IsNullOrEmpty(HttpContext.Request.Cookies["token"]))
            {
                TempData["Unauthenticated"] = "Please Log In";
                return View("Login");
            }

            string token = HttpContext.Request.Cookies["token"];

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            memberclaim ls = new memberclaim();

            string data = JsonConvert.SerializeObject(obj);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/member/" + obj.memberid, content).Result;//send claimid change to memberid
            //no need to do this because content has already the unique claimid

            if (response.IsSuccessStatusCode)
            {
               

                string data1 = response.Content.ReadAsStringAsync().Result;

                ls = JsonConvert.DeserializeObject<memberclaim>(data);

                return View("claimstatus",ls);

            }
            return View();
        }
        [HttpPost]
        public IActionResult claimstatus(memberclaim obj)//Details page method
        {
            if (string.IsNullOrEmpty(HttpContext.Request.Cookies["token"]))
            {
                TempData["Unauthenticated"] = "Please Log In";
                return View("Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("token");
            return RedirectToAction("Login");
        }
    }
}

