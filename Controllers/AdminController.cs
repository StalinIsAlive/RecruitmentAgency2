﻿using Microsoft.AspNetCore.Mvc;

namespace recruitment_agency.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}