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
    public class KhachHangsController : ControllerBase
    {
        IKhachHangService _khachHangService;
        public KhachHangsController(IKhachHangService khachHangService)
        {
            _khachHangService = khachHangService;
        }
        [HttpGet]
        public IActionResult GetKhachHang()
        {
            var khachHang = _khachHangService.GetKhachHang();
            return Ok(khachHang);
        }
        [HttpGet("{username}")]
        public IActionResult GetKhachHangByUser(string username)
        {
            var khachHang = _khachHangService.getKhachHangByUser(username);
            return Ok(khachHang);
        }
        [HttpPost]
        public IActionResult Post([FromBody] KhachHang khachHang)
        {
            var roweffect = _khachHangService.addKhachHang(khachHang);
            if (roweffect == 400)
                return Created("Thông báo", "Username khách hàng đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            var roweffect = _khachHangService.deleteKhachHang(username);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] KhachHang khachHang)
        {
            var roweffect = _khachHangService.updateKhachHang(khachHang);
            return Ok(roweffect);
        }
        [HttpGet("{user}/{pass}")]
        public IActionResult GetByUP(string user, string pass)
        {
            var khachhang = _khachHangService.GetKhachHangByUP(user, pass);
            return Ok(khachhang);
        }
    }
}
