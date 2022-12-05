using FromBox.Business.Repositories;
using FromBox.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FromBox.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthentication _authentication;
        public UsuarioController(
            IUsuarioRepository usuarioRepository,
            IConfiguration configuration,
            IAuthentication authentication)
        {
            _usuarioRepository = usuarioRepository;
            _authentication = authentication;
        }

        [SwaggerResponse(statusCode:200, description:"Sucesso ao logar",Type = typeof(Usuario))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios",Type =typeof(ValidaCamposLoginUsuario))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorGenerico))]
        [HttpPost]
        [Route("logar")]
        public IActionResult Logar(Usuario modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidaCamposLoginUsuario(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            }

            var usuario = _usuarioRepository.ObterUsuario(modelo.Login);

            if (usuario is null)
            {
                return BadRequest("Não foi possivel encontrar o Usuário");
            }

            var token = _authentication.GerarToken(modelo);
            return Ok(new
            {
                Token = token,
                Usuario = modelo,
            });
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao logar", Type = typeof(Usuario))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCamposLoginUsuario))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErrorGenerico))]
        [HttpPost]
        [Route("registrar")]
        public IActionResult Registrar(Usuario modelo)
        {

            var Usuario = new Usuario();
            Usuario.Nome = modelo.Nome;
            Usuario.Login = modelo.Login;
            Usuario.Senha = modelo.Senha;
            Usuario.Email = modelo.Email;
            _usuarioRepository.Adicionar(Usuario);
            _usuarioRepository.Commit();

            return Created("", Usuario);
        }
    }
}
