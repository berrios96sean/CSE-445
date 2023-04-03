using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace try_it
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var app = WebApplication.Create();

            app.MapGet("/people", () => new[]
            {
    new Person("Ana"), new Person("Filipe"), new Person("Emillia")
});

            app.Run();

            record Person(string Name);
        }
    }
}
