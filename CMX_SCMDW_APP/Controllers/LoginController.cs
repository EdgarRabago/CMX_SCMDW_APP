﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CMX_SCMDW_APP.Controllers
{
    public class LoginController : Controller
    {
       

        public IActionResult Login()
        {
            return View();
        }
    }
}