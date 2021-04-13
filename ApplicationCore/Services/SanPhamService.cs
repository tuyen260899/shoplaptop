using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class SanPhamService : ISanPhamService
    {
        ISanPhamRepository _sanPhamRepository;
        public SanPhamService(ISanPhamRepository sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
        }
        public int addSanPham(SanPham sanPham)
        {
            var res = _sanPhamRepository.getSanPhamByMa(sanPham.masp);
            if (res != null)
            {
                return 400;
            }
            else
            {
                var roweffect = _sanPhamRepository.addSanPham(sanPham);
                return roweffect;
            }
        }

        public IEnumerable<SanPham> ClientAction(Filter ft)
        {
            var sanphams = _sanPhamRepository.ClientAction(ft);
            return sanphams;
        }

        public int deleteSanPham(string masp)
        {
            var roweffect = _sanPhamRepository.deleteSanPham(masp);
            return roweffect;
        }

        public IEnumerable<SanPham> GetSanPham()
        {
            var sanPham = _sanPhamRepository.GetSanPham();
            return sanPham;
        }

        public IEnumerable<SanPham> GetSanPhamByLoai(string maLoai)
        {
            var sanphams = _sanPhamRepository.GetSanPhamByLoai(maLoai);
            return sanphams;
        }

        public SanPham getSanPhamByMa(string masp)
        {
            var sanPham = _sanPhamRepository.getSanPhamByMa(masp);
            return sanPham;
        }

        public IEnumerable<SanPham> GetSanPhamByNSX(string maNsx)
        {
            var sanphams = _sanPhamRepository.GetSanPhamByNSX(maNsx);
            return sanphams;
        }

        public IEnumerable<SanPham> GetSanPhamByTen(string tensp)
        {
            var sanPham = _sanPhamRepository.GetSanPhamByTen(tensp);
            return sanPham;
        }

        public IEnumerable<int> giaMax()
        {
            var giamax = _sanPhamRepository.giaMax();
            return giamax;
        }

        public IEnumerable<int> giaMin()
        {
            var giamin = _sanPhamRepository.giaMin();
            return giamin;
        }

        public int updateSanPham(SanPham sanPham)
        {
            var roweffect = _sanPhamRepository.updateSanPham(sanPham);
            return roweffect;
        }
    }
}
