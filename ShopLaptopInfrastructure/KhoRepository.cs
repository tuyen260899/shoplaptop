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
    public class KhoRepository : IKhoRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public KhoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addKho(Kho kho)
        {
            var roweffect = _dbConnection.Execute($"Insert into Kho values('{kho.masp}', '{kho.ngay}', '{kho.soluong}')", commandType: CommandType.Text);
            return roweffect;
        }

        public int deleteKho(string masp)
        {
            var roweffect = _dbConnection.Execute($"Delete from Kho where masp = '{masp}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<Kho> GetKho()
        {
            var kho = _dbConnection.Query<Kho>($"Select Kho.masp, SanPham.tensp, Kho.ngay, Kho.soluong from Kho inner join SanPham on Kho.masp = SanPham.masp", commandType: CommandType.Text);
            return kho;
        }

        public Kho getKhoByMa(string masp)
        {
            var kho = _dbConnection.Query<Kho>($"Select * from Kho where masp = '{masp}'", commandType: CommandType.Text).FirstOrDefault();
            return kho;
        }

        public int updateKho(Kho kho)
        {
            var roweffect = _dbConnection.Execute($"Update Kho SET ngay = '{kho.ngay}', soluong = '{kho.soluong}' where maps = '{kho.masp}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
