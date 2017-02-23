using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BankingApplication.BLL.BusinessServicesInterfaces;
using BankingApplication.WebApi;
using BankingApplication.Models;
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
            _bankingAccountMock.Verify(m => m.GetUserData("user1@test.com"), Times.Once);
        }

        [TestMethod]
        public void Deposit_Money()
        {
            //Arrange
            _bankingAccountMock.Setup(x => x.DepositMoney("user1@test.com", 125));

            var identity = new GenericIdentity("user1@test.com");
            Thread.CurrentPrincipal = new GenericPrincipal(identity, null);
            bankingAccountsController.Request = new HttpRequestMessage();
            bankingAccountsController.Configuration = new HttpConfiguration();

            //Act
            var result = bankingAccountsController.Post_DepositMoney(125);

            //Assert
            _bankingAccountMock.Verify(m => m.DepositMoney("user1@test.com", 125), Times.Once);
        }

        [TestMethod]
        public void Withdraw_Money()
        {
            //Arrange
            _bankingAccountMock.Setup(x => x.WithdrawMoney("user1@test.com", 125));

            var identity = new GenericIdentity("user1@test.com");
            Thread.CurrentPrincipal = new GenericPrincipal(identity, null);
            bankingAccountsController.Request = new HttpRequestMessage();
            bankingAccountsController.Configuration = new HttpConfiguration();

            //Act
            var result = bankingAccountsController.Post_WithdrawMoney(125);

            //Assert
            _bankingAccountMock.Verify(m => m.WithdrawMoney("user1@test.com", 125), Times.Once);
        }
    }
}
