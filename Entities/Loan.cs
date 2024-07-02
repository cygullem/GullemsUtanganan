namespace GULLEM_NEW_MVC.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int Borrower { get; set; }
        public int Amount { get; set; }
        public int Term { get; set; }
        public string Payment { get; set; }
        public float AmountPaid { get; set; }
        public float InterestAmount { get; set; }
        public float Total { get; set; }
        public float Interest { get; set; }
        public float Deduction { get; set; }
        public float ReceivableAmount { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation property
        public ClientInfo ClientInfo { get; set; }
    }
}
