using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCBank.Models
{
    public class CheckAccount
    {
        public int Id { get; set; }

        [Required]
        //[StringLength(10, MinimumLength =6)]
        [RegularExpression(@"\d{6,10}", ErrorMessage ="Account Number must be between 6 and 10 digits.")]
        [Display(Name = "Account Number")] 
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ApplicationUserId { get; set; }
    }
}