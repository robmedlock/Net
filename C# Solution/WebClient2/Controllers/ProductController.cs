using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Entity;
using ClassLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebClient2.Controllers
{
    public class ProductController : Controller
    {
        private IEcommerceService ecommerceService;
        private IHttpContextAccessor context;

        public ProductController(IEcommerceService ecommerceService, IHttpContextAccessor context = null)
        {
            this.ecommerceService = ecommerceService;
            this.context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(string id = null)
        {
            ViewBag.SearchText = id; //used to retain text in input field
            return View(await ecommerceService.SelectProductsAsync(id));
        }

        //GET: Product/AddProduct/5
        [Authorize]
        public async Task<IActionResult> AddProduct(string id)
        {
            Order order = await ecommerceService.AddProductToOrderAsync(id, context.HttpContext.User.Identity.Name);
            //Order order = await  ecommerceService.AddProductToOrderAsync(id, User.Identity.Name);
            return View("Basket", order.LineItems);
        }

        //GET: Product/Basket
        [Authorize]
        public async Task<IActionResult> Basket()
        {
            Order order = await
                ecommerceService.CreateOrSelectProvisionalOrderForExistingAccountAsync(User.Identity.Name);
            return View(order.LineItems);
        }

        //GET: Product/AddProduct/5
        [Authorize]
        public async Task<IActionResult> Purchase()
        {
            await ecommerceService.ConfirmOrderAsync(User.Identity.Name);
            return View();
        }


        //additional methods



        // GET: Product/RemoveProductFromOrder/5
        public async Task<IActionResult> RemoveProductFromOrder(string id)
        {
            await ecommerceService.RemoveProductFromOrderAsync(id, User.Identity.Name);
            return RedirectToAction(nameof(Basket));
        }


        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CostPrice,RetailPrice,RowVersion")] Product product)
        {
            if (ModelState.IsValid)
            {
                await ecommerceService.CreateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await ecommerceService.SelectProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            //await ecommerceService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}