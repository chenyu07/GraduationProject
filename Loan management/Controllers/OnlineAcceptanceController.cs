﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Loan_management.Controllers
{
    public class OnlineAcceptanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}