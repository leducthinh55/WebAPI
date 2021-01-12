using Core.Entities;
using Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public interface ITypeGroupRespository : IRespository<TypeGroup>
    {

    }
    public class TypeGroupRespository : Respository<TypeGroup>, ITypeGroupRespository
    {
        public TypeGroupRespository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
