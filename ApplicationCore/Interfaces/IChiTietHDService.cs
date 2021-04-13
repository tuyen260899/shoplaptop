using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IChiTietHDService
    {
        IEnumerable<ChiTietHD> GetChiTietHD();
        ChiTietHD getCTHoaDonByMa(int mahd);
        int addChiTietHD(ChiTietHD chiTietHD);
        int updateChiTietHD(ChiTietHD chiTietHD);
        int deleteChiTietHD(int mahd);
        IEnumerable<ChiTietHD> ClientGetDh(string username);
        int updateSoluongCTHD(ChiTietHD chiTietHD);
    }
}
