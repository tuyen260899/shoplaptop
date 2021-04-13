using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface INhanVienService
    {
        IEnumerable<NhanVien> GetNhanVien();
        NhanVien getNhanVienByUser(string username);
        int addNhanVien(NhanVien nhanVien);
        int updateNhanVien(NhanVien nhanVien);
        int deleteNhanVien(string username);
        NhanVien GetNhanVienByUP(string user, string pass);
    }
}
