using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;

        private StoreContext context;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        private StoreContext _context
        {
            get
            {
                return context ?? (context = dbFactory.Init());
            }
        }

        public async Task<bool> Commit()
        {
            return await _context.Commit();
        }
    }
}
