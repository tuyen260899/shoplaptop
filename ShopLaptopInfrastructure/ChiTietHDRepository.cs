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
    public class ChiTietHDRepository : IChiTietHDRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public ChiTietHDRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addChiTietHD(ChiTietHD chiTietHD)
        {
            var roweffect = _dbConnection.Execute($"Insert into ChitietHD values('{chiTietHD.masp}', '{chiTietHD.username}', {chiTietHD.soluong}, {chiTietHD.gia}, {chiTietHD.thanhtien})", commandType: CommandType.Text);
            return roweffect;
        }

        public int deleteChiTietHD(int mahd)
        {
            var roweffect = _dbConnection.Execute($"Delete from ChitietHD where mahd = '{mahd}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<ChiTietHD> GetChiTietHD()
        {
            var chiTietHD = _dbConnection.Query<ChiTietHD>($"Select * from ChitietHD", commandType: CommandType.Text);
            return chiTietHD;
        }

        public ChiTietHD getCTHoaDonByMa(int mahd)
        {
            var chiTietHDbyId = _dbConnection.Query<ChiTietHD>($"Select * from ChitietHD where mahd = '{mahd}'", commandType: CommandType.Text).FirstOrDefault();
            return chiTietHDbyId;
        }

        public IEnumerable<ChiTietHD> ClientGetDh(string username)
        {
            var dathangs = _dbConnection.Query<ChiTietHD>($" SELECT ChitietHD.mahd, SanPham.tensp, SanPham.hinh, ChitietHD.soluong, ChitietHD.gia, ChitietHD.soluong*ChitietHD.gia as thanhtien" +
                $" FROM ChitietHD inner join SanPham on ChitietHD.masp = SanPham.masp WHERE ChitietHD.username = '{username}'" +
                $" GROUP BY ChitietHD.mahd, SanPham.tensp, SanPham.hinh, ChitietHD.soluong, ChitietHD.gia, ChitietHD.soluong * ChitietHD.gia", commandType: CommandType.Text);
            return dathangs;
        }

        public int updateChiTietHD(ChiTietHD chiTietHD)
        {
            var roweffect = _dbConnection.Execute($"Update ChiTietHD SET masp = '{chiTietHD.masp}', username = '{chiTietHD.username}' , soluong = '{chiTietHD.soluong}', gia = '{chiTietHD.gia}', thanhtien = '{chiTietHD.thanhtien}' where mahd = '{chiTietHD.mahd}'", commandType: CommandType.Text);
            return roweffect;
        }

        public int updateSoluongCTHD(ChiTietHD chiTietHD)
        {
            var roweffect = _dbConnection.Execute($"Update ChiTietHD SET soluong = '{chiTietHD.soluong}', gia = '{chiTietHD.gia}', thanhtien = '{chiTietHD.thanhtien}' where mahd = '{chiTietHD.mahd}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
