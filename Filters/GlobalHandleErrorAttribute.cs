using aspnetmvc2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc2.Filters
{
    public class GlobalHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>Called when an exception occurs.</summary>
        /// <param name="filterContext">The action-filter context.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="filterContext" /> parameter is null.</exception>
        public override void OnException(ExceptionContext filterContext)
        {
            LogHelper.Default.WriteInfo("GlobalHandleErrorAttribute start.");

            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
               
            if (filterContext.IsChildAction || filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                throw filterContext.Exception;
            }

            Exception exception = filterContext.Exception;

            //500（Internal Server Error）
            if (new HttpException((string)null, exception).GetHttpCode() != 500 || !filterContext.HttpContext.Request.IsAjaxRequest())
            {
                throw filterContext.Exception;
            }

            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];
            HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            ExceptionContext exceptionContext = filterContext;
            ViewResult viewResult1 = new ViewResult();
            viewResult1.ViewName = this.View;
            viewResult1.MasterName = this.Master;
            viewResult1.ViewData = (ViewDataDictionary)new ViewDataDictionary<HandleErrorInfo>(model);
            viewResult1.TempData = filterContext.Controller.TempData;
            ViewResult viewResult2 = viewResult1;
            exceptionContext.Result = (ActionResult)viewResult2;

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            LogHelper.Default.WriteInfo("GlobalHandleErrorAttribute end.");
        }
    }
}