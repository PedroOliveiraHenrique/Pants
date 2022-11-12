using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetPants.Models
{
    [Table("Roupas")]
    public class Roupa
    {
        [Key]
        public int RoupaId { get; set; }


        [Required(ErrorMessage = "O nome da roupa deve ser informado")]
        [Display(Name = "Nome da Roupa")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} ")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O nome da marca deve ser informado")]
        [Display(Name = "Nome da Marca")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} ")]
        public string Marca { get; set; }


        [Required(ErrorMessage = "A descrição da roupa deve ser informada")]
        [Display(Name = "Descrição da Roupa")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} ")]
        public string DescricaoCurta { get; set; }


        [Required(ErrorMessage = "A descrição detalhada da roupa deve ser informada")]
        [Display(Name = "Descrição detalhada da roupa")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} ")]
        public string DescricaoDetalhada { get; set; }


        [Required(ErrorMessage = "Informe o preço da roupa")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 10000, ErrorMessage = "O preço deve estar entre 1 e 10.000")]
        public decimal Preco { get; set; }


        [Display(Name = "Caminho imagem normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }


        [Display(Name = "Caminho imagem miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }


        [Display(Name = "Promoção")]
        public bool IsRoupaPromocao { get; set; }


        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }

        [Display(Name = "Categorias")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
