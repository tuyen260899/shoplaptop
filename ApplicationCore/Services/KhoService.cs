using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class KhoService : IKhoService
    {
        IKhoRepository _khoRepository;
        public KhoService(IKhoRepository khoRepository)
        {
            _khoRepository = khoRepository;
        }
        public int addKho(Kho kho)
        {
            throw new NotImplementedException();
        }

        public int deleteKho(string masp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kho> GetKho()
        {
            var kho = _khoRepository.GetKho();
            return kho;
        }

        public Kho getKhoByMa(string masp)
        {
            throw new NotImplementedException();
        }

        public int updateKho(Kho kho)
        {
            throw new NotImplementedException();
        }
    }
}
