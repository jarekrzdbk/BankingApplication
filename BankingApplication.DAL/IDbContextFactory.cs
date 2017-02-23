using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.DAL
{
    public interface IDbContextFactory
    {
        IApplicationDbContext Create();
    }
}
