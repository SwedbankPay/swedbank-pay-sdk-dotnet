using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sample.AspNetCore.Data;
using Sample.AspNetCore.Extensions;
using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;

namespace Sample.AspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }


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
                    "default",
                    "{controller=Products}/{action=Index}/{id?}");
            });
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StoreDbContext>(options => options.UseInMemoryDatabase("Products"));
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.Configure<PayeeInfoConfig>(options =>
            {
                options.PayeeId = Configuration.GetSection("PayeeInfo")["PayeeId"];
                options.PayeeReference = DateTime.Now.Ticks.ToString();
            });
            services.Configure<UrlsOptions>(Configuration.GetSection("Urls"));
            services.AddScoped(provider => SessionCart.GetCart(provider));
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSwedbankPayClient(Configuration);
            services.AddSession();
        }
    }
}