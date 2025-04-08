using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VestLivros.Models;

[Table ("faculdade")]
public class Faculdade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name= "NomeFaculdade")]
    [Required (ErrorMessage = "Informe a faculdade! (pode ser somente Unicamp ou USP)")]
    [StringLength (100)]
    public string FaculdadeNome { get; set; }
}
