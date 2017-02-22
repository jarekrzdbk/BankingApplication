using BankingApplication.BLL.BusinessServicesInterfaces;
using BankingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BankingApplication.WebApi
{
    public class BankingAccountsController : ApiController
    {
        private IBankingAccount _bankingAccount;

        public BankingAccountsController(IBankingAccount bankingAccount)
        {
            _bankingAccount = bankingAccount;
        }

        [Authorize]
        [HttpGet]
        [Route("api/BankingAccounts/userStatus")]
        public IHttpActionResult GetUserStatus()
        {
            try
            {
                var model = _bankingAccount.GetUserData(User.Identity.Name);
                return Ok(model);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/BankingAccounts/sendMoney")]
        public IHttpActionResult Post_SendMoney(TransferToUserModelView model)
        {
            try
            {
                _bankingAccount.SendMoney(User.Identity.Name, model.UserName, model.Amount, model.Message);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Authorize]
        [HttpPost]
        [Route("api/BankingAccounts/depositMoney")]
        public IHttpActionResult Post_DepositMoney([FromBody] double amount)
        {
            try
            {
                _bankingAccount.DepositMoney(User.Identity.Name, amount);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/BankingAccounts/withdrawMoney")]
        public IHttpActionResult Post_WithdrawMoney([FromBody] double amount)
        {
            try
            {
                _bankingAccount.WithdrawMoney(User.Identity.Name, amount);
                return Ok();
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }
        }

    }
}
