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
    public class PhieuNhapsController : ControllerBase
    {
        IPhieuNhapService _phieuNhapService;
        public PhieuNhapsController(IPhieuNhapService phieuNhapService)
        {
            _phieuNhapService = phieuNhapService;
        }
        [HttpGet]
        public IActionResult GetPhieuNhap()
        {
            var phieuNhap = _phieuNhapService.GetPhieuNhap();
            return Ok(phieuNhap);
        }
        [HttpGet("{mapn}")]
        public IActionResult GetPhieuNhapByMa(int mapn)
        {
            var phieuNhap = _phieuNhapService.getPhieuNhapByMa(mapn);
            return Ok(phieuNhap);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PhieuNhap phieuNhap)
        {
            var roweffect = _phieuNhapService.addPhieuNhap(phieuNhap);
            if (roweffect == 400)
                return Created("Thông báo", "Mã phiếu nhập đã tồn tại");
            return Ok(roweffect);
        }
        [HttpDelete("{mapn}")]
        public IActionResult Delete(int mapn)
        {
            var roweffect = _phieuNhapService.deletePhieuNhap(mapn);
            return Ok(roweffect);
        }
        [HttpPut]
        public IActionResult Put([FromBody] PhieuNhap phieuNhap)
        {
            var roweffect = _phieuNhapService.updatePhieuNhap(phieuNhap);
            return Ok(roweffect);
        }
    }
}
