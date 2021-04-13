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
    public class NhanVienRepository : INhanVienRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public NhanVienRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addNhanVien(NhanVien nhanVien)
        {
            var roweffect = _dbConnection.Execute($"Insert into NhanVien values('{nhanVien.username}', '{nhanVien.password}', N'{nhanVien.hoten}'," +
                $" N'{nhanVien.gioitinh}', '{nhanVien.namsinh.ToString()}', N'{nhanVien.diachi}', N'{nhanVien.sodienthoai}', '{nhanVien.active}')", commandType: CommandType.Text);
            return roweffect;
        }
        public int deleteNhanVien(string username)
        {
            var roweffect = _dbConnection.Execute($"Delete from NhanVien where username = '{username}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<NhanVien> GetNhanVien()
        {
            var nhanViens = _dbConnection.Query<NhanVien>($"Select * from NhanVien", commandType: CommandType.Text);
            return nhanViens;
        }

        public NhanVien GetNhanVienByUP(string user, string pass)
        {
            var nhanVien = _dbConnection.Query<NhanVien>($"SELECT * FROM NhanVien WHERE username=N'{user}' and password=N'{pass}'", commandType: CommandType.Text).FirstOrDefault();
            return nhanVien;
        }

        public NhanVien getNhanVienByUser(string username)
        {
            var nhanVienbyUser = _dbConnection.Query<NhanVien>($"Select * from NhanVien where username = '{username}'", commandType: CommandType.Text).FirstOrDefault();
            return nhanVienbyUser;
        }

        public int updateNhanVien(NhanVien nhanVien)
        {
            var roweffect = _dbConnection.Execute($"Update NhanVien SET password = '{nhanVien.password}'," +
                $" hoten = N'{nhanVien.hoten}', gioitinh = N'{nhanVien.gioitinh}', namsinh = '{nhanVien.namsinh.ToString()}'," +
                $" diachi = N'{nhanVien.diachi}', sodienthoai = N'{nhanVien.sodienthoai}'," +
                $" active = '{nhanVien.active}' where username = '{nhanVien.username}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
