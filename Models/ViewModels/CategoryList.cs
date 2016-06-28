using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicCard.Models.ViewModels
{
    public class CategoryList
    {
        public int CategoryId { get; set; }

        public string CategoryImage { get; set; }      
      
        public bool IsActive { get; set; }

        public int LanguageId { get; set; }

        public string CategoryTitle { get; set; }
    }
}