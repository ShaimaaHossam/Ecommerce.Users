using AutoMapper;
using Ecommerce.Users.Data.Models;
using Ecommerce.Users.ViewModels;
using Ecommerce.Users.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Services.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
