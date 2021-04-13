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
    public class HoaDonsController : ControllerBase
    {
        IHoaDonService _hoaDonService;
        public HoaDonsController(IHoaDonService hoaDonService)
        {
            _hoaDonService = hoaDonService;
        }
        [HttpGet]
        public IActionResult GetHoaDon()
        {
            var hoaDon = _hoaDonService.GetHoaDon();
            return Ok(hoaDon);
        }
        [HttpGet("{mahd}")]
        public IActionResult GetHoaDonByMa(int mahd)
        {
            var hoaDon = _hoaDonService.getHoaDonByMa(mahd);
            return Ok(hoaDon);
        }
        [HttpGet("Product/{username}")]
        public IActionResult GetHoaDonByUser(string username)
        {
            var hoaDon = _hoaDonService.GetHoaDonByUser(username);
            return Ok(hoaDon);
        }
        [HttpPost]
        public IActionResult Post([FromBody] HoaDon hoaDon)
        {
            var roweffect = _hoaDonService.addHoaDon(hoaDon);
            if (roweffect == 400)
                return Created("Thông báo", "Mã hóa đơn đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{mahd}")]
        public IActionResult Delete(int mahd)
        {
            var roweffect = _hoaDonService.deleteHoaDon(mahd);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] HoaDon hoaDon)
        {
            var roweffect = _hoaDonService.updateHoaDon(hoaDon);
            return Ok(roweffect);
        }
    }
}
