using log4net;
using System.Web.Mvc;

namespace Yers.FrontWeb
{
    public class YersExceptionFilter : IExceptionFilter
    {
        private static ILog log = LogManager.GetLogger(typeof(YersExceptionFilter));

        public void OnException(ExceptionContext filterContext)
        {
            log.Error("出现未处理异常", filterContext.Exception);
        }
    }
}