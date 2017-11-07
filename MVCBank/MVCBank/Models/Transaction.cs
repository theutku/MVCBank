using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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