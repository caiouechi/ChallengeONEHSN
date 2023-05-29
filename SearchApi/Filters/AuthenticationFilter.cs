using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Routing;

namespace SearchApi.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {

        public void UnauthorizedAction(HttpActionContext actionContext)
        {
            actionContext.Response =
         new System.Net.Http.HttpResponseMessage(
              System.Net.HttpStatusCode.Unauthorized);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string authToken = actionContext.Request.Headers?.Authorization?.Parameter;

            if (!Auth.JwtAuth.ValidateToken(authToken))
            {
                UnauthorizedAction(actionContext);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}