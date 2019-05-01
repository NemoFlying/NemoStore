using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Castle.Facilities.Logging;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NemoStore.EFCoreOracle;
using NemoStore.EFCoreSql;

namespace NemoStore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //注册Oracle数据库服务 
            services.AddOraDbContext(Configuration["DbConnString:OracleConn"]);

            //注册SqlServer数据库服务 
            //services.AddSqlDbContext(Configuration["DbConnString:SqlConn"]);

            //使用 WindsorContainer
            var windsorContainer = new WindsorContainer();

            //注册模块

            windsorContainer.Install(FromAssembly.Named("NemoStore.Repository"));

            windsorContainer.Install(FromAssembly.Named("NemoStore.Web"));
            
            //注册日志模块
            windsorContainer.AddFacility<LoggingFacility>(facility =>
            facility
            //.LogUsing(new Log4netFactory("log4net.config")));
            .LogUsing<Log4netFactory>()
            //.UseLog4Net()
            .WithConfig("log4net.config"));
            
            ////var fStream = File.OpenRead();
            //var kk = new Log4netFactory("log4net.config").Create("InfrastructureLog");
            //kk.Debug("Info___________");
            return WindsorRegistrationHelper.CreateServiceProvider(windsorContainer, services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
