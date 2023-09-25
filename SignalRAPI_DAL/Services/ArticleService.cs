using SignalRAPI_DAL.Models;
using SignalRAPI_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SignalRAPI_DAL.Services
{
    public class ArticleService : IArticleRepo
    {
        private readonly SqlConnection _connection;

        public ArticleService(SqlConnection connection)
        {
            _connection = connection;
        }
        public bool Create(Article article)
        {
            string sql = "INSERT INTO Article (Name, Price, Description, Category) VALUES " +
                "(@Name, @Price, @Description, @Category)";

            return _connection.Execute(sql, article) > 0;
        }

        public IEnumerable<Article> GetAll()
        {
            string sql = "SELECT * FROM Article";
            return _connection.Query<Article>(sql);
        }

        public Article GetById(int id)
        {
            string sql = "SELECT * FROM Article WHERE Id = @id";
            return _connection.QueryFirst<Article>(sql, new {id});
        }
    }
}
