using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private StoreContext context;

        public StoreContext Init()
        {
            return context ?? (context = new StoreContext());
        }

        protected override void DisposeCore()
        {
            if(context != null)
            {
                context.Dispose();
            }
        }
    }
}
