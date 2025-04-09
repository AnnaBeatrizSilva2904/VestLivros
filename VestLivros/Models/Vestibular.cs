using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VestLivros.Models;

[Table ("vestibular")]
public class Vestibular
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Ano { get; set; }
  
    [Display (Name = "Faculdade")]
    [Required (ErrorMessage = "Por favor informe a faculdade!")]
    public int FaculdadeId { get; set; }
    [ForeignKey ("FaculdadeId")]
    public Faculdade Faculdade { get; set; }
}
