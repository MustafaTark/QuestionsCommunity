using Domain.Models.Communities;
using Domain.SeedWork;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionCommunity.UnitTests.Communities
{
    [TestFixture]
    public class CreateCommunityTests
    {
        [Test]
        public void CreateCommunity_WhenAddNameWithLengthLessOrEqual50Charchter_IsSuccessfull()
        {
            var community = Community.Create("Name", "Test Added Community");
            Assert.That(community, Is.Not.Null);
        }
        [Test]
        public void CreateOrder_WhenAddNameWithLengthMoreThan50Charchter_IsFail()
        {
            Assert.Catch<BusinessRuleValidationException>(() =>
            {
                var community = Community.Create("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.", "Test Added Community");

            });
        }
    }
}
