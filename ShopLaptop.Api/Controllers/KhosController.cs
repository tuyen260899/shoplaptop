using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopLaptop.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class KhosController : ControllerBase
    {
        IKhoService _khoService;
        public KhosController(IKhoService khoService)
        {
            _khoService = khoService;
        }
        [HttpGet]
        public IActionResult GetKho()
        {
            var kho = _khoService.GetKho();
            return Ok(kho);
        }
    }
}
