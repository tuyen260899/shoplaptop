using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface ILoaiSPService
    {
        IEnumerable<LoaiSP> GetLoaiSP();
        LoaiSP getLoaiSPbyMa(string maloai);
        int addLoaiSP(LoaiSP loaiSP);
        int updateLoaiSP(LoaiSP loaiSP);
        int deleteLoaiSP(string maloai);
    }
}
