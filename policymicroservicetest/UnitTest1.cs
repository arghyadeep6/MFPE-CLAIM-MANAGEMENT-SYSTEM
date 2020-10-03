using NUnit.Framework;
using policymicroservice.Controllers;
using policymicroservice.Repository;
using System.Collections.Generic;

namespace policymicroservicetest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EligibleBenefitTest()
        {
            policyController pol = new policyController();
            List<int> a = pol.GetEligibleBenefits(1, 1);
            Assert.AreEqual(4, a.Count);


        }

        [Test]
        public void EligibleClaimAmountTest()
        {
            policyController pol = new policyController();
            int amt = pol.getEligibleClaimAmount(1, 2, 1);
            Assert.AreEqual(100, amt);

        }

       
    }
}