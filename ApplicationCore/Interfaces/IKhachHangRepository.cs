using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IKhachHangRepository
    {
        IEnumerable<KhachHang> GetKhachHang();
        KhachHang getKhachHangByUser(string username);
        int addKhachHang(KhachHang khachHang);
        int updateKhachHang(KhachHang khachHang);
        int deleteKhachHang(string username);
        KhachHang GetKhachHangByUP(string user, string pass);
    }
}
