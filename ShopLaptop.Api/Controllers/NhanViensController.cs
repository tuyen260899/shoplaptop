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
    public class NhanViensController : ControllerBase
    {
        INhanVienService _nhanVienService;
        public NhanViensController(INhanVienService nhanVienService)
        {
            _nhanVienService = nhanVienService;
        }
        [HttpGet]
        public IActionResult GetNhanVien()
        {
            var nhanViens = _nhanVienService.GetNhanVien();
            return Ok(nhanViens);
        }
        [HttpGet("{username}")]
        public IActionResult GetNhanVienByUser(string username)
        {
            var nhanVien = _nhanVienService.getNhanVienByUser(username);
            return Ok(nhanVien);
        }
        [HttpPost]
        public IActionResult Post([FromBody] NhanVien nhanVien)
        {
            var roweffect = _nhanVienService.addNhanVien(nhanVien);
            if (roweffect == 400)
                return Created("Thông báo", "Username nhân viên đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{username}")]
        public IActionResult Delete(string username)
        {
            var roweffect = _nhanVienService.deleteNhanVien(username);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] NhanVien nhanVien)
        {
            var roweffect = _nhanVienService.updateNhanVien(nhanVien);
            return Ok(roweffect);
        }
        [HttpGet("{user}/{pass}")]
        public IActionResult GetByUP(string user, string pass)
        {
            var nhanVien = _nhanVienService.GetNhanVienByUP(user, pass);
            return Ok(nhanVien);
        }
    }
}
