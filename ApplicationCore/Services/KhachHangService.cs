using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class KhachHangService : IKhachHangService
    {
        IKhachHangRepository _khachHangRepository;
        public KhachHangService(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }
        public int addKhachHang(KhachHang khachHang)
        {
            var res = _khachHangRepository.getKhachHangByUser(khachHang.username);
            if (res != null)
            {
                return 400;
            }
            else
            {
                var roweffect = _khachHangRepository.addKhachHang(khachHang);
                return roweffect;
            }
        }

        public int deleteKhachHang(string username)
        {
            var roweffect = _khachHangRepository.deleteKhachHang(username);
            return roweffect;
        }

        public IEnumerable<KhachHang> GetKhachHang()
        {
            var khachHang = _khachHangRepository.GetKhachHang();
            return khachHang;
        }

        public KhachHang getKhachHangByUser(string username)
        {
            var khachHangByUser = _khachHangRepository.getKhachHangByUser(username);
            return khachHangByUser;
        }

        public KhachHang GetKhachHangByUP(string user, string pass)
        {
            var khachhang = _khachHangRepository.GetKhachHangByUP(user, pass);
            return khachhang;
        }

        public int updateKhachHang(KhachHang khachHang)
        {
            var roweffect = _khachHangRepository.updateKhachHang(khachHang);
            return roweffect;
        }
    }
}
