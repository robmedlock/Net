using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Area1.Controllers
{
    [Area("Area1")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}