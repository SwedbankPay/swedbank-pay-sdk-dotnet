using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

using Xunit;

namespace SwedbankPay.Client.Tests
{
    

    public class ConsumerResourceTests
    {
        private SwedbankPayClient _sut;
        public ConsumerResourceTests()
        {
            var swedbankPayOptions = new SwedbankPayOptions
            {
                ApiBaseUrl = new Uri("https://api.externalintegration.payex.com"),
                Token = "588431aa485611f8fce876731a1734182ca0c44fcad6b8d989e22f444104aadf",
                CallBackUrl = new Uri("https://payex.eu.ngrok.io/payment-callback?orderGroupId={orderGroupId}"),
                CompletePageUrl = new Uri("https://payex.eu.ngrok.io/sv/checkout-sv/PayexCheckoutConfirmation/?orderGroupId={orderGroupId}"),
                CancelPageUrl = new Uri("https://payex.eu.ngrok.io/payment-canceled?orderGroupId={orderGroupId}")
            };

            _sut = new SwedbankPayClient(swedbankPayOptions);
        }

        [Fact]
        public void InitializeConsumer_ShouldReturnToken()
        {

        }


    }
}
