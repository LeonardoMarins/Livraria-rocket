using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Livro : ControllerBase
    {

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status201Created)]
        public IActionResult Create([FromBody] Livros request)
        {
            Livros.livrosLista.Add(request);
            return Created(string.Empty, request);
        }

        [HttpGet]
        [Route("buscar")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {  
            return Ok(Livros.livrosLista);
        }

        [HttpPut]
        [Route("editar")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status204NoContent)]
        public IActionResult Editar(int IdEdit, Livros request)
        {
            var item = Livros.livrosLista.FirstOrDefault(x => x.Id == IdEdit); 
            if (item != null)
            {
                item.Autor = request.Autor;
                item.QuantidadeEstoque = request.QuantidadeEstoque;
                item.Titulo = request.Titulo;
                item.Genero = request.Genero;
                item.Preco = request.Preco;
                return Created();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("deletar")]
        [ProducesResponseType(typeof(Livros), StatusCodes.Status204NoContent)]
        public IActionResult Deletar(int IdDelete)
        {
            var item = Livros.livrosLista.FirstOrDefault(x => x.Id == IdDelete);
            if (item != null)
            {
                Livros.livrosLista.Remove(item);
                return Created();
            }
            return NotFound();
        }
    }
}
