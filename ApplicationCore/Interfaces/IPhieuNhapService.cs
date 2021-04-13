using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IPhieuNhapService
    {
        IEnumerable<PhieuNhap> GetPhieuNhap();
        PhieuNhap getPhieuNhapByMa(int mapn);
        int addPhieuNhap(PhieuNhap phieuNhap);
        int updatePhieuNhap(PhieuNhap phieuNhap);
        int deletePhieuNhap(int mapn);
    }
}
