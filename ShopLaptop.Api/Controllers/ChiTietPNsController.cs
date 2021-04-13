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
    public class ChiTietPNsController : ControllerBase
    {
        IChiTietPNService _chiTietPNService;
        public ChiTietPNsController(IChiTietPNService chiTietPNService)
        {
            _chiTietPNService = chiTietPNService;
        }
        [HttpGet]
        public IActionResult GetChiTietHD()
        {
            var chiTietPN = _chiTietPNService.GetChiTietPN();
            return Ok(chiTietPN);
        }
        [HttpGet("{mapn}")]
        public IActionResult GetCTPNbyMa(int mapn)
        {
            var ctPN = _chiTietPNService.getCTPhieuNhapById(mapn);
            return Ok(ctPN);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ChiTietPN ctPn)
        {
            var roweffect = _chiTietPNService.addChiTietPN(ctPn);
            //if (roweffect == 400)
            //    return Created("Thông báo", "Mã hóa đơn đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{mapn}")]
        public IActionResult Delete(int mapn)
        {
            var roweffect = _chiTietPNService.deleteChiTietPN(mapn);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] ChiTietPN chiTietPN)
        {
            var roweffect = _chiTietPNService.updateChiTietPN(chiTietPN);
            return Ok(roweffect);
        }
        [HttpGet("NewProducts")]
        public IActionResult getCart()
        {
            var newProducts = _chiTietPNService.ClientGetNewProduct();
            return Ok(newProducts);
        }

    }
}
