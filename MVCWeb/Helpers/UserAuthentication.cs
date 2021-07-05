using CommonSolution.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Helpers
{
    public class UserAuthentication : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = base.AuthorizeCore(httpContext);

            if (result == false)
            {
                return result;
            }

            if (httpContext.Request.CurrentExecutionFilePath.Split('/').Length > 2)
            {
                string controller = httpContext.Request.CurrentExecutionFilePath.Split('/')[1];
                string action = httpContext.Request.CurrentExecutionFilePath.Split('/')[2];
            }

            return true;
        }
    }
}