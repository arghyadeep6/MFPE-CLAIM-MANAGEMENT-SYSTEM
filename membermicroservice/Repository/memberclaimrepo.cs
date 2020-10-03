using membermicroservice.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace membermicroservice.Repository
{
    public class memberclaimrepo : Imemberclaimrepo
    {
        Uri baseAddress; 
        HttpClient client;
        IConfiguration _config;
        public memberclaimrepo(IConfiguration config)
        {
             _config = config;
            baseAddress = new Uri(_config["Links:CLAIM"]);
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public string submitClaim(memberclaim obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return "success";

                }
                return "failed";
            }
            catch (Exception e)
            {
                return "Exception Occured";
            }
        }

        public memberclaim viewClaimStatus(int id, memberclaim obj)
        {
            try
            {
                memberclaim ob = new memberclaim();

                string data = JsonConvert.SerializeObject(obj);

                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/" + id, content).Result;

                if (response.IsSuccessStatusCode)
                {

                    string data1 = response.Content.ReadAsStringAsync().Result;
                    ob = JsonConvert.DeserializeObject<memberclaim>(data);

                }

                return ob;//for claimstatus.cshtml
            }
            catch(Exception)
            {
                return null;
            }


        }



        public List<memberclaim> getmyclaim(int id)
        {
            List<memberclaim> ls = new List<memberclaim>();


            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;//calls getall method in claim controller

            if (response.IsSuccessStatusCode)
            {

                string data = response.Content.ReadAsStringAsync().Result;

                ls = JsonConvert.DeserializeObject<List<memberclaim>>(data);

            }
            //filtering process

            List<memberclaim> ml = new List<memberclaim>();

            foreach (memberclaim item in ls)
            {
                if (item.memberid == id)
                {
                    ml.Add(item);
                }
            }
            return ml;
        }










    }
}
    

