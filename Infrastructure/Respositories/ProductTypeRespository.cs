using Core.Entities;
using Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public interface IProductTypeRespository : IRespository<ProductType>
    {
    }

    public class ProductTypeRespository : Respository<ProductType>, IProductTypeRespository 
    {
        public ProductTypeRespository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
