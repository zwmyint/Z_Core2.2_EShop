using EShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Services
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public string ShoppingCartId { get; set; }
        public List<m_cls_ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        //
        public void AddToCart(m_cls_Candy candy, int amount)
        {
            var shoppingCartItem = _appDbContext.ShopppingCartItems.SingleOrDefault(
                sci => sci.Candy.CandyId == candy.CandyId && sci.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new m_cls_ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Candy = candy,
                    Amount = amount
                };

                _appDbContext.ShopppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _appDbContext.SaveChanges();
        }

        // remove item amount one by one
        public int RemoveFromCart(m_cls_Candy candy)
        {
            var shoppingCartItem = _appDbContext.ShopppingCartItems.SingleOrDefault(
                s => s.Candy.CandyId == candy.CandyId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShopppingCartItems.Remove(shoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        //
        public List<m_cls_ShoppingCartItem> GetShoppingCartItems()
        {

            return ShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShopppingCartItems.Where(sci => sci.ShoppingCartId == ShoppingCartId)
                .Include(c => c.Candy)
                .ToList());
        }

        //
        public void ClearCart()
        {
            var cartItems = _appDbContext.ShopppingCartItems.Where(sci => sci.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShopppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        //
        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShopppingCartItems.Where(sci => sci.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Candy.Price * c.Amount).Sum();

            return total;
        }


        //
    }
}
