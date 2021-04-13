using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface ISanPhamRepository
    {
        IEnumerable<SanPham> GetSanPham();
        SanPham getSanPhamByMa(string masp);
        IEnumerable<SanPham> GetSanPhamByLoai(string maLoai);
        IEnumerable<SanPham> GetSanPhamByNSX(string maNsx);
        IEnumerable<SanPham> ClientAction(Filter ft);
        IEnumerable<int> giaMin();
        IEnumerable<int> giaMax();
        int addSanPham(SanPham sanPham);
        int updateSanPham(SanPham sanPham);
        int deleteSanPham(string masp);
        IEnumerable<SanPham> GetSanPhamByTen(string tensp);
    }
}
