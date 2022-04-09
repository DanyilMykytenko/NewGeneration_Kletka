﻿using Kletka.Models;
using Kletka.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Kletka.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Kletka.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUserService _userService;
        private readonly IStatusesService _statusesService;
        private readonly ILoginService _loginService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IStatusesService statusService, ILoginService loginService)
        {
            _logger = logger;
            _userService = userService;
            _statusesService = statusService;
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View("Login");
        }
        public async Task<IActionResult> LoginForm(Users users)
        {
            var x = await _loginService.CheckLogin(users.Login, users.Password); 
            if (x == 0)
            {
                return NotFound();
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
