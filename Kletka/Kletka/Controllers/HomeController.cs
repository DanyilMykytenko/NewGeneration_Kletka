using Kletka.Models;
using Kletka.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Kletka.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Kletka.Extensions;
using Newtonsoft.Json;
using Kletka.Exceptions;

namespace Kletka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserService _userService;
        private readonly IStatusesService _statusesService;
        private readonly ILoginService _loginService;
        private readonly ICabinetService _cabinetService;
        private readonly IAccountService _accountService;
        private readonly ITransactionsService _transactionService;

        public HomeController(
            ILogger<HomeController> logger, 
            IUserService userService, 
            IStatusesService statusService, 
            ILoginService loginService, 
            ICabinetService cabinetService, 
            IAccountService accountService, 
            ITransactionsService transactionsService)
        {
            _logger = logger;
            _userService = userService;
            _statusesService = statusService;
            _loginService = loginService;
            _cabinetService = cabinetService;
            _accountService = accountService;
            _transactionService = transactionsService;
        }

        #region Views

        public async Task<IActionResult> Index()
        {
            string token = null;
            if (!Request.Cookies.TryGetValue("token", out token))
                return View("Login");

            var user = await _loginService.CheckToken(token);
            if (user == null)
                return View("Login");

            return RedirectToAction("Cabinet");
        }

        public async Task<IActionResult> LoginForm(LoginFormModel model)
        {
            var user = await _loginService.CheckLogin(model.Login, model.Password);
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            Response.Cookies.Append("token", _loginService.CreateToken(user.Id, user.Password));

            return RedirectToAction("Cabinet");
        }

        public async Task<IActionResult> Cabinet()
        {
            string token = null;
            if (!Request.Cookies.TryGetValue("token", out token))
                return RedirectToAction("Index");

            var user = await _loginService.CheckToken(token);
            if (user == null)
                return RedirectToAction("Index");
            var account = await _cabinetService.GetAccountInformation(user.Id);
            if (account == null)
            {
                return RedirectToAction("Index");
            }

            string userLogo = await _cabinetService.CheckLogoForUpload(user);
            dynamic mymodel = new ExpandoObject();
            mymodel.Users = user;
            mymodel.Accounts = account;
            mymodel.Logo = userLogo;

            return View(mymodel);
        }

        public async Task<IActionResult> LogoutForm()
        {
            Response.Cookies.Delete("token");

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region Json

        [HttpPost]
        public async Task<IActionResult> Money([FromBody] MoneyModel model)
        {
            try
            {
                string token = null;
                if (!Request.Cookies.TryGetValue("token", out token))
                    return Unauthorized();

                var user = await _loginService.CheckToken(token);
                if (user == null)
                    return Unauthorized();

                var account = await _cabinetService.GetAccountInformation(user.Id);
                var affectedAccounts = await _transactionService.MakeTransaction(account.AccountNumber, model.ReceiverAccountNumber, model.MoneyAmount);
                if (!affectedAccounts.Any())
                {
                    return NotFound();
                }

                return Content(JsonConvert.SerializeObject(new { Money = affectedAccounts.First(a => a.AccountNumber == account.AccountNumber).Balance, Success = true }), "application/json");
            }
            catch(NoMoneyException)
            {
                return Content(JsonConvert.SerializeObject(new { Money = 0.0, Success = false, Reason = "Not enough money on your balance" }), "application/json");
            }
        }

        #endregion        
    }
}
