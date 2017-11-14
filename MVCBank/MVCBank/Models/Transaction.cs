using System.ComponentModel.DataAnnotations;


namespace MVCBank.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal amount { get; set; }

        [Required]
        public int CheckAccountId { get; set; }

        public virtual CheckAccount CheckAccount { get; set; }
    }
}