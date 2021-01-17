using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.ViewModels
{
    public class CandyListViewModel
    {
        public IEnumerable<m_cls_Candy> Candies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
