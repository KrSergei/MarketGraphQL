﻿using AutoMapper;
using MarketGraphQL.Models;
using MarketGraphQL.Models.Dto;

namespace MarketGraphQL.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>(MemberList.Destination).ReverseMap();
            CreateMap<Category, CategoryDto>(MemberList.Destination).ReverseMap();
            CreateMap<Storage, StorageDto>(MemberList.Destination).ReverseMap();
        }
    }
}
