using Dapper;
using DataAccess.Interfaces;
using Domain.Enities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private SqlConnection GetConnection() { 
            return new SqlConnection(_connectionString);
        }

        public List<Book> GetAll()
        {
            var connection = GetConnection();
            connection.Open();
            var res = connection.Query<Book>("SELECT * FROM Books").ToList();
            connection.Close();
            return res;
        }
        public Book GetById(int id) {
            var connection = GetConnection();
            connection.Open();
            var res = connection.QueryFirstOrDefault<Book>("SELECT * FROM Books Where Id =@id",new {id = id});
            connection.Close();
            return res;
        }
        public void Edit(Book input)
        {
            var connection = GetConnection();
            connection.Open();
            connection.Execute("Updeate Book Set Name = @name , Genre = @genre where Id = @id", new { genre = input.Genre, name = input.Name, id = input.Id });
            connection.Close();
        }
    }
}
