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

        public HomeController(ILogger<HomeController> logger, IUserService userService, IStatusesService statusService, ILoginService loginService, ICabinetService cabinetService, IAccountService accountService, ITransactionsService transactionsService)
        {
            _logger = logger;
            _userService = userService;
            _statusesService = statusService;
            _loginService = loginService;
            _cabinetService = cabinetService;
            _accountService = accountService;
            _transactionService = transactionsService;
        }

        public IActionResult Index()
        {
            return View("Login");
        }
        public async Task<IActionResult> LoginForm(Users users)
        {
            var user = await _loginService.CheckLogin(users.Login, users.Password);
            if (user == null)
            {
                return NotFound();
            }
            var account = await _cabinetService.uploadAccountInformation(user.Id);
            if (account == null)
            {
                return NotFound();
            }
            //var transaction = await _transactionService.checkingForTransaction(account, account, 0);
            //var transaction = _transactionService;
            string UserLogo = await _cabinetService.checkLogoForUpload(user);
            dynamic mymodel = new ExpandoObject();
            mymodel.Users = user;
            mymodel.Accounts = account;
            //mymodel.TransactionsService = transaction;
            mymodel.Logo = UserLogo;

            return View(mymodel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
