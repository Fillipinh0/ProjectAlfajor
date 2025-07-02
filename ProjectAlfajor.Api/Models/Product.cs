using System.ComponentModel.DataAnnotations;

namespace ProjectAlfajor.Api.Models
{
    public class Product //Produto
    {
        [Key]                              
        public int ProductId { get; set; }  

        [Required(ErrorMessage = "Name is required.")]                   // Obrigatório
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Purchase Price is required.")]
        public decimal PurchasePrice { get; set; }

        [Required(ErrorMessage = "Purchase Date is required.")]
        public DateTime PurchaseDate { get; set; }   
    }
}
