using Dapper;
using DataAccess.Interfaces;
using Domain.Enities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public User GetBy(string username, string password)
        {
            
            var connection = GetConnection();
            connection.Open();
            var user = connection.QueryFirstOrDefault<User>("Select * from Users where Name = @name ,Password = @password", new { name = username, password = password });
            connection.Close();
            return user;
        }
    }
}
