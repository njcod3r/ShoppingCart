using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicCard.Models.ViewModels
{
    public class UserAuth
    {
        public string password { get; set; }
        public bool rememberMe { get; set; }
        public string username { get; set; }               
    }
}