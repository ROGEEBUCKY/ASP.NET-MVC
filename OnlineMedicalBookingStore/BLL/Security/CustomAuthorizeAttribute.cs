using BLL.BLServices;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BLL.Security
    {
    public class CustomAuthorizeAttribute : AuthorizeAttribute
        {
        private readonly string[] allowedroles;
        private readonly LoginServices LoginBObj;
        public CustomAuthorizeAttribute(params string[] roles)
            {
            LoginBObj = new LoginServices();
            this.allowedroles = roles;
            }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
            bool authorize = false;
            var userId = Convert.ToString(httpContext.Session["UserId"]);
            if (!string.IsNullOrEmpty(userId))
                {
                var userRole = LoginBObj.GetUserRole(Convert.ToInt32(userId));
                foreach (var role in allowedroles)
                    {
                    if (role == userRole.Name) return true;
                    }
                }
            return authorize;
            }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Login" },
                    { "action", "NotFound" }
               });
            }
        }
    }
