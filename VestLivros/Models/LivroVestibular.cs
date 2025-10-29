using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace VestLivros.Models;

[Table("livroVestibular")]
public class LivroVestibular
{

    [Key, Column(Order = 1)]
    public int VestibularId { get; set; }
    [ForeignKey("VestibularId")]
    public Vestibular Vestibular { get; set; }

    [Key, Column(Order = 2)]
    public int LivroId { get; set; }
    [ForeignKey("LivroId")]
    public Livro Livro { get; set; }

    [Key, Column(Order = 3)]
    public int FaculdadeId { get; set; }
    [ForeignKey("FaculdadeId")]
    public Faculdade Faculdade { get; set; }

}
