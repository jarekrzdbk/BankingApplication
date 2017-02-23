using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Models
{
    public class TransferToUserModelView
    {
        public double Amount { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
