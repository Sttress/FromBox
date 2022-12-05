using FromBox.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FromBox.Controllers
{
    [Route("api/v1/lista")]
    [ApiController]
    [Authorize]
    public class ListaController : Controller
    {
        private readonly DataBaseFB _db;

        public ListaController(DataBaseFB db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("lista")]
        public async Task<IActionResult> GetList()
        {
            var valid = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var listas = _db.LISTA.ToList();
            return Ok(listas);
        }
    }
}
