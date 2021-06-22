using Mailer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mailer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;


        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Views(string Lang)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(Lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Lang);
            Mail mail = new Mail();
            mail.Subject = _localizer["Subject"];
            mail.Name = _localizer["Name"];
            mail.From = _localizer["Email"];
            mail.Body = _localizer["Details"];
            mail.To = _localizer["Submit"];
            return View(mail);
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
