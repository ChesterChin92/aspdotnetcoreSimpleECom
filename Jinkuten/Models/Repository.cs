using Jinkuten.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinkuten.Models
{
    public class Repository
    {
        ApplicationDbContext context;

        public Repository(ApplicationDbContext ctx) => context = ctx;

        public IQueryable<Product> Products => context.Product;

        public IQueryable<Cart> Carts => context.Cart;

        public IQueryable<Feedback> Feedbacks => context.Feedback;

        public IQueryable<WishList> WishLists => context.WishList;

        public void AddProduct(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
        }

        public Product GetProductById(long Id)
        {
            return context.Product.Find(Id);
        }

        public void UpdateProduct(Product product)
        {
            Product p = GetProductById(product.Id);
            p.ProductName = product.ProductName;
            p.ProductPrice = product.ProductPrice;
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Product.Remove(product);
            context.SaveChanges();
        }

        public void AddCart(Cart cart)
        {
            context.Cart.Add(cart);
            context.SaveChanges();
        }

        public Cart GetCartById(long Id)
        {
            return context.Cart.Find(Id);
        }

        public void UpdateCart(Cart cart)
        {
            Cart c = context.Cart.Find(cart.Id);
           
            context.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            context.Cart.Remove(cart);
            context.SaveChanges();
        }

        public void AddFeedback(Feedback feedback)
        {
            context.Feedback.Add(feedback);
            context.SaveChanges();
        }

        public Feedback GetFeedbackById(long Id)
        {
            return context.Feedback.Find(Id);
        }

        public void UpdateFeedback(Feedback feedback)
        {
            Feedback f = GetFeedbackById(feedback.Id);
            f.FeedbackMessage = feedback.FeedbackMessage;
            context.SaveChanges();
        }

        public void DeleteFeedback(Feedback feedback)
        {
            context.Feedback.Remove(feedback);
            context.SaveChanges();
        }

        public void AddWishList(WishList wishlist)
        {
            context.WishList.Add(wishlist);
            context.SaveChanges();
        }

        public WishList GetWishListById(long Id)
        {
            return context.WishList.Find(Id);
        }

        public void UpdateWishList(WishList wishlist)
        {
            WishList w = GetWishListById(wishlist.Id);
            context.SaveChanges();
        }

        public void DeleteWishList(WishList wishlist)
        {
            context.WishList.Remove(wishlist);
            context.SaveChanges();
        }
    }
}
