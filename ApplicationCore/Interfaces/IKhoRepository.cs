using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IKhoRepository
    {
        IEnumerable<Kho> GetKho();
        Kho getKhoByMa(string masp);
        int addKho(Kho kho);
        int updateKho(Kho kho);
        int deleteKho(string masp);
    }
}
