using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MagicCard.Services;
using System.Web;
using System.IO;
using System.Drawing;


namespace MagicCard.Controllers
{
    
        [RoutePrefix("api")]
        public class FileUploadController : ApiController
        {
            [Route("upload")]
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
        }
    
}
