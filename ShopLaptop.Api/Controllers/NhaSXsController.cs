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
    public class NhaSXsController : ControllerBase
    {
        INhaSXService _nhaSXService;
        public NhaSXsController(INhaSXService nhaSXService)
        {
            _nhaSXService = nhaSXService;
        }
        [HttpGet]
        public IActionResult GetNhaSX()
        {
            var nhaSXs = _nhaSXService.GetNhaSX();
            return Ok(nhaSXs);
        }
        [HttpGet("{mansx}")]
        public IActionResult GetNhaSXByMa(string mansx)
        {
            var nhaSX = _nhaSXService.getNhaSXbyMa(mansx);
            return Ok(nhaSX);
        }
        [HttpPost]
        public IActionResult Post([FromBody] NhaSX nhaSX)
        {
            var roweffect = _nhaSXService.addNhaSX(nhaSX);
            if (roweffect == 400)
                return Created("Thông báo", "Mã nhà sản xuất đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{mansx}")]
        public IActionResult Delete(string mansx)
        {
            var roweffect = _nhaSXService.deleteNhaSX(mansx);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] NhaSX nhaSX)
        {
            var roweffect = _nhaSXService.updateNhaSX(nhaSX);
            return Ok(roweffect);
        }
    }
}
