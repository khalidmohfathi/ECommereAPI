using AutoMapper;
using ECommerce.APIS.DTOs;
using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Specifications;
using ECommerce.Repository.Data.Contexts;
using ECommerce.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.APIS.Controllers
{
	public class ProductController : BaseApiController
	{
		private readonly IGenericRepository<Product> _repository;
		private readonly IMapper _mapper;

		public ProductController(IGenericRepository<Product> repository , IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
		{
			var spec = new ProductSpecifications();
			var products = await _repository.GetAllWithSpecAsync(spec);
			return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductById(int id)
		{
			var spec = new ProductSpecifications(id);
			var product = await _repository.GetWithSpecAsync(spec);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<Product, ProductDto>(product));
		}
		
	}
}
