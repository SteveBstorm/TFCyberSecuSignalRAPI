using SignalRAPI_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAPI_DAL.Repositories
{
    public interface IArticleRepo
    {
        IEnumerable<Article> GetAll();
        Article GetById(int id);
        bool Create(Article article);
    }
}
