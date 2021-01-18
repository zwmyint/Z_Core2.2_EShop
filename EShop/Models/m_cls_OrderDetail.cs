using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class m_cls_OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }

        public int CandyId { get; set; }
        public m_cls_Candy Candy { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public m_cls_Order Order { get; set; }
    }
}
