using ECommerce.Core.Entities;
using ECommerce.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<T?> GetAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);
		Task<T?> GetWithSpecAsync(ISpecification<T> spec);
	}
}
