using ApplicationCore.Entities;
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
    public class ChiTietHDsController : ControllerBase
    {
        IChiTietHDService _chiTietHDService;
        public ChiTietHDsController(IChiTietHDService chiTietHDService)
        {
            _chiTietHDService = chiTietHDService;
        }
        [HttpGet]
        public IActionResult GetChiTietHD()
        {
            var chiTietHD = _chiTietHDService.GetChiTietHD();
            return Ok(chiTietHD);
        }
        [HttpGet("{mahd}")]
        public IActionResult GetCTHDbyMa(int mahd)
        {
            var ctHD = _chiTietHDService.getCTHoaDonByMa(mahd);
            return Ok(ctHD);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ChiTietHD ctHd)
        {
            var roweffect = _chiTietHDService.addChiTietHD(ctHd);
            //if (roweffect == 400)
            //    return Created("Thông báo", "Mã hóa đơn đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{mahd}")]
        public IActionResult Delete(int mahd)
        {
            var roweffect = _chiTietHDService.deleteChiTietHD(mahd);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] ChiTietHD chiTietHD)
        {
            var roweffect = _chiTietHDService.updateChiTietHD(chiTietHD);
            return Ok(roweffect);
        }
        [HttpPut("UpdateCart/{mahd}")]
        public IActionResult UpdateSoluong([FromBody] ChiTietHD chiTietHD)
        {
            var roweffect = _chiTietHDService.updateSoluongCTHD(chiTietHD);
            return Ok(roweffect);
        }

        [HttpGet("Cart/{username}")]
        public IActionResult getCart(string username)
        {
            var dathangs = _chiTietHDService.ClientGetDh(username);
            return Ok(dathangs);
        }
    }
}
