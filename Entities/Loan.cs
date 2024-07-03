using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GULLEM_NEW_MVC.Entities
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        [MaxLength(50)]
        public string Payment { get; set; }

        [Required]
        public decimal Interest { get; set; }

        public decimal? Deduction { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal Total { get; set; }

        public decimal ReceivableAmount { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [ForeignKey("ClientInfo")]
        public int Borrower { get; set; }

        public string Status { get; set; } = "unpaid";

        public virtual ClientInfo ClientInfo { get; set; }
    }
}
