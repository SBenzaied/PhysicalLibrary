namespace PhysicalLibrary.Loans
{
    public class Loan : ILoan
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid MemberId { get; set; }
        public Guid BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool IsActive => ReturnDate == null;

        public bool IsOverdue => IsActive && DateTime.Now > DueDate;
    }
}
