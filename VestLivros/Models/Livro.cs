using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VestLivros.Models;

[Table ("livro")]
public class Livro
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLength(50, ErrorMessage = "O Nome deve possuir no máximo 50 carateres")]
    public string Nome { get; set; }

    [Required]
    [StringLength(3000)]
    public string Resumo { get; set; }

    [Required]
    [StringLength(80000, ErrorMessage = "A análise crítica é obrigatória!")]
    public string AnaliseCritica { get; set; }

    [Required]
    [StringLength (90000, ErrorMessage = "O contexto histórico e social é um campo obrigatório")]
    public string Contexto { get; set; }

    [Display(Name = "Foto")]
    [StringLength(200)]
    [Required (ErrorMessage = "Por favor, informe o arquivo")]
    public string ArquivoFoto { get; set; }
}
