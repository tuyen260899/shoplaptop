using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class NhanVienService : INhanVienService
    {
        INhanVienRepository _nhanVienRepository;
        public NhanVienService(INhanVienRepository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }
        public int addNhanVien(NhanVien nhanVien)
        {
            var res = _nhanVienRepository.getNhanVienByUser(nhanVien.username);
            if (res != null)
            {
                return 400;
            }
            else
            {
                var roweffect = _nhanVienRepository.addNhanVien(nhanVien);
                return roweffect;
            }
        }

        public int deleteNhanVien(string username)
        {
            var roweffect = _nhanVienRepository.deleteNhanVien(username);
            return roweffect;
        }

        public IEnumerable<NhanVien> GetNhanVien()
        {
            var nhanViens = _nhanVienRepository.GetNhanVien();
            return nhanViens;
        }

        public NhanVien GetNhanVienByUP(string user, string pass)
        {
            var nhanVien = _nhanVienRepository.GetNhanVienByUP(user, pass);
            return nhanVien;
        }

        public NhanVien getNhanVienByUser(string username)
        {
            var nhanVienByUser = _nhanVienRepository.getNhanVienByUser(username);
            return nhanVienByUser;
        }

        public int updateNhanVien(NhanVien nhanVien)
        {
            var roweffect = _nhanVienRepository.updateNhanVien(nhanVien);
            return roweffect;
        }
    }
}
