using System.ComponentModel.DataAnnotations;

namespace FromBox.Model
{
    public class Lista
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Campo Nome obrigatório!!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Descrição obrigatório!!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo Usuário obrigatório!!")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
