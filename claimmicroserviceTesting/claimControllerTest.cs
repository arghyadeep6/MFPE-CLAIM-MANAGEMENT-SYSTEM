using NUnit.Framework;
using claimmicroservice.Repository;
using claimmicroservice.Controllers;
using claimmicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;

namespace claimmicroserviceTesting
{
    public class claimControllerTest
    {
        List<memberclaim> claimList = new List<memberclaim>();
        [SetUp]
        public void Setup()
        {
            claimList = new List<memberclaim>
            {
              new memberclaim()
               {
                memberid=1,
                claimid=2,
                billedamount=1200,
                claimedamount=1000,
                claimstatus="Pending",
                benefitid=1
               },
              new memberclaim()
              {
                memberid=2,
                claimid=3,
                billedamount=1200,
                claimedamount=1000,
                claimstatus="Pending",
                benefitid=2
               },
               new memberclaim()
              {
                memberid=3,
                claimid=4,
                billedamount=1300,
                claimedamount=1100,
                claimstatus="Pending",
                benefitid=3
               }

            };
        }

        [Test]
        public void Test1()
        {
            Mock<Imemberclaimrepo> mock = new Mock<Imemberclaimrepo>();
            mock.Setup(p => p.give()).Returns(claimList);
            claimController con = new claimController(mock.Object);
            var data = con.Get() as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }

        //[Test]
        //public void Test2()
        //{
        //    Mock<memberclaimrepo> mock = new Mock<memberclaimrepo>();
        //    mock.Setup(p => p.fetchclaimsformember(1)).Returns(claimList);
        //    claimController con = new claimController(mock.Object);
        //    var data = con.Get(1) as OkObjectResult;
        //    Assert.AreEqual(200, data.StatusCode);

        //}

        [Test]
        public void Test3()
        {
            memberclaim mem1 = new memberclaim
            {
                memberid = 1,
                claimid = 2,
                billedamount = 1200,
                claimedamount = 1000,
                claimstatus = "Pending",
                benefitid = 1
            };
            Mock<Imemberclaimrepo> acr = new Mock<Imemberclaimrepo>();
            claimController contr = new claimController(acr.Object);
            var data = contr.Post(mem1) as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);

        }
        [Test]
        public void Test4()
        {
            memberclaim obj = new memberclaim();
            var repo = new Mock<Imemberclaimrepo>();
            memberclaim obb = new memberclaim();
            repo.Setup(p => p.GetClaimStatus(1, obj)).Returns(obb);
            claimController contr = new claimController(repo.Object);
            var data = contr.Put(1, obj) as ObjectResult;
            Assert.AreEqual(200, data.StatusCode);



        }




    }
}