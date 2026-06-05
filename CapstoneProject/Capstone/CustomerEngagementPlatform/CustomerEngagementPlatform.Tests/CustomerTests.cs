using Xunit;
using CustomerEngagementPlatform.Models;

namespace CustomerEngagementPlatform.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_Name_Should_Not_Be_Null()
        {
            var customer = new Customer
            {
                Name = "Nandhini"
            };

            Assert.NotNull(customer.Name);
        }

        [Fact]
        public void Customer_Email_Should_Contain_At()
        {
            var customer = new Customer
            {
                Email = "test@gmail.com"
            };

            Assert.Contains("@", customer.Email);
        }
    }
}