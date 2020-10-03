using memberportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace memberportal.Repository
{
    public class memberpolicyrepo
    {
        public static List<memberpolicy> m = new List<memberpolicy>()
        {
            new memberpolicy()
            {
              policyid=1,
              memberid=1,
              membername="ARGHYADEEP SAHA",
              subscriptiondate=new DateTime(2020,09,28).ToString("dd/MM/yyyy"),
              locationid=1,
              locationname="ULTADANGA",
              hospitalid=2,
              hospitalname="CMRI",
              topupfrequency=2
            },
            new memberpolicy()
            {
              policyid=1,
              memberid=2,
              membername="BISWARUP CHAKRABORTY",
              subscriptiondate=new DateTime(2020,09,28).ToString("dd/MM/yyyy"),
              locationid=1,
              locationname="ULTADANGA",
              hospitalid=3,
              hospitalname="NRS",
              topupfrequency=1
            },
            new memberpolicy()
            {
              policyid=2,
              memberid=3,
              membername="SAURAV KUMAR",
              subscriptiondate=new DateTime(2020,09,28).ToString("dd/MM/yyyy"),
              locationid=2,
              locationname="PARK STREET",
              hospitalid=3,
              hospitalname="NRS",
              topupfrequency=0
            },
            new memberpolicy()
            {
              policyid=1,
              memberid=4,
              membername="AYAN NANDI",
              subscriptiondate=new DateTime(2020,09,28).ToString("dd/MM/yyyy"),
              locationid=3,
              locationname="SEALDAH",
              hospitalid=1,
              hospitalname="AMRI",
              topupfrequency=2
            },
            new memberpolicy()
            {
              policyid=2,
              memberid=5,//given
              membername="SUJOY",
              subscriptiondate=new DateTime(2020,09,28).ToString("dd/MM/yyyy"),
              locationid=2,//
              locationname="PARK STREET",
              hospitalid=1,//
              hospitalname="AMRI",
              topupfrequency=0
            }
        };
        public int receivepolicyid(int memberid)
        {
            int x;//we need to assign a value to x if x does not get value in forloop it will be nullable int ?x
            foreach (var item in m)
            {
                if (item.memberid == memberid)
                {
                    x = item.policyid;
                    return x;
                }
            }
            return 0;
        }
    }
}
