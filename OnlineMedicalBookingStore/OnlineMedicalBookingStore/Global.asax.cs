using AutoMapper;
using BLL.Mappings;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineMedicalBookingStore
    {
    public class MvcApplication : System.Web.HttpApplication
        {
        protected void Application_Start()
            {
            Mapper.Initialize(c => c.AddProfile<MappingProfiles>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
        }
    }
