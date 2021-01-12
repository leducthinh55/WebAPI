using Core.Entities;
using Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public interface IProductDetailRespository : IRespository<ProductDetail>
    {

    }
    public class ProductDetailRespository : Respository<ProductDetail>, IProductDetailRespository
    {
        public ProductDetailRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
