using System;
using System.Threading.Tasks;
using Hangfire.Controllers;
using Hangfire.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hangfire.Startup))]

namespace Hangfire
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");
            app.UseHangfireDashboard();
            DAL obj = new DAL();
            RecurringJob.AddOrUpdate(() => obj.getdefaulters(), Cron.Minutely);
            app.UseHangfireServer();
        }
    }
}
