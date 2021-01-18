using EShop.Models;
using EShop.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Services.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        //
        public void CreateOrder(m_cls_Order order)
        {
            // BindNever Field at Model (need to add by system to this order object)
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            // Get all shopping cart items and add to order detail
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new m_cls_OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Candy.Price,
                    CandyId = shoppingCartItem.Candy.CandyId,
                    OrderId = order.OrderId
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();

        }

        


        //
    }
}
