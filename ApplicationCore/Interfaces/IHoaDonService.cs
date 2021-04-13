using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IHoaDonService
    {
        IEnumerable<HoaDon> GetHoaDon();
        HoaDon getHoaDonByMa(int mahd);
        int addHoaDon(HoaDon hoaDon);
        int updateHoaDon(HoaDon hoaDon);
        int deleteHoaDon(int mahd);
        IEnumerable<HoaDon> GetHoaDonByUser(string username);
    }
}
