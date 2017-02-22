using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.DAL 
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly ILifetimeScope _container;

        public DbContextFactory()
        {

        }
        public DbContextFactory(ILifetimeScope container)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            _container = container;
        }
        public virtual IApplicationDbContext Create()
        {
            return _container.Resolve<IApplicationDbContext>();
        }
    }
}
