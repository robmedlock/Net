using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebClient2.Controllers
{
    public class ProductController : Controller
    {
        private IEcommerceService ecommerceService;
        public ProductController(IEcommerceService ecommerceService)
        {
            this.ecommerceService = ecommerceService;
        }
        // GET: Product
        public async Task<IActionResult> Index(string id = null)
        {
            ViewBag.SearchText = id;
            return View(await ecommerceService.SelectProductsAsync(id));
        }

    }
}