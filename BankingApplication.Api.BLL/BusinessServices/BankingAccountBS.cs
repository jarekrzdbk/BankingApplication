using BankingApplication.Api.BLL.BusinessServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApplication.Api.Models;
using BankingApplication.Api.DAL;

namespace BankingApplication.Api.BLL.BusinessServices
{
    public class BankingAccountBS : IBankingAccount
    {
        public void DepositMoney(string userName, double amount)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Transactions.Add(new Entities.Transaction()
                {
                    UserFrom = null,
                    UserTo = userName,
                    Amount = amount,
                    DateTime = DateTime.Now
                }
                );
                context.SaveChanges();
            }
        }

        public UserViewModel GetUserData(string userName)
        {
            UserViewModel vm = new UserViewModel();
            using (var context = new ApplicationDbContext())
            {
                vm.History = context.Transactions
                    .Where(x => x.UserFrom == userName || x.UserTo == userName)
                    .Select( t =>
                        new TransactionViewModel() { UserFrom = t.UserFrom, UserTo = t.UserTo , Amount = t.Amount, DateTime = t.DateTime, Message =t.Message}
                    ).OrderBy(t => t.DateTime).ToList();
                vm.AvailableAmount = vm.History.Where(t => t.UserTo == userName).Sum(t => t.Amount) - vm.History.Where(t => t.UserFrom == userName).Sum(t => t.Amount);
            }
            return vm;
        }

        public void SendMoney(string userNameFrom, string userNameTo, double amount, string message)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = GetUserData(userNameFrom);
                if (user.AvailableAmount - amount > 0)
                {
                    context.Transactions.Add(new Entities.Transaction()
                    {
                        UserFrom = userNameFrom,
                        UserTo = userNameTo,
                        Amount = amount,
                        DateTime = DateTime.Now,
                        Message = message
                    }
                    );
                }
                else
                {
                    throw new Exception("You have no enough money for this operation!");
                }
                context.SaveChanges();
            }
        }

        public void WithdrawMoney(string userName, double amount)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = GetUserData(userName);
                if (user.AvailableAmount - amount > 0)
                {

                    context.Transactions.Add(new Entities.Transaction()
                    {
                        UserFrom = userName,
                        UserTo = null,
                        Amount = amount,
                        DateTime = DateTime.Now
                    }
                );
                }
                else
                {
                    throw new Exception("You have no enough money for this operation!");
                }
                context.SaveChanges();
            }
        }
    }
}
