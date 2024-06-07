using System.ComponentModel.DataAnnotations;

namespace TextEditor.Models
{
    public class Documento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o título")]
        public string Titulo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Digite o conteúdo")]
        public string Conteudo { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
