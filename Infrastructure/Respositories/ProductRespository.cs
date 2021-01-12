using Core.Entities;
using Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public interface IProductRespository : IRespository<Product>
    {

    }
    public class ProductRespository : Respository<Product>, IProductRespository
    {
        public ProductRespository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
