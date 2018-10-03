using AutoMapper;
using Northwind.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.API
{
    public static class MapperConfig
    {
        public static void MapEntitiesToDTO()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>().ForMember(dest => dest.OrderCount, opt => opt.MapFrom(src => src.Orders.Count()));
                cfg.CreateMap<Order, OrderDTO>()
                    .ForMember(dest => dest.ProductCount, opt => opt.MapFrom(src => src.Order_Details.Count()))
                    .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Order_Details.Select(x => x.Quantity * (float)x.UnitPrice * (1 - x.Discount)).Sum()))
                    .ForMember(dest => dest.HasDiscontinuedProduct, opt => opt.MapFrom(src => src.Order_Details.Any(x => x.Product.Discontinued)))
                    .ForMember(dest => dest.HasInsufficientQuantity, opt => opt.MapFrom(src => src.Order_Details.Any(x => x.Product.UnitsInStock < x.Product.UnitsOnOrder)));
            }
            );
        }
    }
}