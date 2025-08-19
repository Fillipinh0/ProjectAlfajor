using System.ComponentModel.DataAnnotations;

namespace ProjectAlfajor.Api.DTOs
{
    public class ProductCreateDTO
    {
        [Required(ErrorMessage = "Name is required.")]                
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Unit Price is required.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Purchase Date is required.")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}
