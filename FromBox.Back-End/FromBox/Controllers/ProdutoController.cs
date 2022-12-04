using FromBox.Data;
using FromBox.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FromBox.Controllers
{
    [Route("api/v1/produto")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly DataBaseFB _db;

        public ProdutoController(DataBaseFB db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public ActionResult GetList()
        {
            try
            {
                var produtos = _db.PRODUTO.ToList();
                return Ok(produtos);
            }
            catch
            {
                return BadRequest("Problema ao buscar os Produtos!");
            }
        }

        [HttpGet]
        [Route("ID")]
        public ActionResult GetForId(int Id)
        {
            try
            {
                var modelo = _db.PRODUTO.Where(e => e.Id == Id).FirstOrDefault();
                return Ok(modelo);
            }
            catch
            {
                return BadRequest("Problema ao buscar o Produto!");
            }
        }
        [HttpPost]
        [Route("")]
        public ActionResult Create(Produto modelo)
        {
            try
            {
                _db.PRODUTO.Add(modelo);
                _db.SaveChanges();

                return Created("",modelo);
            }
            catch
            {
                return BadRequest("Problema ao adicionar um novo Produto!");
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult Edit(Produto modelo)
        {
            try
            {
                var modelo_db = _db.PRODUTO.Where(e => e.Id == modelo.Id).FirstOrDefault();
                modelo_db.Nome = modelo.Nome;
                modelo_db.Quantidade = modelo.Quantidade;
                modelo_db.Preco = modelo.Preco;
                _db.Update(modelo_db);
                _db.SaveChanges();

                return Ok(modelo_db);
            }
            catch
            {
                return BadRequest("Problema ao editar o Produto!");
            }
        }

        [HttpDelete]
        [Route("")]
        public ActionResult Delete(int Id)
        {
            try
            {
                var modelo = _db.PRODUTO.Where(e => e.Id == Id).FirstOrDefault();
                _db.Remove(modelo);
                _db.SaveChanges();

                return Ok();
            }
            catch
            {
                return BadRequest("Problema ao tentar excluir o Produto");
            }
        }
    }
}
