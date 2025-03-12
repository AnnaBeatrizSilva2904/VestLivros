using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestLivros.Models;

[Table ("livro_foto")]
public class LivroFoto
{
    [Key] // chave primária ID
    public int Id { get; set; }

    [Display (Name = "Livro")]
    [Required (ErrorMessage = "Por favor, informe o livro")]
    public int LivroId { get; set; }
    [ForeignKey ("LivroId")]
    public Livro Livro { get; set; }

    [Display (Name = "Foto")]
    [StringLength(200)]
    [Required (ErrorMessage = "Por favor, informe o arquivo")]
    public string ArquivoFoto { get; set; }
}
