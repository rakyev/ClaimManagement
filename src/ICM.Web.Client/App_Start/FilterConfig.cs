﻿using System.Web;
using System.Web.Mvc;

namespace ICM.Web.Client
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}