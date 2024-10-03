using ECommerce.Core.Entities;
using ECommerce.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository
{
	public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> innerQuery, ISpecification<TEntity> spec)
		{
			var query = innerQuery;
			if (spec.Criteria is not null)
			{
				query = query.Where(spec.Criteria);
			}
			query = spec.Includes.Aggregate(query , (currentQuery , includesExpression)=> currentQuery.Include(includesExpression));

			return query;
		}

	}
}
