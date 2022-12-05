using FromBox.Business.Repositories;
using FromBox.Data;
using FromBox.Model;
using System.Linq;

namespace FromBox.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataBaseFB _db;

        public UsuarioRepository(DataBaseFB db)
        {
            _db = db;
        }
        public void Adicionar(Usuario usuario)
        {
            _db.USUARIO.Add(usuario);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public Usuario ObterUsuario(string login)
        {
            var usuario = _db.USUARIO.Where(e => e.Login == login).FirstOrDefault();
            return usuario;
        }
    }
}
