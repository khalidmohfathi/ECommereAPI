﻿using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces;
using ECommerce.Repository.Data.Contexts;
using ECommerce.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.APIS.Controllers
{
	public class ProductController : BaseApiController
	{
		private readonly IGenericRepository<Product> _repository;

		public ProductController(IGenericRepository<Product> repository)
		{
			_repository = repository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProductById(int id)
		{
			var product = await _repository.GetAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
		{
			var products = await _repository.GetAllAsync();
			return Ok(products);
		}
	}
}
