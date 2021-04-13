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
    public class SanPhamRepository : ISanPhamRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public SanPhamRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addSanPham(SanPham sanPham)
        {
            var roweffect = _dbConnection.Execute($"Insert into SanPham Values('{sanPham.masp}', N'{sanPham.tensp}'," +
                $" '{sanPham.gia}', N'{sanPham.hinh}', N'{sanPham.maloai}', N'{sanPham.mansx}', N'{sanPham.CPU}', N'{sanPham.RAM}', N'{sanPham.HDD}'," +
                $" N'{sanPham.VGA}', N'{sanPham.display}', N'{sanPham.wireless}', N'{sanPham.battery}', N'{sanPham.weight}'," +
                $" N'{sanPham.baohanh}', N'{sanPham.chitiet}', '{sanPham.active}')", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<SanPham> ClientAction(Filter ft)
        {
            var sanpham = _dbConnection.Query<SanPham>($"select * from SanPham where mansx like N'%{ft.mansx}%' and maloai like N'%{ft.maloai}%' and gia >= {ft.giaMin} and gia<={ft.giaMax}{ft.sort}", commandType: CommandType.Text);
            return sanpham;
        }

        public int deleteSanPham(string masp)
        {
            var roweffect = _dbConnection.Execute($"Delete from SanPham where masp = '{masp}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<SanPham> GetSanPham()
        {
            var sanPham = _dbConnection.Query<SanPham>($"Select * from SanPham", commandType: CommandType.Text);
            return sanPham;
        }

        public IEnumerable<SanPham> GetSanPhamByLoai(string maLoai)
        {
            var sps = _dbConnection.Query<SanPham>($"SELECT * FROM SanPham where maloai = N'{maLoai}'", commandType: CommandType.Text);
            return sps;
        }

        public SanPham getSanPhamByMa(string masp)
        {
            var sanPham = _dbConnection.Query<SanPham>($"Select * from SanPham where masp = '{masp}'", commandType: CommandType.Text).FirstOrDefault();
            return sanPham;
        }

        public IEnumerable<SanPham> GetSanPhamByNSX(string maNsx)
        {
            var sps = _dbConnection.Query<SanPham>($"SELECT * FROM SanPham where mansx = N'{maNsx}'", commandType: CommandType.Text);
            return sps;
        }

        public IEnumerable<SanPham> GetSanPhamByTen(string tensp)
        {
            var sanPham = _dbConnection.Query<SanPham>($"Select * from SanPham where tensp like '%{tensp}%'", commandType: CommandType.Text);
            return sanPham;
        }

        public IEnumerable<int> giaMax()
        {
            var giamax = _dbConnection.Query<int>($"SELECT MAX(gia) FROM SanPham", commandType: CommandType.Text);
            return giamax;
        }

        public IEnumerable<int> giaMin()
        {
            var giamin = _dbConnection.Query<int>($"SELECT MIN(gia) FROM SanPham", commandType: CommandType.Text);
            return giamin;
        }

        public int updateSanPham(SanPham sanPham)
        {
            var roweffect = _dbConnection.Execute($"Update SanPham SET tensp = N'{sanPham.tensp}'," +
                $" gia = '{sanPham.gia}', hinh = N'{sanPham.hinh}', maloai = '{sanPham.maloai}', mansx = '{sanPham.mansx}',CPU = N'{sanPham.CPU}', RAM = N'{sanPham.RAM}', HDD = N'{sanPham.HDD}'," +
                $" VGA = N'{sanPham.VGA}', display = N'{sanPham.display}', wireless = N'{sanPham.wireless}', battery = N'{sanPham.battery}', weight = N'{sanPham.weight}'," +
                $" baohanh = N'{sanPham.baohanh}', chitiet = N'{sanPham.chitiet}', active = '{sanPham.active}' where masp = N'{sanPham.masp}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
