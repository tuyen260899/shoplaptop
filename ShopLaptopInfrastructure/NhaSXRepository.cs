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
    public class NhaSXRepository : INhaSXRepository
    {
        IConfiguration _configuration;
        string _connectString = string.Empty;
        IDbConnection _dbConnection = null;
        public NhaSXRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectString = _configuration.GetConnectionString("DBConnectString");
            _dbConnection = new SqlConnection(_connectString);
        }
        public int addNhaSX(NhaSX nhaSX)
        {
            var roweffect = _dbConnection.Execute($"Insert into NhaSX values(N'{nhaSX.mansx}', N'{nhaSX.tennsx}')", commandType: CommandType.Text);
            return roweffect;
        }

        public int deleteNhaSX(string mansx)
        {
            var roweffect = _dbConnection.Execute($"Delete from NhaSX where mansx = '{mansx}'", commandType: CommandType.Text);
            return roweffect;
        }

        public IEnumerable<NhaSX> GetNhaSX()
        {
            var nhaSXs = _dbConnection.Query<NhaSX>($"Select * from NhaSX", commandType: CommandType.Text);
            return nhaSXs;
        }

        public NhaSX getNhaSXbyMa(string mansx)
        {
            var nhaSxByMa = _dbConnection.Query<NhaSX>($"Select * from NhaSX where mansx = '{mansx}'", commandType: CommandType.Text).FirstOrDefault();
            return nhaSxByMa;
        }

        public int updateNhaSX(NhaSX nhaSX)
        {
            var roweffect = _dbConnection.Execute($"Update NhaSX SET tennsx = N'{nhaSX.tennsx}'," +
                $" where mansx = '{nhaSX.mansx}'", commandType: CommandType.Text);
            return roweffect;
        }
    }
}
