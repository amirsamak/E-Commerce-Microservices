using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {   
            CreateMap<ProductBrand, BrandResponseDto>().ReverseMap();
            CreateMap<ProductType, TypeResponseDto>();
            CreateMap<Product, ProductResponseDto>();
            CreateMap<Pagination<Product>, Pagination<ProductResponseDto>>();
            //.ForMember(dest => dest.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
            //.ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name));
        }
    }
}
