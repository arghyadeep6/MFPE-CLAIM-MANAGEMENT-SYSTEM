using memberportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memberportal.Repository
{
    public class memberdetailsrepo
    {
        public static List<memberdetails> pq = new List<memberdetails>()
        {
            new memberdetails
            {
              memberid=1,
              membername="ARGHYADEEP SAHA",
              phonenumber="7890634189",
              salary=1500,
              gender="MALE",
              polid=1
            },
            new memberdetails
            {
               memberid=2,
               membername="BISWARUP CHAKRABORTY",
               phonenumber="9854671000",
               salary=2000,
               gender="MALE",
               polid=1
            },
            new memberdetails
            {
               memberid=3,
               membername="SAURAV KUMAR",
               phonenumber="7412589630",
               salary=2500,
               gender="MALE",
               polid=2
            },
            new memberdetails
            {
               memberid=4,
               membername="AYAN NANDI",
               phonenumber="8569741032",
               salary=3000,
               gender="MALE",
               polid=1
            }
        };
        public List<memberdetails> supplymemberdetails()
        {
            return pq;
        }
    }
}
