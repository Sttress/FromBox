using FromBox.Model;

namespace FromBox.Business.Repositories
{
    public interface IAuthentication
    {
        string GerarToken(Usuario usuario);
    }
}
