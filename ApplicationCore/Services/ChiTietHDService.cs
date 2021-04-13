using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class ChiTietHDService : IChiTietHDService
    {
        IChiTietHDRepository _chiTietHDRepository;
        public ChiTietHDService(IChiTietHDRepository chiTietHDRepository)
        {
            _chiTietHDRepository = chiTietHDRepository;
        }
        public int addChiTietHD(ChiTietHD chiTietHD)
        {
            var roweffect = _chiTietHDRepository.addChiTietHD(chiTietHD);
            return roweffect;
        }

        public int deleteChiTietHD(int mahd)
        {
            var roweffect = _chiTietHDRepository.deleteChiTietHD(mahd);
            return roweffect;
        }

        public IEnumerable<ChiTietHD> GetChiTietHD()
        {
            var chiTietHD = _chiTietHDRepository.GetChiTietHD();
            return chiTietHD;
        }

        public ChiTietHD getCTHoaDonByMa(int mahd)
        {
            var ctHD = _chiTietHDRepository.getCTHoaDonByMa(mahd);
            return ctHD;
        }

        public IEnumerable<ChiTietHD> ClientGetDh(string username)
        {
            var dathangs = _chiTietHDRepository.ClientGetDh(username);
            return dathangs;
        }

        public int updateChiTietHD(ChiTietHD chiTietHD)
        {
            var roweffect = _chiTietHDRepository.updateChiTietHD(chiTietHD);
            return roweffect;
        }

        public int updateSoluongCTHD(ChiTietHD chiTietHD)
        {
            var roweffect = _chiTietHDRepository.updateSoluongCTHD(chiTietHD);
            return roweffect;
        }
    }
}
