using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.AspNetCore.Data;
using Sample.AspNetCore.Models;
using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;

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
		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
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

			var swedbankPayConSettings = Configuration.GetSection("SwedbankPay");
			services.Configure<SwedbankPayConnectionSettings>(swedbankPayConSettings);

			var swedBankPayOptions = swedbankPayConSettings.Get<SwedbankPayConnectionSettings>();
			services.AddSingleton(s => swedBankPayOptions);

			services.Configure<PayeeInfoConfig>(options =>
			{
				options.PayeeId = swedBankPayOptions.PayeeId;
				options.PayeeReference = DateTime.Now.Ticks.ToString();
			});

			services.Configure<UrlsOptions>(Configuration.GetSection("Urls"));
			services.AddScoped(provider => SessionCart.GetCart(provider));
			services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

			void configureClient(HttpClient a)
			{
				a.BaseAddress = swedBankPayOptions.ApiBaseUrl;
				a.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", swedBankPayOptions.Token);
                a.DefaultRequestHeaders.Add("User-Agent", $"swedbankpay-sdksamplesite-dotnet/{Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version}");
			}
			services.AddSwedbankPayClient(configureClient);
			services.AddSession();

			// Code copied from:
			// https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.1&tabs=visual-studio#options
			services.AddHsts(options =>
			{
				options.Preload = true;
				options.IncludeSubDomains = true;
				options.MaxAge = TimeSpan.FromDays(60);
			});

			services.AddHttpsRedirection(options =>
			{
				options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
				options.HttpsPort = 5001;
			});
		}
	}
}