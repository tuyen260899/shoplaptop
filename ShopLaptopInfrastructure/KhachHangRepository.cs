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
    public class KhachHangRepository : IKhachHangRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public KhachHangRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addKhachHang(KhachHang khachHang)
        {
            var roweffect = _dbConnection.Execute($"Insert into KhachHang values('{khachHang.username}', '{khachHang.password}', N'{khachHang.hoten}'," +
                $" N'{khachHang.gioitinh}', '{khachHang.namsinh.ToString()}', N'{khachHang.diachi}', N'{khachHang.sodienthoai}', '{khachHang.quyenhan}', '{khachHang.active}')", commandType: CommandType.Text);
            return roweffect;
        }

        public int deleteKhachHang(string username)
        {
            var roweffect = _dbConnection.Execute($"Delete from KhachHang where username = '{username}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<KhachHang> GetKhachHang()
        {
            var khachHang = _dbConnection.Query<KhachHang>($"Select * from KhachHang", commandType: CommandType.Text);
            return khachHang;
        }

        public KhachHang getKhachHangByUser(string username)
        {
            var khachHangbyUser = _dbConnection.Query<KhachHang>($"Select * from KhachHang where username = '{username}'", commandType: CommandType.Text).FirstOrDefault();
            return khachHangbyUser;
        }

        public KhachHang GetKhachHangByUP(string user, string pass)
        {
            var khachhang = _dbConnection.Query<KhachHang>($"SELECT * FROM KhachHang WHERE username=N'{user}' and password=N'{pass}'", commandType: CommandType.Text).FirstOrDefault();
            return khachhang;
        }

        public int updateKhachHang(KhachHang khachHang)
        {
            var roweffect = _dbConnection.Execute($"Update KhachHang SET password = '{khachHang.password}'," +
                $" hoten = N'{khachHang.hoten}', gioitinh = N'{khachHang.gioitinh}', namsinh = '{khachHang.namsinh.ToString()}'," +
                $" diachi = N'{khachHang.diachi}', sodienthoai = N'{khachHang.sodienthoai}', quyenhan = '{khachHang.quyenhan}'," +
                $" active = '{khachHang.active}' where username = '{khachHang.username}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
