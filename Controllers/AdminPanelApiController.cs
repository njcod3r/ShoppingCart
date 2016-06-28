using MagicCard.Models.DataServices;
using MagicCard.Models.ViewModels;
using MagicCard.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Script.Serialization;


namespace MagicCard.Controllers
{
    public class AdminPanelApiController : ApiController
    {
        AdminPanelServices _AdminPanelServices = new AdminPanelServices();
        ShopDBServices _shopDBServices = new ShopDBServices();


        [HttpGet]
        public IHttpActionResult getAllShopList()
        {
            return Ok(_AdminPanelServices.getAllShopList());
        }

        [HttpGet]
        public IHttpActionResult getAllShopById(int shopId)
        {
            var Shop = _AdminPanelServices.getShopById(shopId);
            if (Shop == null)
            {
                return NotFound();
            }
            return Ok(Shop);
        }

        [HttpPost]
        public IHttpActionResult createShop(ShopList shop)
        {
            var isSuccess = _AdminPanelServices.createShop(shop);
            if (shop == null || !isSuccess)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpPost]
        public IHttpActionResult updateShop(ShopList shop)
        {
            var isSuccess = _AdminPanelServices.updateShop(shop);
            if (shop == null || !isSuccess)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpPost]
        public IHttpActionResult deleteShop(ShopList shop)
        {
            var isSuccess = _AdminPanelServices.deleteShop(shop);
            if (shop == null || !isSuccess)
            {
                return NotFound();
            }
            return Ok(shop);
        }

        [HttpGet]
        public IHttpActionResult getCategories()
        {
            return Ok(_AdminPanelServices.getAllCategoriesList().Where(x => x.IsActive == true).Select(x => new {x.CategoryId , x.CategoryTitle }));
        }

        [HttpGet]
        public IHttpActionResult getAllCategoriesList()
        {
            return Ok(_AdminPanelServices.getAllCategoriesList());
        }

        [HttpGet]
        public IHttpActionResult getAllCategoryById(int categoryId)
        {
            var category = _AdminPanelServices.getCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
       
        [HttpPost]
        public  IHttpActionResult createCategory(CategoryList category)
        {                  
            var isSuccess = _AdminPanelServices.createCategory(category);
            if (category == null || !isSuccess)
            {
                return NotFound();
            }
            return Ok(category);
        }
   
        [HttpPost]
        public IHttpActionResult updateCategory(CategoryList category)
        {
            var isSuccess = _AdminPanelServices.updateCategory(category);
            if (category == null || !isSuccess)
            {
                return NotFound();
            }
            return Ok(category);
        }
     
        [HttpPost]
        public IHttpActionResult deleteCategory(CategoryList category)
        {
            var isSuccess = _AdminPanelServices.deleteCategory(category);
            if (category == null || !isSuccess)
            {
                return NotFound();
            }
            return Ok(category);
        }


        //[HttpGet]
        //public IHttpActionResult UserAuthentication(string username, string password)
        //{
        //    Usr_Users user = new Usr_Users() ;
        //    if (userLoginValidation(username, password))
        //        user = _AdminPanelServices.getAuthentication(username, password);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
                 
        //    return Ok(user.UserId);
        //}

        [HttpGet]
        public IHttpActionResult getContactInfoAndUrl()
        {
            return Ok(_AdminPanelServices.getContactInfoAndUrl());
        }

        [HttpPost]
        public IHttpActionResult updateContactInfoAndUrl(Info_ContactUs contactInfo)
        {
            bool isSuccess = _AdminPanelServices.contactAndUrlUpdate(contactInfo);
            if (isSuccess) return Ok();
            else return NotFound();                      
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UploadFile(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var data = await Request.Content.ParseMultipartAsync();

            if (data.Files.ContainsKey("file"))
            {
                var file = data.Files["file"].File;
                var fileName = data.Files["file"].Filename;
                string targetFolder = HttpContext.Current.Server.MapPath("~/Images/CategoryImages");
                string targetPath = Path.Combine(targetFolder, fileName);
                MemoryStream ms = new MemoryStream(file);
                Image returnImage = Image.FromStream(ms);
                returnImage.Save(targetPath);
            }
          
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Thank you for uploading the file...")
            };
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UploadFileShop(HttpRequestMessage request)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var data = await Request.Content.ParseMultipartAsync();

            if (data.Files.ContainsKey("file"))
            {
                var file = data.Files["file"].File;
                var fileName = data.Files["file"].Filename;
                string targetFolder = HttpContext.Current.Server.MapPath("~/Images/ShopImages");
                string targetPath = Path.Combine(targetFolder, fileName);
                MemoryStream ms = new MemoryStream(file);
                Image returnImage = Image.FromStream(ms);
                returnImage.Save(targetPath);
            }

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("Thank you for uploading the file...")
            };
        }

        //private bool userLoginValidation(string username, string password)
        //{
        //    bool isValid = true;
        //    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        //        isValid = false;
        //    return isValid;
        //}
    }
}
