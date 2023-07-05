using livrariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class livrariaController : ControllerBase
    {
        private readonly ToDoContext _context;

        // Preenchendo banco de dados
        public livrariaController(ToDoContext context) 
        {
            _context = context;

            _context.todoProducts.Add(new Produto { ID = "1", Nome = "Book1", Preco = 24.0, Quant = 1, Categoria = "Acao", Img = "img1" });
            _context.todoProducts.Add(new Produto { ID = "2", Nome = "Book2", Preco = 30.0, Quant = 8, Categoria = "Acao", Img = "img2" });
            _context.todoProducts.Add(new Produto { ID = "3", Nome = "Book3", Preco = 50.0, Quant = 5, Categoria = "Acao", Img = "img3" });
            _context.todoProducts.Add(new Produto { ID = "4", Nome = "Book4", Preco = 70.0, Quant = 2, Categoria = "Acao", Img = "img4" });
            _context.todoProducts.Add(new Produto { ID = "5", Nome = "Book5", Preco = 10.0, Quant = 3, Categoria = "Acao", Img = "img5" });


            _context.SaveChanges();
        }

        //Listando todos Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos() 
        {
            return await _context.todoProducts.ToListAsync();
        }

        //Listando Produto pelo id
        [HttpGet ("{id}")]
        public async Task<ActionResult<Produto>> GetItem(int id)
        {
            var item = await _context.todoProducts.FindAsync(id.ToString());

            if(item == null) 
            {
                return NotFound();
            }

            return item;
        }

        //Adicionando Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto (Produto produto)
        {
            _context.todoProducts.Add(produto);

            return Ok(produto);
        }
    }
}
