using FromBox.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;

namespace FromBox.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [SwaggerResponse(statusCode:200, description:"Sucesso ao logar",Type = typeof(Usuario))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios",Type =typeof(ValidaCamposLoginUsuario))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorGenerico))]
        [HttpPost]
        [Route("logar")]
        public IActionResult Logar(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidaCamposLoginUsuario(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            }
            return Ok(usuario);
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao logar", Type = typeof(Usuario))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCamposLoginUsuario))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorGenerico))]
        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(Usuario usuario)
        {
            return Created("",usuario);
        }
    }
}
