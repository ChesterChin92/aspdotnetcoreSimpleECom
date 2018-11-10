using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jinkuten.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Jinkuten.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        long UserId;
        Repository repository;
        public HomeController(Repository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void About()
        {
            UserId = Convert.ToInt64(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Console.WriteLine(UserId);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ShowAllProduct()
        {
            return View("ShowAllProduct", repository.Products);
        }

        public IActionResult UpdateProduct(int Id)
        {
            return View("UpdateProduct", repository.GetProductById(Id));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            repository.UpdateProduct(product);
            return RedirectToAction(nameof(ShowAllProduct));
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            repository.AddProduct(product);
            return RedirectToAction(nameof(ShowAllProduct));
        }

        public IActionResult AddProduct()
        {
            return View("AddProduct");
        }

        public IActionResult DeleteProduct(int Id)
        {
            repository.DeleteProduct(new Product { Id = Id});
            return RedirectToAction(nameof(ShowAllProduct));
        }

        public IActionResult ShowAllReview(int Id)
        {
            return View("ShowAllReview", repository.Feedbacks.Where(p=>p.ProductId == Id));
        }

        public IActionResult ShowAllCart()
        {
            return View("ShowAllCart", repository.Carts.Where(p=>p.AspNetUsersId == UserId));
        }

        public IActionResult AddCart(int Id)
        {
            repository.AddCart(new Cart { ProductId = Id, AspNetUsersId = UserId});
            return RedirectToAction(nameof(ShowAllCart));
        }

        public IActionResult DeleteCart(int Id)
        {
            repository.DeleteCart(new Cart { Id = Id});
            return RedirectToAction(nameof(ShowAllCart));
        }

        public IActionResult ShowAllWishList()
        {
            return View("ShowAllWishList", repository.WishLists.Where(p=>p.AspNetUsersId == UserId));
        }

        public IActionResult AddWishList(int Id)
        {
            repository.AddWishList(new WishList { ProductId = Id });
            return RedirectToAction(nameof(ShowAllWishList));
        }

        public IActionResult DeleteWishList(int Id)
        {
            repository.DeleteWishList(new WishList { Id = Id });
            return RedirectToAction(nameof(ShowAllWishList));
        }
    }
}
