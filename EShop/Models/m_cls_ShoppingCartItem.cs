using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Models
{
    public class m_cls_ShoppingCartItem
    {
        //
        [Key]
        public int ShoppingCartItemId { get; set; }
        public string ShoppingCartId { get; set; }
        public m_cls_Candy Candy { get; set; }
        public int Amount { get; set; }
        //
    }
}
