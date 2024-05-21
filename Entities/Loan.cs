using System;

namespace GULLEM_NEW_MVC.Entities
{
    public partial class Loan
    {
        public int Id { get; set; }

        // Adjusted Borrower property to match your application's requirements
        public string Borrower { get; set; }

        // Adjusted Amount, AmountPaid, InterestAmount, Total, Interest, Deduction, and ReceivableAmount to decimal for accurate monetary representation
        public decimal Amount { get; set; }

        public int Term { get; set; }

        public string Payment { get; set; }

        // Adjusted AmountPaid, InterestAmount, Total, Interest, Deduction, and ReceivableAmount to decimal for accurate monetary representation
        public decimal AmountPaid { get; set; }

        public decimal InterestAmount { get; set; }

        public decimal Total { get; set; }

        public double Interest { get; set; }

        public decimal Deduction { get; set; }

        public decimal ReceivableAmount { get; set; }

        public string Status { get; set; }

        public DateTime DueDate { get; set; }

        // Changed DateCreated to DateTime for storing creation date
        public DateTime DateCreated { get; set; }
    }
}
