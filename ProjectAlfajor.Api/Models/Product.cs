using System.ComponentModel.DataAnnotations;

namespace ProjectAlfajor.Api.Models
{
    public class Product
    {
        [Key]                              
        public int? ProductId { get; set; }  

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

        [Required(ErrorMessage = "Total Purchase Value is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total must be a positive value.")]
        public decimal TotalPurchaseValue { get; set; }
    }
}
