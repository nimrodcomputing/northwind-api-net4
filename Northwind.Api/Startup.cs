﻿using System;
using System.Collections.Generic;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Northwind.Api.Startup))]

namespace Northwind.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
