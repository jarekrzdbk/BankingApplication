using BankingApplication.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.Api.BLL.BusinessServicesInterfaces
{
    public interface IBankingAccount
    {
        UserViewModel GetUserData(string userName);
        void DepositMoney(string userName, double amount);
        void WithdrawMoney(string userName, double amount);
        void SendMoney(string userNameFrom, string userNameTo, double amount, string message);
    }
}
