using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BankingApplication.Api.BLL.BusinessServicesInterfaces;
using BankingApplication.WebApi;
using BankingApplication.Api.Models;
using System.Net.Http;
using System.Web.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http.Results;

namespace BankingApplication.Tests
{
    [TestClass]
    public class BankingAccountsControllerTest
    {
        private Mock<IBankingAccount> _bankingAccountMock;
        BankingAccountsController bankingAccountsController;
        UserViewModel userViewModel;

        [TestInitialize]
        public void Initialize()
        {

            _bankingAccountMock = new Mock<IBankingAccount>();
            bankingAccountsController = new BankingAccountsController(_bankingAccountMock.Object);
            userViewModel = new UserViewModel
            {
                AvailableAmount = 100,
                History = new List<TransactionViewModel>()
                { new TransactionViewModel { Amount = 100,DateTime = DateTime.Now.AddDays(1),UserFrom = null, UserTo = "user1@test.com"},
                  new TransactionViewModel { Amount = 100,DateTime = DateTime.Now.AddDays(1),UserFrom = "user1@test.com", UserTo = null},
                   new TransactionViewModel { Amount = 100,DateTime = DateTime.Now.AddDays(1),UserFrom = "user1@test.com", UserTo = "user2@test.com"},
                }
            };

        }

        [TestMethod]
        public void Get_User_Status()
        {
            //Arrange
            _bankingAccountMock.Setup(x => x.GetUserData("user1@test.com")).Returns(userViewModel);

            var identity = new GenericIdentity("user1@test.com");
            Thread.CurrentPrincipal = new GenericPrincipal(identity, null);
            bankingAccountsController.Request = new HttpRequestMessage();
            bankingAccountsController.Configuration = new HttpConfiguration();

            //Act
            OkNegotiatedContentResult<UserViewModel> result = (OkNegotiatedContentResult<UserViewModel>)bankingAccountsController.GetUserStatus();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.History.Count, 3);
            Assert.AreEqual(result.Content.History[0].Amount, 100);
            Assert.AreEqual(result.Content.History[0].UserTo, "user1@test.com");
            Assert.AreEqual(result.Content.History[0].UserFrom, null);
        }

        [TestMethod]
        public void Deposit_Money()
        {
            //Arrange
            _bankingAccountMock.Setup(x => x.DepositMoney("user1@test.com",125)).Callback(()=> {
                userViewModel.AvailableAmount += 125;
                userViewModel.History.Add(new TransactionViewModel { Amount = 125, UserFrom = null,UserTo = "user1@test.com" });
            });

            var identity = new GenericIdentity("user1@test.com");
            Thread.CurrentPrincipal = new GenericPrincipal(identity, null);
            bankingAccountsController.Request = new HttpRequestMessage();
            bankingAccountsController.Configuration = new HttpConfiguration();
            var historyCount = userViewModel.History.Count;
            var availableAmmount = userViewModel.AvailableAmount;

            //Act
            var result = bankingAccountsController.Post_DepositMoney(125);

            //Assert
            _bankingAccountMock.Verify(m => m.DepositMoney("user1@test.com", 125), Times.Once);

            Assert.AreEqual(userViewModel.History.Count, historyCount + 1);
            Assert.AreEqual(userViewModel.History.Last().Amount, 125);
            Assert.AreEqual(userViewModel.AvailableAmount, availableAmmount + 125);
            Assert.AreEqual(userViewModel.History.Last().UserTo, "user1@test.com");
        }

        [TestMethod]
        public void Withdraw_Money()
        {
            //Arrange
            _bankingAccountMock.Setup(x => x.WithdrawMoney("user1@test.com", 125)).Callback(() => {
                userViewModel.AvailableAmount -= 125;
                userViewModel.History.Add(new TransactionViewModel { Amount = 125, UserFrom = "user1@test.com", UserTo = null });
            });

            var identity = new GenericIdentity("user1@test.com");
            Thread.CurrentPrincipal = new GenericPrincipal(identity, null);
            bankingAccountsController.Request = new HttpRequestMessage();
            bankingAccountsController.Configuration = new HttpConfiguration();
            var historyCount = userViewModel.History.Count;
            var availableAmmount = userViewModel.AvailableAmount;

            //Act
            var result = bankingAccountsController.Post_WithdrawMoney(125);

            //Assert
            _bankingAccountMock.Verify(m => m.WithdrawMoney("user1@test.com", 125), Times.Once);

            Assert.AreEqual(userViewModel.History.Count, historyCount + 1);
            Assert.AreEqual(userViewModel.History.Last().Amount, 125);
            Assert.AreEqual(userViewModel.AvailableAmount, availableAmmount - 125);
            Assert.AreEqual(userViewModel.History.Last().UserFrom, "user1@test.com");
        }
    }
}
