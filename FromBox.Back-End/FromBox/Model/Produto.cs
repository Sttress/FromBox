using System;
using System.ComponentModel.DataAnnotations;

namespace FromBox.Model
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Nome obrigatório!!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Quantidade obrigatório!!")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Campo Preço obrigatório!!")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Campo Lista obrigatório!!")]
        public int IdLista { get; set; }
        public Lista Lista { get; set; }
        [Required(ErrorMessage = "Campo Tipo de Produto obrigatório!!")]
        public int IdTipoLista { get; set; }
        public Tipo_Produto Tipo_Produto { get; set; }


    }
}
