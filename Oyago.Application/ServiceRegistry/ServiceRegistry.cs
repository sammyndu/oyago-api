using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Oyago.Data;
using Oyago.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Oyago.Domain.Entities;

namespace Oyago.Application.ServiceRegistry
{
    public static class ServiceRegistry
    {
        public static IServiceCollection ServiceDependecies(this IServiceCollection services, IConfiguration conf, IHostEnvironment hostingEnvironment)
        {
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conf.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conf.GetConnectionString("CoreConnection")));

            services.AddSwagger();
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddScoped<UserManager<ApplicationUser>>();
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<IClientService, ClientService>();
            //services.AddScoped<IBankService, BankService>();
            //services.AddScoped<ICacheService, CacheService>();
            //services.AddScoped<IZenithTransferService, ZenithTransferService>();
            //services.AddScoped<IZenCoreHandler, ZenCoreHandler>();

            //services.Configure<ZenCoreSettings>(conf.GetSection("ZenCoreSettings"));
            //services.Configure<BankSettings>(conf.GetSection("BankSettings"));
            //services.Configure<SecuritySettings>(conf.GetSection("SecuritySettings"));
            //services.Configure<AccountSettings>(conf.GetSection("AccountSettings"));
            //services.Configure<TransferSettings>(conf.GetSection("TransferSettings"));
            //services.Configure<AuthSettings>(conf.GetSection("AuthSettings"));
            //services.Configure<EnvironmentSettings>(conf.GetSection("EnvironmentSettings"));

            services.AddHttpClient();
            //services.AddHttpClient(conf["ZenCoreSettings:ClientName"], client =>
            //{
            //    client.BaseAddress = new Uri(conf["ZenCoreSettings:BaseUrl"]);
            //    client.DefaultRequestHeaders.Add("X-CallerID", conf["ZenCoreSettings:CallerID"]);
            //    client.DefaultRequestHeaders.Add("X-CallerName", conf["ZenCoreSettings:CallerName"]);
            //    client.DefaultRequestHeaders.Add("X-CallerPassword", conf["ZenCoreSettings:CallerPassword"]);
            //});

            //services.AddHttpClient(conf["AuthSettings:ClientName"], client =>
            //{
            //    client.BaseAddress = new Uri(conf["AuthSettings:BaseUrl"]);
            //});
            return services;
        }
    }
}
