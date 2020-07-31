using aspnetmvc2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc2.Filters
{
    /// <summary>
    /// 集約権限管理フォルタクラス
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class GlobalAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// ユーザ認証処理
        /// </summary>
        /// <param name="filterContext">フォルタ</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            LogHelper.Default.WriteInfo("GlobalAuthorizeAttribute#OnAuthorization executed.");
            // 基底の認証処理を実行する
            base.OnAuthorization(filterContext);
        }

        /// <summary>
        /// 権限認証処理
        /// </summary>
        /// <param name="httpContext">フォルタ</param>
        /// <returns>true: 認証成功, false: 認証失敗</returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            LogHelper.Default.WriteInfo("GlobalAuthorizeAttribute#AuthorizeCore executed.");
            return true;
        }
    }
}