using System;
using Moq;
using FluentAssertions;
using Xunit;

namespace Testing
{
    public class NameMatchServiceTest
    {
        private readonly INameMatchService _matchService;

        public NameMatchServiceTest()
        {
            // Create dependency mock:
            var customerServiceMock = new Mock<ICustomerService>();

            // Stub method call result on dependency:
            customerServiceMock.Setup(c => c.GetCustomers(It.IsAny<string>())).Returns(new[] { new Customer("Dmitry Novik") });

            _matchService = new NameMatchService(customerServiceMock.Object);
        }


        [Fact]
        public void Customers_Containing_Dmitry_Novik_Must_Match_Dmitry_Novik()
        {
            _matchService.IsFlying(new Customer("DMITRY NOVIK"), "QF147").Should().Be(true);
        }

        [Fact]
        public void Customers_Containing_Dmitry_Novik_Must_Match_Novik_Dmitry()
        {
            _matchService.IsFlying(new Customer("NOVIK DMITRY1"), "QF147").Should().Be(true);
        }

        [Fact]
        public void Customers_Containing_Dmitry_Novik_Must_Not_Match_Dimitri_Novick()
        {
            _matchService.IsFlying(new Customer("DIMITRI NOVICK"), "QF147").Should().Be(false);
        }

        [Fact]
        public void Has_Match_Throws_On_Null()
        {
            // MUST THROW ArgumentNullException:
            Assert.Throws<ArgumentNullException>(() => _matchService.IsFlying(null, ""));
        }

    }
}
