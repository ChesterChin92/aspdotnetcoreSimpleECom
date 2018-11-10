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
using System.IO;
using Microsoft.EntityFrameworkCore;

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

        public void About()
        {
            Console.WriteLine(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ShowAllProduct()
        {
            return View("ShowAllProduct", new ViewModelProduct {
                Id = UserId,
                products = repository.Products
            });
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
        public async Task<IActionResult> AddProduct(ViewModelAddProduct product)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", Path.GetFileName(product.ImageFile.FileName));

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(stream);
            }

            repository.AddProduct(new Product {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Description = product.Description,
                ProductPublishedDate = DateTime.Now,
                ImageName = Path.GetFileName(product.ImageFile.FileName),
                AspNetUsersId = UserId
            });
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

        public IActionResult ShowAllCart()
        {
            return View("ShowAllCart", repository.Carts.Where(p=>p.AspNetUsersId == UserId).Include("Product"));
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
            return View("ShowAllWishList", repository.WishLists.Where(p=>p.AspNetUsersId == UserId).Include("Product"));
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

        public IActionResult ShowAllFeedback(int Id)
        {
            return View("ShowAllFeedback", new ViewModelAddFeedback {
                Feedback = repository.Feedbacks.Where(p => p.ProductId == Id),
                Id = Id,
                UserId = UserId
            });
        }

        public IActionResult AddFeedback(int Id)
        {
            return View("AddFeedback", new ViewModelAddFeedback {
                Id = Id,
                UserId = UserId
            });
        }

        [HttpPost]
        public IActionResult AddFeedback(ViewModelAddFeedback vm)
        {
            repository.AddFeedback(new Feedback
            {
                ProductId = vm.Id,
                AspNetUserId = vm.UserId,
                FeedbackMessage = vm.fbk.FeedbackMessage
            });
            return RedirectToAction(nameof(ShowAllProduct));
        }
    }
}
