using System.ComponentModel.DataAnnotations;

namespace FromBox.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Nome obrigatório!!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo  Login obrigatório!!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo E-mail obrigatório!!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Senha obrigatório!!")]
        public string Senha { get; set; }
    }
}
