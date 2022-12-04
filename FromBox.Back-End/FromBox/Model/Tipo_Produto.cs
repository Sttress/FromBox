using System.ComponentModel.DataAnnotations;

namespace FromBox.Model
{
    public class Tipo_Produto
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo Nome obrigatório!!")]
        public string Nome { get; set; }
    }
}
