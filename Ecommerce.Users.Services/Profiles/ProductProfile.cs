using AutoMapper;
using Ecommerce.Users.Data.Models;
using Ecommerce.Users.ViewModels;
using Ecommerce.Users.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Services.Profiles
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductViewModel>().ReverseMap();
            CreateMap<Product, UpdateProductViewModel>().ReverseMap();
            CreateMap<ProductsImage, AddImageViewModel>().ReverseMap();
        }
    }
}
