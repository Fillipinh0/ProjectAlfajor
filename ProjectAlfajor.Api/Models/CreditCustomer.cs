using System.ComponentModel.DataAnnotations;

namespace ProjectAlfajor.Api.Models
{
    public class CreditCustomer
    {
        [Key]
        public int CreditCustomerId { get; set; } 

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Amount Owed is required.")]
        public decimal AmountOwed { get; set; }     // Valor devido

        [Required(ErrorMessage = "Sale Date is required.")]
        public DateTime SaleDate { get; set; }

        //Isso nao sera informado no front pois ele ja gera false.
        //E ce estou registrando um devedor é exatamente por que ele n pagou
        public bool IsPaid { get; set; }            // Pago (true = sim, false = não)
    }
}
