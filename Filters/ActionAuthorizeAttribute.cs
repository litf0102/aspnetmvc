using aspnetmvc2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc2.Filters
{
    /// <summary>
    /// 画面アクセス制御フォルタクラス
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class ActionAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// アクション実行前処理
        /// </summary>
        /// <param name="filterContext">フォルタ</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogHelper.Default.WriteInfo("ActionAuthorizeAttribute#OnActionExecuting executed.");
            base.OnActionExecuting(filterContext);
        }

        
    }
}