using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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
            config.GetSection("payex:someAccount").Bind(payExOptions);

            //IOptions<SwedbankPayOptions> options = new OptionsWrapper<SwedbankPayOptions>(payExOptions);

            //IHttpClientFactory httpClientFactory = new HttpClientCreator(options.Value);

            //ISelectClient clientSelector = new DummySelector();


            //IConfigureOptions<SwedbankPayOptions> optionsConfigurator = new ConfigureOptions<SwedbankPayOptions>(Conf(payExOptions));
            //var configureOptionses = new []{ optionsConfigurator };
            //IPostConfigureOptions<SwedbankPayOptions> postoptionsConfigurator = new PostConfigureOptions<SwedbankPayOptions>(Constants.THECLIENTNAME,Conf(payExOptions));
            //var postConfigureOptionses = new []{ postoptionsConfigurator};
            
            //IOptionsSnapshot<SwedbankPayOptions> optionsSnap = new OptionsManager<SwedbankPayOptions>(new OptionsFactory<SwedbankPayOptions>(configureOptionses,postConfigureOptionses));
            //var dynamic = new PayExClientDynamic(httpClientFactory, optionsSnap);
            //var payExClient = new PayExClient(dynamic, clientSelector);
            //var prices = new Price
            //{
            //    Amount = 10000,
            //    VatAmount = 2500,
            //    Type = PriceTypes.Vipps
            //};
            //var paymentRequest = new PaymentRequest("Console.Sample/1.0.0", "Some productname", "order123", "123456", prices);
            //var res = payExClient.PostVippsPayment(paymentRequest).GetAwaiter().GetResult();
            //Console.WriteLine($"Payment created with id : {res.Payment.Id}");

            //var dynamicallyCreated = dynamic.PostVippsPayment(clientSelector.Select(), paymentRequest).GetAwaiter().GetResult();
            //Console.WriteLine($"Payment created with dynamic client. id : {dynamicallyCreated.Payment.Id}");

        }

        //private static Action<SwedbankPayOptions> Conf(SwedbankPayOptions swedbankPayOptions)
        //{
        //    return o =>
        //    {
        //        o.ApiBaseUrl = swedbankPayOptions.ApiBaseUrl;
        //        o.Token = swedbankPayOptions.Token;
        //        o.MerchantId = swedbankPayOptions.MerchantId;
        //        o.MerchantName = swedbankPayOptions.MerchantName;
        //        o.CallBackUrl = swedbankPayOptions.CallBackUrl;
        //        o.CancelPageUrl = swedbankPayOptions.CancelPageUrl;
        //        o.CompletePageUrl = swedbankPayOptions.CompletePageUrl;
        //    };
        //}
    }

    //internal class DummySelector : ISelectClient
    //{
    //    public string Select()
    //    {
    //        return Constants.THECLIENTNAME;
    //    }
    //}

    //internal class HttpClientCreator : IHttpClientFactory
    //{
    //    private readonly SwedbankPayOptions _swedbankPayOptions;

    //    public HttpClientCreator(SwedbankPayOptions swedbankPayOptions)
    //    {
    //        _swedbankPayOptions = swedbankPayOptions;
    //    }
    //    public HttpClient CreateClient(string name)
    //    {
    //        var httpClient = new HttpClient();
    //        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_swedbankPayOptions.Token}");
    //        httpClient.BaseAddress = _swedbankPayOptions.ApiBaseUrl;
    //        return httpClient;
    //    }
    //}

    //public static class Constants
    //{
    //    public const string THECLIENTNAME = "someAccount";
    //}
}
