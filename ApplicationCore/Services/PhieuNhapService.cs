using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class PhieuNhapService : IPhieuNhapService
    {
        IPhieuNhapRepository _phieuNhapRepository;
        public PhieuNhapService(IPhieuNhapRepository phieuNhapRepository)
        {
            _phieuNhapRepository = phieuNhapRepository;
        }
        public int addPhieuNhap(PhieuNhap phieuNhap)
        {
            var res = _phieuNhapRepository.getPhieuNhapByMa(phieuNhap.mapn);
            if (res != null)
            {
                return 400;
            }
            else
            {
                var roweffect = _phieuNhapRepository.addPhieuNhap(phieuNhap);
                return roweffect;
            }
        }

        public int deletePhieuNhap(int mapn)
        {
            var roweffect = _phieuNhapRepository.deletePhieuNhap(mapn);
            return roweffect;
        }

        public IEnumerable<PhieuNhap> GetPhieuNhap()
        {
            var phieuNhap = _phieuNhapRepository.GetPhieuNhap();
            return phieuNhap;
        }

        public PhieuNhap getPhieuNhapByMa(int mapn)
        {
            var phieuNhap = _phieuNhapRepository.getPhieuNhapByMa(mapn);
            return phieuNhap;
        }

        public int updatePhieuNhap(PhieuNhap phieuNhap)
        {
            var roweffect = _phieuNhapRepository.updatePhieuNhap(phieuNhap);
            return roweffect;
        }
    }
}
