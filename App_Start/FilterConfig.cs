using aspnetmvc2.Filters;
using System.Web;
using System.Web.Mvc;

namespace aspnetmvc2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            // グローバル例外処理
            filters.Add(new GlobalHandleErrorAttribute());
            // グローバル認証処理
            filters.Add(new GlobalAuthorizeAttribute());
        }
    }
}
