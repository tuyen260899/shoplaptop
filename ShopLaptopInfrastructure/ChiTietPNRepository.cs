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
    public class ChiTietPNRepository : IChiTietPNRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public ChiTietPNRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addChiTietPN(ChiTietPN chiTietPN)
        {
            var roweffect = _dbConnection.Execute($"Insert into ChitietPN values('{chiTietPN.masp}', '{chiTietPN.soluong}')", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<ChiTietPN> ClientGetNewProduct()
        {
            var chiTietPNs = _dbConnection.Query<ChiTietPN>($"Select SanPham.masp, SanPham.tensp, SanPham.hinh, SanPham.gia, SanPham.CPU from SanPham inner join ChitietPN on SanPham.masp = ChitietPN.masp " +
                $"inner join PhieuNhap on ChitietPN.mapn = PhieuNhap.mapn where (DATEDIFF(day, PhieuNhap.ngay, GETDATE())) < 10", commandType: CommandType.Text);
            return chiTietPNs;
        }

        public int deleteChiTietPN(int id)
        {
            var roweffect = _dbConnection.Execute($"Delete from ChitietHD where mapn = '{id}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<ChiTietPN> GetChiTietPN()
        {
            var chiTietPN = _dbConnection.Query<ChiTietPN>($"Select ChitietPN.mapn, ChitietPN.masp, SanPham.tensp, PhieuNhap.ngay, soluong from ChitietPN inner join SanPham on ChitietPN.masp = SanPham.masp" +
                $" inner join PhieuNhap on ChitietPN.mapn = PhieuNhap.mapn", commandType: CommandType.Text);
            return chiTietPN;
        }

        public ChiTietPN getCTPhieuNhapById(int id)
        {
            var chiTietPN = _dbConnection.Query<ChiTietPN>($"Select * from ChitietPN where mapn = '{id}'", commandType: CommandType.Text).FirstOrDefault();
            return chiTietPN;
        }

        public int updateChiTietPN(ChiTietPN chiTietPN)
        {
            var roweffect = _dbConnection.Execute($"Update ChiTietPN SET masp = '{chiTietPN.masp}', soluong = '{chiTietPN.soluong}' where mapn = '{chiTietPN.mapn}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
