using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Specifications
{
	public class ProductSpecifications : BaseSpecifications<Product>
	{
		public ProductSpecifications() : base()
		{
			Includes.Add(P => P.Brand);
			Includes.Add(P => P.Category);
		}
		public ProductSpecifications(int id) : base(P => P.Id == id)
		{
			Includes.Add(P => P.Brand);
			Includes.Add(P => P.Category);
		}
	}
}
