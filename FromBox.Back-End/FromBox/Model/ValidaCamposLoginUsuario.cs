using System.Collections.Generic;

namespace FromBox.Model
{
    public class ValidaCamposLoginUsuario
    {
        public IEnumerable<string> Erros { get; set; }

        public ValidaCamposLoginUsuario(IEnumerable<string> erros)
        {
            Erros = erros;
        }
    }
}
