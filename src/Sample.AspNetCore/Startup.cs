namespace Sample.AspNetCore
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Sample.AspNetCore.Data;
    using Sample.AspNetCore.Models;
    using Microsoft.EntityFrameworkCore;
    using SwedbankPay.Sdk;
    using SwedbankPay.Sdk.PaymentOrders;
    using Sample.AspNetCore.Extensions;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreDbContext>(options => options.UseInMemoryDatabase("Products"));
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.Configure<PayeeInfo>(options =>
            {
                options.PayeeId = Configuration.GetSection("PayeeInfo")["PayeeId"];
            });
            services.Configure<Urls>(Configuration.GetSection("Urls"));
            services.AddScoped<Cart>(provider => SessionCart.GetCart(provider));
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSwedbankPayClient(Configuration, "someAccount");
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{id?}");
            });
        }
    }
}
