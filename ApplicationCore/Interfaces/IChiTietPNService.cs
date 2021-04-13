using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IChiTietPNService
    {
        IEnumerable<ChiTietPN> GetChiTietPN();
        ChiTietPN getCTPhieuNhapById(int mapn);
        int addChiTietPN(ChiTietPN chiTietPN);
        int updateChiTietPN(ChiTietPN chiTietPN);
        int deleteChiTietPN(int mapn);
        IEnumerable<ChiTietPN> ClientGetNewProduct();
    }
}
