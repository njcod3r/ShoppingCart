using MagicCard.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicCard.Models.DataServices
{

    public class ShopDBServices
    {
        private readonly MagicCardModel db;

        public ShopDBServices()
        {
            db = new MagicCardModel();
        }

        public IEnumerable<ShopList> getAllShops()
        {

            IEnumerable<ShopList> shopsList = (from shp in db.Shp_Shop
                                               join cat in db.Lup_Category on shp.CategoryId equals cat.CategoryId
                                               join catT in db.Lup_CategoryTranslation on cat.CategoryId equals catT.CategoryId
                                               join shpT in db.Shp_ShopTranslation on shp.ShopId equals shpT.ShopId
                                               join shpDiscount in db.Shp_CardDiscount on shp.ShopId equals shpDiscount.ShopId
                                               where shpT.LanguageId == 1 && catT.LanguageId == 1 && shpDiscount.IsCurrent == true
                                               select new ShopList
                                                {
                                                    ShopId = shp.ShopId,
                                                    CategoryId = shp.CategoryId,
                                                    IsActive = shp.IsActive,
                                                    CardDiscountId = shpDiscount.CardDiscountId,
                                                    ShopImage = shp.ShopImage,
                                                    ShopImage1 = shp.ShopImage1,
                                                    ShopImage2 = shp.ShopImage2,
                                                    ShopImage3 = shp.ShopImage3,
                                                    CategoryTitle = catT.CategoryTitle,
                                                    ShopTitle = shpT.ShopTitle,
                                                    ShopAddress = shpT.ShopAddress,
                                                    ShopDescription = shpT.ShopDescription,
                                                    CardDiscountPercentage = shpDiscount.CardDiscountPercentage
                                                });

            return shopsList;
        }

        public ShopList getShopById(int shopId)
        {

            var shop = (from shp in db.Shp_Shop
                        join cat in db.Lup_Category on shp.CategoryId equals cat.CategoryId
                        join catT in db.Lup_CategoryTranslation on cat.CategoryId equals catT.CategoryId
                        join shpT in db.Shp_ShopTranslation on shp.ShopId equals shpT.ShopId
                        join shpDiscount in db.Shp_CardDiscount on shp.ShopId equals shpDiscount.ShopId
                        where shpT.LanguageId == 1 && catT.LanguageId == 1 && shpDiscount.IsCurrent == true && shp.ShopId == shopId
                        select new ShopList
                        {
                            ShopId = shp.ShopId,
                            CategoryId = shp.CategoryId,
                            IsActive = shp.IsActive,
                            CardDiscountId = shpDiscount.CardDiscountId,
                            ShopImage = shp.ShopImage,
                            ShopImage1 = shp.ShopImage1,
                            ShopImage2 = shp.ShopImage2,
                            ShopImage3 = shp.ShopImage3,
                            CategoryTitle = catT.CategoryTitle,
                            ShopTitle = shpT.ShopTitle,
                            ShopAddress = shpT.ShopAddress,
                            ShopDescription = shpT.ShopDescription,
                            CardDiscountPercentage = shpDiscount.CardDiscountPercentage
                        }).FirstOrDefault();
            return shop;
        }

        public bool createShop(ShopList shop)
        {
            var shp = new Shp_Shop();
            shp.ShopImage = shop.ShopImage;
            shp.ShopImage1 = shop.ShopImage1;
            shp.ShopImage2 = shop.ShopImage2;
            shp.ShopImage3 = shop.ShopImage3;
            shp.CategoryId = shop.CategoryId;
            shp.RCDate = DateTime.Now.Date;
            shp.IsActive = true;

            var shpT = new Shp_ShopTranslation();
            shpT.ShopTitle = shop.ShopTitle;
            shpT.ShopDescription = shop.ShopDescription;
            shpT.ShopAddress = shop.ShopAddress;
            shpT.LanguageId = 1;
            shpT.RCDate = DateTime.Now.Date;

            var shpD = new Shp_CardDiscount();
            shpD.CardDiscountPercentage = shop.CardDiscountPercentage;
            shpD.IsCurrent = true;
            shpD.RCDate = DateTime.Now.Date;
            shpD.StartDate = DateTime.Now.Date;
            shp.Shp_ShopTranslation.Add(shpT);
            shp.Shp_CardDiscount.Add(shpD);
            db.Shp_Shop.Add(shp);

            bool isSuccess = (db.SaveChanges() > 0 ? true : false);
            return isSuccess;
        }

        public bool updateShop(ShopList shop)
        {
            Shp_Shop shp = db.Shp_Shop.Select(x => x)
                .Where(x => x.ShopId == shop.ShopId)
                .FirstOrDefault();
            shp.ShopImage = shop.ShopImage;
            shp.ShopImage1 = shop.ShopImage1;
            shp.ShopImage2 = shop.ShopImage2;
            shp.ShopImage3 = shop.ShopImage3;
            shp.CategoryId = shop.CategoryId;
            shp.LADate = DateTime.Now.Date;

            var shpT = shp.Shp_ShopTranslation.Select(x => x).FirstOrDefault();
            shpT.ShopTitle = shop.ShopTitle;
            shpT.ShopDescription = shop.ShopDescription;
            shpT.ShopAddress = shop.ShopAddress;
            shpT.LADate = DateTime.Now.Date;

            var shpDSelect = shp.Shp_CardDiscount.Where(x => x.IsCurrent == true).Select(x => x).FirstOrDefault();
            if (shpDSelect.CardDiscountPercentage != shop.CardDiscountPercentage)
            {
                shpDSelect.IsCurrent = false;
                shpDSelect.LADate = DateTime.Now.Date;
                shpDSelect.EndDate = DateTime.Now.Date;

                var shpD = new Shp_CardDiscount();
                shpD.CardDiscountPercentage = shop.CardDiscountPercentage;
                shpD.IsCurrent = true;
                shpD.RCDate = DateTime.Now.Date;
                shpD.StartDate = DateTime.Now.Date;
                shpD.ShopId = shop.ShopId;
                db.Shp_CardDiscount.Add(shpD);
            }



            bool isSuccess = (db.SaveChanges() > 0 ? true : false);
            return isSuccess;

        }

        public bool deleteShop(ShopList shop)
        {
            Shp_Shop shp = db.Shp_Shop.Select(x => x)
                .Where(x => x.ShopId == shop.ShopId)
                .FirstOrDefault();
            shp.IsActive = !shp.IsActive;
            shp.LADate = DateTime.Now;
            bool isSuccess = (db.SaveChanges() > 0 ? true : false);
            return isSuccess;
        }



        public Info_ContactUs getContactAndUrlInfo()
        {
            var info = db.Info_ContactUs.Select(i => i).FirstOrDefault();
            return info;
        }

        public bool contactAndUrlUpdate(Info_ContactUs contactInfo)
        {                     
            var info = db.Info_ContactUs.Select(i => i).FirstOrDefault();
            info.ContactAddress = contactInfo.ContactAddress;
            info.ContactPhone = contactInfo.ContactPhone;
            info.ContactEmail = contactInfo.ContactEmail;
            info.AdUrl = contactInfo.AdUrl;

            bool isSuccess = (db.SaveChanges() > 0 ? true : false);
            return isSuccess;
        }

        public IEnumerable<CategoryList> getAllCategories()
        {
            IEnumerable<CategoryList> categoriesList =
                (from cat in db.Lup_Category
                 join catT in db.Lup_CategoryTranslation on cat.CategoryId equals catT.CategoryId
                 where catT.LanguageId == 1
                 select new CategoryList
                 {
                     CategoryId = cat.CategoryId,
                     CategoryImage = cat.CategoryImage,
                     IsActive = cat.IsActive,
                     CategoryTitle = catT.CategoryTitle,

                 });
            return categoriesList;
        }

        public CategoryList getCategoryById(int categoryId)
        {
            var category =
                (from cat in db.Lup_Category
                 join catT in db.Lup_CategoryTranslation on cat.CategoryId equals catT.CategoryId
                 where catT.LanguageId == 1 && cat.CategoryId == categoryId
                 select new CategoryList
                 {
                     CategoryId = cat.CategoryId,
                     CategoryImage = cat.CategoryImage,
                     IsActive = cat.IsActive,
                     CategoryTitle = catT.CategoryTitle,
                     LanguageId = catT.LanguageId

                 }).FirstOrDefault();
            return category;
        }

        public bool createCategory(CategoryList category)
        {
            var cat = new Lup_Category();
            cat.CategoryImage = category.CategoryImage;
            cat.IsActive = true;
            cat.RCDate = DateTime.Now;

            var catT = new Lup_CategoryTranslation();
            catT.CategoryTitle = category.CategoryTitle;
            catT.LanguageId = 1;
            catT.RCDate = DateTime.Now;
            cat.Lup_CategoryTranslation.Add(catT);
            db.Lup_Category.Add(cat);
            bool isSuccess = (db.SaveChanges() > 0 ? true : false);
            return isSuccess;
        }

        public bool updateCategory(CategoryList category)
        {

            Lup_Category cat = db.Lup_Category.Select(x => x)
                .Where(x => x.CategoryId == category.CategoryId)
                .FirstOrDefault();
            cat.CategoryImage = category.CategoryImage;
            cat.LADate = DateTime.Now;
            var catT = cat.Lup_CategoryTranslation.Select(x => x).FirstOrDefault();
            catT.CategoryTitle = category.CategoryTitle;
            catT.LADate = DateTime.Now;
            //catT.LanguageId = category.LanguageId;

            bool isSuccess = (db.SaveChanges() > 0 ? true : false);
            return isSuccess;

        }

        public bool deleteCategory(CategoryList category)
        {
            Lup_Category cat = db.Lup_Category.Select(x => x)
                .Where(x => x.CategoryId == category.CategoryId)
                .FirstOrDefault();
            cat.IsActive = !cat.IsActive;
            cat.LADate = DateTime.Now;
            bool isSuccess = (db.SaveChanges() > 0 ? true : false);
            return isSuccess;

        }

    }
}