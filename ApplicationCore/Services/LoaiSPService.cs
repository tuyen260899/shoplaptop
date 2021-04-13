using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class LoaiSPService : ILoaiSPService
    {
        ILoaiSPRepository _loaiSPRepository;
        public LoaiSPService(ILoaiSPRepository loaiSPRepository)
        {
            _loaiSPRepository = loaiSPRepository;
        }
        public int addLoaiSP(LoaiSP loaiSP)
        {
            var res = _loaiSPRepository.getLoaiSPbyMa(loaiSP.maloai);
            if (res != null)
            {
                return 400;
            }
            else
            {
                var roweffect = _loaiSPRepository.addLoaiSP(loaiSP);
                return roweffect;
            }
        }

        public int deleteLoaiSP(string maloai)
        {
            var roweffect = _loaiSPRepository.deleteLoaiSP(maloai);
            return roweffect;
        }

        public IEnumerable<LoaiSP> GetLoaiSP()
        {
            var loaiSP = _loaiSPRepository.GetLoaiSP();
            return loaiSP;
        }

        public LoaiSP getLoaiSPbyMa(string maloai)
        {
            var loaiSp = _loaiSPRepository.getLoaiSPbyMa(maloai);
            return loaiSp;
        }
        public int updateLoaiSP(LoaiSP loaiSP)
        {
            var roweffect = _loaiSPRepository.updateLoaiSP(loaiSP);
            return roweffect;
        }
    }
}
