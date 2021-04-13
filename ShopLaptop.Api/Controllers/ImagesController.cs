using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptop.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        public IActionResult PostImg(IFormFile fileImg)
        {
            if (fileImg != null)
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "themes/images/cloth", fileImg.FileName);
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    fileImg.CopyTo(file);
                }
            }
            return Ok();
        }
    }
}
