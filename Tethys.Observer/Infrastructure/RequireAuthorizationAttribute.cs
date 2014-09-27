using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tethys.Observer.Infrastructure
{
    public class RequireAuthorizationAttribute : AuthorizeAttribute
    {
        private IEnumerable<string> roles = new string[] { };

        public RequireAuthorizationAttribute()
        {
        }

        public RequireAuthorizationAttribute(params string[] allowedRoles)
        {
            roles = allowedRoles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SecurityManager.Current.LoggedUser == null) return false;

            if (!roles.Any()) return true;

            return roles.Contains(SecurityManager.Current.LoggedUser.Role.Name);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/user/login");
        }
    }
}