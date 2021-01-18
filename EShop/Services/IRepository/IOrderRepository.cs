using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Services.IRepository
{
    public interface IOrderRepository
    {

        void CreateOrder(m_cls_Order order);

    }
}
