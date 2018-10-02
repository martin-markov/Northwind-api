using AutoMapper;
using Northwind.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Northwind.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ConfigureAutomaper();
        }

        private void ConfigureAutomaper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>().ForMember(dest => dest.OrderCount, opt => opt.MapFrom(src => src.Orders.Count())).ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerID));
                
            }
            );
        }
    }
}
