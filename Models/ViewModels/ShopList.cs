using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicCard.Models.ViewModels
{
    public class ShopList
    {
        public int ShopId { get; set; }

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }

        public int CardDiscountId { get; set; }       

        public string ShopImage { get; set; }

        public string ShopImage1 { get; set; }

        public string ShopImage2 { get; set; }

        public string ShopImage3 { get; set; }

        public string CategoryTitle { get; set; }     
       
        public string ShopTitle { get; set; }
        
        public string ShopAddress { get; set; }

        public string ShopDescription { get; set; }

        public decimal CardDiscountPercentage { get; set; }

       
    }
}