namespace SwedbankPay.Sdk.Tests.UnitTests
{

    using System;
    using SwedbankPay.Sdk.PaymentOrders;
    using Xunit;
    using Xunit.Sdk;

    public class EmailAddressTests
    {
        private string validAddress = "leia.ahlstrom@payex.com";

        
       [Fact]
        public void AddressValue_IsSetCorrectly_WhenGivenValidAddressString()
        {
            //ACT
            var addressObject = new EmailAddress(this.validAddress);

            //ASSERT
            Assert.Equal(this.validAddress, addressObject.ToString());
        }
        
        [Theory]
        [InlineData("plainaddress")]
        [InlineData("#@%^%#$@#$@#.com")]
        [InlineData("@example.com")]
        [InlineData("Joe Smith <email@example.com>")]
        [InlineData("email.example.com")]
        [InlineData("email@example@example.com")]
        [InlineData(".email@example.com")]
        [InlineData("email.@example.com")]
        [InlineData("email..email@example.com")]
        [InlineData("あいうえお@example.com")]
        [InlineData("email@example.com (Joe Smith)")]
        [InlineData("email@example")]
        [InlineData("email@-example.com")]
        [InlineData("email@example..com")]
        [InlineData("Abc..123@example.com")]
        public void ThrowsArgumentException_WhenGivenInvalidAddressString(string address)
        {
            //ASSERT
            Assert.Throws<ArgumentException>("emailAddress", () => new EmailAddress(address));
        }

        [Theory]
        [InlineData("email@example.com")]
        [InlineData("firstname.lastname@example.com")]
        [InlineData("email@subdomain.example.com")]
        [InlineData("firstname+lastname@example.com")]
        [InlineData("email@123.123.123.123")]
        [InlineData("\"email\"@example.com")]
        [InlineData("1234567890@example.com")]
        [InlineData("email@example-one.com")]
        [InlineData("email@example.name")]
        [InlineData("email@example.museum")]
        [InlineData("email@example.co.jp")]
        [InlineData("firstname-lastname@example.com")]
        public void CreateNewEmailAddress_DoesNotThrow_WhenGivenValidAddressString(string address)
        {
            //ACT
            var ex = Record.Exception(() => new EmailAddress(address));
            
            //ASSERT
            Assert.Null(ex);
        }

    }
}