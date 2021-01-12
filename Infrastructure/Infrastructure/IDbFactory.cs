using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Infrastructure
{
    public interface IDbFactory
    {
        StoreContext Init();
    }
}
