using Application.Common.Mapping.Resolver;
using Application.Dtos.Products;
using AutoMapper;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
	{
        public MappingProfile()
        {
			CreateMap<Product, ProductDto>()
				.ForMember(x=>x.PictureUrl,c=>c.MapFrom<ProductImageUrlResolver>())
				.ForMember(x => x.ProductTypeName, c => c.MapFrom(d => d.ProductType.Title))
				.ForMember(x => x.ProductBrandName, c => c.MapFrom(d => d.ProductBrand.Title));
		}
    }
}
