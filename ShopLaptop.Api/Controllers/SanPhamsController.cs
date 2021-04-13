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
    public class SanPhamsController : ControllerBase
    {
        ISanPhamService _sanPhamService;
        public SanPhamsController(ISanPhamService sanPhamService)
        {
            _sanPhamService = sanPhamService;
        }
        [HttpGet]
        public IActionResult GetSanPham()
        {
            var sanPham = _sanPhamService.GetSanPham();
            return Ok(sanPham);
        }
        [HttpGet("{masp}")]
        public IActionResult GetSanPhamByMa(string masp)
        {
            var sanPham = _sanPhamService.getSanPhamByMa(masp);
            return Ok(sanPham);
        }
        [HttpGet("tensp")]
        public IActionResult GetSanPhamByTen(string tensp)
        {
            var sanPham = _sanPhamService.GetSanPhamByTen(tensp);
            return Ok(sanPham);
        }
        [HttpPost("Filter")]
        public IActionResult ClientAction([FromBody] Filter ft)
        {
            var sps = _sanPhamService.ClientAction(ft);
            return Ok(sps);
        }
        [HttpGet("GiaMin")]
        public IActionResult getMinGia()
        {
            var mingia = _sanPhamService.giaMin();
            return Ok(mingia);
        }
        [HttpGet("GiaMax")]
        public IActionResult getMaxGia()
        {
            var maxgia = _sanPhamService.giaMax();
            return Ok(maxgia);
        }
        [HttpPost]
        public IActionResult Post([FromBody] SanPham sanPham)
        {
            var roweffect = _sanPhamService.addSanPham(sanPham);
            if (roweffect == 400)
                return Created("Thông báo", "Mã sản phẩm đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{masp}")]
        public IActionResult Delete(string masp)
        {
            var roweffect = _sanPhamService.deleteSanPham(masp);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] SanPham sanPham)
        {
            var roweffect = _sanPhamService.updateSanPham(sanPham);
            return Ok(roweffect);
        }
    }
}
