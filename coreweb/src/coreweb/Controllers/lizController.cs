using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace coreweb.Controllers
{
    public class lizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}