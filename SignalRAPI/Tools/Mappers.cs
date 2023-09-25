using SignalRAPI.DTOs;
using SignalRAPI_DAL.Models;

namespace SignalRAPI.Tools
{
    public static class Mappers
    {
        public static Article ToDal(this NewArticle a)
        {
            return new Article
            {
                Name = a.Name,
                Description = a.Description,
                Price = a.Price,
                Category = a.Category
            };
        }
    }
}
