using Core.Entities;
using Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public interface ITypeGroupUserRespository : IRespository<TypeGroupUser>
    {

    }
    public class TypeGroupUserRespository : Respository<TypeGroupUser>, ITypeGroupUserRespository
    {
        public TypeGroupUserRespository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
