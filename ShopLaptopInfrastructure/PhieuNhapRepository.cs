using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ShopLaptopInfrastructure
{
    public class PhieuNhapRepository : IPhieuNhapRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public PhieuNhapRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addPhieuNhap(PhieuNhap phieuNhap)
        {
            var roweffect = _dbConnection.Execute($"Insert into PhieuNhap values('{phieuNhap.mapn}', '{phieuNhap.ngay}', '{phieuNhap.active}')", commandType: CommandType.Text);
            return roweffect;
        }

        public int deletePhieuNhap(int mapn)
        {
            var roweffect = _dbConnection.Execute($"Delete from PhieuNhap where mapn = '{mapn}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<PhieuNhap> GetPhieuNhap()
        {
            var phieuNhap = _dbConnection.Query<PhieuNhap>($"Select * from PhieuNhap", commandType: CommandType.Text);
            return phieuNhap;
        }

        public PhieuNhap getPhieuNhapByMa(int mapn)
        {
            var phieuNhap = _dbConnection.Query<PhieuNhap>($"Select * from PhieuNhap where mapn = '{mapn}'", commandType: CommandType.Text).FirstOrDefault();
            return phieuNhap;
        }

        public int updatePhieuNhap(PhieuNhap phieuNhap)
        {
            var roweffect = _dbConnection.Execute($"Update PhieuNhap SET ngay = '{phieuNhap.ngay}', active = '{phieuNhap.active}' where mapn = '{phieuNhap.mapn}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
