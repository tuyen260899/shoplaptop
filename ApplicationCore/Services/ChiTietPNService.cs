using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class ChiTietPNService : IChiTietPNService
    {
        IChiTietPNRepository _chiTietPNRepository;
        public ChiTietPNService(IChiTietPNRepository chiTietPNRepository)
        {
            _chiTietPNRepository = chiTietPNRepository;
        }
        public int addChiTietPN(ChiTietPN chiTietPN)
        {
            var roweffect = _chiTietPNRepository.addChiTietPN(chiTietPN);
            return roweffect;
        }

        public IEnumerable<ChiTietPN> ClientGetNewProduct()
        {
            var newProducts = _chiTietPNRepository.ClientGetNewProduct();
            return newProducts;
        }

        public int deleteChiTietPN(int mapn)
        {
            var roweffect = _chiTietPNRepository.deleteChiTietPN(mapn);
            return roweffect;
        }

        public IEnumerable<ChiTietPN> GetChiTietPN()
        {
            var chiTietPN = _chiTietPNRepository.GetChiTietPN();
            return chiTietPN;
        }

        public ChiTietPN getCTPhieuNhapById(int mapn)
        {
            var ctHD = _chiTietPNRepository.getCTPhieuNhapById(mapn);
            return ctHD;
        }

        public int updateChiTietPN(ChiTietPN chiTietPN)
        {
            var roweffect = _chiTietPNRepository.updateChiTietPN(chiTietPN);
            return roweffect;
        }
    }
}
