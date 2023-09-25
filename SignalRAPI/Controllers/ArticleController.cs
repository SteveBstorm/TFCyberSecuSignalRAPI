using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRAPI.DTOs;
using SignalRAPI.Hubs;
using SignalRAPI.Tools;
using SignalRAPI_DAL.Repositories;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepo _repo;
        private readonly ArticleHub _articleHub;

        public ArticleController(IArticleRepo repo, ArticleHub articleHub)
        {
            _repo = repo;
            _articleHub = articleHub;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewArticle newArticle)
        {
            if(!ModelState.IsValid) 
                return BadRequest();

            if (_repo.Create(newArticle.ToDal()))
            {
                await _articleHub.RefreshArticle();
                return Ok();
            }

            return BadRequest("Erreur d'enregistrement");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetById(id));
        }

    }
}
