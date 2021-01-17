using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Services.IRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<m_cls_Category> GetAllCategories { get; }
    }
}
