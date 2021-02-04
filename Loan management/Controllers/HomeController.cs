using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Loan_management.Models;
using System.Text;

namespace Loan_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Content(string.Format(@"<script>location.href='/Login/Index'</script>"), "text/html", Encoding.GetEncoding("utf-8"));
        }

        public IActionResult Privacy()
        {
            //string msg = System.Data.Common.CommonHelper.HelloBody();

            //ViewData["Msg"] = msg;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
