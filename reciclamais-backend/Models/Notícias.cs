using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reciclamais_backend.Models
{
    [Table("Noticias")]
    public class Noticia
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a categoria!")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o título!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o conteúdo!")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [Display(Name = "Data da Publicação")]
        public DateTime DataInsercao { get; set; }
    }
}
