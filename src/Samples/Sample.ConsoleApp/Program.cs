using Microsoft.Extensions.Configuration;

using System;

namespace Sample.ConsoleApp
{
    using SwedbankPay.Client;
    using SwedbankPay.Client.Models.Common;
    using SwedbankPay.Client.Models.Vipps.PaymentAPI.Request;

    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var payExOptions = new SwedbankPayOptions();
            config.GetSection("SwedbankPay:someAccount").Bind(payExOptions);
            

            var swedbankPayClient = new SwedbankPayClient(payExOptions);
            var prices = new Price
            {
                Amount = 10000,
                VatAmount = 2500,
                Type = PriceTypes.Vipps
            };

            var paymentRequest = new PaymentRequest("Console.Sample/1.0.0", "Some productname", "order123", "123456", prices);

            var res = swedbankPayClient.Payment.PostVippsPayment(paymentRequest).GetAwaiter().GetResult();
            Console.WriteLine($"Payment created with id : {res.Payment.Id}");

            var dynamicallyCreated = swedbankPayClient.Payment.PostVippsPayment(paymentRequest).GetAwaiter().GetResult();
            Console.WriteLine($"Payment created with dynamic client. id : {dynamicallyCreated.Payment.Id}");
        }
    }
}
