using MagicCard.Models.DataServices;
using MagicCard.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MagicCard.Services
{
    public class AdminPanelServices
    {
        private readonly UsersDBServices _userDbServices;
        private readonly ShopDBServices _shopDBServices;

        public AdminPanelServices()
        {
            _userDbServices = new UsersDBServices();
            _shopDBServices = new ShopDBServices();
        }

        public Usr_Users getAuthentication(string username, string password)
        {
            byte[] bytePassword = Encoding.UTF8.GetBytes(password);
            var user = _userDbServices.getUserDataByNameAndPassword(username, bytePassword);
            return user;
        }

        public IEnumerable<ShopList> getAllShopList()
        {
            return _shopDBServices.getAllShops();
        }

        public ShopList getShopById(int shopId)
        {
            return _shopDBServices.getShopById(shopId);
        }

        public bool createShop(ShopList shop)
        {
            if (shop == null || string.IsNullOrWhiteSpace(shop.ShopTitle))
                return false;

            return _shopDBServices.createShop(shop);
        }

        public bool updateShop(ShopList shop)
        {
            if (shop == null || string.IsNullOrWhiteSpace(shop.CategoryTitle))
                return false;

            return _shopDBServices.updateShop(shop);
        }

        public bool deleteShop(ShopList shop)
        {
            if (shop == null)
                return false;

            return _shopDBServices.deleteShop(shop);
        }      

        public IEnumerable<CategoryList> getAllCategoriesList()
        {
            return _shopDBServices.getAllCategories();
        }

        public CategoryList getCategoryById(int categoryId)
        {
            return _shopDBServices.getCategoryById(categoryId);
        }

        public bool createCategory(CategoryList category)
        {           
            if (category == null || string.IsNullOrWhiteSpace(category.CategoryTitle))
                return false;

            return _shopDBServices.createCategory(category);
        }

        public bool updateCategory(CategoryList category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.CategoryTitle))
                return false;

            return _shopDBServices.updateCategory(category);
        }

        public bool deleteCategory(CategoryList category)
        {
            if (category == null)
                return false;

            return _shopDBServices.deleteCategory(category);
        }
      
        public Info_ContactUs getContactInfoAndUrl()
        {
            return _shopDBServices.getContactAndUrlInfo();
        }

        public bool contactAndUrlUpdate(Info_ContactUs contactInfo)
        {
            if (contactInfo == null)
                return false;
            return _shopDBServices.contactAndUrlUpdate(contactInfo);
        }
    }
}