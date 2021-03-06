﻿using System.Web.Mvc;
using Yers.FrameworkWeb;

namespace Yers.AdminWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new YersExceptionFilter());
            filters.Add(new JsonNetActionFilter());
            filters.Add(new YersAuthorizeFilter());
        }
    }
}