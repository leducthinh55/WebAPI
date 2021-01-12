using Core.Entities;
using Infrastructure.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Respositories
{
    public interface IColorRespository : IRespository<Color>
    {
    }

    public class ColorRespository : Respository<Color>, IColorRespository
    {
        public ColorRespository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
