using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CMX_SCMDW_APP.Attributes
{
    public class AppAuthorizeAttribute : AuthorizeAttribute
    {
     

        
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.ErrorMessage = "User has not been setup in Lineage";            
            base.HandleUnauthorizedRequest(filterContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string enableRedirect = WebConfigurationManager.AppSettings["enableRedirect"].ToUpper();
            string oldURLHostName = WebConfigurationManager.AppSettings["OldUrlHostName"].ToUpper();
            string newURL = WebConfigurationManager.AppSettings["newUrl"];

            string host = filterContext.HttpContext.Request.Url.Host.ToUpper();

            if (enableRedirect == "TRUE" && host == oldURLHostName)
            {
                filterContext.Result = new RedirectResult(newURL, true);
                return;
            }

            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //PredictivePowerDB db = new PredictivePowerDB("PredictivePower");

            //let the framework log in the user
            var isAuthorized = base.AuthorizeCore(httpContext);

            //check if user exists in the DB...if not kick them out
            //var userLoggedIn = db.Users.Where(b => b.UserName == httpContext.User.Identity.Name && b.Status == UserStatus.Active).FirstOrDefault();

            //if (userLoggedIn == null)
            //{
            //    isAuthorized = false;
            //    return isAuthorized;
            //}

            //var controllerName = (string)httpContext.Request.RequestContext.RouteData.Values["controller"];
            //var actionName = (string)httpContext.Request.RequestContext.RouteData.Values["action"];

            ////If the routing data contains the customer, then use that customer value and ensure the user has access.
            //CustomerAccess = (string)httpContext.Request.RequestContext.RouteData.Values["customerName"];

            //if (isAuthorized)
            //{
            //    //check if it is a valid customer
            //    if (CustomerAccess != "")
            //    {
            //        //is it a valid customer
            //        var isCustInList = db.Customers.Any(x => x.CustomerName == CustomerAccess);

            //        if (isCustInList)
            //        {
            //            isAuthorized = isValidByCustomer(userLoggedIn) && isValidByGroup(userLoggedIn);
            //        }
            //        else
            //        {
            //            //user will get kicked out with a 404 on the HasCustomerNameAttribute
            //            isAuthorized = true;
            //        }
            //    }
            //    else
            //    {
            //        isAuthorized = true;
            //    }                
            //}

            //db.Dispose();

            return isAuthorized;
        }  

      
    }

}