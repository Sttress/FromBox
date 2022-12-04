using FromBox.Model;
using Microsoft.EntityFrameworkCore;

namespace FromBox.Data
{
    public class DataBaseFB:DbContext
    {
        public DataBaseFB(DbContextOptions options):base(options)
        {

        }
        public DbSet<Usuario> USUARIO { get; set; }
        public DbSet<Produto> PRODUTO { get; set; }
        public DbSet<Lista> LISTA { get; set; }
        public DbSet<Tipo_Produto> TIPO_PRODUTO { get; set; }

    }
}
