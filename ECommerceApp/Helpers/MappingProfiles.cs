using AutoMapper;
using ECommerceApp.Core.Dtos;
using ECommerceApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(c => c.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(c => c.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(c => c.PictureUrl, o => o.MapFrom<ImageUrlResolver>());
        }
    }
}
