using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestLivros.Models;

[Table ("Livro")]
public class Livro
{
    [Required (ErrorMessage = "Por favor informe o ano que este livro pertence!!!")]
    public int Anos { get; set; }

    [Required (ErrorMessage = "Por favor, informe o título do livro")]
    [StringLength (50)]
    public string Nome { get; set; }

    [Required (ErrorMessage = "Por favor, informe a faculdade do livro")]
    [StringLength (50)]
    public string Faculdade { get; set; }


    [Display (Name = "Análise crítica")]
    [StringLength (6000, ErrorMessage = "Por favor informe a análise crítica do livro")]
    public string Análise { get; set; }

    [Display (Name = "Resumo da obra")]
    [StringLength (6000, ErrorMessage = "Por favor informe o resumo do livro")]
    public string Resumo { get; set; }

    [Display (Name = "Contexto histórico e social")]
    [StringLength (6000, ErrorMessage = "Por favor informe o contexto histórico e social do livro")]
    public string Contexto { get; set; }
}
