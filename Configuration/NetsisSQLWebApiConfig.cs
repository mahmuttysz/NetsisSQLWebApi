using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NetsisSQLWebApi.Configuration
{
    public class NetsisSQLWebApiConfig
    {
       
        public static void Register(HttpConfiguration config)
        {
            string token = "61d1bf81482adf2ec6db5cbb703649b9e0770bb44b168d34a19cd2ecfb379a67c75c917023d603091f73e0b386b4c1e1134eb5f06fcc17b12334017c9c3fe8e7";
          // Web API routes
             config.MapHttpAttributeRoutes();
           
             config.Routes.MapHttpRoute(
                name: "NetsisSQLWebApi",
                routeTemplate: "token/"+token + "/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }
        
    }
}