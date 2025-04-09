using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace VestLivros.Models;

[Table ("livroVestibular")]
public class LivroVestibular
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display (Name = "Vestibular")]
    [Required (ErrorMessage = "Por favor informe o nome do vestibular!")]
    public int VestibularId { get; set; }
    [ForeignKey ("VestibularId")]
    public Vestibular Vestibular { get; set; }
    
    [Display (Name = "Livro")]
    [Required (ErrorMessage = "Por favor informe o livro")]
    public int LivroId { get; set; }
    [ForeignKey ("LivroId")]
    public Livro Livro { get; set; }
}
