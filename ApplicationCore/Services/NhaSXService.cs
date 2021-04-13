using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class NhaSXService : INhaSXService
    {
        INhaSXRepository _nhaSXRepository;
        public NhaSXService(INhaSXRepository nhaSXRepository)
        {
            _nhaSXRepository = nhaSXRepository;
        }
        public int addNhaSX(NhaSX nhaSX)
        {
            var res = _nhaSXRepository.getNhaSXbyMa(nhaSX.mansx);
            if (res != null)
            {
                return 400;
            }
            else
            {
                var roweffect = _nhaSXRepository.addNhaSX(nhaSX);
                return roweffect;
            }
        }

        public int deleteNhaSX(string mansx)
        {
            var roweffect = _nhaSXRepository.deleteNhaSX(mansx);
            return roweffect;
        }

        public IEnumerable<NhaSX> GetNhaSX()
        {
            var nhaSXs = _nhaSXRepository.GetNhaSX();
            return nhaSXs;
        }

        public NhaSX getNhaSXbyMa(string mansx)
        {
            var nhaSX = _nhaSXRepository.getNhaSXbyMa(mansx);
            return nhaSX;
        }

        public int updateNhaSX(NhaSX nhaSX)
        {
            var roweffect = _nhaSXRepository.updateNhaSX(nhaSX);
            return roweffect;
        }
    }
}
