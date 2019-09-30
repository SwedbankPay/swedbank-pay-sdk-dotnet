using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankPay.Client.Tests
{
    public abstract class ResourceTestsBase
    {
        protected SwedbankPayClient _sut;

        protected ResourceTestsBase()
        {
            var swedbankPayOptions = new SwedbankPayOptions
            {
                ApiBaseUrl = new Uri("https://api.externalintegration.payex.com"),
                Token = "588431aa485611f8fce876731a1734182ca0c44fcad6b8d989e22f444104aadf",
                CallBackUrl = new Uri("https://payex.eu.ngrok.io/payment-callback?orderGroupId={orderGroupId}"),
                CompletePageUrl = new Uri("https://payex.eu.ngrok.io/sv/checkout-sv/PayexCheckoutConfirmation/?orderGroupId={orderGroupId}"),
                CancelPageUrl = new Uri("https://payex.eu.ngrok.io/payment-canceled?orderGroupId={orderGroupId}"),
                MerchantId = "91a4c8e0-72ac-425c-a687-856706f9e9a1"
            };

            _sut = new SwedbankPayClient(swedbankPayOptions);
        }
    }
}
