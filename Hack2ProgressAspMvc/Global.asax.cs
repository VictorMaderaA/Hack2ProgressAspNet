﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Hack2ProgressAspMvc.BaseLogic;

namespace Hack2ProgressAspMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DocumentDbRepository<Hack2ProgressAspMvc.Models.Casa>.Initialize();
            DocumentDbRepository<Hack2ProgressAspMvc.Models.Hogar>.Initialize();
        }
    }
}
