namespace SwedbankPay.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPayExHttpClient(this IServiceCollection services, IConfiguration configuration, string clientName)
        {
            var payexConfigsection = configuration.GetSection($"PayEx:{clientName}");
            services.Configure<SwedbankPayOptions>(clientName, payexConfigsection);
            services.AddHttpClient<PayExHttpClient>(clientName);
            services.AddTransient<PayExClient>();
            services.AddTransient<PayExClientDynamic>();
            return services;
        }
    }
}