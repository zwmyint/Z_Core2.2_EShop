using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Services.IRepository
{
    public interface ICandyRepository
    {
        IEnumerable<m_cls_Candy> GetAllCandy { get; }
        IEnumerable<m_cls_Candy> GetCandyOnSale { get; }
        m_cls_Candy GetCandyById(int candyId);
    }
}
