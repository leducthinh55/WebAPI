using Core.Entities;
using Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public interface IModifiedProductRespository : IRespository<ModifiedProduct>
    {
    }

    public class ModifiedProductRespository : Respository<ModifiedProduct>, IModifiedProductRespository
    {
        public ModifiedProductRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
