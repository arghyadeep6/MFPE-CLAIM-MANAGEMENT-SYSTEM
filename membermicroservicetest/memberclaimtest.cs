using membermicroservice.Controllers;
using membermicroservice.Models;
using membermicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace membermicroservicetest
{
    public class memberclaimtest
    {
        [Test]
        public void PostTestPass()
        {
            memberclaim obj = new memberclaim { benefitid = 1, billedamount = 100, claimedamount = 100, memberid = 1 };
            var ob = new Mock<Imemberclaimrepo>();
            ob.Setup(p => p.submitClaim(obj)).Returns("success");
            memberController controller = new memberController(ob.Object);
            var result = controller.Post(obj) as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);


        }
        [Test]
        public void PostTestFail()
        {
            memberclaim obj = new memberclaim { benefitid = 1, billedamount = 100, claimedamount = 100, memberid = 1 };
            var ob = new Mock<Imemberclaimrepo>();
            ob.Setup(p => p.submitClaim(obj)).Returns("failure");
            memberController controller = new memberController(ob.Object);
            var result = controller.Post(obj) as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [Test]
        public void PutTest()
        {
            memberclaim obj = new memberclaim { benefitid = 1, billedamount = 100, claimedamount = 100, memberid = 1 };
            var ob = new Mock<Imemberclaimrepo>();
            memberclaim obb = new memberclaim();
            ob.Setup(p => p.viewClaimStatus(1, obj)).Returns(obb);
            memberController controller = new memberController(ob.Object);
            var result = controller.Put(1,obj) as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        


    }
}
