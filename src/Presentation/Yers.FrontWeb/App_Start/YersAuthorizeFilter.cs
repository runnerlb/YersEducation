using System.Web.Mvc;
using Yers.Common;
using Yers.FrameworkWeb;

namespace Yers.FrontWeb.App_Start
{
    public class YersAuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //0.0判断是否有贴跳过登录检查的特性标签
            if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(SkipCheckLoginAttribute), false))
            {
                return;
            }

            if (filterContext.ActionDescriptor.IsDefined(typeof(SkipCheckLoginAttribute), false))
            {
                return;
            }
            if (filterContext.HttpContext.Session[Keys.WeiOpenId] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    AjaxResult ajaxResult = new AjaxResult
                    {
                        Result = false,
                        Data = "/Authorize/Index",
                        Msg = "没有登录"
                    };
                    filterContext.Result = new JsonNetResult { Data = ajaxResult };
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Authorize/Index");
                }
            }
        }
    }
}