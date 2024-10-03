using AutoMapper;
using ECommerce.APIS.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.APIS.Helpers
{
	public class PictureUrlResolver : IValueResolver<Product, ProductDto, string>
	{
		private readonly IConfiguration _configuration;

		public PictureUrlResolver(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.PictureUrl))
			{
				return $"{_configuration["BaseUrl"]}/{source.PictureUrl}";
			}
			return string.Empty;
		}
	}
}
