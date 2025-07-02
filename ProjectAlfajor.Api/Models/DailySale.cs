using System.ComponentModel.DataAnnotations;

namespace ProjectAlfajor.Api.Models
{
    public class DailySale
    {
        [Key]
        public int DailySaleId { get; set; } 

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Quantity Sold is required.")]
        public int QuantitySold { get; set; }      // Quantidade vendida

        [Required(ErrorMessage = "Quantity Left is required.")]
        public int QuantityLeft { get; set; }      // Quantidade sobrando

        [Required(ErrorMessage = "Total Received is required.")]
        public decimal TotalReceived { get; set; } 

    }
}
