using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Northwind.Services.Interfaces;

namespace Northwind.Api.Controllers
{

    // Note that this is an MVC controller, not WebApi
    public class ImagesController : Controller
    {
        private readonly IImagesService _imagesService;

        public ImagesController(IImagesService imagesService)
        {
            _imagesService = imagesService;
        }

        public async Task<ActionResult> Categories(int id)
        {
            try
            {
                byte[] image = await _imagesService.Category(id);
                return Image(image);

            }
            catch (KeyNotFoundException)
            {
                return HttpNotFound();
            }
        }

        public async Task<ActionResult> Employees(int id)
        {
            try
            {
                byte[] image = await _imagesService.Employee(id);
                return Image(image);

            }
            catch (KeyNotFoundException)
            {
                return HttpNotFound();
            }
        }

        private ActionResult Image(byte[] image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // 78 is the size of the OLE header for Northwind images
                ms.Write(image, 78, image.Length - 78);
                return File(ms.ToArray(), "image/jpeg");
            }
        }
    }
}