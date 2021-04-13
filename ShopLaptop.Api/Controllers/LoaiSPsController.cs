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
    public class LoaiSPsController : ControllerBase
    {
        ILoaiSPService _loaiSPService;
        public LoaiSPsController(ILoaiSPService loaiSPService)
        {
            _loaiSPService = loaiSPService;
        }
        [HttpGet]
        public IActionResult GetLoaiSP()
        {
            var loaiSP = _loaiSPService.GetLoaiSP();
            return Ok(loaiSP);
        }
        [HttpGet("{maloai}")]
        public IActionResult GetLoaiSpByMa(string maloai)
        {
            var loaiSp = _loaiSPService.getLoaiSPbyMa(maloai);
            return Ok(loaiSp);
        }
        [HttpPost]
        public IActionResult Post([FromBody] LoaiSP loaiSp)
        {
            var roweffect = _loaiSPService.addLoaiSP(loaiSp);
            if (roweffect == 400)
                return Created("Thông báo", "Mã loại sản phẩm đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{maloai}")]
        public IActionResult Delete(string maloai)
        {
            var roweffect = _loaiSPService.deleteLoaiSP(maloai);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] LoaiSP loaiSp)
        {
            var roweffect = _loaiSPService.updateLoaiSP(loaiSp);
            return Ok(roweffect);
        }
    }

}
