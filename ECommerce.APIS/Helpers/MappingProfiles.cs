using AutoMapper;
using ECommerce.APIS.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.APIS.Helpers
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Product, ProductDto>()
					 .ForMember(D => D.Brand, O => O.MapFrom(S => S.Brand.Name))
					 .ForMember(D => D.Category, O => O.MapFrom(S => S.Category.Name))
					 .ForMember(D => D.PictureUrl, O => O.MapFrom<PictureUrlResolver>());
		}
	}
}
