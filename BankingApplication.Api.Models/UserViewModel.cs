using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Models
{
    public class UserViewModel
    {
        public double AvailableAmount { get; set; }
        public List<TransactionViewModel> History { get; set; }
    }
}
