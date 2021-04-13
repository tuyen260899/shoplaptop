using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface INhaSXRepository
    {
        IEnumerable<NhaSX> GetNhaSX();
        NhaSX getNhaSXbyMa(string mansx);
        int addNhaSX(NhaSX nhaSX);
        int updateNhaSX(NhaSX nhaSX);
        int deleteNhaSX(string mansx);
    }
}
