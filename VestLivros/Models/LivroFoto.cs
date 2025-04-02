using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VestLivros.Models;

[Table ("livro_foto")]
public class LivroFoto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Livro")]
    [Required (ErrorMessage = "Por favor informe o livro!")]
    public int LivroId { get; set; }
    [ForeignKey ("LivroId")]
    public Livro Livro { get; set; }

    [Display(Name = "Foto")]
    [StringLength(200)]
    [Required (ErrorMessage = "Por favor, informe o arquivo")]
    public string ArquivoFoto { get; set; }

    [Display(Name ="Descrição")]
    [StringLength(100, ErrorMessage = "A descrição deve possuir 100 caracteres")]
    public string Descricao { get; set; }
}
