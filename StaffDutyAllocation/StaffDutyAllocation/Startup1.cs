using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using StaffDutyAllocation.Controllers;
using System;

[assembly: OwinStartup(typeof(StaffDutyAllocation.Startup1))]

namespace StaffDutyAllocation
    {
    public class Startup1
        {

        public void Configuration(IAppBuilder app)
            {

            JobStorage.Current = new SqlServerStorage("DutyAllocationDBContext");
            AdminController ad = new AdminController();
            RecurringJob.AddOrUpdate(() => ad.BlockInActiveUsers(), Cron.Daily);
            app.UseHangfireServer();
            }
        }
    }
