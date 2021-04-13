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
    public class HoaDonRepository : IHoaDonRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public HoaDonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addHoaDon(HoaDon hoaDon)
        {
            var roweffect = _dbConnection.Execute($"Insert into HoaDon values(N'{hoaDon.mahd}', N'{hoaDon.username}', N'{hoaDon.ngaylap.ToString()}'," +
               $" N'{hoaDon.ngaythanhtoan.ToString()}', N'{hoaDon.trangthai}', N'{hoaDon.active}')", commandType: CommandType.Text);
            return roweffect;
        }

        public int deleteHoaDon(int mahd)
        {
            var roweffect = _dbConnection.Execute($"Delete from HoaDon where mahd = '{mahd}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<HoaDon> GetHoaDon()
        {
            var hoaDon = _dbConnection.Query<HoaDon>($"Select * from HoaDon", commandType: CommandType.Text);
            return hoaDon;
        }

        public HoaDon getHoaDonByMa(int mahd)
        {
            var hoaDonByMa = _dbConnection.Query<HoaDon>($"Select * from HoaDon where mahd = '{mahd}'", commandType: CommandType.Text).FirstOrDefault();
            return hoaDonByMa;
        }

        public IEnumerable<HoaDon> GetHoaDonByUser(string username)
        {
            var hoaDon = _dbConnection.Query<HoaDon>($"SELECT SanPham.masp, SanPham.tensp, SanPham.hinh, SanPham.gia, SanPham.CPU from HoaDon inner join ChitietHD on HoaDon.mahd = ChitietHD.mahd" +
                $" inner join SanPham on ChitietHD.masp = SanPham.masp where HoaDon.username = '{username}'" +
                $" GROUP BY SanPham.masp, SanPham.tensp, SanPham.hinh, SanPham.gia, SanPham.CPU", commandType: CommandType.Text);
            return hoaDon;
        }

        public int updateHoaDon(HoaDon hoaDon)
        {
            var roweffect = _dbConnection.Execute($"Update HoaDon SET username = N'{hoaDon.username}'," +
                $" ngaylap = N'{hoaDon.ngaylap.ToString()}', ngaythanhtoan = N'{hoaDon.ngaythanhtoan.ToString()}', trangthai = '{hoaDon.trangthai}'," +
                $" active = N'{hoaDon.active}' where mahd = N'{hoaDon.mahd}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
