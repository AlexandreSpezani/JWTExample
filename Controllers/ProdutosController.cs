using JWTExample.Models;
using JWTExample.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        public readonly AppDbContext _dbContext;

        public ProdutosController(AppDbContext appContext)
        {
            _dbContext = appContext;
        }

        [HttpGet]
        public List<Produto> Get()
        {
            return _dbContext.Produtos.ToList();
        }

        [ClaimsAuthorize("Produto", "Incluir")]
        [HttpPost]
        public ActionResult Add([FromBody] Produto produto)
        {

            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();

            return Ok(produto);
        }
    }
}
