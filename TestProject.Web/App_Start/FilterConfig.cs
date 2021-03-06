﻿using System.Web;
using System.Web.Mvc;
using TestProject.Web.Filters;

namespace TestProject.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new InitializeLinksDatabaseAttribute());
        }
    }
}
