using System;

namespace GULLEM_NEW_MVC.Entities
{
    public partial class Loan
    {
        public int Id { get; set; }
        public int Borrower { get; set; }
        public int Amount { get; set; }
        public int Term { get; set; }
        public string Payment { get; set; } = null!;
        public float AmountPaid { get; set; }
        public float InterestAmount { get; set; }
        public float Total { get; set; }
        public float Interest { get; set; }
        public float Deduction { get; set; }
        public float ReceivableAmount { get; set; }
        public string Status { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public byte[] DateCreated { get; set; } = null!;
    }
}
