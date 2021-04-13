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
    public class LoaiSPRepository : ILoaiSPRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public LoaiSPRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addLoaiSP(LoaiSP loaiSP)
        {
            var roweffect = _dbConnection.Execute($"Insert into LoaiSP values('{loaiSP.maloai}', N'{loaiSP.tenloai}', '{loaiSP.active}')", commandType: CommandType.Text);
            return roweffect;
        }

        public int deleteLoaiSP(string maloai)
        {
            var roweffect = _dbConnection.Execute($"Delete from LoaiSP where maloai = '{maloai}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<LoaiSP> GetLoaiSP()
        {
            var loaiSP = _dbConnection.Query<LoaiSP>($"Select * from LoaiSP", commandType: CommandType.Text);
            return loaiSP;
        }

        public LoaiSP getLoaiSPbyMa(string maloai)
        {
            var loaiSpByMa = _dbConnection.Query<LoaiSP>($"Select * from LoaiSP where maloai = '{maloai}'", commandType: CommandType.Text).FirstOrDefault();
            return loaiSpByMa;
        }

        public int updateLoaiSP(LoaiSP loaiSP)
        {
            var roweffect = _dbConnection.Execute($"Update LoaiSP SET tenloai = N'{loaiSP.tenloai}'," +
                $" active = '{loaiSP.active}' where maloai = '{loaiSP.maloai}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
