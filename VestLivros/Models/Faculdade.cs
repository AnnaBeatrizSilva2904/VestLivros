using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VestLivros.Models;

[Table ("faculdade")]
public class Faculdade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength (100, ErrorMessage = "Informe a faculdade! (pode ser somente Unicamp ou USP)")]
    public string FaculdadeNome { get; set; }
}
