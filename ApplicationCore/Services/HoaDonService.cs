using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class HoaDonService : IHoaDonService
    {
        IHoaDonRepository _hoaDonRepository;
        public HoaDonService(IHoaDonRepository hoaDonRepository)
        {
            _hoaDonRepository = hoaDonRepository;
        }
        public int addHoaDon(HoaDon hoaDon)
        {
            var res = _hoaDonRepository.getHoaDonByMa(hoaDon.mahd);
            if (res != null)
            {
                return 400;
            }
            else
            {
                var roweffect = _hoaDonRepository.addHoaDon(hoaDon);
                return roweffect;
            }
        }

        public int deleteHoaDon(int mahd)
        {
            var roweffect = _hoaDonRepository.deleteHoaDon(mahd);
            return roweffect;
        }

        public IEnumerable<HoaDon> GetHoaDon()
        {
            var hodDon = _hoaDonRepository.GetHoaDon();
            return hodDon;
        }

        public HoaDon getHoaDonByMa(int mahd)
        {
            var hoaDonByMa = _hoaDonRepository.getHoaDonByMa(mahd);
            return hoaDonByMa;
        }

        public IEnumerable<HoaDon> GetHoaDonByUser(string username)
        {
            var hodDon = _hoaDonRepository.GetHoaDonByUser(username);
            return hodDon;
        }

        public int updateHoaDon(HoaDon hoaDon)
        {
            var roweffect = _hoaDonRepository.updateHoaDon(hoaDon);
            return roweffect;
        }
    }
}
