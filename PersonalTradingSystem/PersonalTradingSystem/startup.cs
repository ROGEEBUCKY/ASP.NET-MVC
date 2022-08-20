using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PersonalTradingSystem.Startup))]

namespace PersonalTradingSystem
    {
    public class Startup
        {
        public void Configuration(IAppBuilder app)
            {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("TradingContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
            }
        }
    }
