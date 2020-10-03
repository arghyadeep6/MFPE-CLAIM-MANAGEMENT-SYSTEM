using membermicroservice.Controllers;
using membermicroservice.Models;
using membermicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace membermicroservicetest
{
    public class Tests
    {
        List<memberpremium> premiumList = new List<memberpremium>();
        [SetUp]
        public void Setup()
        {
            premiumList = new List<memberpremium>
            {
                 new memberpremium
                 {
                    memberid=1,
                    policyid=1,
                    topup=1000,
                    premium=2000,
                    paiddate=DateTime.Today.ToString()
                 },
                 new memberpremium
                 {
                    memberid=2,
                    policyid=2,
                    topup=1000,
                    premium=2000,
                    paiddate=DateTime.Today.ToString()
                 },
                 new memberpremium
                 {
                    memberid=3,
                    policyid=3,
                    topup=2000,
                    premium=3000,
                    paiddate=DateTime.Today.ToString()
                 },
                 new memberpremium
                 {
                    memberid=4,
                    policyid=4,
                    topup=4000,
                    premium=5000,
                    paiddate=DateTime.Today.ToString()
                 },
                  
            };
            

        }

        
        [Test]
        public void GetByIdPositive()
        {
            memberpremiumrepo ob = new memberpremiumrepo();  
            billsController controller = new billsController(ob);
            IActionResult data = controller.Get1(1, 1);
            var result = data as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [Test]
        public void GetByIdNegative()
        {
            memberpremiumrepo ob = new memberpremiumrepo();
            billsController controller = new billsController(ob);
            IActionResult data = controller.Get1(7, 1);
            var result = data as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
    }
}