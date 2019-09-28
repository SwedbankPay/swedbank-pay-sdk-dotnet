namespace SwedbankPay.Client.Tests
{
    using SwedbankPay.Client.Models;
    using Xunit;

    public class UtilsTests
    {
        [Fact]
        public void ExpandPaymentTransactionsAndUrlParameterShouldReturnCorrectQueryString()
        {
            var expandParameter = PaymentExpand.Urls | PaymentExpand.Transactions;
            var queryStringParamater = Utils.GetExpandQueryString(expandParameter);

            var expected = "?$expand=urls,transactions";
            Assert.Equal(expected, queryStringParamater);
        }


        [Fact]
        public void ExpandUrlsAndCurrentPaymentParameterShouldReturnCorrectQueryString()
        {
            var expandParameter = PaymentOrderExpand.Urls | PaymentOrderExpand.CurrentPayment;
            var queryStringParamater = Utils.GetExpandQueryString(expandParameter);

            var expected = "?$expand=urls,currentpayment";
            Assert.Equal(expected, queryStringParamater);
        }


        [Fact]
        public void ExpandAllPaymentParametersShouldReturnCorrectQueryString()
        {
            var expandParameter = PaymentExpand.All;
            var queryStringParamater = Utils.GetExpandQueryString(expandParameter);

            var expected = "?$expand=prices,payeeinfo,urls,transactions,authorizations,captures,reversals,cancellations";
            Assert.Equal(expected, queryStringParamater);
        }

        [Fact]
        public void ExpandNonePaymentParametersShouldReturnCorrectQueryString()
        {
            var expandParameter = PaymentExpand.None;
            var queryStringParamater = Utils.GetExpandQueryString(expandParameter);

            var expected = "";
            Assert.Equal(expected, queryStringParamater);
        }


        [Fact]
        public void ExpandNonePaymentOrderParametersShouldReturnCorrectQueryString()
        {
            var expandParameter = PaymentOrderExpand.None;
            var queryStringParamater = Utils.GetExpandQueryString(expandParameter);

            var expected = "";
            Assert.Equal(expected, queryStringParamater);
        }

        [Fact]
        public void ExpandAllPaymentOrderParameterShouldReturnCorrectQueryString()
        {
            var expandParameter = PaymentOrderExpand.All;
            var queryStringParamater = Utils.GetExpandQueryString(expandParameter);

            var expected = "?$expand=urls,payeeinfo,settings,payers,orderitems,metadata,payments,currentpayment";
            Assert.Equal(expected, queryStringParamater);
        }
    }
}
